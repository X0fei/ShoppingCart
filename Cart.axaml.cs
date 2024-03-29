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
        foreach (Products product in productsInCart)
        {
            product.IDInCart = productsInCart.IndexOf(product);
        }
        shoppingCart.ItemsSource = productsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
    public int Sum()
    {
        int sum = 0;
        foreach (Products product in productsInCart)
        {
            sum += Convert.ToInt32(product.Price) * product.Count;
        }
        return sum;
    }
    public void BackToMainWindow(object source, RoutedEventArgs args)
    {
        MainWindow mainWindow = new(products, productsInCart);
        mainWindow.Show();
        Close();
    }
    public void Delete(object? sender, RoutedEventArgs args)
    {
        int id = (int)(sender as Button).Tag;
        foreach (Products product in productsInCart)
        {
            if (id == product.IDInCart)
            {
                productsInCart.RemoveAt(product.IDInCart);
                break;
            }
        }
        foreach (Products product in productsInCart)
        {
            product.IDInCart = productsInCart.IndexOf(product);
        }
        shoppingCart.ItemsSource = productsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
    public void Increase(object? sender, RoutedEventArgs args)
    {
        int id = (int)(sender as Button).Tag;
        foreach(Products product in productsInCart)
        {
            if (id == product.IDInCart)
            {
                product.Count++;
                break;
            }
        }
        shoppingCart.ItemsSource = productsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
    public void Decrease(object? sender, RoutedEventArgs args)
    {
        int id = (int)(sender as Button).Tag;
        foreach (Products product in productsInCart)
        {
            if (id == product.IDInCart && product.Count > 1)
            {
                product.Count--;
                break;
            }
        }
        shoppingCart.ItemsSource = productsInCart.ToList();
        result.Text = $"Итого: {Sum()}";
    }
}
