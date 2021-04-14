using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing
{
    /// <summary>
    /// Maps DB entities to objects in Domain
    /// </summary>
    public class Mapper : IMapper
    {
        public Domain.Models.Customer Map(Entities.Customer Customer)
        {
            return new Domain.Models.Customer
            {
                Id = Customer.CustomerId,
                Name = Customer.CustomerName
            };
        }

        public Entities.Customer Map(Domain.Models.Customer Customer)
        {
            return new Entities.Customer
            {
                CustomerId = Customer.Id,
                CustomerName = Customer.Name
            };
        }
        public Domain.Models.Store Map(Entities.Store Store)
        {
            return new Domain.Models.Store
            {
                Id = Store.StoreId,
                Name = Store.StoreName
            };
        }

        public Entities.Store Map(Domain.Models.Store Store)
        {
            return new Entities.Store
            {
                StoreId = Store.Id,
                StoreName = Store.Name
            };
        }
        public Domain.Models.Pizza Map(Entities.Pizza Pizza)
        {
            List<int?> pizzaToppingsId = new List<int?>();
            pizzaToppingsId.Add(Pizza.Topping1Id);
            pizzaToppingsId.Add(Pizza.Topping2Id);
            pizzaToppingsId.Add(Pizza.Topping3Id);
            pizzaToppingsId.Add(Pizza.Topping4Id);
            pizzaToppingsId.Add(Pizza.Topping5Id);
            return new Domain.Models.Pizza
            {
                Id = Pizza.PizzaId,
                Name = Pizza.PizzaName,
                ToppingsId = pizzaToppingsId
            };
        }

        public Entities.Pizza Map(Domain.Models.Pizza Pizza)
        {
            return new Entities.Pizza
            {
                PizzaId = Pizza.Id,
                PizzaName = Pizza.Name,
                Topping1Id = Pizza.ToppingsId[0],
                Topping2Id = Pizza.ToppingsId[1],
                Topping3Id = Pizza.ToppingsId[2],
                Topping4Id = Pizza.ToppingsId[3],
                Topping5Id = Pizza.ToppingsId[4]
            };
        }

        public Domain.Models.Crust Map(Entities.Crust Crust)
        {
            return new Domain.Models.Crust
            {
                Id = Crust.CrustId,
                Name = Crust.CrustName,
                Price = Crust.Price
            };
        }

        public Entities.Crust Map(Domain.Models.Crust Crust)
        {
            return new Entities.Crust
            {
                CrustId = Crust.Id,
                CrustName = Crust.Name,
                Price = Crust.Price
            };
        }

        public Domain.Models.Size Map(Entities.Size Size)
        {
            return new Domain.Models.Size
            {
                Id = Size.SizeId,
                Name = Size.SizeName,
                Price = Size.Price
            };
        }

        public Entities.Size Map(Domain.Models.Size Size)
        {
            return new Entities.Size
            {
                SizeId = Size.Id,
                SizeName = Size.Name,
                Price = Size.Price
            };
        }

        public Domain.Models.Topping Map(Entities.Topping Topping)
        {
            return new Domain.Models.Topping
            {
                Id = Topping.ToppingId,
                Name = Topping.ToppingName,
                Price = Topping.Price
            };
        }

        public Entities.Topping Map(Domain.Models.Topping Topping)
        {
            return new Entities.Topping
            {
                ToppingId = Topping.Id,
                ToppingName = Topping.Name,
                Price = Topping.Price
            };
        }

        public Domain.Models.Order Map(Entities.Order Order)
        {
            List<int?> orderToppingsId = new List<int?>();
            orderToppingsId.Add(Order.Topping1Id);
            orderToppingsId.Add(Order.Topping2Id);
            orderToppingsId.Add(Order.Topping3Id);
            orderToppingsId.Add(Order.Topping4Id);
            orderToppingsId.Add(Order.Topping5Id);
            return new Domain.Models.Order
            {
                Id = Order.OrderId,
                StoreId = Order.StoreId,
                CustomerId = Order.CustomerId,
                PizzaId = Order.PizzaId,
                CrustId = Order.CrustId,
                SizeId = Order.SizeId,
                ToppingsId = orderToppingsId,
                Price = Order.Price
            };
        }

        public Entities.Order Map(Domain.Models.Order Order)
        {
            return new Entities.Order
            {
                OrderId = Order.Id,
                StoreId = Order.StoreId,
                CustomerId = Order.CustomerId,
                PizzaId = Order.PizzaId,
                CrustId = Order.CrustId,
                SizeId = Order.SizeId,
                Topping1Id = Order.ToppingsId[0],
                Topping2Id = Order.ToppingsId[1],
                Topping3Id = Order.ToppingsId[2],
                Topping4Id = Order.ToppingsId[3],
                Topping5Id = Order.ToppingsId[4],
                Price = Order.Price
            };
        }
    }
}