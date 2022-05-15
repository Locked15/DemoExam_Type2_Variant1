using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Пиши_Стирай.Entities;

namespace Пиши_Стирай.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductListItem.xaml.
    /// </summary>
    public partial class ProductListItem : UserControl
    {
        public Product CurrentProduct { get; set; }

        public ProductListItem(Product product)
        {
            CurrentProduct = product;

            InitializeComponent();
            DataContext = CurrentProduct;
        }

        private void UserControl_Loaded(Object sender, RoutedEventArgs e)
        {
            CheckDiscountAndUpdateBackground();
            CheckCostAndUpdateCostTextBlocks();
        }

        private void CheckDiscountAndUpdateBackground()
        {
            if (CurrentProduct.ProductDiscountAmount > 15)
                Background = ColorConverter.ConvertFromString("#7fff00") as SolidColorBrush;
        }

        private void CheckCostAndUpdateCostTextBlocks()
        {
            if (CurrentProduct.ProductDiscountAmount > 0)
            {
                DiscountCost.Visibility = Visibility.Visible;

                OriginalCost.TextDecorations = TextDecorations.Strikethrough;
            }
        }
    }
}
