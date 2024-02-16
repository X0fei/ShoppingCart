using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public partial class MainWindow : Window
    {   
        private readonly List<Products> products = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ProductAdd(object source, RoutedEventArgs args)
        {
            bool empty = false;
            for (int i = 0; i < productName.Text.Length; i++)
            {
                if (productName.Text[i] == ' ')
                {
                    empty = true;
                }
            }
            for (int i = 0; i < productPrice.Text.Length; i++)
            {
                if (productPrice.Text[i] == ' ')
                {
                    empty = true;
                }
            }
            if (productName.Text != null && productName.Text != "" && productPrice.Text != null && productPrice.Text != "" && empty == false)
            {
                products.Add(new Products()
                {
                    ProductNameSC = productName.Text,
                    ProductPriceSC = productPrice.Text
                });
                shoppingCart.ItemsSource = products.ToList();
            }
        }
    }
}