using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace autofixture.tests
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using Ploeh.AutoFixture;

    [TestClass]
    public class LogMessageTest
    {
        [TestMethod]
        public void DateTimes()
        {
            // Arrange
            var fixture = new Fixture();
            DateTime logTime = fixture.Create<DateTime>();
            var message = fixture.Create<string>();

            // Act
            LogMessage result = LogMessageCreator.Create(message, logTime);

            // Assert
            Assert.AreEqual(result.Year, logTime.Year);
        }

        [TestMethod]
        public void TestSequencesInFixture()
        {
            var fixture = new Fixture();

            // Testing Generic creation of string
            var collection = fixture.CreateMany<string>();
            foreach (var el in collection)
            { 
                Debug.WriteLine(el);
            }

            var coll = new List<string>();
            fixture.AddManyTo(coll, 4);
            fixture.AddManyTo(coll, () => "hi");
            foreach (var el in coll)
            {
                Debug.WriteLine(el);
            }


        }
    }
}
