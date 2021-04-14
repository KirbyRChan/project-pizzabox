using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// Store Model
    /// </summary>
    public class Store : AStore
    {
        /// <summary>
        /// Store Constructor
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