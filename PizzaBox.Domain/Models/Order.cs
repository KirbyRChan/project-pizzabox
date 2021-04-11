using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public int CrustId { get; set; }
        public int SizeId { get; set; }
        public int? Topping1Id { get; set; }
        public int? Topping2Id { get; set; }
        public int? Topping3Id { get; set; }
        public int? Topping4Id { get; set; }
        public int? Topping5Id { get; set; }
        public decimal Price { get; set; }


    }
}