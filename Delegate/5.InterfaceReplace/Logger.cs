using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.InterfaceReplace
{
    /// <summary>
    /// 打印Log类
    /// </summary>
    class Logger
    {
        /// <summary>
        /// 记录程序运行的函数
        /// </summary>
        /// <param name="product"></param>
        public void Log(Product product)
        {
            //DateTime.Now是带有时区的时间，不准确
            //DateTime.UtcNow是不带有时区的时间
            Console.WriteLine($"Product'{product.Name}' created at {DateTime.UtcNow}. Price is {product.Price}.");
        }
    }
}
