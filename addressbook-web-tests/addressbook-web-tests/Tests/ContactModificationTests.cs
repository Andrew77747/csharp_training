using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contact.CreateIfNoContact();

            ContactData newContactData = new ContactData("Сергей", "Сергеев");
            newContactData.MiddleName = "Сергеевич";

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(0, newContactData);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts[0] = newContactData;

            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts[0].LastName = newContactData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}