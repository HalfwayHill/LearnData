using System;
using System.Collections.Generic;
using System.Text;

namespace Event.EventStatement
{
    class Waiter
    {
        public void WaiterCOrder(CompleteStatementCustomer customer, OrderEventArgs e)
        {
            Console.WriteLine($"I will serve you the dish {e.DishName}");
            double price = 10;

            switch (e.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }

        public void WaiterBOrder(object sender, EventArgs e)
        {
            BriefStatementCustomer customer = sender as BriefStatementCustomer;
            OrderEventArgs orderEventArgs = e as OrderEventArgs;

            Console.WriteLine($"I will serve you the dish {orderEventArgs.DishName}");
            double price = 20;

            switch (orderEventArgs.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }
    }
}
