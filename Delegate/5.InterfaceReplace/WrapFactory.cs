using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.InterfaceReplace
{
    /// <summary>
    /// 封装环节
    /// </summary>
    class WrapFactory
    {
        /// <summary>
        /// 封装产品，同时打印产品生产信息 (使用接口)
        /// </summary>
        /// <param name="productFactory">产品工厂接口</param>
        /// <returns>包装箱</returns>
        public Box WrapProduct(IProductFactory productFactory)
        {
            //通过调用接口的统一函数方法，实现扩展，比委托方便
            Product product = productFactory.Make();
            

            return new Box(product);
        }
    }
}
