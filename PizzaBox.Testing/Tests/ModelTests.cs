using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class PizzaTests
    {
        [Fact]
        public void Test_CustomerModel()
        {
            //arrange
            var sut = new Pizza();

            var actual = sut.Name;

            Assert.Null(actual);

        }

        [Fact]
        public void Test_StoreModel()
        {
            //arrange
            var sut = new Store();

            //act
            var actual = sut.Name;

            //assert
            Assert.Equal(actual, "Store");
        }

        [Fact]
        public void Test_PizzaModel()
        {
            //arrange
            var sut = new Pizza();

            //act
            var actual = sut.Name;

            //assert
            Assert.Null(actual);
        }

        [Fact]
        public void Test_CrustModel()
        {
            //arrange
            var sut = new Crust();

            //act
            var actual = sut.Price;

            //assert
            Assert.Equal(actual, 0);
        }

        [Fact]
        public void Test_SizeModel()
        {
            //arrange
            var sut = new Size();

            //act
            var actual = sut.Id;

            //assert
            Assert.Equal(actual, 0);
        }

        [Fact]
        public void Test_ToppingModel()
        {
            //arrange
            var sut = new Topping();
            //act
            var actual = sut.Price;

            //assert
            Assert.Equal(actual, 0);
        }
    }
}