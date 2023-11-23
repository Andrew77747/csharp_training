using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            app.Contact.CreateIfNoContact();

            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0); 
            
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetails()
        {
            app.Contact.CreateIfNoContact();

            ContactData fromProperties = app.Contact.GetContactInformationFromPropertiesPage(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromProperties.AllProperties, fromForm.AllProperties);
        }
    }
}