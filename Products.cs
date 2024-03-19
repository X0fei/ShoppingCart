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
        public string Name { get; set; }
        public string Price { get; set; }
        public int Count { get; set; }
        public Button Increase { get; set; }
        public Button Decrease { get; set; }
        public ICommand ButtonCommand { get; set; }
    }
}
