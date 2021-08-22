using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Event.EventStatement
{
    /// <summary>
    /// 简略声明事件案例
    /// </summary>
    public class BriefStatementCustomer
    {
        //简略声明事件 它包含 关键字event 事件处理器EventHandler 事件名称
        //注意这样可以自己创建自己的事件信息类
        public event EventHandler Order;

        public double Bill { get; set; }

        public void PayBill()
        {
            Console.WriteLine($"I will pay ${this.Bill}.");
        }

        void WalkIn()
        {
            Console.WriteLine($"Walk into the restaurant.");
        }

        void SitDown()
        {
            Console.WriteLine($"Sit down.");
        }

        void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Let me think...");
                Thread.Sleep(1000);
            }

            OnOrder("Kongpao Chicken", "large");
        }

        //使用关键字protected进行约束，防止被错误引用
        protected void OnOrder(string dishName, string size)
        {
            //当前事件信息，即订餐信息 传递自己的事件信息类
            OrderEventArgs e = new OrderEventArgs(dishName, size);
            //当前事件处理器委托为空，即餐馆没有服务员能够订餐
            this.Order?.Invoke(this, e);
        }

        public void Action()
        {
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }
}
