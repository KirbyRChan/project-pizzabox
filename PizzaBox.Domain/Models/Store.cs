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
            Name = "ChicagoStore";
        }

        public override string ToString()
        {
            return $"This is Chitown - {Name}";
        }
    }
}