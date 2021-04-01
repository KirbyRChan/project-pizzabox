using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    //public open to all assemblies
    //protected open to assemblies in inheritance tree
    //internal open to only the assembly
    //defaults to internal
    //protected internal, privated protected

    //static and const created at application start (created by runtime)
    //readonly created at construction (created by us)
    class Program
    {
        //defaults to private
        private static void Main(string[] args)
        {
            Program.Run();
        }

        private static void Run()
        {
            var stores = new List<AStore>()
            {
                new NewYorkStore(),
                new ChicagoStore()
            };

            foreach (var item in stores)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
