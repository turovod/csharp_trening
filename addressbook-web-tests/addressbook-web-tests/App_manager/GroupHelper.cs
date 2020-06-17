using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreatin();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper Remove(int v)
        {
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();

            manager.Auth.Logout();

            return this;
        }

        public GroupHelper SubmitContactCreatin()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();

            return this;
        }

        public GroupHelper FillContactForm(ContactsData contactsData)
        {
            Type(By.Name("firstname"), contactsData.FirstName);
            Type(By.Name("middlename"), contactsData.MiddleName);
            Type(By.Name("lastname"), contactsData.LastName);
            Type(By.Name("nickname"), contactsData.Nickname);
            Type(By.Name("title"), contactsData.Title);
            Type(By.Name("company"), contactsData.Company);
            Type(By.Name("address"), contactsData.Address);
            Type(By.Name("home"), contactsData.Home);
            Type(By.Name("mobile"), contactsData.Mobile);
            Type(By.Name("work"), contactsData.Work);
            Type(By.Name("fax"), contactsData.Fax);
            Type(By.Name("email"), contactsData.Email);
            Type(By.Name("email2"), contactsData.Email2);
            Type(By.Name("email3"), contactsData.Email3);
            Type(By.Name("homepage"), contactsData.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contactsData.BDay);
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contactsData.BMonth);
            driver.FindElement(By.Name("bmonth")).Click();
            Type(By.Name("byear"), contactsData.BYear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contactsData.ADay);
            driver.FindElement(By.Name("aday")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contactsData.AMonth);
            driver.FindElement(By.Name("amonth")).Click();
            Type(By.Name("ayear"), contactsData.AYear);
            Type(By.Name("address2"), contactsData.SAddress);
            Type(By.Name("phone2"), contactsData.SHome);
            Type(By.Name("notes"), contactsData.SNotes);

            return this;
        }

        public GroupHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();

            return this;
        }

        public GroupHelper SubmitGroupCreatin()
        {
            driver.FindElement(By.Name("submit")).Click();

            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;
        }

        
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();

            return this;
        }


        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();

            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();

            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath($"(//input[@name='selected[]'])[{index}]")).Click();

            return this;
        }

        public GroupHelper GoTpGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();

            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool IsGroupPresent()
        {
            if (driver.Url != manager.Navigator.baseURL + "/addressbook/group.php")
            {
                manager.Navigator.GoToGroupsPage();
            }
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}
