using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contact.IsContactCreated())
            {
                ContactData contact = new ContactData("Иван", "Иванов");
                contact.MiddleName = "Иванович";

                app.Contact.Create(contact);
            }

            ContactData newContactData = new ContactData("Сергей", "Сергеев");
            newContactData.MiddleName = "Сергеевич";

            app.Contact.Modify(1, newContactData);
        }
    }
}