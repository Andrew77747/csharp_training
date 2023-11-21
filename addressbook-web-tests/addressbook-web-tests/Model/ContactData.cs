using LinqToDB.Mapping;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allProperties;
        private string allPhonesFromDetailsPage;

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return FirstName == other.FirstName
                   && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int resultCompare = LastName.CompareTo(other.LastName);
            return resultCompare != 0 ? resultCompare : FirstName.CompareTo(other.FirstName);
        }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllPhonesFromDetailsPage
        {
            get
            {
                if (allPhonesFromDetailsPage != null)
                {
                    return allPhonesFromDetailsPage;
                }
                else
                {
                    if (string.IsNullOrEmpty(HomePhone)
                        && string.IsNullOrEmpty(MobilePhone)
                        && string.IsNullOrEmpty(WorkPhone))
                    {
                        return "";
                    }
                    return (SetHomePhone(HomePhone) + SetMobilePhone(MobilePhone) + SetWorkPhone(WorkPhone)) + "\r\n";
                }
            }
            set
            {
                allPhonesFromDetailsPage = value;
            }
        }

        public string AllProperties
        {
            get
            {
                if (allProperties != null)
                {
                    return allProperties;
                }
                else
                {
                    return ((SetName(FirstName) + SetName(MiddleName) + SetName(LastName)).Trim() + "\r\n"
                            + SetProperty(Address) + "\r\n"
                            + AllPhonesFromDetailsPage
                            + SetProperty(Email) + SetProperty(Email2) + SetProperty(Email3)).Trim();
                }
            }
            set
            {
                allProperties = value;
            }
        }

        private string SetHomePhone(string homePhone)
        {
            if (string.IsNullOrEmpty(homePhone))
            {
                return "";
            }

            return "H: " + homePhone + "\r\n";
        }

        private string SetMobilePhone(string mobilePhone)
        {
            if (string.IsNullOrEmpty(mobilePhone))
            {
                return "";
            }

            return "M: " + mobilePhone + "\r\n";
        }

        private string SetWorkPhone(string workPhone)
        {
            if (string.IsNullOrEmpty(workPhone))
            {
                return "";
            }

            return "W: " + workPhone + "\r\n";
        }

        private string SetProperty(string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return "";
            }

            return property + "\r\n";
        }

        private string SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }

            return name + " ";
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n";
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
