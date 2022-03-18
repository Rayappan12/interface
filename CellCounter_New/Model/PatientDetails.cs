using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCounter_New.Model
{
    public class PatientDetails
    {
        public int lab_id { get; set; }
        public int patient_id { get; set; }
        public int branch_id { get; set; }
        public int patient_no { get; set; }
        public string manual_id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public object local_name { get; set; }
        public string last_name { get; set; }
        public string mobile_no { get; set; }
        public string alternate_mobile_no { get; set; }
        public string email_id { get; set; }
        public string dob { get; set; }
        public string age { get; set; }
        public object age_type { get; set; }
        public string gender { get; set; }
        public int refered_by { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string patient_come { get; set; }
        public int created_by { get; set; }
        public DateTime created_at { get; set; }
        public string status { get; set; }
        public object profile_image { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public string bp { get; set; }
        public string specimen { get; set; }
        public int points { get; set; }
        public string passport_no { get; set; }
        public object otp { get; set; }
        public int referral_hospital { get; set; }
        public int outside_lab { get; set; }
        public int rewardamount { get; set; }
        public string labnumber { get; set; }
        public DateTime updated_at { get; set; }
        public string adhar_no { get; set; }
        public object sid_no { get; set; }
        public string blood_group { get; set; }
        public string allergies { get; set; }
        public string injuries { get; set; }
        public string smoking_habits { get; set; }
        public string alcohol_consumption { get; set; }
        public object patient_nick_name { get; set; }
        public object nationality { get; set; }
        public object icmr_id { get; set; }
        public object icmr_approve_no { get; set; }
        public int isActive { get; set; }
    }

    public class Testdetail
    {
        public int bill_id { get; set; }
        public int test_id { get; set; }
        public string test_name { get; set; }
        public string department { get; set; }
        public int group_id { get; set; }
    }

    public class RootOne
    {
        public List<PatientDetails> patient_details { get; set; }
        public List<Testdetail> testdetails { get; set; }
    }
}
