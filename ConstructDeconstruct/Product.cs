using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructDeconstruct
{
    public class Product
    {
        public string Name { get; }
        public double Price {get;}
        public int Quantity {get;}

        public Product(string name, double price, int quantity) 
        {
            Name = name;
            Price = price;
            Quantity = quantity;

        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
            Quantity = 1;
        }

        public void Deconstruct(out string name, out double price, out int quantity)
        {
            name = Name;
            price = Price;
            quantity = Quantity;
        }
    }
}
