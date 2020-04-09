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

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.ContactIsPresent();

            app.Contacts.Remove(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //ContactData toBeRemoved = oldContacts[0];
            //oldContacts.RemoveAt(0);
            //Assert.AreEqual(oldContacts, newContacts);

            //foreach (ContactData contact in newContacts)
            //{
            //Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            //}
        }
    }
}