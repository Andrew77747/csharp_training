﻿using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.GoToGroupsPage();
            app.Groups.CreateIfNoGroup(app.Groups.IsGroupCreated()); //todo переделать метод

            app.Groups.RemoveGroup(1);
        }
    }
}
