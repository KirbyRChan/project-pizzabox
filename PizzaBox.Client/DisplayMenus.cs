using System;
using System.Collections.Generic;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    internal static class DisplayMenus
    {
        internal static void DisplayStoreMenu(IRepository repository)
        {
            var Stores = repository.GetAllStores();
            Console.WriteLine("+--+------------+");
            Console.WriteLine("|ID|STORE       |");
            Console.WriteLine("+--+------------+");
            foreach (var store in Stores)
            {
                Console.WriteLine($"|{store.Id,-2}|{store.Name,-12}|");
            }
            Console.WriteLine("+--+------------+");
        }

        internal static void DisplayPizzaMenu(IRepository repository)
        {
            var Pizzas = repository.GetAllPizzas();
            Console.WriteLine("+--+----------+--------------+--------------+--------------+--------------+--------------+");
            Console.WriteLine("|ID|PIZZA     |TOPPINGS                                                                  |");
            Console.WriteLine("+--+----------+--------------+--------------+--------------+--------------+--------------+");
            foreach (var pizza in Pizzas)
            {
                Console.WriteLine($"|{pizza.Id,-2}|{pizza.Name,-10}|" +
                $"{repository.GetToppingById(pizza.ToppingsId[0]).Name,-14}|" +
                $"{repository.GetToppingById(pizza.ToppingsId[1]).Name,-14}|" +
                $"{repository.GetToppingById(pizza.ToppingsId[2]).Name,-14}|" +
                $"{repository.GetToppingById(pizza.ToppingsId[3]).Name,-14}|" +
                $"{repository.GetToppingById(pizza.ToppingsId[4]).Name,-14}|");
            }
            Console.WriteLine("+--+----------+--------------+--------------+--------------+--------------+--------------+");
        }
        internal static void DisplayCrustMenu(IRepository repository)
        {
            var Crusts = repository.GetAllCrusts();
            Console.WriteLine("+--+------------+------+");
            Console.WriteLine("|ID|CRUST       | PRICE|");
            Console.WriteLine("+--+------------+------+");
            foreach (var crust in Crusts)
            {
                Console.WriteLine($"|{crust.Id,-2}|{crust.Name,-12}|{crust.Price,6:C2}|");
            }
            Console.WriteLine("+--+------------+------+");
        }
        internal static void DisplaySizeMenu(IRepository repository)
        {
            var Sizes = repository.GetAllSizes();
            Console.WriteLine("+--+------------+------+");
            Console.WriteLine("|ID|SIZE        | PRICE|");
            Console.WriteLine("+--+------------+------+");
            foreach (var size in Sizes)
            {
                Console.WriteLine($"|{size.Id,-2}|{size.Name,-12}|{size.Price,6:C2}|");
            }
            Console.WriteLine("+--+------------+------+");
        }
        internal static void DisplayToppingMenu(IRepository repository)
        {
            var Toppings = repository.GetAllToppings();
            Console.WriteLine("+--+--------------+------+");
            Console.WriteLine("|ID|TOPPING       | PRICE|");
            Console.WriteLine("+--+--------------+------+");
            foreach (var topping in Toppings)
            {
                Console.WriteLine($"|{topping.Id,-2}|{topping.Name,-14}|{topping.Price,6:C2}|");
            }
            Console.WriteLine("+--+--------------+------+");
        }
    }
}