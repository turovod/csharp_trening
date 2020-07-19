using Json.Net;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactsData> RandomContactDataProvider()
        {
            List<ContactsData> contacts = new List<ContactsData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactsData(GenerateRandomString(20),"admin", "secret")
                {
                    MiddleName = GenerateRandomString(20),
                    LastName = GenerateRandomString(20),
                    Nickname = GenerateRandomString(20),
                    Company = GenerateRandomString(20),
                    Title = GenerateRandomString(20),
                    Address = GenerateRandomString(20),
                    Home = GenerateRandomString(20),
                    Mobile = GenerateRandomString(20),
                    Work = GenerateRandomString(20),
                    Fax = GenerateRandomString(20),
                    Email = GenerateRandomString(20),
                    Email2 = GenerateRandomString(20),
                    Email3 = GenerateRandomString(20),
                    Homepage = GenerateRandomString(20),
                    BDay = GenerateRandomDay(),
                    BMonth = GenerateRandomString(20),
                    BYear = GenerateRandomYer(),
                    ADay = GenerateRandomDay(),
                    AMonth = GenerateRandomString(20),
                    AYear = GenerateRandomYer(),
                    SAddress = GenerateRandomString(20),
                    SHome = GenerateRandomString(20),
                    SNotes = GenerateRandomString(20),
                });
            }

            return contacts;
        }

        public static IEnumerable<ContactsData> ContactDataFromXmlFile()
        {
            return new XmlSerializer(typeof(List<ContactsData>)).Deserialize(new StreamReader(@"contacts.json"))
                                                                                        as List<ContactsData>;
        }

        public static IEnumerable<ContactsData> ContactDataFromJsonFile()
        {
            return JsonNet.Deserialize<List<ContactsData>>(File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactsData contactsData)
        {
            //ContactsData contactsData = new ContactsData("MN", "admin", "secret");

            //contactsData.MiddleName = "a";
            //contactsData.LastName = "LN";
            //contactsData.Nickname = "a";
            //contactsData.Company = "a";
            //contactsData.Title = "a";
            //contactsData.Address = "a";
            //contactsData.Home = "a";
            //contactsData.Mobile = "a";
            //contactsData.Work = "a";
            //contactsData.Fax = "a";
            //contactsData.Email = "a";
            //contactsData.Email2 = "a";
            //contactsData.Email3 = "a";
            //contactsData.Homepage = "a";
            //contactsData.BDay = "28";
            //contactsData.BMonth = "April";
            //contactsData.BYear = "2000";
            //contactsData.ADay = "12";
            //contactsData.AMonth = "January";
            //contactsData.AYear = "2000";
            //contactsData.SAddress = "a";
            //contactsData.SHome = "a";
            //contactsData.SNotes = "a";

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
            //foreach (var item in oldContacts)
            //{
            //    System.Console.Write(item.FirstName + " " + item.LastName);
            //}

            //System.Console.WriteLine();

            //foreach (var item in newContacts)
            //{
            //    System.Console.Write(item.FirstName + " " + item.LastName);
            //}
// -----------------------------------------------------------------------------


            Assert.AreEqual(oldContacts, newContacts);
            
        }
    }
}
