using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        private string baseURL;
        private string addProjectUrl = "/manage_proj_page.php";

        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToAddProjectPage()
        {
            if (driver.Url == baseURL + addProjectUrl)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + addProjectUrl);
        }
    }
}
