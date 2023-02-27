using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact.RemoveContact(1);
        }
    }
}