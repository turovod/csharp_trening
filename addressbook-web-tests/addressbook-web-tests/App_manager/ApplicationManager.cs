using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected LogoutHelper logoutHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;

        public ApplicationManager()
        {
            loginHelper = new LoginHelper(driver);
            logoutHelper = new LogoutHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public NavigationHelper Navigator
        {
            get { return navigationHelper; }
        }

        public LogoutHelper AuthOut
        {
            get { return logoutHelper; }
        }

        public GroupHelper Groups
        {
            get { return  groupHelper; }
        }
    }
}
