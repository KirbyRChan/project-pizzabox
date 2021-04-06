namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Represents the Pizza Abstract Class
    /// </summary>
    public abstract class AComponent
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}