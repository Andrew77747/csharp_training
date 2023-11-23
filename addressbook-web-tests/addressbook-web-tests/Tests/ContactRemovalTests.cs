using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.CreateIfNoContact();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contact.RemoveContact(toBeRemoved);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}