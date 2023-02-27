using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("newTest1");
            newData.Header = "newTest2";
            newData.Footer = "newTest3";

            app.Groups.Modify(1, newData);
        }
    }
}