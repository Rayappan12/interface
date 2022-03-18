using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCounter_New.Model
{
    public class MachineReport
    {
        public string name { get; set; }
        public string barcode { get; set; }
    }
    public class SampleBarcode
    {
        public string PatientName { get; set; }
        public string Barcode { get; set; }
    }
}
