using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Event.EventStatement
{
    //事件处理器委托函数指针
    public delegate void OrderCCustomerEventHandler(CompleteStatementCustomer customer, OrderEventArgs e);

    /// <summary>
    /// 完整声明事件案例
    /// </summary>
    public class CompleteStatementCustomer
    {
        #region 完整声明
        //1.先声明事件处理器委托OrderEventHandler 它的参数一个是事件拥有者Customer 一个是事件信息
        //2.在创建事件信息类OrderEventHandler

        //3.
        //该字段就是来引用事件处理器委托
        private OrderCCustomerEventHandler orderEventHandler;
        //声明一个事件
        public event OrderCCustomerEventHandler Order
        {
            //事件添加器
            add
            {
                this.orderEventHandler += value;
            }
            //事件移除器
            remove
            {
                this.orderEventHandler -= value;
            }
        }

        /*
         * 由此可见事件就是委托的一层封装
         * 事件跟属性类似
         */

        #endregion
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
            this.orderEventHandler?.Invoke(this, e);
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
