using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.InterfaceReplace
{
    /// <summary>
    /// 产品封装箱
    /// </summary>
    class Box
    {
        public Product Product { get; set; }

        public Box() { }

        public Box(Product product)
        {
            this.Product = product;
        }
    }
}
