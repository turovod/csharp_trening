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
            app.Contacts.Remove();
        }
    }
}
