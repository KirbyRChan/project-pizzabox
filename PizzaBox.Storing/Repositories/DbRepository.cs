using System.Collections.Generic;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;
using System.Linq;

namespace PizzaBox.Storing
{
    /// <summary>
    /// Database Repository. Handles calls from Client to Database.
    /// </summary>
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

        public List<Order> GetOrderHistoryById(int Id)
        {
            var OrderHistory = context.Orders.Where(x => x.CustomerId == Id);
            if (OrderHistory == null)
            {
                return null;
            }
            return OrderHistory.Select(mapper.Map).ToList();
        }
        public Customer GetCustomerByName(string name)
        {
            var Customer = context.Customers.Where(x => x.CustomerName == name).FirstOrDefault();
            if (Customer == null)
            {
                context.Add(mapper.Map(new Domain.Models.Customer { Name = name }));
                context.SaveChanges();

                Customer = context.Customers.Where(x => x.CustomerName == name).FirstOrDefault();
            }

            return mapper.Map(Customer);

        }

        public Store GetStoreById(int Id)
        {
            var Store = context.Stores.Where(x => x.StoreId == Id).FirstOrDefault();
            if (Store == null)
            {
                return null;
            }
            return mapper.Map(Store);
        }
        public Pizza GetPizzaById(int Id)
        {
            var Pizza = context.Pizzas.Where(x => x.PizzaId == Id).FirstOrDefault();
            if (Pizza == null)
            {
                return null;
            }
            return mapper.Map(Pizza);
        }

        public Size GetSizeById(int Id)
        {
            var Size = context.Sizes.Where(x => x.SizeId == Id).FirstOrDefault();
            if (Size == null)
            {
                return null;
            }
            return mapper.Map(Size);
        }
        public Crust GetCrustById(int Id)
        {
            var Crust = context.Crusts.Where(x => x.CrustId == Id).FirstOrDefault();
            if (Crust == null)
            {
                return null;
            }
            return mapper.Map(Crust);
        }

        public Topping GetToppingById(int? Id)
        {
            var Topping = context.Toppings.Where(x => x.ToppingId == Id).FirstOrDefault();
            if (Topping != null)
            {
                return mapper.Map(Topping);
            }
            return new Topping();
        }
    }
}