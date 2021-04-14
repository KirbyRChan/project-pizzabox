using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Represents the Store Abstract Class
    /// </summary>
    [XmlInclude(typeof(Store))]
    public class AStore
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Abstract Store
        /// </summary>
        protected AStore()
        {

        }

        /// <summary>
        /// Converts Abstract Store to String
        /// </summary>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}