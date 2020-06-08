using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactsData contactsData = new ContactsData("z", "admin", "secret");

            contactsData.MiddleName = "z";
            contactsData.LastName = "z";
            contactsData.Nickname = "z";
            contactsData.Company = "z";
            contactsData.Title = "z";
            contactsData.Address = "z";
            contactsData.Home = "z";
            contactsData.Mobile = "z";
            contactsData.Work = "z";
            contactsData.Fax = "z";
            contactsData.Email = "z";
            contactsData.Email2 = "z";
            contactsData.Email3 = "z";
            contactsData.Homepage = "z";
            contactsData.BDay = "29";
            contactsData.BMonth = "April";
            contactsData.BYear = "2001";
            contactsData.ADay = "14";
            contactsData.AMonth = "January";
            contactsData.AYear = "2001";
            contactsData.SAddress = "z";
            contactsData.SHome = "z";
            contactsData.SNotes = "z";

            app.Contacts.Modify(contactsData);
        }
    }
}