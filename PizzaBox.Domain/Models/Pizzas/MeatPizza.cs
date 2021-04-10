using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class MeatPizza : APizza
    {
        public override void AddToppings()
        {
            Toppings.Add(new Topping());
        }
    }
}