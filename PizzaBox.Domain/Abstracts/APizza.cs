using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class APizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Topping1Id { get; set; }
        public int? Topping2Id { get; set; }
        public int? Topping3Id { get; set; }
        public int? Topping4Id { get; set; }
        public int? Topping5Id { get; set; }

        // protected APizza()
        // {
        //     Factory();
        // }

        // private void Factory()
        // {
        //     Toppings = new List<int?>();
        // }
    }
}