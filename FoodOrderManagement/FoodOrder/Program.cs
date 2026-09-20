using FoodOrder.Entities;
using FoodOrder.Factory;
using FoodOrder.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder
{
    internal class Program
    {
        static IOrderRepository repo = new OrderRepository();

        static void Main(string[] args)
        {
            try 
            {
                DoTask(); 
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message); 
            }
            finally 
            {
                Console.ReadLine(); 
            }
        }

        private static void DoTask()
        {
            while (true)
            {
                Console.WriteLine("\n===================== Food Ordering Management ==============");
                Console.WriteLine("Select Operation type: 1. Create | 2. View | 3. Update | 4. Delete | 5. Exit");
              
                var operation = Convert.ToInt16(Console.ReadLine());
                if (operation == 5) break;
                switch (operation)
                {
                    case 1:
                        Create(); break;
                    case 2:
                        View(); break;
                    case 3:
                        Update(); break;
                    case 4:
                        Delete(); break;
                    default:
                        Console.WriteLine("Invalid selection."); break;
                }
            }
        }

        private static void Create()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Location: ");
            string loc = Console.ReadLine();
            Console.WriteLine("Select Food: 1. Pizza | 2. Burger | 3. ColdCoffee");
            FoodItem food = (FoodItem)int.Parse(Console.ReadLine());
            Console.Write("Quantity: "); 
            int qty = int.Parse(Console.ReadLine());
            Console.WriteLine("Select Payment Method:  1. OnlinePay | 2. CashOnDelivery");
            PaymentMethod pay = (PaymentMethod)int.Parse(Console.ReadLine());

            double price;
            switch (food)
            {
                case FoodItem.Pizza: price = 500.0; break;
                case FoodItem.Burger: price = 200.0; break;
                case FoodItem.ColdCoffee: price = 150.0; break;
                default: price = 0.0; break;
            }

            OrderItem ord = new OrderItem(0, name, loc, food, pay, qty, price);

           
            OrderFactory factory = pay == PaymentMethod.OnlinePay
                ? (OrderFactory)new OnlinePayFactory(ord)
                : new CashOnDelivaryFactory(ord);

            factory.ProcessOrder();
            repo.SaveOrder(ord);
            View();
        }

        private static void Update()
        {
            Console.Write("Enter Order Id to Update: ");
            int id = int.Parse(Console.ReadLine());
            var obj = repo.OrderDescriptionById(id);
            if (obj == null) 
            {
                Console.WriteLine("Order Not found.");
                return; 
            }

            Console.Write("Enter New Name: ");
            obj.CustomerName = Console.ReadLine();
            Console.Write("Enter New Location: ");
            obj.Location=Console.ReadLine();
            Console.WriteLine("Enter New Food:  1. Pizza | 2. Burger | 3. ColdCoffee");
            obj.Food = (FoodItem)int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: "); 
            obj.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Payment Method:  1. OnlinePay | 2. CashOnDelivery");
            obj.Payment = (PaymentMethod)int.Parse(Console.ReadLine());

           
            switch (obj.Food)
            {
                case FoodItem.Pizza: obj.UnitPrice = 500; break;
                case FoodItem.Burger: obj.UnitPrice = 200; break;
                case FoodItem.ColdCoffee: obj.UnitPrice = 150; break;
                default: obj.UnitPrice = 0; break;
            }

            
            OrderFactory factory = obj.Payment == PaymentMethod.OnlinePay
                ? (OrderFactory)new OnlinePayFactory(obj)
                : new CashOnDelivaryFactory(obj);

            factory.ProcessOrder();
            repo.UpdateOrderItem(obj);
            View();
        }
        private static void View()
        {
            var ords = repo.GetAllOrder();

            Console.WriteLine("\n" + new string('=', 130));
            Console.WriteLine("\t\t\t\tFood Order List");
            Console.WriteLine(new string('=', 130));

            string header = "| {0,-5} | {1,-10} | {2,-15} | {3,-10} | {4,-15} | {5,-8} | {6,-10} | {7,-8} | {8,-10} | {9,-10} |";

            Console.WriteLine(header,
                "ID", "Name", "Location", "Food", "Payment",
                "Qty", "UnitPrice", "Discount", "Delivery", "Total");

            Console.WriteLine(new string('=', 130));

            if (!ords.Any())
            {
                Console.WriteLine("\t\t\tNo Data Found");
                return;
            }

            foreach (var o in ords)
            {
                   Console.WriteLine(header,
                    o.OrderId,
                    o.CustomerName,
                    o.Location,
                    o.Food,
                    o.Payment,
                    o.Quantity,
                    o.UnitPrice,
                    o.Discount,    
                    o.DeliveryCharge,
                    o.TotalPrice );
            }
        }
        


        private static void Delete()
        {
            Console.Write("Enter ID to Delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                repo.DeleteOrderItem(id);
                View();
            }
        }
    }
    
}

