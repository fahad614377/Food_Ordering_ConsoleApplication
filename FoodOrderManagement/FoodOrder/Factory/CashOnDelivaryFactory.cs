using FoodOrder.Entities;
using FoodOrder.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Factory
{
    public class CashOnDelivaryFactory : OrderFactory
    {
        public CashOnDelivaryFactory(OrderItem order) : base(order)
        {

        }

        public override IOrderManager Create()
        {
           return new CashOnDelivaryManager();
        }


    }
}
