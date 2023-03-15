using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']//input[{index + 1}]")).Click();

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
            contactCache = null;
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
            driver.FindElement(By.XPath($"//*[@title='Edit'][{index + 1}]")).Click();

            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@name='update'][1]")).Click();
            contactCache = null;
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

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigation.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElement(By.CssSelector("td:nth-child(3)")).Text,
                        element.FindElement(By.CssSelector("td:nth-child(2)")).Text));
                }
            }

            return new List<ContactData>(contactCache);
        }
    }
}