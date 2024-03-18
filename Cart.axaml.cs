using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        result.Text = $"Итого: {Sum()}";
    }
    public int Sum()
    {
        int sum = 0;
        foreach (Products product in productsInCart)
        {
            sum += Convert.ToInt32(product.Price);
        }
        return sum;
    }
    public void BackToMainWindow(object source, RoutedEventArgs args)
    {
        MainWindow mainWindow = new(products, productsInCart);
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
                    product.Count = 1;
                    productsInCart.Remove(product);
                    break;
                }
            }
        }
        shoppingCart.ItemsSource = productsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
    public void Increase(object source, RoutedEventArgs args)
    {
        Button button = new Button();
        for (int i = 0; i < productsInCart.Count; i++)
        {
            if (button.Tag == i)
            {
                productsInCart[i].Count++;
            }
        }
    }
    public void Decrease(object source, RoutedEventArgs args)
    {

    }
}
