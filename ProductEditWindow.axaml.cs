using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace ShoppingCart;

public partial class ProductEditWindow : Window
{
    private List<Products> products = new();
    private List<Products> selectedProducts = new();
    public int ID { get; set; }
    public string ProductName { get; set; }
    public string ProductPrice { get; set; }
    public ProductEditWindow()
    {
        InitializeComponent();
    }
    public ProductEditWindow(Products product, List<Products> products, List<Products> selectedProducts)
    {
        InitializeComponent();
        this.products = products;
        this.selectedProducts = selectedProducts;
        ProductName = product.Name;
        ProductPrice = product.Price;
        productName.Text = ProductName;
        productPrice.Text = ProductPrice;
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
            ProductPrice = productName.Text;
            ProductPrice = productPrice.Text;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}