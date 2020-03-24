using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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
            //Logout();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            ContactIsPresent();
            SelectContact(p);
            RemoveContact();
            Logout();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            ContactIsPresent();
            InitContactModification();
            EditContactForm(newData);
            Logout();
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
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            driver.SwitchTo().Alert().Accept();
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
            return this;
        }

        public void ContactIsPresent()
        {
            if (IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
                return;
            }

            ContactData contact = new ContactData("ivan");
            contact.Lastname = "ivanov";
            Create(contact);

            manager.Navigator.GoToHomePage();
        }
    }
}
