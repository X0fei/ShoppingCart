using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();
            allProducts.ItemsSource = Lists.Products.ToList();
        }
        public void ProductAdd(object source, RoutedEventArgs args)
        {
            bool error = false;
            if (productName.Text == null || productPrice.Text == null || productName.Text == "" || productPrice.Text == "")
            {
                error = true;
            }
            else
            {
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
                foreach (Products product in Lists.Products)
                {
                    if (productName.Text == product.Name)
                    {
                        error = true;
                        break;
                    }
                }
            }
            if (error == false)
            {
                Lists.Products.Add(new Products()
                {
                    Id = Lists.Products.Count,
                    Name = productName.Text,
                    Price = productPrice.Text,
                    Count = 1
                });
                allProducts.ItemsSource = Lists.Products.ToList();
                productName.Text = null;
                productPrice.Text = null;
            }
        }
        public void ProductEdit(object? sender, RoutedEventArgs args)
        {
            int id = (int)(sender as Button).Tag;
            foreach (Products product in Lists.Products)
            {
                if (id == product.Id)
                {
                    ProductEditWindow productEditWindow = new(product);
                    productEditWindow.Show();
                    Close();
                    break;
                }
            }
            allProducts.ItemsSource = Lists.Products.ToList();
        }
        public void ProductDelete(object? sender, RoutedEventArgs args)
        {
            int id = (int)(sender as Button).Tag;
            foreach (Products product in Lists.Products)
            {
                if (id == product.Id)
                {
                    if (Lists.ProductsInCart.Count > 0)
                    {
                        Lists.ProductsInCart.RemoveAt(product.IdInCart);
                    }
                    break;
                }
            }
            Lists.Products.RemoveAt(id);
            foreach (Products product in Lists.Products)
            {
                product.Id = Lists.Products.IndexOf(product);
            }
            allProducts.ItemsSource = Lists.Products.ToList();
        }
        public void ToCart(object source, RoutedEventArgs args)
        {
            if (allProducts.SelectedItems != null)
            {
                bool error;
                foreach (Products selectedProduct in allProducts.SelectedItems)
                {
                    error = false;
                    foreach (Products product in Lists.ProductsInCart)
                    {
                        if (selectedProduct.Id == product.Id)
                        {
                            error = true;
                            break;
                        }
                    }
                    if (error == false)
                    {
                        Lists.ProductsInCart.Add(selectedProduct);
                    }
                }
                Cart cart = new();
                cart.Show();
                Close();
            }
        }
    }
}
