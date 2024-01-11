using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldProjects = app.Project.GetProjects();
            ProjectData newProject = new ProjectData("Project" + TestBase.GenerateRandomString(10));

            app.Project.Create(newProject);

            List<ProjectData> newProjects = app.Project.GetProjects();
            oldProjects.Add(newProject);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
