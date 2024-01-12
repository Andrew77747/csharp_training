using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<ProjectData> GetProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigation.GoToAddProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//*[text()='Проекты']//..//tbody//td/a"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }

            return projects;
        }

        public void Create(ProjectData project)
        {
            manager.Navigation.GoToAddProjectPage();
            InitProjectCreation();
            Type(By.Id("project-name"), project.Name);
            ConfirmProjectCreation();
        }

        public void RemoveProject(ProjectData project)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            manager.Navigation.GoToAddProjectPage();
            wait.Until(d => d.FindElements(By.LinkText(project.Name)).Count > 0);
            driver.FindElement(By.LinkText(project.Name)).Click();
            Remove();
            wait.Until(d => d.FindElements(By.ClassName("confirm-msg")).Count > 0);
            Remove();
        }

        public void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='создать новый проект']")).Click();
        }

        public void ConfirmProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public void Remove()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void CreateIfNoProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigation.GoToAddProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//*[text()='Проекты']//..//tbody//td/a"));

            if (elements.Count == 0)
            {
                ProjectData newProject = new ProjectData("Project" + TestBase.GenerateRandomString(10));

                Create(newProject);
            }
        }
    }
}
