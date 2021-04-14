using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Store : AStore
    {
        /// <summary>
        /// 
        /// </summary>
        public Store()
        {
            Name = "Store";
        }

        public override string ToString()
        {
            return $"This is {Name}";
        }
    }
}