using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.InterfaceReplace
{
    class PizzaFactory : IProductFactory
    {
        public Product Make()
        {
            return new Product("Pizza", 12);
        }
    }
}
