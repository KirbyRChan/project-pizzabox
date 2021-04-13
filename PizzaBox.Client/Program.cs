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

        private static IRepository repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            repository = Dependencies.CreateRepository();
            Run();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Run()
        {
            var order = new Order();

            Console.WriteLine("WELCOME TO THE PIZZABOX");
            order.CustomerId = GetNameInput();
            order.StoreId = GetStoreInput();
            order.PizzaId = GetPizzaInput();
            order.CrustId = GetCrustInput();
            order.SizeId = GetSizeInput();
            if (order.PizzaId == 1)
            {
                GetToppingInput(order);
            }
        }

        private static int GetNameInput()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            var Customer = repository.GetCustomerByName(name);
            Console.WriteLine($"Hello, {Customer.Name}. Your ID is {Customer.Id}. Let's start on your order.\n");
            return Customer.Id;
        }
        private static int GetStoreInput()
        {
            int num = -1;
            bool valid = false;

            DisplayMenus.DisplayStoreMenu(repository);
            while (!valid)
            {
                Console.Write("Please choose a store by entering its ID: ");
                string input = Console.ReadLine();
                valid = int.TryParse(input, out num);
                if (valid)
                {
                    Store Store = repository.GetStoreById(num);
                    if (Store == null)
                    {
                        Console.WriteLine("This ID is not associated with any store.");
                        valid = false;
                    }
                    else
                    {
                        Console.WriteLine($"You have chosen {Store.Name}.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer.");
                }
            }
            return num;
        }
        private static int GetPizzaInput()
        {
            int num = -1;
            bool valid = false;

            DisplayMenus.DisplayPizzaMenu(repository);
            while (!valid)
            {
                Console.Write("Please choose a pizza by entering its ID: ");
                string input = Console.ReadLine();
                valid = int.TryParse(input, out num);
                if (valid)
                {
                    Pizza Pizza = repository.GetPizzaById(num);
                    if (Pizza == null)
                    {
                        Console.WriteLine("This ID is not associated with any pizza.");
                        valid = false;
                    }
                    else
                    {
                        Console.WriteLine($"You have chosen {Pizza.Name}.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer.");
                }
            }
            return num;
        }
        private static int GetCrustInput()
        {
            int num = -1;
            bool valid = false;

            DisplayMenus.DisplayCrustMenu(repository);
            while (!valid)
            {
                Console.Write("Please choose a crust by entering its ID: ");
                string input = Console.ReadLine();
                valid = int.TryParse(input, out num);
                if (valid)
                {
                    Crust Crust = repository.GetCrustById(num);
                    if (Crust == null)
                    {
                        Console.WriteLine("This ID is not associated with any crust.");
                        valid = false;
                    }
                    else
                    {
                        Console.WriteLine($"You have chosen {Crust.Name}.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer.");
                }
            }
            return num;
        }
        private static int GetSizeInput()
        {
            int num = -1;
            bool valid = false;

            DisplayMenus.DisplaySizeMenu(repository);
            while (!valid)
            {
                Console.Write("Please choose a size by entering its ID: ");
                string input = Console.ReadLine();
                valid = int.TryParse(input, out num);
                if (valid)
                {
                    Size Size = repository.GetSizeById(num);
                    if (Size == null)
                    {
                        Console.WriteLine("This ID is not associated with any size.");
                        valid = false;
                    }
                    else
                    {
                        Console.WriteLine($"You have chosen {Size.Name}.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer.");
                }
            }
            return num;
        }
        private static int GetToppingInput(Order order)
        {
            int num = -1;
            bool valid = false;

            DisplayMenus.DisplayToppingMenu(repository);
            while (!valid)
            {
                Console.Write("Please choose a topping by entering its ID: ");
                string input = Console.ReadLine();
                valid = int.TryParse(input, out num);
                if (valid)
                {
                    Topping Topping = repository.GetToppingById(num);
                    if (Topping.Name == null)
                    {
                        Console.WriteLine("This ID is not associated with any topping.");
                        valid = false;
                    }
                    else
                    {
                        Console.WriteLine($"You have chosen {Topping.Name}.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer.");
                }
            }
            return num;
        }
    }
}