using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(IWebDriver driver) : base(driver)
        {

        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@name='submit'][1]")).Click();
        }

        public void FillContactForm(ContactData data)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(data.FirstName);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(data.MiddleName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(data.LastName);
        }

        public void GoToAddContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}