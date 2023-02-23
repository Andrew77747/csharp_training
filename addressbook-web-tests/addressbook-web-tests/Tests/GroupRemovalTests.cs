using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigation.GoToGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.RemoveGroup();
            app.Groups.ReturnToGroupsPage();
        }
    }
}
