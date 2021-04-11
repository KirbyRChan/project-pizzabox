using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing
{
    public class Mapper : IMapper
    {
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
            return new Domain.Models.Pizza
            {
                Id = Pizza.PizzaId,
                Name = Pizza.PizzaName,
                Topping1Id = Pizza.Topping1Id,
                Topping2Id = Pizza.Topping2Id,
                Topping3Id = Pizza.Topping3Id,
                Topping4Id = Pizza.Topping4Id,
                Topping5Id = Pizza.Topping5Id
            };
        }

        public Entities.Pizza Map(Domain.Models.Pizza Pizza)
        {
            return new Entities.Pizza
            {
                PizzaId = Pizza.Id,
                PizzaName = Pizza.Name,
                Topping1Id = Pizza.Topping1Id,
                Topping2Id = Pizza.Topping2Id,
                Topping3Id = Pizza.Topping3Id,
                Topping4Id = Pizza.Topping4Id,
                Topping5Id = Pizza.Topping5Id
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
            return new Domain.Models.Order
            {
                Id = Order.OrderId,
                StoreId = Order.StoreId,
                CustomerId = Order.CustomerId,
                PizzaId = Order.PizzaId,
                CrustId = Order.CrustId,
                SizeId = Order.SizeId,
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
                Price = Order.Price
            };
        }
    }
}