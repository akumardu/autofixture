using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace autofixture.tests
{
    using Ploeh.AutoFixture;

    [TestClass]
    public class EmailMessageTest
    {
        [TestMethod]
        public void ObjectCreationTest()
        {
            var fixture = new Fixture();
            var emailObject = fixture.Create<EmailMessage>();

            var eBuffer = new EmailMessageBuffer();

            eBuffer.Add(emailObject);

            Assert.AreEqual(1, eBuffer.Emails.Count);
        }
    }
}
