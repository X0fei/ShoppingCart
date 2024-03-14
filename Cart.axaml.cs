using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart;

public partial class Cart : Window
{
    private List<Products> products = new();
    private List<Products> productsInCart = new();
    private int sum = 0;
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
        result.Text = $"Итого: {Sum()}";
    }
    public int Sum()
    {
        sum = 0;
        foreach (Products product in productsInCart)
        {
            sum += Convert.ToInt32(product.Price);
        }
        return sum;
    }
    public void BackToMainWindow(object source, RoutedEventArgs args)
    {
        MainWindow mainWindow = new MainWindow(products, productsInCart);
        mainWindow.Show();
        Close();
    }
    public void Delete(object source, RoutedEventArgs args)
    {
        foreach (Products selectedProduct in shoppingCart.SelectedItems)
        {
            foreach (Products product in productsInCart)
            {
                if (selectedProduct.Name == product.Name && selectedProduct.Price == product.Price)
                {
                    productsInCart.Remove(product);
                    break;
                }
            }
        }
        shoppingCart.ItemsSource = productsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
}