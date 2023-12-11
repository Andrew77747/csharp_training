using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            Application app = Application.Launch(@"C:\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);


            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

        public Window MainWindow { get; private set; }

        public GroupHelper Groups 
        {
            get { return groupHelper; }
        }
    }
}
