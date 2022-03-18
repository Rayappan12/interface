using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCounter_New.Model
{
    public class PatientTestFieldList
    {
        public int id { get; set; }
        public int lab_id { get; set; }
        public int test_id { get; set; }
        public string test_short_name { get; set; }
        public string test_full_name { get; set; }
        public int field_id { get; set; }
        public string field_name { get; set; }
        public int department_id { get; set; }
        public int group_id { get; set; }
        public int branch_id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string units { get; set; }
        public string default_range { get; set; }
        public string min_range { get; set; }
        public string max_range { get; set; }
        public string isAgeSpecific { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string content_freeze { get; set; }
        public string status { get; set; }
        public int created_by { get; set; }
        public int? updated_by { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int input_type { get; set; }
        public int value_input_type { get; set; }
        public object six_header_title1 { get; set; }
        public object six_header_title2 { get; set; }
        public object six_header_title3 { get; set; }
        public object six_header_title4 { get; set; }
        public object six_header_title5 { get; set; }
        public object six_header_title6 { get; set; }
        public string formula { get; set; }
        public string optional { get; set; }
        public int isActive { get; set; }
        public string work_list { get; set; }
        public DateTime testDate { get; set; }
        public double testResult { get; set; }
        public string testUnit { get; set; }

    }
    public class Status
    {
        public string status { get; set; }
    }
}
