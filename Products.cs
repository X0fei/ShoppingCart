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
        public int ID { get; set; }
        public int IDInCart { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Count { get; set; }
    }
}
