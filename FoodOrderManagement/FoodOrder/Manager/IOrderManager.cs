using FoodOrder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Manager
{
    public interface IOrderManager
    {

        double Getdiscount(OrderItem odr);
        double GetToTalamount(OrderItem odr);
     
    }
}
