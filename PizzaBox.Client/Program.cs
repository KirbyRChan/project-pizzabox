using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain;
using PizzaBox.Client.Singletons;
using System.Linq;

namespace PizzaBox.Client
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        //private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        //private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

        private static IRepository repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            repo = Dependencies.CreateRepository();
            Run();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Run()
        {
            Console.WriteLine("WELCOME TO THE PIZZABOX");

            List<Order> Orders = new List<Order>();
            Customer Customer = GetNameInput();
            Store Store = GetStoreInput();

            int num = -1;
            while (num != 0 && num != 1)
            {
                Console.WriteLine("\n0.Save order and exit\n1.Exit\n2.View order history\n3.View current order\n4.Add pizza to order");
                Console.Write("Please enter a number: ");
                num = validNumInput();
                switch (num)
                {
                    case 0:
                        //save
                        foreach (var x in Orders)
                        {
                            repo.AddOrder(x);
                        }
                        Console.WriteLine("Order has been saved. Have a good day.");
                        break;
                    case 1:
                        Console.WriteLine("Have a good day.");
                        //exit
                        break;
                    case 2:
                        var OrderHistory = repo.GetOrderHistoryById(Customer.Id);
                        if (OrderHistory == null || OrderHistory.Count == 0)
                        {
                            Console.WriteLine("No order history found.");
                        }
                        else
                        {
                            foreach (var x in OrderHistory)
                            {
                                PrintOrder(x);
                            }
                        }
                        break;
                    case 3:
                        if (Orders.Count == 0)
                        {
                            Console.WriteLine("Your order is currently empty.");
                        }
                        decimal total = 0;
                        foreach (var x in Orders)
                        {
                            PrintOrder(x);
                            total += x.Price;
                        }
                        Console.WriteLine($"Total cost: {total:C2}");
                        break;
                    case 4:
                        Orders.Add(NewPizza(Customer, Store));
                        break;
                    default:
                        Console.WriteLine("There is no option with this number.");
                        break;
                }
            }
        }
        private static Order NewPizza(Customer Customer, Store Store)
        {
            var Order = new Order();

            Pizza Pizza = GetPizzaInput();
            Crust Crust = GetCrustInput();
            Size Size = GetSizeInput();

            Order.CustomerId = Customer.Id;
            Order.StoreId = Store.Id;
            Order.PizzaId = Pizza.Id;
            Order.CrustId = Crust.Id;
            Order.SizeId = Size.Id;

            if (Pizza.Name.Equals("Custom"))
            {
                CustomPizzaToppings(Pizza);
            }
            Order.ToppingsId = Pizza.ToppingsId;

            PrintOrder(Order);

            return Order;
        }

        private static Customer GetNameInput()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            var Customer = repo.GetCustomerByName(name);
            Console.WriteLine($"Hello, {Customer.Name}. Your ID is {Customer.Id}. Let's start on your order.\n");
            return Customer;
        }
        private static Store GetStoreInput()
        {
            DisplayMenus.DisplayStoreMenu(repo);
            Console.Write("Please choose a store by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Store Store = repo.GetStoreById(num);
                if (Store == null)
                {
                    Console.Write("This ID is not associated with any store, try again: ");
                }
                else
                {
                    Console.WriteLine($"You have chosen {Store.Name}.\n");
                    return Store;
                }
            }
        }
        private static Pizza GetPizzaInput()
        {
            DisplayMenus.DisplayPizzaMenu(repo);
            Console.Write("Please choose a pizza by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Pizza Pizza = repo.GetPizzaById(num);
                if (Pizza == null)
                {
                    Console.Write("This ID is not associated with any pizza, try again: ");
                }
                else
                {
                    Console.WriteLine($"You have chosen {Pizza.Name}.\n");
                    return Pizza;
                }
            }
        }
        private static Crust GetCrustInput()
        {
            DisplayMenus.DisplayCrustMenu(repo);
            Console.Write("Please choose a crust by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Crust Crust = repo.GetCrustById(num);
                if (Crust == null)
                {
                    Console.Write("This ID is not associated with any crust, try again: ");
                }
                else
                {
                    Console.WriteLine($"You have chosen {Crust.Name} ({Crust.Price:C2}).\n");
                    return Crust;
                }
            }
        }
        private static Size GetSizeInput()
        {
            DisplayMenus.DisplaySizeMenu(repo);
            Console.Write("Please choose a size by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Size Size = repo.GetSizeById(num);
                if (Size == null)
                {
                    Console.Write("This ID is not associated with any size, try again: ");
                }
                else
                {
                    Console.WriteLine($"You have chosen {Size.Name} ({Size.Price:C2}).\n");
                    return Size;
                }
            }
        }
        private static Topping GetToppingInput()
        {
            DisplayMenus.DisplayToppingMenu(repo);
            Console.Write("Please choose a topping by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Topping Topping = repo.GetToppingById(num);
                if (Topping.Name == null)
                {
                    Console.Write("This ID is not associated with any topping, try again: ");
                }
                else
                {
                    Console.WriteLine($"You have chosen {Topping.Name} ({Topping.Price:C2}).\n");
                    return Topping;
                }
            }
        }

        private static int validNumInput()
        {
            int num;
            while (true)
            {
                string input = Console.ReadLine();
                bool valid = int.TryParse(input, out num);
                if (valid)
                {
                    return num;
                }
                else
                {
                    Console.Write("Invalid input, please enter an integer: ");
                }
            }
        }

        private static void CustomPizzaToppings(Pizza Pizza)
        {
            bool moreToppings = true;
            int num = 0;
            while (moreToppings && Pizza.ToppingsId[4] == null)
            {
                Console.Write("Would you like to add more toppings?( 0.No | 1.Yes ): ");
                num = validNumInput();
                if (num == 1)
                {
                    Topping Topping = GetToppingInput();
                    if (Pizza.ToppingsId[0] == null)
                    {
                        Pizza.ToppingsId[0] = Topping.Id;
                    }
                    else if (Pizza.ToppingsId[1] == null)
                    {
                        Pizza.ToppingsId[1] = Topping.Id;
                    }
                    else if (Pizza.ToppingsId[2] == null)
                    {
                        Pizza.ToppingsId[2] = Topping.Id;
                    }
                    else if (Pizza.ToppingsId[3] == null)
                    {
                        Pizza.ToppingsId[3] = Topping.Id;
                    }
                    else
                    {
                        Pizza.ToppingsId[4] = Topping.Id;
                    }
                }
                else if (num == 0)
                {
                    moreToppings = false;
                }
                else
                {
                    Console.WriteLine("Please enter either 1 or 0.");
                }
            }
        }

        private static decimal ToppingsTotalCost(Order order)
        {
            decimal total = 0;
            foreach (int? i in order.ToppingsId)
            {
                if (i != null)
                {
                    total += repo.GetToppingById(i).Price;
                }
            }
            return total;
        }

        private static void PrintOrder(Order order)
        {
            Console.WriteLine($"Pizza Summary: ");
            Console.WriteLine($"    Store: {repo.GetStoreById(order.StoreId).Name}");
            Console.WriteLine($"    Pizza: {repo.GetPizzaById(order.PizzaId).Name}");
            Console.WriteLine($"    Crust: {repo.GetCrustById(order.CrustId).Name}");
            Console.WriteLine($"    Size: {repo.GetSizeById(order.SizeId).Name}");
            Console.Write("    Topping(s): ");
            foreach (int? i in order.ToppingsId)
            {
                if (i != null)
                {
                    Console.Write($"{repo.GetToppingById(i).Name} ");
                }
            }
            decimal price = ToppingsTotalCost(order) + repo.GetCrustById(order.CrustId).Price + repo.GetSizeById(order.SizeId).Price;
            order.Price = price;
            Console.WriteLine($"\n    Price: {price:C2}");
        }
    }
}