using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBasse
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            //driver = new FirefoxDriver();
            //baseURL = "http://localhost/addressbook/";
            //verificationErrors = new StringBuilder();

            app = new ApplicationManager(); 
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }      
    }
}
