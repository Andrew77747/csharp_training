using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='создать новый проект']")).Click();
        }

        public void ConfirmProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }
    }
}
