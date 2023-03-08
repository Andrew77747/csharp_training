using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.CreateIfNoContact();

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.RemoveContact(0);

            List<ContactData> newContacts = app.Contact.GetContactList();
            
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}