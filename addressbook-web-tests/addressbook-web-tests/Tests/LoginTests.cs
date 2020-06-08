using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{ 
    [TestFixture]

    public class LoginTests : TestBasse
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");

            app.Auth.Login(account);

            // (Утверждать) Проверка что залогинены
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }

        [Test]

        public void LoginWithInvalidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "12345");

            app.Auth.Login(account);

            // (Утверждать) Проверка что залогинены
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
