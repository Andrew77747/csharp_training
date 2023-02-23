using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigation.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.GoToAddContactPage();
            ContactData contact = new ContactData("Иван", "Иванов");
            contact.MiddleName = "Иванович";
            app.Contact.FillContactForm(contact);
            app.Contact.SubmitContactCreation();
            app.Contact.ReturnToHomePage();
        }
    }
}
