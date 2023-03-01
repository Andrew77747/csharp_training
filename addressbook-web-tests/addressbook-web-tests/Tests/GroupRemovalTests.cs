using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.GoToGroupsPage();
            if (!app.Groups.IsGroupCreated())
            {
                GroupData group = new GroupData("test1");
                group.Header = "test2";
                group.Footer = "test3";

                app.Groups.Create(group);
            }

            app.Groups.RemoveGroup(1);
        }
    }
}
