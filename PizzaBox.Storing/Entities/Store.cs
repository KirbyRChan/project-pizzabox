using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("stores")]
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("store_id")]
        public int StoreId { get; set; }
        [Required]
        [Column("store_name")]
        [StringLength(50)]
        public string StoreName { get; set; }

        [InverseProperty(nameof(Order.Store))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
