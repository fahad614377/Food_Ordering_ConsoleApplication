using FoodOrder.Entities;
using FoodOrder.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Factory
{
    public abstract class OrderFactory
    {
        protected OrderItem _order;

        protected OrderFactory(OrderItem order)
        {
            _order = order;
        }

        public abstract IOrderManager Create();


        public OrderItem ProcessOrder()
        {
            IOrderManager manager= Create();
            _order.Discount = manager.Getdiscount(_order);
            _order.TotalPrice=manager.GetToTalamount(_order);
            return _order;
        }
    }
}
