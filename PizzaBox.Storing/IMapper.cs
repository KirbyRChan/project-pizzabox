using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
    public interface IMapper
    {
        PizzaBox.Domain.Models.Pizza Map(PizzaBox.Storing.Entities.Pizza Pizza);
        PizzaBox.Storing.Entities.Pizza Map(PizzaBox.Domain.Models.Pizza Pizza);
        PizzaBox.Domain.Models.Crust Map(PizzaBox.Storing.Entities.Crust Crust);
        PizzaBox.Storing.Entities.Crust Map(PizzaBox.Domain.Models.Crust Crust);
        PizzaBox.Domain.Models.Size Map(PizzaBox.Storing.Entities.Size Size);
        PizzaBox.Storing.Entities.Size Map(PizzaBox.Domain.Models.Size Size);
        PizzaBox.Domain.Models.Topping Map(PizzaBox.Storing.Entities.Topping Topping);
        PizzaBox.Storing.Entities.Topping Map(PizzaBox.Domain.Models.Topping Topping);
        PizzaBox.Domain.Models.Order Map(PizzaBox.Storing.Entities.Order Order);
        PizzaBox.Storing.Entities.Order Map(PizzaBox.Domain.Models.Order Order);

    }
}