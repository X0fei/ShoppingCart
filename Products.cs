using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoppingCart
{
    public class Products
    {
        public int Id { get; set; }
        public int IdInCart { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Count { get; set; }
    }
    public static class Lists
    {
        public static List<Products> Products = new List<Products>();
        public static List<Products> ProductsInCart = new List<Products>();
    }
}
