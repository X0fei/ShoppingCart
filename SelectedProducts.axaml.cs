using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace ShoppingCart;

public partial class SelectedProducts : Window
{
    public SelectedProducts(List<Products> products)
    {
        InitializeComponent();
        selectedProducts.ItemSource = products;
    }
}