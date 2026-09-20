using FoodOrder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private List<OrderItem> foodList;
        public OrderRepository()
        {
            foodList=new List<OrderItem>()
            {
                new OrderItem()
                {OrderId=1,CustomerName="Fahad",Location="FR hall,Nilkhet",Food=FoodItem.Burger,Payment=PaymentMethod.OnlinePay,Quantity=2,UnitPrice=200.0,Discount=50.0,DeliveryCharge=60.0,TotalPrice=410.0},
                 
                new OrderItem()
                {OrderId=2,CustomerName="Ali",Location="FR hall,Nilkhet",Food=FoodItem.Pizza,Payment=PaymentMethod.CashOnDelivery,Quantity=1,UnitPrice=500.0,Discount=0.0,DeliveryCharge=60,TotalPrice=560.0}
            };
        }

        public void DeleteOrderItem(int id)
        {
            OrderItem obj = OrderDescriptionById(id);
                if (obj != null)
                {
                        foodList.Remove(obj);
                }
        }

        public IEnumerable<OrderItem> GetAllOrder()
        {
            return foodList;
        }

        public OrderItem OrderDescriptionById(int id)
        {
            return foodList.FirstOrDefault(e=>e.OrderId==id);
        }

        public void SaveOrder(OrderItem obj)
        {
            obj.OrderId = foodList.Count > 0 ? foodList.Max(e => e.OrderId) + 1 : 1;
            foodList.Add(obj);
        }

        public void UpdateOrderItem(OrderItem obj)
        {
            OrderItem ord = OrderDescriptionById(obj.OrderId);
            if (ord != null)
            {
                ord.CustomerName = obj.CustomerName;
                ord.Location = obj.Location;
                ord.Food = obj.Food;
                ord.Payment=obj.Payment;
                ord.Quantity = obj.Quantity;
                
            }
        }
    }
}
