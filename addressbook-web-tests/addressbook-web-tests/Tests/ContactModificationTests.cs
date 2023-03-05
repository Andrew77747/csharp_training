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

            app.Contact.Modify(1, newContactData);
        }
    }
}