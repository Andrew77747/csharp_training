using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigation.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            //ReturnToGroupsPage(); todo нужен ли этот метод здесь

            return this;
        }

        public GroupHelper Modify(int index, GroupData newData)
        {
            manager.Navigation.GoToGroupsPage();
            CreateIfNoGroup();
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper RemoveGroup(int index)
        {
            manager.Navigation.GoToGroupsPage();
            CreateIfNoGroup();
            SelectGroup(index);
            InitRemoveGroup();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper InitRemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();

            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            index++;    
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();

            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();

            return this;
        }

        public GroupHelper FillGroupForm(GroupData data)
        {
            Type(By.Name("group_name"), data.Name);
            Type(By.Name("group_header"), data.Header);
            Type(By.Name("group_footer"), data.Footer);

            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();

            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();

            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();

            return this;
        }

        public bool IsGroupCreated()
        {
            return IsElementPresent(By.ClassName("group"));
        }

        public void CreateIfNoGroup()
        {
            if (!IsGroupCreated())
            {
                GroupData group = new GroupData("test1");
                group.Header = "test2";
                group.Footer = "test3";

                Create(group);
            }
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigation.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;
        }
    }
}