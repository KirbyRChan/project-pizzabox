using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("crusts")]
    public partial class Crust
    {
        public Crust()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("crust_id")]
        public int CrustId { get; set; }
        [Required]
        [Column("crust_name")]
        [StringLength(50)]
        public string CrustName { get; set; }
        [Column("price", TypeName = "money")]
        public decimal Price { get; set; }

        [InverseProperty(nameof(Order.Crust))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
