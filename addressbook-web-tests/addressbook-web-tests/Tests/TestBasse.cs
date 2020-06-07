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
            app = TestSuiteFixture.app;
            app.Navigator.GoToHomePage();
            app.Auth.Login(new ContactsData("a", "admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }      
    }
}
