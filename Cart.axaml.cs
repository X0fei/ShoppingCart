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
    public Cart()
    {
        InitializeComponent();
        foreach (Products product in Lists.ProductsInCart)
        {
            product.IdInCart = Lists.ProductsInCart.IndexOf(product);
        }
        shoppingCart.ItemsSource = Lists.ProductsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
    public int Sum()
    {
        int sum = 0;
        foreach (Products product in Lists.ProductsInCart)
        {
            sum += Convert.ToInt32(product.Price) * product.Count;
        }
        return sum;
    }
    public void BackToMainWindow(object source, RoutedEventArgs args)
    {
        MainWindow mainWindow = new();
        mainWindow.Show();
        Close();
    }
    public void Increase(object? sender, RoutedEventArgs args)
    {
        int id = (int)(sender as Button).Tag;
        foreach(Products product in Lists.ProductsInCart)
        {
            if (id == product.IdInCart)
            {
                product.Count++;
                break;
            }
        }
        shoppingCart.ItemsSource = Lists.ProductsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
    public void Decrease(object? sender, RoutedEventArgs args)
    {
        int id = (int)(sender as Button).Tag;
        foreach (Products product in Lists.ProductsInCart)
        {
            if (id == product.IdInCart && product.Count > 1)
            {
                product.Count--;
                break;
            }
        }
        shoppingCart.ItemsSource = Lists.ProductsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
    public void Delete(object? sender, RoutedEventArgs args)
    {
        int id = (int)(sender as Button).Tag;
        foreach (Products product in Lists.ProductsInCart)
        {
            if (id == product.IdInCart)
            {
                Lists.ProductsInCart.RemoveAt(product.IdInCart);
                break;
            }
        }
        foreach (Products product in Lists.ProductsInCart)
        {
            product.IdInCart = Lists.ProductsInCart.IndexOf(product);
        }
        shoppingCart.ItemsSource = Lists.ProductsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
}
