using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.CreateIfNoContact(app.Contact.IsContactCreated());

            app.Contact.RemoveContact(1);
        }
    }
}