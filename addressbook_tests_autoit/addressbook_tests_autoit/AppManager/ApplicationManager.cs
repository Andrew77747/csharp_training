using AutoItX3Lib;
namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        private AutoItX3 aux;
        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run();
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {

        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        public GroupHelper Groups 
        {
            get { return groupHelper; }
        }
    }
}
