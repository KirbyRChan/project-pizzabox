using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Pizza : APizza
    {
        public override void AddCrust()
        {
            Crust = null;
        }

        public override void AddSize()
        {
            Size = null;
        }

        public override void AddToppings()
        {
            Toppings.AddRange(new Topping[] { new Topping(), new Topping() });
        }
    }
}