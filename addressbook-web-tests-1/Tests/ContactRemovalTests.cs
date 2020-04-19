using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        //[Test]
        //public void ContactRemovalTest()
        //{
        //    app.Contacts.ContactIsPresent();

        //    List<ContactData> oldContacts = app.Contacts.GetContactList();

        //    app.Contacts.Remove(0);

        //    Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

        //    List<ContactData> newContacts = app.Contacts.GetContactList();

        //    oldContacts.RemoveAt(0);
        //    oldContacts.Sort();
        //    newContacts.Sort();
        //    Assert.AreEqual(oldContacts, newContacts);
        //}

        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.ContactIsPresent();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.RemoveById(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}