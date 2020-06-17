using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactHelper Remove()
        {
            SelectContact();
            RemoveContact();

            return this;
        }

        internal ContactHelper Modify(ContactsData contactsData)
        {
            SelectContact();
            InitContactModification();
            FillContactForm(contactsData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        public ContactHelper FillContactForm(ContactsData contactsData)
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

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();

            return this;
        }

        private ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();

            return this;
        }

        public ContactHelper SubmitContactCreatin()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();

            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }


        public bool IsContactPresent()
        {
            if (driver.Url == manager.Navigator.baseURL + "/addressbook/")
            {
                manager.Navigator.GoToHomePage();
            }
            return IsElementPresent(By.Name("selected[]"));
        }

    }


}
