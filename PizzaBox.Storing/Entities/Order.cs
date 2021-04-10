using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("orders")]
    public partial class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("pizza_id")]
        public int PizzaId { get; set; }
        [Column("crust_id")]
        public int CrustId { get; set; }
        [Column("size_id")]
        public int SizeId { get; set; }
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
        [Column("price", TypeName = "money")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(CrustId))]
        [InverseProperty("Orders")]
        public virtual Crust Crust { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(PizzaId))]
        [InverseProperty("Orders")]
        public virtual Pizza Pizza { get; set; }
        [ForeignKey(nameof(SizeId))]
        [InverseProperty("Orders")]
        public virtual Size Size { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Orders")]
        public virtual Store Store { get; set; }
        [ForeignKey(nameof(Topping1Id))]
        [InverseProperty(nameof(Topping.OrderTopping1s))]
        public virtual Topping Topping1 { get; set; }
        [ForeignKey(nameof(Topping2Id))]
        [InverseProperty(nameof(Topping.OrderTopping2s))]
        public virtual Topping Topping2 { get; set; }
        [ForeignKey(nameof(Topping3Id))]
        [InverseProperty(nameof(Topping.OrderTopping3s))]
        public virtual Topping Topping3 { get; set; }
        [ForeignKey(nameof(Topping4Id))]
        [InverseProperty(nameof(Topping.OrderTopping4s))]
        public virtual Topping Topping4 { get; set; }
        [ForeignKey(nameof(Topping5Id))]
        [InverseProperty(nameof(Topping.OrderTopping5s))]
        public virtual Topping Topping5 { get; set; }
    }
}
