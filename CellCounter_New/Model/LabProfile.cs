using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCounter_New.Model
{
    public class LabProfile
    {
        public int id { get; set; }
        public int sid { get; set; }
        public int uid { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string mobile_no { get; set; }
        public string landline_no { get; set; }
        public string register_id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pincode { get; set; }
        public string branch { get; set; }
        public string header { get; set; }
        public string footer { get; set; }
        public string lab_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string patient_photo_need { get; set; }
        public string barcode { get; set; }
        public string plan { get; set; }
        public string expired_date { get; set; }
        public string bill_begins { get; set; }
        public string default_payment_mode { get; set; }
        public string reg_type { get; set; }
        public string page_border { get; set; }
        public string field_border { get; set; }
        public int font_size { get; set; }
        public int cell_padding { get; set; }
        public string prefix_need { get; set; }
        public string prefix { get; set; }
        public string reason { get; set; }
        public string whatsapp { get; set; }
        public string email { get; set; }
        public object whatsapp_link { get; set; }
        public object whatsapp_token { get; set; }
        public string page_no { get; set; }
        public string outside_report { get; set; }
        public string cutoff_page { get; set; }
        public int weight_need { get; set; }
        public int height_need { get; set; }
        public int bp_need { get; set; }
        public int specimen { get; set; }
        public int reportColumnCount { get; set; }
        public string rangeDisplayText { get; set; }
        public double points { get; set; }
        public int patient_id_from { get; set; }
        public string outside_lab { get; set; }
        public string font_style { get; set; }
        public string reference_need { get; set; }
        public string plno_need { get; set; }
        public string appointment { get; set; }
        public string consolidate_approve { get; set; }
        public string admin_sign { get; set; }
        public string doctor_sign { get; set; }
    }

    public class Root
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public LabProfile lab_profile { get; set; }
        public int expires_in { get; set; }
    }
}
