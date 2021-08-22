using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.GeneralUse
{
    /// <summary>
    /// 生产环节
    /// </summary>
    class ProductFactory
    {
        public Product MakePizza()
        {
            return new Product("Pizza", 12);
        }

        public Product MakeToyCar()
        {
            return new Product("ToyCar", 100);
        }
    }
}
