using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            manager.Navigation.GoToHomePage();
            InitContactModification(contact.Id);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();

            return this;
        }

        public ContactHelper RemoveContact(ContactData contact)
        {   
            manager.Navigation.GoToHomePage();
            SelectContact(contact.Id);
            InitRemoveContact();;
            AcceptAlert();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

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

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath($"//input[@name='selected[]' and @value='{id}']")).Click();

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
            Type(By.Name("address"), data.Address);
            Type(By.Name("home"), data.HomePhone);
            Type(By.Name("mobile"), data.MobilePhone);
            Type(By.Name("work"), data.WorkPhone);
            Type(By.Name("email"), data.Email);
            Type(By.Name("email2"), data.Email2);
            Type(By.Name("email3"), data.Email3);

            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            //driver.FindElement(By.XPath($"//*[@title='Edit'][{index + 1}]")).Click();

            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();

            return this;
        }

        public ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath($"//input[@name='selected[]' and @value='{id}']//..//../td[8]/a")).Click();

            return this;
        }

        public ContactHelper ShowContactProperties(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();

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
                contact.Address = "ул. Мира 5";
                contact.HomePhone = "+7812-255-555-55";
                contact.MobilePhone = "+7 (921) 333 33 33";
                contact.WorkPhone = "8 800 500 50 50";
                contact.Email = "test@mail.ru";
                contact.Email2 = "test2@mail.ru";
                contact.Email3 = "test3@mail.ru";

                Create(contact);
            }
        }

        public void CreateContactIfNotExist()
        {
            List<ContactData> contacts = ContactData.GetAll();
            if (contacts.Count == 0)
            {
                ContactData contact = new ContactData("Иван", "Иванов");
                contact.MiddleName = "Иванович";
                contact.Address = "ул. Мира 5";
                contact.HomePhone = "+7812-255-555-55";
                contact.MobilePhone = "+7 (921) 333 33 33";
                contact.WorkPhone = "8 800 500 50 50";
                contact.Email = "test@mail.ru";
                contact.Email2 = "test2@mail.ru";
                contact.Email3 = "test3@mail.ru";

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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigation.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromPropertiesPage(int index)
        {
            manager.Navigation.GoToHomePage();
            ShowContactProperties(index);

            string allProperties = driver.FindElement(By.Id("content")).Text;

            return new ContactData
            {
                AllProperties = allProperties
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigation.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                MiddleName = middleName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigation.GoToAddContactPage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.GoToHomePage();
            ClearGroupFilter();
            SelectContactById(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.GoToHomePage();
            SelectGroupToRemove(group.Name);
            SelectContactById(contact.Id);
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void SelectGroupToRemove(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        private void SelectContactById(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
    }
}