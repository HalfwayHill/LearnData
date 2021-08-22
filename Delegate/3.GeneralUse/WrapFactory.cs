using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.GeneralUse
{
    /// <summary>
    /// 封装环节
    /// </summary>
    class WrapFactory
    {
        /// <summary>
        /// 封装产品(模板方法)，同时打印产品生产信息(回调函数Callback)
        /// </summary>
        /// <param name="getProduct">模板方法</param>
        /// <param name="logCallback">回调函数Callback</param>
        /// <returns>包装箱</returns>
        public Box WrapProduct(Func<Product> getProduct, Action<Product> logCallback)
        {
            //通过模板方法获取返回值
            Product product = getProduct?.Invoke();

            //选择性使用回调函数
            if (product.Price >= 50)
            {
                //回调函数，告知当前产品的生产信息
                logCallback?.Invoke(product);
            }
            

            return new Box(product);
        }
    }
}
