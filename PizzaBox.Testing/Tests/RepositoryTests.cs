using System.Collections.Generic;
using PizzaBox.Client;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class RepositoryTests
    {
        IRepository repository = Dependencies.CreateRepository();

        [Fact]
        public void Test_GetAllStores()
        {
            List<Store> sut = repository.GetAllStores();

            int actual = sut.Count;
            Assert.Equal(actual, 5);
        }
        [Fact]
        public void Test_GetAllPizzas()
        {
            List<Pizza> sut = repository.GetAllPizzas();

            int actual = sut.Count;
            Assert.Equal(actual, 7);
        }
        [Fact]
        public void Test_GetAllCrusts()
        {
            List<Crust> sut = repository.GetAllCrusts();

            int actual = sut.Count;
            Assert.Equal(actual, 4);
        }
        [Fact]
        public void Test_GetAllSizes()
        {
            List<Size> sut = repository.GetAllSizes();

            int actual = sut.Count;
            Assert.Equal(actual, 5);
        }
        [Fact]
        public void Test_GetAllToppings()
        {
            List<Topping> sut = repository.GetAllToppings();

            int actual = sut.Count;
            Assert.Equal(actual, 9);
        }
        [Fact]
        public void Test_GetCustomerByName()
        {
            Customer sut = repository.GetCustomerByName("Kirby");

            int actual = sut.Id;
            Assert.Equal(actual, 0);
        }
        [Fact]
        public void Test_GetStoreById()
        {
            Store sut = repository.GetStoreById(2);
            string actual = sut.Name;

            Assert.Equal(actual, "Brave Store");

        }
        [Fact]
        public void Test_GetPizzaById()
        {
            Pizza sut = repository.GetPizzaById(10);
            Assert.Null(sut);
        }
        [Fact]
        public void Test_GetCrustById()
        {
            Crust sut = repository.GetCrustById(2);
            decimal actual = sut.Price;

            Assert.Equal(actual, 2);
        }
        [Fact]
        public void Test_GetSizeById()
        {
            Size sut = repository.GetSizeById(1);
            int actual = sut.Id;

            Assert.Equal(actual, 1);
        }
        [Fact]
        public void Test_GetToppingById()
        {
            Topping sut = repository.GetToppingById(3);
            string actual = sut.Name;

            Assert.Equal(actual, "Chicken");
        }
    }
}