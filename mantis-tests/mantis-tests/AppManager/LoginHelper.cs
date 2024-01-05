using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Name);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.Id("logout-link")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Id("logout-link"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                   && GetLoggedUserName() == account.Name;

        }

        public string GetLoggedUserName()
        {
            return driver.FindElement(By.Id("logged-in-user")).Text;
        }
    }
}
