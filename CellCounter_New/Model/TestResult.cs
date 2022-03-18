using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCounter_New.Model
{
   public class TestResult
    {
        public class CellCounterRecordCreate
        {
            public string bill_id { get; set; }
            public string test_id { get; set; }
            public string patient_id { get; set; }
            public string department_id { get; set; }
            public string group_id { get; set; }
            public List<CCTestRecord> test_result { get; set; }
        }
        public class CellCounterTestResults
        {
            public string test_id { get; set; }
            public string test_name { get; set; }
            public string test_short_name { get; set; }
            public string test_value { get; set; }
        }
        public class CCTestRecord
        {
            public string test_id { get; set; }
            public string test_name { get; set; }
            public string test_short_name { get; set; }
            public string test_value { get; set; }
        }
    }
}
