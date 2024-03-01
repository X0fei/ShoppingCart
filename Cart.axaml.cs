using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace ShoppingCart;

public partial class Cart : Window
{
    private List<Products> products = new();
    private List<Products> productsInCart = new();
    public Cart()
    {
        InitializeComponent();
    }
    public Cart(List<Products> products, List<Products> selectedProducts)
    {
        InitializeComponent();
        this.products = products;
        productsInCart = selectedProducts;
        shoppingCart.ItemsSource = productsInCart;
    }
    public void BackToMainWindow(object source, RoutedEventArgs args)
    {
        MainWindow mainWindow = new MainWindow(products, productsInCart);
        mainWindow.Show();
        Close();
    }
}