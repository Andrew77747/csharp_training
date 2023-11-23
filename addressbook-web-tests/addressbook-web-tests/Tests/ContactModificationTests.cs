using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contact.CreateIfNoContact();

            ContactData newContactData = new ContactData("Сергей", "Сергеев");
            newContactData.MiddleName = "Сергеевич";

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModificated = oldContacts[0];

            app.Contact.Modify(toBeModificated, newContactData);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[0] = newContactData;
            oldContacts[0].FirstName = newContactData.FirstName;
            oldContacts[0].LastName = newContactData.LastName;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}