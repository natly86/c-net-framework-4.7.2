using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        //[Test]
        //public void ContactModificationTest()
        //{
        //    ContactData newData = new ContactData("petr", "petrov");

        //    app.Contacts.ContactIsPresent();

        //    List<ContactData> oldContacts = app.Contacts.GetContactList();

        //    app.Contacts.Modify(0, newData);

        //    List<ContactData> newContacts = app.Contacts.GetContactList();
        //    oldContacts[0].Lastname = newData.Lastname;
        //    oldContacts.Sort();
        //    newContacts.Sort();
        //    Assert.AreEqual(oldContacts, newContacts);
        //}

        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("petr", "petrov");

            app.Contacts.ContactIsPresent();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModifyed = oldContacts[0];

            app.Contacts.ModifyById(toBeModifyed, newData);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreEqual(contact.Id, toBeModifyed.Id);
            }
        }
    }
}
