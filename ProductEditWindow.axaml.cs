using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace ShoppingCart;

public partial class ProductEditWindow : Window
{
    public int Id { get; set; }
    public ProductEditWindow()
    {
        InitializeComponent();
    }
    public ProductEditWindow(Products product)
    {
        InitializeComponent();
        Id = product.Id;
        productName.Text = product.Name;
        productPrice.Text = product.Price;
    }
    public void Edit(object source, RoutedEventArgs args)
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
        if (productName.Text != null && productName.Text != "" && productPrice.Text != null && productPrice.Text != "" && error == false)
        {
            foreach (Products product in Lists.Products)
            {
                if (Lists.Products.IndexOf(product) == Id)
                {
                    product.Name = productName.Text;
                    product.Price = productPrice.Text;
                    break;
                }
            }
            foreach (Products product in Lists.ProductsInCart)
            {
                if (Lists.ProductsInCart.IndexOf(product) == Id)
                {
                    product.Name = productName.Text;
                    product.Price = productPrice.Text;
                    break;
                }
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
