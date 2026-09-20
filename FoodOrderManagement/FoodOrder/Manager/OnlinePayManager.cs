using FoodOrder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Manager
{
    public class OnlinePayManager : IOrderManager
    {
        public double Getdiscount(OrderItem odr)
        {
           return ((odr.UnitPrice * odr.Quantity) + odr.DeliveryCharge) * 0.1;
        }

        public double GetToTalamount(OrderItem odr)
        {
            return ((odr.UnitPrice * odr.Quantity) + odr.DeliveryCharge) - Getdiscount(odr);
        }
    }
}
