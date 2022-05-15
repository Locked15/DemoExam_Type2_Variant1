using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Пиши_Стирай.Classes;
using Пиши_Стирай.Entities;
using Пиши_Стирай.UserControls;

namespace Пиши_Стирай.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderFormation.xaml.
    /// <br/>
    /// Перед открытием окна необходимо провести расчет даты доставки заказа.
    /// </summary>
    public partial class OrderFormation : Window
    {
        public Order CurrentOrder { get; set; } = SessionData.CurrentOrder;

        public OrderFormation()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateProductsList();
            InitializeVisibilityAndUserInfo();

            PickupPointSelector.ItemsSource = TradeEntities.Instance.PickupPoints.ToList();
            PickupPointSelector.SelectedItem = CurrentOrder.PickupPoint;

            MessageBox.Show("Чтобы удалить товар используйте контекстное меню.\n\nПеред сохранением заказа не забудьте указать пункт получения, если он ещё не указан.", 
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void InitializeVisibilityAndUserInfo()
        {
            if (CurrentOrder.User == null)
            {
                UserNameInfo.Visibility = Visibility.Hidden;
                UserRoleInfo.Visibility = Visibility.Hidden;
            }

            else
            {
                User user = CurrentOrder.User;

                UserNameInfo.Text = $"{user.UserSurname} {user.UserName.Substring(0, 1)}.";
            }
        }

        private void UpdateProductsList()
        {
            List<Product> products = CurrentOrder.OrderProducts.Select(p => p.Product).ToList();
            AllProductsInOrder.Items.Clear();

            foreach (Product product in products)
            {
                ProductListItem item = new ProductListItem(product)
                {
                    Width = GetOptimalWidth()
                };
                item.AddToOrder.Click += AddToOrder;
                item.RemoveFromOrder.Click += RemoveFromOrder;

                AllProductsInOrder.Items.Add(item);
            }

            if (products.Count == 0)
            {
                Close();
            }

            UpdateInfo();
        }

        private void AllProductsInOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selected = (AllProductsInOrder.SelectedItem as ProductListItem)?.CurrentProduct;

            if (selected != null)
            {
                OrderProduct tethered = CurrentOrder.OrderProducts.First(op => op.ProductArticleNumber == selected.ProductArticleNumber);

                CurrentProductCount_TextBox.Text = tethered.CountInOrder.ToString();
            }
        }

        private void CurrentProductCount_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(CurrentProductCount_TextBox.Text, out Int32 count))
            {
                Product selected = (AllProductsInOrder.SelectedItem as ProductListItem).CurrentProduct;
                OrderProduct tethered = CurrentOrder.OrderProducts.First(op => op.ProductArticleNumber == selected.ProductArticleNumber);

                if (count > 0)
                {
                    tethered.CountInOrder = count;
                }

                else
                {
                    MessageBoxResult result = MessageBox.Show($"Такое значение ({count}) приведет к удалению товара.\n\nВы уверены?", 
                                                               "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        CurrentOrder.RemoveProduct(selected);

                        UpdateProductsList();
                    }

                    else
                    {
                        CurrentProductCount_TextBox.Text = "1";
                    }
                }

                UpdateInfo();
            }

            else
            {
                MessageBox.Show("Некорректное значение.\n\nПомните: это должно быть целое число.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                CurrentProductCount_TextBox.Text = "1";
            }
        }

        private void AddToOrder(Object sender, dynamic e)
        {
            Product selected = (AllProductsInOrder.SelectedItem as ProductListItem).CurrentProduct;
            CurrentOrder.InsertNewProduct(selected);

            UpdateInfo();
        }

        private void RemoveFromOrder(Object sender, dynamic e)
        {
            var result = MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Product selected = (AllProductsInOrder.SelectedItem as ProductListItem).CurrentProduct;
                CurrentOrder.RemoveProduct(selected);

                UpdateProductsList();
            }
        }

        private void PickupPointSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentOrder.PickupPoint = PickupPointSelector.SelectedItem as PickupPoint;
            CurrentOrder.OrderPickupPointId = CurrentOrder.PickupPoint.Id;
        }

        private void UpdateInfo()
        {
            try
            {
                String cost = CurrentOrder.FinalOrderCost.ToString();
                String dis = CurrentOrder.FinalOrderDiscount.ToString();

                FinalCost_TextBlock.Text = cost.Substring(0, cost.LastIndexOf(',') + 3);
                FinalDiscount_TextBlock.Text = dis.Substring(0, dis.LastIndexOf(',') + 3);
            }

            catch
            { }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (ProductListItem item in AllProductsInOrder.Items)
            {
                item.Width = GetOptimalWidth();
            }
        }

        private Double GetOptimalWidth()
        {
            if (WindowState == WindowState.Maximized)
                return RenderSize.Width - 55;

            else
                return Width - 55;
        }

        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CheckToErrors())
            {
                if (CurrentOrder.OrderID == default)
                {
                    TradeEntities.Instance.Orders.Add(CurrentOrder);
                    TradeEntities.Instance.OrderProducts.AddRange(CurrentOrder.OrderProducts);

                    TradeEntities.Instance.SaveChanges();
                }

                else
                {
                    TradeEntities.Instance.SaveChanges();
                }

                MessageBox.Show("Заказ сохранен в БД.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private Boolean CheckToErrors()
        {
            String errors = String.Empty;

            if (CurrentOrder.PickupPoint == null)
                errors += "Необходимо выбрать пункт получения.\n";

            if (errors == String.Empty)
            {
                return true;
            }

            else
            {
                MessageBox.Show($"Обнаружены ошибки:\n\n{errors}", "Ошибки!", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
        }
    }
}
