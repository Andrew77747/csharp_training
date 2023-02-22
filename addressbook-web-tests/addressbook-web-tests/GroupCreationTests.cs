using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            navigation.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigation.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("test1");
            group.Header = "test2";
            group.Footer = "test3";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
        }
    }
}
