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
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.InitNewContactCreation();
                app.Contacts.FillContactForm(new ContactsData("a", "admin", "secret")
                {
                    MiddleName = "a",
                    LastName = "a",
                    Nickname = "a",
                    Company = "a",
                    Title = "a",
                    Address = "a",
                    Home = "a",
                    Mobile = "a",
                    Work = "a",
                    Fax = "a",
                    Email = "a",
                    Email2 = "a",
                    Email3 = "a",
                    Homepage = "a",
                    BDay = "28",
                    BMonth = "April",
                    BYear = "2000",
                    ADay = "12",
                    AMonth = "January",
                    AYear = "2000",
                    SAddress = "a",
                    SHome = "a",
                    SNotes = "a"
                });

                app.Contacts.SubmitContactCreatin();
                app.Navigator.GoToHomePage();
            }

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