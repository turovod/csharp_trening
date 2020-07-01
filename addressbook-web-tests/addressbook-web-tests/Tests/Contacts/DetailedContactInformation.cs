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
            ContactsData fromForm = app.Contacts.GetContacInformationFromEditForm(0);
            ContactsData fromPropertiesForm = app.Contacts.GetContacInformationFromPropertiesForm();

            Console.WriteLine("Edit");
            Console.WriteLine(fromForm.AllInfo);
            Console.WriteLine("Proper");
            Console.WriteLine(fromPropertiesForm.AllInfo);

            Assert.AreEqual(fromForm.AllInfo, fromPropertiesForm.AllInfo);
        }
    }
}
