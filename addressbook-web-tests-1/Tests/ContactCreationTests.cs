using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

        //[Test]
        //public void EmptyContactCreationTest()
        //{
        //    ContactData contact = new ContactData("", "");

        //    List<ContactData> oldContacts = app.Contacts.GetContactList();

        //    app.Contacts.Create(contact);

        //    Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

        //    List<ContactData> newContacts = app.Contacts.GetContactList();
        //    oldContacts.Sort();
        //    newContacts.Sort();
        //    Assert.AreEqual(oldContacts, newContacts);
        //}

        //[Test]
        //public void BadNameContactCreationTest()
        //{
        //    ContactData contact = new ContactData("a'a", "ivanov");

        //    List<ContactData> oldContacts = app.Contacts.GetContactList();

        //    app.Contacts.Create(contact);

        //    List<ContactData> newContacts = app.Contacts.GetContactList();
        //    oldContacts.Add(contact);
        //    oldContacts.Sort();
        //    newContacts.Sort();
        //    Assert.AreEqual(oldContacts, newContacts);

        //}
    }
}
