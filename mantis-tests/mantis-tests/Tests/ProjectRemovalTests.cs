using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            app.API.CreateIfNoProjects(account);

            List<ProjectData> oldProjects = app.API.GetProjects(account); ;
            ProjectData toBeRemoved = oldProjects[0];

            app.Project.RemoveProject(toBeRemoved);

            List<ProjectData> newProjects = app.API.GetProjects(account);

            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
