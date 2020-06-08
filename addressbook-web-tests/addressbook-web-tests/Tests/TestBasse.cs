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
            app = ApplicationManager.GetInstance();          
        }    
    }
}
