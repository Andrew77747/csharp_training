using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class IssueData
    {
        public string Summary { get; internal set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
