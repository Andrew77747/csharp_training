using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            app.Navigation.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigation.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("test1");
            group.Header = "test2";
            group.Footer = "test3";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();
        }
    }
}
