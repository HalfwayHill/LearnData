using System;
using System.Collections.Generic;
using System.Text;

namespace Event.EventStatement
{
    /// <summary>
    /// 点菜的事件信息
    /// </summary>
    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }

        public OrderEventArgs(string dishname,string size)
        {
            this.DishName = dishname;
            this.Size = size;
        }
    }
}
