using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public partial class MainWindow : Window
    {   
        private List<Products> products = new List<Products>();
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
            if (productName.Text != null && productName.Text != "" && empty == false)
            {
                products.Add(new Products()
                {
                    ProductNameSC = productName.Text
                });
                shoppingCart.ItemsSource = products.ToList();
            }
        }
    }
}