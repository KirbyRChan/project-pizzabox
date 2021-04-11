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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            IRepository repository = Dependencies.CreateRepository();
            Console.WriteLine("Fetching PizzaBox Database");
            Run(repository);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Run(IRepository repository)
        {
            var order = new Order();

            Console.WriteLine("Welcome to PizzaBox");
            // DisplayStoreMenu(repository);
            // DisplayPizzaMenu(repository);
            // DisplayCrustMenu(repository);
            // DisplaySizeMenu(repository);
            DisplayToppingMenu(repository);
        }
        private static void DisplayStoreMenu(IRepository repository)
        {
            var Stores = repository.GetAllStores();
            foreach (var store in Stores)
            {
                Console.WriteLine($"{store.Id,-2} {store.Name}");
            }
        }

        private static void DisplayPizzaMenu(IRepository repository)
        {
            var Pizzas = repository.GetAllPizzas();
            foreach (var pizza in Pizzas)
            {
                Console.WriteLine($"{pizza.Id,-2} {pizza.Name} {pizza.Topping1Id} {pizza.Topping2Id} {pizza.Topping3Id} {pizza.Topping4Id} {pizza.Topping5Id}");
            }
        }
        private static void DisplayCrustMenu(IRepository repository)
        {
            var Crusts = repository.GetAllCrusts();
            foreach (var crust in Crusts)
            {
                Console.WriteLine($"{crust.Id,-2} {crust.Name} {crust.Price:C2}");
            }
        }
        private static void DisplaySizeMenu(IRepository repository)
        {
            var Sizes = repository.GetAllSizes();
            foreach (var size in Sizes)
            {
                Console.WriteLine($"{size.Id,-2} {size.Name} {size.Price:C2}");
            }
        }
        private static void DisplayToppingMenu(IRepository repository)
        {
            var Toppings = repository.GetAllToppings();
            Console.WriteLine("+--+------------+------+");
            Console.WriteLine("|ID|TOPPING     | PRICE|");
            Console.WriteLine("+--+------------+------+");
            foreach (var topping in Toppings)
            {
                Console.WriteLine($"|{topping.Id,-2}|{topping.Name,-12}|{topping.Price,6:C2}|");
            }
            Console.WriteLine("+--+------------+------+");
        }
    }
}