using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Иван", "Иванов");
            contact.MiddleName = "Иванович";

            app.Contact.Create(contact);
        }
    }
}
