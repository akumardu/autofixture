using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace autofixture.tests
{
    using Ploeh.AutoFixture;

    [TestClass]
    public class NameJoinerTest
    {
        [TestMethod]
        public void BasicString()
        {
            // Arrange
            var fixture = new Fixture();
            var njoiner = new NameJoiner();

            // seed string (these are prefixed values)
            var firstName = fixture.Create<string>("first");
            var lastName = fixture.Create<string>("last");

            // Act
            var result = njoiner.Join(firstName, lastName);

            // Assert
            Assert.AreEqual(result, firstName + " " + lastName);
        }
    }
}
