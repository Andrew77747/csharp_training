using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Contact.CreateContactIfNotExist();
            app.Groups.CreateGroupIfNotExist();
            ContactData contact;

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            List<ContactData> contacts = ContactData.GetAll();

            if (oldList.Count == contacts.Count) 
            {
                app.Contact.Create(new ContactData("Иван", "Иванов"));
                contact = ContactData.GetAll().FirstOrDefault(i => i.Id == ContactData.MaxContactId());
            }
            else
            {
                contact = ContactData.GetAll().Except(oldList).First();
            }

            app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
