using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace autofixture.tests
{
    using Ploeh.AutoFixture;

    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Traditional()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            calc.Subtract(1);

            // Assert
            Assert.IsTrue(calc.Value < 0);
        }

        [TestMethod]
        public void AutoFixtureAnonymousData()
        {
            // Arrange
            var calc = new Calculator();
            var fixture = new Fixture();

            // Act
            // Anonymous object to generate data
            calc.Subtract(fixture.Create<int>());

            //Assert
            Assert.IsTrue(calc.Value < 0);
        }

        [TestMethod]
        public void TestAddMethod()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new Calculator();
            int num = fixture.Create<int>();

            // Act
            sut.Add(num);

            // Assert
            Assert.AreEqual(num, sut.Value);
        }
    }
}
