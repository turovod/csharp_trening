using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";

            loginHelper = new LoginHelper(this);
            logoutHelper = new LogoutHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
        }

        public IWebDriver Driver 
        {
            get { return driver; }
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
