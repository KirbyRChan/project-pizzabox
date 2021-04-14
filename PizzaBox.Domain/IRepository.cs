
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public interface IRepository
    {
        List<Models.Store> GetAllStores();
        List<Models.Pizza> GetAllPizzas();

        List<Models.Size> GetAllSizes();

        List<Models.Crust> GetAllCrusts();

        List<Models.Topping> GetAllToppings();

        void AddOrder(Models.Order Order);

        List<Models.Order> GetOrderHistoryByName(string name);
        Models.Customer GetCustomerByName(string name);
        Models.Store GetStoreById(int Id);
        Models.Pizza GetPizzaById(int Id);

        Models.Size GetSizeById(int Id);
        Models.Crust GetCrustById(int Id);
        Models.Topping GetToppingById(int? Id);


    }
}