using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class PizzaTests
    {
        [Fact]
        public void Test_PizzaCrust()
        {
            //arrange
            var sut = new MeatPizza();

            var actual = sut.Crust;

            Assert.Null(actual);

        }
    }
}