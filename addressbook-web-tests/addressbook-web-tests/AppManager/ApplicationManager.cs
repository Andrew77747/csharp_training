using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigation;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(driver);
            navigation = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public NavigationHelper Navigation
        {
            get { return navigation; }
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

        public ContactHelper Contact
        {
            get { return contactHelper; }
        }
    }
}