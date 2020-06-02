using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBasse
    {
        [Test]
        public void ContactRemovalTest()
        {
            // Проверить наличие контакта с этим id
            app.Contacts.Remove("14");
        }
    }
}
