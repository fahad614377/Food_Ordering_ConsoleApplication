# Food_Ordering_ConsoleApplication

Hungry? This is a simple console app that makes managing food orders easy. Built with C# and .NET Framework 4.8, it lets you create, view, update, and delete orders right from your terminal, no fancy setup needed.

## ✨ What It Can Do

- 🧾 **Place orders** with the customer's name, location, food choice, quantity, and payment method
- 🍔 **Pick from the menu:** Pizza (500), Burger (200), or Cold Coffee (150)
- 💳 **Choose how to pay:** Online Payment or Cash on Delivery, each handled with its own order-processing logic
- 📋 **See all your orders** in a neat table with unit price, discount, delivery charge, and total
- ✏️ **Update or delete** any order by its ID

## 🧩 Under the Hood

This project uses a couple of classic design patterns to keep the code clean and easy to extend:

- **Factory Pattern:** `OnlinePayFactory` and `CashOnDelivaryFactory` handle orders differently depending on the payment method
- **Repository Pattern:** `IOrderRepository` and `OrderRepository` take care of saving and retrieving orders, keeping data logic separate from the UI

## 🛠️ Built With

- C#
- .NET Framework 4.8
- Console Application

## 🚀 Getting Started

1. **Clone** this repository
2. **Open** `FoodOrder.sln` in Visual Studio
3. **Build** the solution (`Ctrl + Shift + B`)
4. **Run** it (`F5`) and follow the on-screen menu

## 🎮 How to Use It

When the app starts, you'll see a menu like this:

```
Select Operation type: 1. Create | 2. View | 3. Update | 4. Delete | 5. Exit
```

Just type the number of the action you want and follow the prompts. It's that simple!

---

Made with ❤️ and a lot of imaginary pizza.
