using FoodOrder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Repository
{
    public interface IOrderRepository
    {
        void SaveOrder(OrderItem obj);
        IEnumerable<OrderItem> GetAllOrder();
        OrderItem OrderDescriptionById(int id);
        void UpdateOrderItem(OrderItem obj);
        void DeleteOrderItem(int id);


    }
}
