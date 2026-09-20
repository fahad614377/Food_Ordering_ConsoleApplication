using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Entities
{
    public class OrderItem
    {
       
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public FoodItem Food { get; set; }
        public PaymentMethod Payment { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double DeliveryCharge { get; set; }
        public double TotalPrice { get; set; }

        public OrderItem()
        {
            
        }     

        public OrderItem(int orderId, string customerName, string location, FoodItem food, PaymentMethod payment, int quantity,double unitPrice)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Location = location;
            Food = food;
            Payment = payment;
            Quantity = quantity;
            DeliveryCharge = 60.0;
            UnitPrice = unitPrice;

           
            Discount = 0;
            TotalPrice = 0;

        }      
        

    }
}
