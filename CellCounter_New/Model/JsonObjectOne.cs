using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CellCounter_New.Model
{
    public class XmlToObject
    {        
        [XmlRoot(ElementName = "MSH.7")]
        public class MSH7
        {
            [XmlElement(ElementName = "TS.1")]
            public double TS1 { get; set; }
        }

        [XmlRoot(ElementName = "MSH.9")]
        public class MSH9
        {
            [XmlElement(ElementName = "MSG.1")]
            public string MSG1 { get; set; }

            [XmlElement(ElementName = "MSG.2")]
            public string MSG2 { get; set; }
        }

        [XmlRoot(ElementName = "MSH.11")]
        public class MSH11
        {

            [XmlElement(ElementName = "PT.1")]
            public string PT1 { get; set; }
        }

        [XmlRoot(ElementName = "MSH.12")]
        public class MSH12
        {

            [XmlElement(ElementName = "VID.1")]
            public DateTime VID1 { get; set; }
        }

        [XmlRoot(ElementName = "MSH")]
        public class MSH
        {
            [XmlElement(ElementName = "MSH.1")]
            public string MSH1 { get; set; }

            [XmlElement(ElementName = "MSH.2")]
            public string MSH2 { get; set; }

            [XmlElement(ElementName = "MSH.7")]
            public MSH7 MSH7 { get; set; }

            [XmlElement(ElementName = "MSH.9")]
            public MSH9 MSH9 { get; set; }

            [XmlElement(ElementName = "MSH.10")]
            public int MSH10 { get; set; }

            [XmlElement(ElementName = "MSH.11")]
            public MSH11 MSH11 { get; set; }

            [XmlElement(ElementName = "MSH.12")]
            public MSH12 MSH12 { get; set; }

            [XmlElement(ElementName = "MSH.18")]
            public string MSH18 { get; set; }
        }

        [XmlRoot(ElementName = "PID.3")]
        public class PID3
        {

            [XmlElement(ElementName = "CX.5")]
            public string CX5 { get; set; }
        }

        [XmlRoot(ElementName = "PID.5")]
        public class PID5
        {

            [XmlElement(ElementName = "XPN.2")]
            public string XPN2 { get; set; }
        }

        [XmlRoot(ElementName = "PID")]
        public class PID
        {

            [XmlElement(ElementName = "PID.1")]
            public int PID1 { get; set; }

            [XmlElement(ElementName = "PID.3")]
            public PID3 PID3 { get; set; }

            [XmlElement(ElementName = "PID.5")]
            public PID5 PID5 { get; set; }
        }

        [XmlRoot(ElementName = "PV1")]
        public class PV1
        {

            [XmlElement(ElementName = "PV1.1")]
            public int PV11 { get; set; }
        }

        [XmlRoot(ElementName = "ORU_R01.VISIT")]
        public class ORUR01VISIT
        {

            [XmlElement(ElementName = "PV1")]
            public PV1 PV1 { get; set; }
        }

        [XmlRoot(ElementName = "ORU_R01.PATIENT")]
        public class ORUR01PATIENT
        {

            [XmlElement(ElementName = "PID")]
            public PID PID { get; set; }

            [XmlElement(ElementName = "ORU_R01.VISIT")]
            public ORUR01VISIT ORUR01VISIT { get; set; }
        }

        [XmlRoot(ElementName = "OBR.3")]
        public class OBR3
        {

            [XmlElement(ElementName = "EI.1")]
            public int EI1 { get; set; }
        }

        [XmlRoot(ElementName = "OBR.4")]
        public class OBR4
        {

            [XmlElement(ElementName = "CE.1")]
            public int CE1 { get; set; }

            [XmlElement(ElementName = "CE.2")]
            public string CE2 { get; set; }

            [XmlElement(ElementName = "CE.3")]
            public string CE3 { get; set; }
        }

        [XmlRoot(ElementName = "OBR.7")]
        public class OBR7
        {

            [XmlElement(ElementName = "TS.1")]
            public double TS1 { get; set; }
        }

        [XmlRoot(ElementName = "NDL.1")]
        public class NDL1
        {

            [XmlElement(ElementName = "CN.1")]
            public string CN1 { get; set; }
        }

        [XmlRoot(ElementName = "OBR.32")]
        public class OBR32
        {

            [XmlElement(ElementName = "NDL.1")]
            public NDL1 NDL1 { get; set; }
        }

        [XmlRoot(ElementName = "OBR")]
        public class OBR
        {

            [XmlElement(ElementName = "OBR.1")]
            public int OBR1 { get; set; }

            [XmlElement(ElementName = "OBR.3")]
            public OBR3 OBR3 { get; set; }

            [XmlElement(ElementName = "OBR.4")]
            public OBR4 OBR4 { get; set; }

            [XmlElement(ElementName = "OBR.7")]
            public OBR7 OBR7 { get; set; }

            [XmlElement(ElementName = "OBR.24")]
            public string OBR24 { get; set; }

            [XmlElement(ElementName = "OBR.32")]
            public OBR32 OBR32 { get; set; }
        }

        [XmlRoot(ElementName = "OBX.3")]
        public class OBX3
        {

            [XmlElement(ElementName = "CE.1")]
            public int CE1 { get; set; }

            [XmlElement(ElementName = "CE.2")]
            public string CE2 { get; set; }

            [XmlElement(ElementName = "CE.3")]
            public string CE3 { get; set; }
        }

        [XmlRoot(ElementName = "OBX")]
        public class OBX
        {

            [XmlElement(ElementName = "OBX.8")]
            public List<string> OBX8 { get; set; }

            [XmlElement(ElementName = "OBX.11")]
            public string OBX11 { get; set; }

            [XmlElement(ElementName = "OBX.1")]
            public int OBX1 { get; set; }

            [XmlElement(ElementName = "OBX.2")]
            public string OBX2 { get; set; }

            [XmlElement(ElementName = "OBX.3")]
            public OBX3 OBX3 { get; set; }

            [XmlElement(ElementName = "OBX.5")]
            public double OBX5 { get; set; }

            [XmlElement(ElementName = "OBX.6")]
            public OBX6 OBX6 { get; set; }

            [XmlElement(ElementName = "OBX.7")]
            public string OBX7 { get; set; }
        }

        [XmlRoot(ElementName = "ORU_R01.OBSERVATION")]
        public class ORUR01OBSERVATION
        {

            [XmlElement(ElementName = "OBX")]
            public OBX OBX { get; set; }
        }

        [XmlRoot(ElementName = "OBX.6")]
        public class OBX6
        {

            [XmlElement(ElementName = "CE.1")]
            public string CE1 { get; set; }
        }

        [XmlRoot(ElementName = "ORU_R01.ORDER_OBSERVATION")]
        public class ORUR01ORDEROBSERVATION
        {

            [XmlElement(ElementName = "OBR")]
            public OBR OBR { get; set; }

            [XmlElement(ElementName = "ORU_R01.OBSERVATION")]
            public List<ORUR01OBSERVATION> ORUR01OBSERVATION { get; set; }
        }

        [XmlRoot(ElementName = "ORU_R01.PATIENT_RESULT")]
        public class ORUR01PATIENTRESULT
        {

            [XmlElement(ElementName = "ORU_R01.PATIENT")]
            public ORUR01PATIENT ORUR01PATIENT { get; set; }

            [XmlElement(ElementName = "ORU_R01.ORDER_OBSERVATION")]
            public ORUR01ORDEROBSERVATION ORUR01ORDEROBSERVATION { get; set; }
        }

        [XmlRoot(ElementName = "ORU_R01")]
        public class ORUR01
        {

            [XmlElement(ElementName = "MSH")]
            public MSH MSH { get; set; }

            [XmlElement(ElementName = "ORU_R01.PATIENT_RESULT")]
            public ORUR01PATIENTRESULT ORUR01PATIENTRESULT { get; set; }

            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }

            [XmlText]
            public string Text { get; set; }
        }


    }
    public class JsonObjectOne
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class MSH8
        {
            [JsonProperty("MSH.8.0")]
            public string MSH80 { get; set; }

            [JsonProperty("MSH.8.1")]
            public string MSH81 { get; set; }
        }

        public class MSH
        {
            [JsonProperty("MSH.0")]
            public string MSH0 { get; set; }

            [JsonProperty("MSH.1")]
            public string MSH1 { get; set; }

            [JsonProperty("MSH.2")]
            public string MSH2 { get; set; }

            [JsonProperty("MSH.3")]
            public string MSH3 { get; set; }

            [JsonProperty("MSH.4")]
            public string MSH4 { get; set; }

            [JsonProperty("MSH.5")]
            public string MSH5 { get; set; }

            [JsonProperty("MSH.6")]
            public string MSH6 { get; set; }

            [JsonProperty("MSH.7")]
            public string MSH7 { get; set; }

            [JsonProperty("MSH.8")]
            public MSH8 MSH8 { get; set; }

            [JsonProperty("MSH.9")]
            public string MSH9 { get; set; }

            [JsonProperty("MSH.10")]
            public string MSH10 { get; set; }

            [JsonProperty("MSH.11")]
            public string MSH11 { get; set; }

            [JsonProperty("MSH.12")]
            public string MSH12 { get; set; }

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
        }

        public class PID3
        {
            [JsonProperty("PID.3.0")]
            public string PID30 { get; set; }

            [JsonProperty("PID.3.1")]
            public string PID31 { get; set; }

            [JsonProperty("PID.3.2")]
            public string PID32 { get; set; }

            [JsonProperty("PID.3.3")]
            public string PID33 { get; set; }

            [JsonProperty("PID.3.4")]
            public string PID34 { get; set; }
        }

        public class PID
        {
            [JsonProperty("PID.0")]
            public string PID0 { get; set; }

            [JsonProperty("PID.1")]
            public string PID1 { get; set; }

            [JsonProperty("PID.2")]
            public string PID2 { get; set; }

            [JsonProperty("PID.3")]
            public PID3 PID3 { get; set; }

            [JsonProperty("PID.4")]
            public string PID4 { get; set; }

            [JsonProperty("PID.5")]
            public string PID5 { get; set; }
        }

        public class PV1
        {
            [JsonProperty("PV1.0")]
            public string PV10 { get; set; }

            [JsonProperty("PV1.1")]
            public string PV11 { get; set; }
        }

        public class OBR4
        {
            [JsonProperty("OBR.4.0")]
            public string OBR40 { get; set; }

            [JsonProperty("OBR.4.1")]
            public string OBR41 { get; set; }

            [JsonProperty("OBR.4.2")]
            public string OBR42 { get; set; }
        }

        public class OBR
        {
            [JsonProperty("OBR.0")]
            public string OBR0 { get; set; }

            [JsonProperty("OBR.1")]
            public string OBR1 { get; set; }

            [JsonProperty("OBR.2")]
            public string OBR2 { get; set; }

            [JsonProperty("OBR.3")]
            public string OBR3 { get; set; }

            [JsonProperty("OBR.4")]
            public OBR4 OBR4 { get; set; }

            [JsonProperty("OBR.5")]
            public string OBR5 { get; set; }

            [JsonProperty("OBR.6")]
            public string OBR6 { get; set; }

            [JsonProperty("OBR.7")]
            public string OBR7 { get; set; }

            [JsonProperty("OBR.8")]
            public string OBR8 { get; set; }

            [JsonProperty("OBR.9")]
            public string OBR9 { get; set; }

            [JsonProperty("OBR.10")]
            public string OBR10 { get; set; }

            [JsonProperty("OBR.11")]
            public string OBR11 { get; set; }

            [JsonProperty("OBR.12")]
            public string OBR12 { get; set; }

            [JsonProperty("OBR.13")]
            public string OBR13 { get; set; }

            [JsonProperty("OBR.14")]
            public string OBR14 { get; set; }

            [JsonProperty("OBR.15")]
            public string OBR15 { get; set; }

            [JsonProperty("OBR.16")]
            public string OBR16 { get; set; }

            [JsonProperty("OBR.17")]
            public string OBR17 { get; set; }

            [JsonProperty("OBR.18")]
            public string OBR18 { get; set; }

            [JsonProperty("OBR.19")]
            public string OBR19 { get; set; }

            [JsonProperty("OBR.20")]
            public string OBR20 { get; set; }

            [JsonProperty("OBR.21")]
            public string OBR21 { get; set; }

            [JsonProperty("OBR.22")]
            public string OBR22 { get; set; }

            [JsonProperty("OBR.23")]
            public string OBR23 { get; set; }

            [JsonProperty("OBR.24")]
            public string OBR24 { get; set; }

            [JsonProperty("OBR.25")]
            public string OBR25 { get; set; }

            [JsonProperty("OBR.26")]
            public string OBR26 { get; set; }

            [JsonProperty("OBR.27")]
            public string OBR27 { get; set; }

            [JsonProperty("OBR.28")]
            public string OBR28 { get; set; }

            [JsonProperty("OBR.29")]
            public string OBR29 { get; set; }

            [JsonProperty("OBR.30")]
            public string OBR30 { get; set; }

            [JsonProperty("OBR.31")]
            public string OBR31 { get; set; }

            [JsonProperty("OBR.32")]
            public string OBR32 { get; set; }
        }

        public class OBX3
        {
            [JsonProperty("OBX.3.0")]
            public string OBX30 { get; set; }

            [JsonProperty("OBX.3.1")]
            public string OBX31 { get; set; }

            [JsonProperty("OBX.3.2")]
            public string OBX32 { get; set; }
        }

        public class OBX
        {
            [JsonProperty("OBX.0")]
            public string OBX0 { get; set; }

            [JsonProperty("OBX.1")]
            public string OBX1 { get; set; }

            [JsonProperty("OBX.2")]
            public string OBX2 { get; set; }

            [JsonProperty("OBX.3")]
            public OBX3 OBX3 { get; set; }

            [JsonProperty("OBX.4")]
            public string OBX4 { get; set; }

            [JsonProperty("OBX.5")]
            public string OBX5 { get; set; }

            [JsonProperty("OBX.6")]
            public string OBX6 { get; set; }

            [JsonProperty("OBX.7")]
            public string OBX7 { get; set; }

            [JsonProperty("OBX.8")]
            public string OBX8 { get; set; }

            [JsonProperty("OBX.9")]
            public string OBX9 { get; set; }

            [JsonProperty("OBX.10")]
            public string OBX10 { get; set; }

            [JsonProperty("OBX.11")]
            public string OBX11 { get; set; }
        }

        public class HL7Message
        {
            public MSH MSH { get; set; }
            public PID PID { get; set; }
            public PV1 PV1 { get; set; }
            public OBR OBR { get; set; }
            public List<OBX> OBX { get; set; }
        }

        public class Roots
        {
            public HL7Message HL7Message { get; set; }
        }


    }
}
