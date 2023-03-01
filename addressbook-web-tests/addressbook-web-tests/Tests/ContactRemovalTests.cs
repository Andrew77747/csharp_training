using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contact.IsContactCreated())
            {
                ContactData contact = new ContactData("Иван", "Иванов");
                contact.MiddleName = "Иванович";

                app.Contact.Create(contact);
            }

            app.Contact.RemoveContact(1);
        }
    }
}