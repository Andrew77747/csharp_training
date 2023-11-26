using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> listContactsInGroup = group.GetContacts();

            if (listContactsInGroup.Count == 0)
            {
                ContactData contact = ContactData.GetAll().First();
                app.Contact.AddContactToGroup(contact, group);
                listContactsInGroup = group.GetContacts();
            }

            ContactData contactInGroup = listContactsInGroup[0];

            app.Contact.RemoveContactFromGroup(contactInGroup, group);

            List<ContactData> newListContactsInGroup = group.GetContacts();
            Assert.That(newListContactsInGroup, Has.No.Member(contactInGroup));
        }
    }
}
