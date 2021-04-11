using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public interface IRepository
    {
        List<Models.Pizza> GetAllPizzas();

        List<Models.Size> GetAllSizes();

        List<Models.Crust> GetAllCrusts();

        List<Models.Topping> GetAllToppings();

        void AddOrder(Models.Order superHero);

        List<Models.Order> GetOrderHistoryByName(string name);
    }
}