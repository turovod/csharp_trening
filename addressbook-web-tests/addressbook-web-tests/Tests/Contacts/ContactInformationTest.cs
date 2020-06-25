using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class  ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactsData fromTable = app.Contacts.GetContacInformationFromTable(0);
            ContactsData fromForm = app.Contacts.GetContacInformationFromEditForm(0);

            Console.WriteLine(fromTable.AllEmails);
            Console.WriteLine(fromForm.AllPhones);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            //Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);

        }
    }
}
