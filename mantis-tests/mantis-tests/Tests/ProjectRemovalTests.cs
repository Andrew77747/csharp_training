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
            app.Project.CreateIfNoProjects();

            List<ProjectData> oldProjects = app.Project.GetProjects();
            ProjectData toBeRemoved = oldProjects[0];

            app.Project.RemoveProject(toBeRemoved);

            List<ProjectData> newProjects = app.Project.GetProjects();

            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
