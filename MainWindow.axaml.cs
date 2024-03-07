using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public partial class MainWindow : Window
    {   
        private List<Products> products = new();
        private List<Products> selectedProducts = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(List<Products> products, List<Products> productsInCart)
        {
            InitializeComponent();
            this.products = products;
            allProducts.ItemsSource = this.products;
            this.selectedProducts = productsInCart;
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
                    ProductName = productName.Text,
                    ProductPrice = productPrice.Text
                });
                allProducts.ItemsSource = products.ToList();
                productName.Text = null;
                productPrice.Text = null;
            }
        }
        public void ToSelectedProducts(object source, RoutedEventArgs args)
        {
            if (allProducts.SelectedItems != null)
            {
                foreach (Products selectedProduct in allProducts.SelectedItems)
                {
                    selectedProducts.Add(selectedProduct);
                }
                Cart cart = new Cart(products, selectedProducts);
                cart.Show();
                Close();
            }
        }
    }
}