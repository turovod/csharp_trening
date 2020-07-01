using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactsData GetContacInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;





            return new ContactsData(firstName, "admin", "secret")
            {
                LastName = lastName,
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };

        }

        public ContactsData GetContacInformationFromPropertiesForm()
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            //string Text = driver.FindElement(By.XPath("//div[@id='content']/b")).Text;

            //string allInfo = driver.FindElement(By.TagName("body")).FindElement(By.TagName("br")).Text;
            string allInfo = driver.FindElement(By.Id("content")).Text;

            return new ContactsData("aa", "admin", "secret")
            {
                LastName = "bb",
                AllInfo = allInfo
            };
        }

        public ContactsData GetContacInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModificationByIndex(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePone = driver.FindElement(By.Name("home")).GetAttribute("value"); 
            string mobilePone = driver.FindElement(By.Name("mobile")).GetAttribute("value"); 
            string workPone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");          
            string email = driver.FindElement(By.Name("email")).GetAttribute("value"); 
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value"); 
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bMonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string bYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string aMonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string sAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string sHome = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string sNotes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            string allInfo = firstName + " " + middleName + " " + lastName + "\r\n" +
                nickName + "\r\n" + company + "\r\n" + title + "\r\n" + address + "\r\n\r\n" +
                "H: " + homePone + "\r\nM: " + mobilePone + "\r\nW: " + workPone + "\r\nF: " + fax +
                "\r\n\r\n" + email + email2 + "\r\n" + email3 + "\r\nHomepage:\r\n" + homepage + "\r\n\r\n" +
                "Birthday " + bDay + ". " + bMonth + " " + bYear + " (20)\r\n" + "Anniversary " +
                aDay + ". " + aMonth + " " + aYear + " (20)\r\n\r\n" + sAddress + "\r\n\r\n" +
                "P: " + sHome + "\r\n\r\n" + sNotes;

            return new ContactsData(firstName, "admin", "secret")
            {
                LastName = lastName,
                Address = address,
                Home = homePone,
                Mobile = mobilePone,
                Work = workPone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                AllInfo = allInfo
            };
        }

        private void InitContactModificationByIndex(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();
        }

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

            contactCash = null;

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

        private List<ContactsData> contactCash = null;

        public List<ContactsData> GetContacList()
        {
            if (contactCash == null)
            {
                contactCash = new List<ContactsData>();
                manager.Navigator.GoToHomePage();

                ICollection<IWebElement> elementsFirstName = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr/td[3]"));
                IList<IWebElement> elementsLastName = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr/td[2]"));

                int i = 0;

                foreach (IWebElement element in elementsFirstName)
                {
                    contactCash.Add(new ContactsData(element.Text, "admin", "secret")
                    {
                        LastName = elementsLastName[i].Text
                    });

                    i++;

                }
            }

            return new List<ContactsData>(contactCash);
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

            contactCash = null;

            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCash = null;
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

        public int GetNumbersOfSerchResalts()
        {
            manager.Navigator.GoToHomePage();

            string text = driver.FindElement(By.TagName("label")).Text;

            Match m = new Regex(@"\d+").Match(text);

            return Convert.ToInt32(m.Value);
        }

    }


}
