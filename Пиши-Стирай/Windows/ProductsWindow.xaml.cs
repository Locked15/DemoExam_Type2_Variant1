using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using Пиши_Стирай.Classes;
using Пиши_Стирай.Entities;
using Пиши_Стирай.UserControls;

namespace Пиши_Стирай.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml.
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public List<Product> SelectedProducts { get; private set; } = TradeEntities.Instance.Products.ToList();

        public ProductsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeVisibility();
            InitializeListeners();

            SelectionParametersChanged(null, null);

            MessageBox.Show("Чтобы вернуться к окну авторизации, закройте текущее окно.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void InitializeVisibility()
        {
            if (SessionData.CurrentUser.UserRole != 4)
            {
                CreateProduct.Visibility = Visibility.Hidden;

                if (SessionData.CurrentUser.UserRole != 3)
                {
                    AllOrders.Visibility = Visibility.Hidden;
                }
            }

            if (SessionData.CurrentOrder.OrderProducts.Count < 1)
                CurrentOrder.Visibility = Visibility.Hidden;

            else
                CurrentOrder.Visibility = Visibility.Visible;
        }

        private void InitializeListeners()
        {
            SearchBox.TextChanged += SelectionParametersChanged;

            SortComboBox.SelectedIndex = 0;
            SortComboBox.SelectionChanged += SelectionParametersChanged;

            FilterComboBox.SelectedIndex = 0;
            FilterComboBox.SelectionChanged += SelectionParametersChanged;
        }

        private void SelectionParametersChanged(object sender, dynamic e)
        {
            SelectedProducts = TradeEntities.Instance.Products.ToList();

            // Поиск.
            if (SearchBox.Text.ToLower() is var search && search != null)
            {
                SelectedProducts = SelectedProducts.Where(p =>
                                   p.ProductName.ToLower().Contains(search) ||
                                   (p.ProductDescription != null && p.ProductDescription.ToLower().Contains(search))).ToList();
            }

            // Сортировка.
            if (SortComboBox.SelectedIndex != 0)
            {
                // По возрастанию.
                if (SortComboBox.SelectedIndex == 2)
                    SelectedProducts = SelectedProducts.OrderBy(p => p.FinalCost).ToList();

                // По убыванию.
                else
                    SelectedProducts = SelectedProducts.OrderByDescending(p => p.FinalCost).ToList();
            }

            // Фильтрация.
            if (FilterComboBox.SelectedIndex != 0)
            {
                switch (FilterComboBox.SelectedIndex)
                {
                    case 1:
                        SelectedProducts = SelectedProducts.Where(p => 
                                           p.ProductDiscountAmount < 10).ToList();

                        break;

                    case 2:
                        SelectedProducts = SelectedProducts.Where(p =>
                                           p.ProductDiscountAmount >= 10 &&
                                           p.ProductDiscountAmount < 15).ToList();

                        break;

                    default:
                        SelectedProducts = SelectedProducts.Where(p =>
                                           p.ProductDiscountAmount >= 15).ToList();

                        break;

                }
            }

            UpdateProductsList();
            UpdateDisplayedInformation();

            if (SelectedProducts.Count == 0)
            {
                MessageBox.Show("По вашему запросу ничего не найдено.\n\nПопробуйте сбросить фильтры.", "Информация", MessageBoxButton.OK, 
                                MessageBoxImage.Information);
            }
        }

        private void UpdateProductsList()
        {
            AllProductsListView.Items.Clear();

            foreach (Product product in SelectedProducts)
            {
                ProductListItem item = new ProductListItem(product)
                {
                    Width = GetOptimalWidth()
                };
                item.AddToOrder.Click += ProductAddedToOrder_Click;
                item.RemoveFromOrder.Click += ProductRemovedFromOrder_Click;

                AllProductsListView.Items.Add(item);
            }
        }

        private void UpdateDisplayedInformation()
        {
            if (!TradeEntities.Instance.Products.Any())
                CurrentDisplayedProducts.Text = "NaN";

            else
                CurrentDisplayedProducts.Text = $"{SelectedProducts.Count} — {TradeEntities.Instance.Products.Count()}";
        }

        private void ProductAddedToOrder_Click(Object sender, dynamic e)
        {
            Product selected = (AllProductsListView.SelectedItem as ProductListItem).CurrentProduct;
            SessionData.CurrentOrder.InsertNewProduct(selected);

            InitializeVisibility();
        }

        private void ProductRemovedFromOrder_Click(Object sender, dynamic e)
        {
            Product selected = (AllProductsListView.SelectedItem as ProductListItem).CurrentProduct;
            SessionData.CurrentOrder.RemoveProduct(selected);

            InitializeVisibility();
        }

        private void AllProductsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SessionData.CurrentUser.UserRole == 4)
                MessageBox.Show("Ещё не реализовано.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            else if (AllProductsListView.SelectedItem is ProductListItem selected && selected != null)
                SessionData.CurrentOrder.InsertNewProduct(selected.CurrentProduct);
        }

        private void CurrentOrder_Click(object sender, RoutedEventArgs e)
        {
            SessionData.CurrentOrder.CalculateDeliveryDate();

            OrderFormation window = new OrderFormation();
            window.ShowDialog();

            InitializeVisibility();
        }

        private void AllOrders_Click(object sender, RoutedEventArgs e) =>
                     MessageBox.Show("Ещё не реализовано.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

        private void CreateProduct_Click(object sender, RoutedEventArgs e) =>
                     MessageBox.Show("Ещё не реализовано.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (ProductListItem item in AllProductsListView.Items)
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow window = new MainWindow();

            window.Show();
        }
    }
}
