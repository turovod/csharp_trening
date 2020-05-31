using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace WebAddressbookTests
{
    public class TestBasse
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            ContactsData contactsData = new ContactsData("a", "admin", "secret");

            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(contactsData);

           
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }      
    }
}
