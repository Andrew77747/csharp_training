namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstName;
        private string lastName;
        private string middleName = "";

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }
    }
}
