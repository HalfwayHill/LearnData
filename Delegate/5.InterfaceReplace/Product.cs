using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.InterfaceReplace
{
    /// <summary>
    /// 产品
    /// </summary>
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product() { }

        public Product(string name)
        {
            this.Name = name;
        }

        public Product(string name, double price) : this(name)
        {
            this.Price = price;
        }
    }
}
