using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
    /// <summary>
    /// Mapper Interface
    /// </summary>
    public interface IMapper
    {
        PizzaBox.Domain.Models.Customer Map(PizzaBox.Storing.Entities.Customer Customer);
        PizzaBox.Storing.Entities.Customer Map(PizzaBox.Domain.Models.Customer Customer);
        PizzaBox.Domain.Models.Store Map(PizzaBox.Storing.Entities.Store Store);
        PizzaBox.Storing.Entities.Store Map(PizzaBox.Domain.Models.Store Store);
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