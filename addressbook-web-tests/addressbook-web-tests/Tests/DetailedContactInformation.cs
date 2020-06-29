using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class DetailedContactInformation : AuthTestBase
    {
        [Test]

        public void VerificationDetailedContactInformation()
        {
            ContactsData fromTable = app.Contacts.GetContacInformationFromTable(0);
            ContactsData fromForm = app.Contacts.GetContacInformationFromPropertiesForm();

            Assert.AreEqual(fromTable, fromForm);
        }
    }
}
