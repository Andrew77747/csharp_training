using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigation.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        //[TearDown]
        //public void StopApplicationManager()
        //{
        //    ApplicationManager.GetInstance().Stop();
        //}
    }
}