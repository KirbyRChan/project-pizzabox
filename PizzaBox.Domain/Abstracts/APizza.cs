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
        public List<int?> ToppingsId { get; set; }
    }
}