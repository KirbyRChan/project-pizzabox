using System.Collections.Generic;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;
using System.Linq;

namespace PizzaBox.Storing
{
    public class DbRepository : IRepository
    {
        private readonly Entities.PizzaBoxDbContext context;
        IMapper mapper = new Mapper();
        public DbRepository(Entities.PizzaBoxDbContext context)
        {
            this.context = context;
        }
        public void AddOrder(Domain.Models.Order Order)
        {
            context.Add(mapper.Map(Order));
            context.SaveChanges();
        }

        public List<Crust> GetAllCrusts()
        {
            var Crusts = context.Crusts;
            return Crusts.Select(mapper.Map).ToList();
        }

        public List<Order> GetAllOrders()
        {
            var Orders = context.Orders;
            return Orders.Select(mapper.Map).ToList();
        }

        public List<Pizza> GetAllPizzas()
        {
            var Pizzas = context.Pizzas;
            return Pizzas.Select(mapper.Map).ToList();
        }

        public List<Size> GetAllSizes()
        {
            var Sizes = context.Sizes;
            return Sizes.Select(mapper.Map).ToList();
        }

        public List<Store> GetAllStores()
        {
            var Stores = context.Stores;
            return Stores.Select(mapper.Map).ToList();
        }

        public List<Topping> GetAllToppings()
        {
            var Toppings = context.Toppings;
            return Toppings.Select(mapper.Map).ToList();
        }

        public List<Order> GetOrderHistoryByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}