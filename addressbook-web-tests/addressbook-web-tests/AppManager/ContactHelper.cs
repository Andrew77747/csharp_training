using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigation.GoToAddContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();

            return this;
        }

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigation.GoToHomePage();
            InitContactModification(index);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();

            return this;
        }

        public ContactHelper RemoveContact(int index)
        {   
            manager.Navigation.GoToHomePage();
            SelectContact(index);
            InitRemoveContact();
            AcceptAlert();

            return this;
        }

        public ContactHelper InitRemoveContact()
        {
            driver.FindElement(By.XPath($"//input[@value='Delete']")).Click();

            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']//input[{index}]")).Click();

            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();

            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@name='submit'][1]")).Click();

            return this;
        }

        public ContactHelper FillContactForm(ContactData data)
        {

            Type(By.Name("firstname"), data.FirstName);
            Type(By.Name("middlename"), data.MiddleName);
            Type(By.Name("lastname"), data.LastName);

            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath($"//*[@title='Edit'][{index}]")).Click();

            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@name='update'][1]")).Click();

            return this;
        }

        public void CreateIfNoContact()
        {
            if (!IsElementPresent(By.Name("entry")))
            {
                ContactData contact = new ContactData("Иван", "Иванов");
                contact.MiddleName = "Иванович";

                Create(contact);
            }
        }
    }
}