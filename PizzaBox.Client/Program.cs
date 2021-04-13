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
            var Order = new Order();

            Console.WriteLine("WELCOME TO THE PIZZABOX");
            Customer Customer = GetNameInput();
            Order.CustomerId = Customer.Id;

            Store Store = GetStoreInput();
            Order.StoreId = Store.Id;

            Pizza Pizza = GetPizzaInput();
            Order.PizzaId = Pizza.Id;

            Crust Crust = GetCrustInput();
            Order.CrustId = Crust.Id;

            Size Size = GetSizeInput();
            Order.SizeId = Size.Id;

            if (Pizza.Name.Equals("Custom"))
            {
                CustomPizzaToppings(Pizza);
            }
            Order.ToppingsId = Pizza.ToppingsId;

            PrintSaveOrder(Order);


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
                Console.Write("Would you like to add more toppings?( 1.Yes | 2.No ): ");
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
            foreach (int i in order.ToppingsId)
            {
                total += repo.GetToppingById(i).Price;
            }
            return total;
        }

        private static void PrintSaveOrder(Order order)
        {
            Console.WriteLine($"Pizza Summary: ");
            Console.WriteLine($"    Store: {repo.GetStoreById(order.StoreId).Name}");
            Console.WriteLine($"    Pizza: {repo.GetPizzaById(order.PizzaId).Name}");
            Console.WriteLine($"    Crust: {repo.GetCrustById(order.CrustId).Name}");
            Console.WriteLine($"    Size: {repo.GetSizeById(order.SizeId).Name}");
            Console.Write("    Topping(s): ");
            foreach (int i in order.ToppingsId)
            {
                Console.Write($"{repo.GetToppingById(i).Name} ");
            }
            decimal price = ToppingsTotalCost(order) + repo.GetCrustById(order.CrustId).Price + repo.GetSizeById(order.SizeId).Price;
            Console.WriteLine($"\n    Price: {price:C2}");
        }
    }
}