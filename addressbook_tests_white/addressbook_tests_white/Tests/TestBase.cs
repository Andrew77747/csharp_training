using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class TestBase
    {
        public ApplicationManager app;

        [TestFixtureSetUp]
        public void InitApplication()
        {
            app = new ApplicationManager();
        }

        [TestFixtureTearDown]
        public void StopApplication()
        {
            app.Stop();
        }
    }
}
