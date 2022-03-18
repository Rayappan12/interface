using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCounter_New.Model
{
    public class JsonToObject
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class MSH3
        {
            [JsonProperty("HD.1")]
            public string HD1 { get; set; }
        }

        public class MSH4
        {
            [JsonProperty("HD.1")]
            public string HD1 { get; set; }
        }

        public class MSH5
        {
            [JsonProperty("HD.1")]
            public string HD1 { get; set; }
        }

        public class MSH6
        {
            [JsonProperty("HD.1")]
            public string HD1 { get; set; }
        }

        public class MSH7
        {
            [JsonProperty("TS.1")]
            public string TS1 { get; set; }
        }

        public class MSH9
        {
            [JsonProperty("MSG.1")]
            public string MSG1 { get; set; }

            [JsonProperty("MSG.2")]
            public string MSG2 { get; set; }
        }

        public class MSH11
        {
            [JsonProperty("PT.1")]
            public string PT1 { get; set; }
        }

        public class MSH12
        {
            [JsonProperty("VID.1")]
            public string VID1 { get; set; }
        }

        public class MSH
        {
            [JsonProperty("MSH.1")]
            public string MSH1 { get; set; }

            [JsonProperty("MSH.2")]
            public string MSH2 { get; set; }

            [JsonProperty("MSH.3")]
            public MSH3 MSH3 { get; set; }

            [JsonProperty("MSH.4")]
            public MSH4 MSH4 { get; set; }

            [JsonProperty("MSH.5")]
            public MSH5 MSH5 { get; set; }

            [JsonProperty("MSH.6")]
            public MSH6 MSH6 { get; set; }

            [JsonProperty("MSH.7")]
            public MSH7 MSH7 { get; set; }

            [JsonProperty("MSH.9")]
            public MSH9 MSH9 { get; set; }

            [JsonProperty("MSH.10")]
            public string MSH10 { get; set; }

            [JsonProperty("MSH.11")]
            public MSH11 MSH11 { get; set; }

            [JsonProperty("MSH.12")]
            public MSH12 MSH12 { get; set; }

            [JsonProperty("MSH.13")]
            public string MSH13 { get; set; }

            [JsonProperty("MSH.14")]
            public string MSH14 { get; set; }

            [JsonProperty("MSH.15")]
            public string MSH15 { get; set; }

            [JsonProperty("MSH.16")]
            public string MSH16 { get; set; }

            [JsonProperty("MSH.17")]
            public string MSH17 { get; set; }

            [JsonProperty("MSH.18")]
            public string MSH18 { get; set; }
        }

        public class CX4
        {
            [JsonProperty("HD.1")]
            public string HD1 { get; set; }
        }

        public class PID3
        {
            [JsonProperty("CX.1")]
            public string CX1 { get; set; }

            [JsonProperty("CX.2")]
            public string CX2 { get; set; }

            [JsonProperty("CX.3")]
            public string CX3 { get; set; }

            [JsonProperty("CX.4")]
            public CX4 CX4 { get; set; }

            [JsonProperty("CX.5")]
            public string CX5 { get; set; }
        }

        public class PID4
        {
            [JsonProperty("CX.1")]
            public string CX1 { get; set; }
        }

        public class PID5
        {
            [JsonProperty("XPN.2")]
            public string XPN2 { get; set; }
        }

        public class XPN1
        {
            [JsonProperty("FN.1")]
            public string FN1 { get; set; }
        }

        public class PID6
        {
            [JsonProperty("XPN.1")]
            public XPN1 XPN1 { get; set; }
        }

        public class PID7
        {
            [JsonProperty("TS.1")]
            public string TS1 { get; set; }
        }

        public class PID
        {
            [JsonProperty("PID.1")]
            public string PID1 { get; set; }

            [JsonProperty("PID.3")]
            public PID3 PID3 { get; set; }

            [JsonProperty("PID.4")]
            public PID4 PID4 { get; set; }

            [JsonProperty("PID.5")]
            public PID5 PID5 { get; set; }

            [JsonProperty("PID.6")]
            public PID6 PID6 { get; set; }

            [JsonProperty("PID.7")]
            public PID7 PID7 { get; set; }

            [JsonProperty("PID.8")]
            public string PID8 { get; set; }
        }

        public class PV1
        {
            [JsonProperty("PV1.1")]
            public string PV11 { get; set; }
        }

        public class ORUR01VISIT
        {
            public PV1 PV1 { get; set; }
        }

        public class ORUR01PATIENT
        {
            public PID PID { get; set; }

            [JsonProperty("ORU_R01.VISIT")]
            public ORUR01VISIT ORUR01VISIT { get; set; }
        }

        public class OBR3
        {
            [JsonProperty("EI.1")]
            public string EI1 { get; set; }
        }

        public class OBR4
        {
            [JsonProperty("CE.1")]
            public string CE1 { get; set; }

            [JsonProperty("CE.2")]
            public string CE2 { get; set; }

            [JsonProperty("CE.3")]
            public string CE3 { get; set; }
        }

        public class OBR7
        {
            [JsonProperty("TS.1")]
            public string TS1 { get; set; }
        }

        public class NDL1
        {
            [JsonProperty("CN.1")]
            public string CN1 { get; set; }
        }

        public class OBR32
        {
            [JsonProperty("NDL.1")]
            public NDL1 NDL1 { get; set; }
        }

        public class OBR
        {
            [JsonProperty("OBR.1")]
            public string OBR1 { get; set; }

            [JsonProperty("OBR.3")]
            public OBR3 OBR3 { get; set; }

            [JsonProperty("OBR.4")]
            public OBR4 OBR4 { get; set; }

            [JsonProperty("OBR.7")]
            public OBR7 OBR7 { get; set; }

            [JsonProperty("OBR.24")]
            public string OBR24 { get; set; }

            [JsonProperty("OBR.32")]
            public OBR32 OBR32 { get; set; }
        }

        public class OBX3
        {
            [JsonProperty("CE.1")]
            public string CE1 { get; set; }

            [JsonProperty("CE.2")]
            public string CE2 { get; set; }

            [JsonProperty("CE.3")]
            public string CE3 { get; set; }
        }

        public class OBX6
        {
            [JsonProperty("CE.1")]
            public string CE1 { get; set; }
        }

        public class OBX
        {
            [JsonProperty("OBX.1")]
            public string OBX1 { get; set; }

            [JsonProperty("OBX.2")]
            public string OBX2 { get; set; }

            [JsonProperty("OBX.3")]
            public OBX3 OBX3 { get; set; }

            [JsonProperty("OBX.5")]
            public string OBX5 { get; set; }

            [JsonProperty("OBX.11")]
            public string OBX11 { get; set; }

            [JsonProperty("OBX.6")]
            public OBX6 OBX6 { get; set; }

            [JsonProperty("OBX.7")]
            public string OBX7 { get; set; }

            [JsonProperty("OBX.8")]
            public object OBX8 { get; set; }
        }

        public class ORUR01OBSERVATION
        {
            public OBX OBX { get; set; }
        }

        public class ORUR01ORDEROBSERVATION
        {
            public OBR OBR { get; set; }

            [JsonProperty("ORU_R01.OBSERVATION")]
            public List<ORUR01OBSERVATION> ORUR01OBSERVATION { get; set; }
        }

        public class ORUR01PATIENTRESULT
        {
            [JsonProperty("ORU_R01.PATIENT")]
            public ORUR01PATIENT ORUR01PATIENT { get; set; }

            [JsonProperty("ORU_R01.ORDER_OBSERVATION")]
            public ORUR01ORDEROBSERVATION ORUR01ORDEROBSERVATION { get; set; }
        }

        public class ORUR01
        {
            [JsonProperty("@xmlns")]
            public string Xmlns { get; set; }
            public MSH MSH { get; set; }

            [JsonProperty("ORU_R01.PATIENT_RESULT")]
            public ORUR01PATIENTRESULT ORUR01PATIENTRESULT { get; set; }
        }

        public class Root
        {
            public ORUR01 ORU_R01 { get; set; }
        }


    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class GridViewObject
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

        public List<TestValues> test_details { get; set; }
    }

    public class TestValues
    {
        public string test_name { get; set; }

        public string test_result { get; set; }
    }

    public class TestGridDetails
    {
        public string barcode { get; set; }
        public List<GridViewObject> GridViewObject { get; set; }
    }
}



