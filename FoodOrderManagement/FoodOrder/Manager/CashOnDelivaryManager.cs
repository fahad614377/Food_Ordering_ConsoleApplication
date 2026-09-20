using FoodOrder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Manager
{
    public class CashOnDelivaryManager : IOrderManager
    {
        public double Getdiscount(OrderItem odr) => 0.0;
        public double GetToTalamount(OrderItem odr) => (odr.UnitPrice * odr.Quantity) + odr.DeliveryCharge;

    }
}
