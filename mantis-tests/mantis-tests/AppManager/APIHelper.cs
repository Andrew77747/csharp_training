using System.Collections.Generic;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjects(AccountData account)
        {
            List<ProjectData> projects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            var mantisProjects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            foreach (var project in mantisProjects)
            {
                projects.Add(new ProjectData(project.name));
            }

            return projects;
        }

        public void CreateIfNoProjects(AccountData account)
        {
            var mantisProjects = GetProjects(account);

            if (mantisProjects.Count == 0)
            {
                ProjectData project = new ProjectData("Project" + TestBase.GenerateRandomString(10));
                CreateProject(account, project);
            }
        }

        public void CreateProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.name = project.Name;
            client.mc_project_add(account.Name, account.Password, projectData);
        }
    }
}
