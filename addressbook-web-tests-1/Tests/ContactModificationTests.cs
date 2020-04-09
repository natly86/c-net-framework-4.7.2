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
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("petr", "petrov");

           List<ContactData> oldContacts = app.Contacts.GetContactList();
           ContactData oldData = oldContacts[0];

            app.Contacts.ContactIsPresent();

            app.Contacts.Modify(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //foreach (ContactData contact in newContacts)
            //{
            //    if (contact.Id == oldData.Id)
            //    {
            //        Assert.AreEqual(newData.Firstname, contact.Firstname);
            //   }
            //}
        }
    }
}
