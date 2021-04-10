using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("toppings")]
    public partial class Topping
    {
        public Topping()
        {
            OrderTopping1s = new HashSet<Order>();
            OrderTopping2s = new HashSet<Order>();
            OrderTopping3s = new HashSet<Order>();
            OrderTopping4s = new HashSet<Order>();
            OrderTopping5s = new HashSet<Order>();
            PizzaTopping1s = new HashSet<Pizza>();
            PizzaTopping2s = new HashSet<Pizza>();
            PizzaTopping3s = new HashSet<Pizza>();
            PizzaTopping4s = new HashSet<Pizza>();
            PizzaTopping5s = new HashSet<Pizza>();
        }

        [Key]
        [Column("topping_id")]
        public int ToppingId { get; set; }
        [Required]
        [Column("topping_name")]
        [StringLength(50)]
        public string ToppingName { get; set; }
        [Column("price", TypeName = "money")]
        public decimal Price { get; set; }

        [InverseProperty(nameof(Order.Topping1))]
        public virtual ICollection<Order> OrderTopping1s { get; set; }
        [InverseProperty(nameof(Order.Topping2))]
        public virtual ICollection<Order> OrderTopping2s { get; set; }
        [InverseProperty(nameof(Order.Topping3))]
        public virtual ICollection<Order> OrderTopping3s { get; set; }
        [InverseProperty(nameof(Order.Topping4))]
        public virtual ICollection<Order> OrderTopping4s { get; set; }
        [InverseProperty(nameof(Order.Topping5))]
        public virtual ICollection<Order> OrderTopping5s { get; set; }
        [InverseProperty(nameof(Pizza.Topping1))]
        public virtual ICollection<Pizza> PizzaTopping1s { get; set; }
        [InverseProperty(nameof(Pizza.Topping2))]
        public virtual ICollection<Pizza> PizzaTopping2s { get; set; }
        [InverseProperty(nameof(Pizza.Topping3))]
        public virtual ICollection<Pizza> PizzaTopping3s { get; set; }
        [InverseProperty(nameof(Pizza.Topping4))]
        public virtual ICollection<Pizza> PizzaTopping4s { get; set; }
        [InverseProperty(nameof(Pizza.Topping5))]
        public virtual ICollection<Pizza> PizzaTopping5s { get; set; }
    }
}
