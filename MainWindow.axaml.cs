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
            allProducts.ItemsSource = this.products.ToList();
            selectedProducts = productsInCart;
        }
        public void ProductAdd(object source, RoutedEventArgs args)
        {
            bool error = false;
            for (int i = 0; i < productName.Text.Length; i++)
            {
                if (productName.Text[i] == ' ')
                {
                    error = true;
                    break;
                }
            }
            for (int i = 0; i < productPrice.Text.Length; i++)
            {
                if (productPrice.Text[i] == ' ')
                {
                    error = true;
                    break;
                }
            }
            foreach (Products product in products)
            {
                if (productName.Text == product.Name)
                {
                    error = true;
                    break;
                }
            }
            if (productName.Text != null && productName.Text != "" && productPrice.Text != null && productPrice.Text != "" && error == false)
            {
                products.Add(new Products()
                {
                    ID = products.Count,
                    Name = productName.Text,
                    Price = productPrice.Text,
                    Count = 1
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
                bool error;
                foreach (Products selectedProduct in allProducts.SelectedItems)
                {
                    error = false;
                    foreach (Products product in selectedProducts)
                    {
                        if (selectedProduct.ID == product.ID)
                        {
                            error = true;
                            break;
                        }
                    }
                    if (error == false)
                    {
                        selectedProducts.Add(selectedProduct);
                    }
                }
                Cart cart = new(products, selectedProducts);
                cart.Show();
                Close();
            }
        }
        public void Delete(object? sender, RoutedEventArgs args)
        {
            int id = (int)(sender as Button).Tag;
            foreach (Products product in products)
            {
                if (id == product.ID)
                {
                    if (selectedProducts.Count > 0)
                    {
                        selectedProducts.RemoveAt(product.IDInCart);
                    }
                    break;
                }
            }
            products.RemoveAt(id);
            foreach (Products product in products)
            {
                product.ID = products.IndexOf(product);
            }
            allProducts.ItemsSource = products.ToList();
        }
        public void ProductEditing(object? sender, RoutedEventArgs args)
        {
            int id = (int)(sender as Button).Tag;
            foreach (Products product in products)
            {
                if (id == product.ID)
                {
                    //selectedProducts.RemoveAt(product.IDInCart);
                    //products.RemoveAt(product.ID);
                    ProductEditWindow productEditWindow = new(product, products, selectedProducts);
                    productEditWindow.Show();
                    Close();
                    break;
                }
            }
            allProducts.ItemsSource = products.ToList();
        }
    }
}
