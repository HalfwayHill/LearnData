using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.InterfaceReplace
{
    class ToyCarFactory : IProductFactory
    {
        public Product Make()
        {
            return new Product("ToyCar", 100);
        }
    }
}
