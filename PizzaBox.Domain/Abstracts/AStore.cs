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
        /// 
        /// </summary>
        protected AStore()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}