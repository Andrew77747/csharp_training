using addressbook_web_tests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            navigation.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.GoToAddContactPage();
            ContactData contact = new ContactData("Иван", "Иванов");
            contact.MiddleName = "Иванович";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreation();
            contactHelper.ReturnToHomePage();
        }
    }
}
