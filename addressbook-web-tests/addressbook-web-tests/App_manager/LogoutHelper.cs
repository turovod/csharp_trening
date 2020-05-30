using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class LogoutHelper : HelperBase
    {
        private IWebDriver driver;

        public LogoutHelper(IWebDriver driver) : base(driver) { }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
