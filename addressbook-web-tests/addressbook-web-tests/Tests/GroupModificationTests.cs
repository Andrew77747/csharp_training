using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigation.GoToGroupsPage();
            if (!app.Groups.IsGroupCreated())
            {
                GroupData group = new GroupData("test1");
                group.Header = "test2";
                group.Footer = "test3";

                app.Groups.Create(group);
            }

            GroupData newData = new GroupData("newTest1");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);
        }
    }
}