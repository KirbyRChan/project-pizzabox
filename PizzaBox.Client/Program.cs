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
            Customer Customer = GetNameInput();
            Store Store = GetStoreInput();
            Pizza Pizza = GetPizzaInput();
            Crust Crust = GetCrustInput();
            Size Size = GetSizeInput();
            if (Pizza.Name.Equals("Custom"))
            {
                CustomPizzaToppings(Pizza);
            }
        }

        private static Customer GetNameInput()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            var Customer = repository.GetCustomerByName(name);
            Console.WriteLine($"Hello, {Customer.Name}. Your ID is {Customer.Id}. Let's start on your order.\n");
            return Customer;
        }
        private static Store GetStoreInput()
        {
            DisplayMenus.DisplayStoreMenu(repository);
            Console.Write("Please choose a store by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Store Store = repository.GetStoreById(num);
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
            DisplayMenus.DisplayPizzaMenu(repository);
            Console.Write("Please choose a pizza by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Pizza Pizza = repository.GetPizzaById(num);
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
            DisplayMenus.DisplayCrustMenu(repository);
            Console.Write("Please choose a crust by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Crust Crust = repository.GetCrustById(num);
                if (Crust == null)
                {
                    Console.Write("This ID is not associated with any crust, try again: ");
                }
                else
                {
                    Console.WriteLine($"You have chosen {Crust.Name}.\n");
                    return Crust;
                }
            }
        }
        private static Size GetSizeInput()
        {
            DisplayMenus.DisplaySizeMenu(repository);
            Console.Write("Please choose a size by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Size Size = repository.GetSizeById(num);
                if (Size == null)
                {
                    Console.Write("This ID is not associated with any size, try again: ");
                }
                else
                {
                    Console.WriteLine($"You have chosen {Size.Name}.\n");
                    return Size;
                }
            }
        }
        private static Topping GetToppingInput()
        {
            DisplayMenus.DisplayToppingMenu(repository);
            Console.Write("Please choose a topping by entering its ID: ");
            while (true)
            {
                int num = validNumInput();
                Topping Topping = repository.GetToppingById(num);
                if (Topping.Name == null)
                {
                    Console.Write("This ID is not associated with any topping, try again: ");
                }
                else
                {
                    Console.WriteLine($"You have chosen {Topping.Name}.\n");
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
    }
}