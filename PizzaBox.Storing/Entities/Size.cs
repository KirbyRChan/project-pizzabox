using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    [Table("sizes")]
    public partial class Size
    {
        public Size()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("size_id")]
        public int SizeId { get; set; }
        [Required]
        [Column("size_name")]
        [StringLength(50)]
        public string SizeName { get; set; }
        [Column("price", TypeName = "money")]
        public decimal Price { get; set; }

        [InverseProperty(nameof(Order.Size))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
