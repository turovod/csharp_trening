using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
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

            app.Contacts.Remove();
        }
    }
}
