using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactsData contactsData = new ContactsData("MN", "admin", "secret");

            contactsData.MiddleName = "a";
            contactsData.LastName = "LN";
            contactsData.Nickname = "a";
            contactsData.Company = "a";
            contactsData.Title = "a";
            contactsData.Address = "a";
            contactsData.Home = "a";
            contactsData.Mobile = "a";
            contactsData.Work = "a";
            contactsData.Fax = "a";
            contactsData.Email = "a";
            contactsData.Email2 = "a";
            contactsData.Email3 = "a";
            contactsData.Homepage = "a";
            contactsData.BDay = "28";
            contactsData.BMonth = "April";
            contactsData.BYear = "2000";
            contactsData.ADay = "12";
            contactsData.AMonth = "January";
            contactsData.AYear = "2000";
            contactsData.SAddress = "a";
            contactsData.SHome = "a";
            contactsData.SNotes = "a";

            List<ContactsData> oldContacts = app.Contacts.GetContacList();

            app.Groups
                .InitNewContactCreation()
                .FillContactForm(contactsData)
                .SubmitContactCreatin();
            app.Navigator.GoToHomePage();

            List<ContactsData> newContacts = app.Contacts.GetContacList();

            //oldContacts.Add(contactsData);

            oldContacts.Sort();
            newContacts.Sort();
// ----------------------------------------------------------------------------- Проверка вывода имени и фамилии
            foreach (var item in oldContacts)
            {
                System.Console.Write(item.FirstName + " " + item.LastName);
            }

            System.Console.WriteLine();

            foreach (var item in newContacts)
            {
                System.Console.Write(item.FirstName + " " + item.LastName);
            }
// -----------------------------------------------------------------------------


            Assert.AreEqual(oldContacts, newContacts);
            
        }
    }
}
