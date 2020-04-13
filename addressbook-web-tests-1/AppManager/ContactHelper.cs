using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : LoginHelper
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddNewContactPage();

            FillContactForm(contact);
            manager.Navigator.GoToHomePage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            //if (contactCache == null)
            //{
            //contactCache = new List<ContactData>();
            ///manager.Navigator.GoToHomePage();
            //ICollection<IWebElement> rows = driver.FindElements(By.XPath("//tr[@name='entry']"));
            List<ContactData> contacts = new List<ContactData>();
            ICollection<IWebElement> rows = driver.FindElements(By.Name("entry"));
            foreach (IWebElement row in rows)
                {
               //contactCache.Add(new ContactData(row.Text, ""));
                //{
                //var lastname = row.FindElements(By.XPath(".//td"))[1].Text;
                //var firstname = row.FindElements(By.XPath(".//td"))[2].Text;
                //ContactData contact = new ContactData(firstname, lastname);
                var cells = row.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(cells[2].Text, cells[1].Text));
                }
            //}
        //}
            //return new List<ContactData>(contactCache);
            return contacts;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification();
            EditContactForm(newData);
            manager.Navigator.GoToHomePage();
            return this;
        }

        public void FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            driver.FindElement(By.Name("submit")).Click();
        }

        public void EditContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            driver.FindElement(By.Name("update")).Click();
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public void ContactIsPresent()
        {
            if (IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
                return;
            }

            ContactData contact = new ContactData("ivan", "ivanov");
            Create(contact);

            manager.Navigator.GoToHomePage();
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        //public ContactData GetContactInformationFromViewPage(int index)
        //{
        //    string homePhone = null;
        //    string mobilePhone = null;
        //    string workPhone = null;
        //    string address = null;
        //    manager.Navigator.GoToHomePage();
        //    driver.FindElement(By.XPath("(//img[@alt='Edit'])")).Click();

        //    string[] lines = driver.FindElement(By.CssSelector("#content")).Text.Split('\n');
        //    string fullName = lines[0].Trim();
        //    if (lines.Length == 1)
        //    {
        //        address = "";
        //    }
        //    else
        //    {
        //        address = lines[1];
        //    }

        //    foreach (string l in lines)
        //    {
        //        if (l.StartsWith("H:"))
        //        {
        //            homePhone = l.Substring(3);
        //        }
        //        if (l.StartsWith("M:"))
        //        {
        //            mobilePhone = l.Substring(3);
        //        }
        //        if (l.StartsWith("W:"))
        //        {
        //            workPhone = l.Substring(3);
        //        }
        //    }

        //    //return new ContactData(firstName, lastName)
        //    //{
        //    //    Address = address,
        //    //    AllEmails = allEmails,
        //    //    AllPhones = allPhones
        //    //};
        //}

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            initContactModification(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public void initContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}