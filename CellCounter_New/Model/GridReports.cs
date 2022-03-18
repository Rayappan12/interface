using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCounter_New.Model
{
    class GridReports
    {
        public class TestDetails
        {
            public string test_name { get; set; }
            public string test_result { get; set; }
        }

        public class TestDetail
        {
            public int bill_id { get; set; }
            public int test_id { get; set; }
            public string test_name { get; set; }
            public int department { get; set; }
            public int group_id { get; set; }
        }

        public class GridViewObjects
        {
            public string MSH { get; set; }
            public string MshDate { get; set; }
            public string ORU { get; set; }
            public string R01 { get; set; }
            public string PID { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string Gender { get; set; }
            public string oprator_mode { get; set; }
            public string age { get; set; }
            public string test_mode { get; set; }
            public List<TestDetail> test_details { get; set; }
        }

        public class Roots
        {
            public string barcode { get; set; }
            public List<GridViewObject> GridViewObject { get; set; }
        }
    }
}
