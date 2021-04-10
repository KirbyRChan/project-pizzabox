using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("pizzas")]
    public partial class Pizza
    {
        public Pizza()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("pizza_id")]
        public int PizzaId { get; set; }
        [Required]
        [Column("pizza_name")]
        [StringLength(50)]
        public string PizzaName { get; set; }
        [Column("topping1_id")]
        public int? Topping1Id { get; set; }
        [Column("topping2_id")]
        public int? Topping2Id { get; set; }
        [Column("topping3_id")]
        public int? Topping3Id { get; set; }
        [Column("topping4_id")]
        public int? Topping4Id { get; set; }
        [Column("topping5_id")]
        public int? Topping5Id { get; set; }

        [ForeignKey(nameof(Topping1Id))]
        [InverseProperty(nameof(Topping.PizzaTopping1s))]
        public virtual Topping Topping1 { get; set; }
        [ForeignKey(nameof(Topping2Id))]
        [InverseProperty(nameof(Topping.PizzaTopping2s))]
        public virtual Topping Topping2 { get; set; }
        [ForeignKey(nameof(Topping3Id))]
        [InverseProperty(nameof(Topping.PizzaTopping3s))]
        public virtual Topping Topping3 { get; set; }
        [ForeignKey(nameof(Topping4Id))]
        [InverseProperty(nameof(Topping.PizzaTopping4s))]
        public virtual Topping Topping4 { get; set; }
        [ForeignKey(nameof(Topping5Id))]
        [InverseProperty(nameof(Topping.PizzaTopping5s))]
        public virtual Topping Topping5 { get; set; }
        [InverseProperty(nameof(Order.Pizza))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
