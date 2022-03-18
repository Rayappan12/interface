using CellCounter_New.Model;
using log4net;
using Newtonsoft.Json;
using NHapi.Base.Parser;
using NHapi.Model.V231.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
//using Root = CellCounter_New.Model.XmlToObject.Root;

namespace CellCounter_New
{
    public class OurSimpleMultiThreadedMllpHl7ServerNew
    {
        #region variables
        private static readonly ILog log = LogManager.GetLogger(typeof(frmConfig));
        private Socket client;

        // add a delegate for general message
        public delegate void GeneralMessageUpdateHandler(object sender, GeneralMessageUpdateEventArgs e);
        // add an event of the delegate type
        public event GeneralMessageUpdateHandler GeneralMessageHandler;
        #endregion

        public XmlDocument doc = new XmlDocument();
        public JsonToObject.Root Root = new JsonToObject.Root();
        public JsonObjectOne.Roots Roots = new JsonObjectOne.Roots();
        List<GridViewObject> _GridViewReports = new List<GridViewObject>();
        TestGridDetails _testGridDetails = new TestGridDetails();
        List<TestValues> _testValues = new List<TestValues>();
        string hl7Data = string.Empty;
        public void StartOurTcpServer(string iPAddress, int port)
        {
            try
            {
                log.Info("IP:=" + IPAddress.Parse(iPAddress) + " Port:=" + port);
                client = new Socket(IPAddress.Parse(iPAddress).AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(iPAddress), port);
                client.Connect(endPoint);
                GeneralMessageUpdateEventArgs args = new GeneralMessageUpdateEventArgs("Started server successfully...");
                GeneralMessageHandler(this, args);

                while (true)
                {
                    if (client.Available > 0)
                    {
                        Byte[] bytes = new Byte[client.Available];
                        if (bytes.Length > 0)
                        {
                            int byteData;
                            byteData = client.Receive(bytes);
                            hl7Data = Encoding.ASCII.GetString(bytes, 0, byteData);

                            PipeParser Parser = new PipeParser();
                            var message = Parser.Parse(hl7Data, "2.3.1");
                            //var m = Parser.Parse(hl7Data);


                            ORU_R01 ormo01 = message as ORU_R01;

                            XMLParser xmlParser = new DefaultXMLParser();

                            string recoveredMessage = xmlParser.Encode(ormo01);

                            //Assert.AreNotEqual(string.Empty, recoveredMessage);

                            XmlDocument ormDoc = new XmlDocument();

                            ormDoc.LoadXml(recoveredMessage);

                            string jsonText = JsonConvert.SerializeXmlNode(ormDoc, Newtonsoft.Json.Formatting.Indented);
                            //Root = JsonConvert.DeserializeObject<JsonToObject.Root>(jsonText);

                            JsonToObject.Root myDeserializedClass = JsonConvert.DeserializeObject<JsonToObject.Root>(jsonText);

                            if (myDeserializedClass.ORU_R01.ORUR01PATIENTRESULT.ORUR01PATIENT.PID.PID3.CX1 != null)
                            {

                                var result = myDeserializedClass.ORU_R01.ORUR01PATIENTRESULT.ORUR01ORDEROBSERVATION.ORUR01OBSERVATION.ToList();
                                foreach (var res in result)
                                {
                                    var Result = res.OBX.OBX5;
                                }

                            }
                            //XmlSerializer serializer = new XmlSerializer(typeof(ORUR01));
                            //using (StringReader reader = new StringReader(recoveredMessage))
                            //{
                            //    var test = (ORUR01)serializer.Deserialize(reader);
                            //}
                            //ValidateJsonObject(hl7Data);
                            //ValidateReports();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //print any exceptions during the communications to the console
                log.Error("Server Stoped", ex);
            }
            finally
            {
                client?.Close();
            }

        }

        private async Task<bool> ValidateJsonObject(string root)
        {
            try
            {

                string xmlFileContents = HL7ToXmlConverter.ConvertToXml(hl7Data);
                doc.LoadXml(xmlFileContents);
                string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
                Root = JsonConvert.DeserializeObject<JsonToObject.Root>(jsonText);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void ValidateReports()
        {
            var Result = ValidateJsonObject(hl7Data).Result;
            if (Result)
            {
                string xmlFileContents = HL7ToXmlConverter.ConvertToXml(hl7Data);
                doc.LoadXml(xmlFileContents);
                string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
                Root = JsonConvert.DeserializeObject<JsonToObject.Root>(jsonText);
                //DeserializeJsonReport();
            }
            else
            {
                string xmlFileContents = HL7ToXmlConverter.ConvertToXml(hl7Data);
                doc.LoadXml(xmlFileContents);
                string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
                Roots = JsonConvert.DeserializeObject<JsonObjectOne.Roots>(jsonText);
                DeserializeJsonReports();
            }
        }

        string first_name;
        string last_name;
        string MSH;
        string MshDate;
        string ORU;
        string R01;
        string PID;
        string Gender;
        string oprator_mode;
        string AGE;
        DateTime dates;
        List<TestValues> test_details;
        private string test_mode;
        //private void DeserializeJsonReport()
        //{
        //    if (Root.HL7Message != null)
        //    {
        //        if (Root.HL7Message.MSH != null)
        //        {
        //            string[] format = { "yyyyMMddHHmmss" };
        //            string date = Root.HL7Message.MSH.MSH6;
        //            DateTime.TryParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dates);
        //            MSH = Root.HL7Message.MSH.MSH0 == null ? string.Empty : Root.HL7Message.MSH.MSH0;
        //            MshDate = dates.ToString() == null ? string.Empty : dates.ToString();
        //            ORU = Root.HL7Message.MSH.MSH8.MSH80 == null ? string.Empty : Root.HL7Message.MSH.MSH8.MSH80;
        //            R01 = Root.HL7Message.MSH.MSH8.MSH81 == null ? string.Empty : Root.HL7Message.MSH.MSH8.MSH81;
        //        }

        //        if (Root.HL7Message.PID != null)
        //        {
        //            PID = Root.HL7Message.PID.PID3.PID30 == null ? string.Empty : Root.HL7Message.PID.PID3.PID30;
        //            Gender = Root.HL7Message.PID.PID8 == null ? string.Empty : Root.HL7Message.PID.PID8;
        //            if (Root.HL7Message.PID.PID5 != null)
        //            {
        //                if (Root.HL7Message.PID.PID5.PID50 != null)
        //                {
        //                    first_name = Root.HL7Message.PID.PID5.PID50 == null ? string.Empty : Root.HL7Message.PID.PID5.PID50;
        //                }
        //                else
        //                {
        //                    first_name = null;
        //                }
        //                if (Root.HL7Message.PID.PID5.PID51 != null)
        //                {
        //                    last_name = Root.HL7Message.PID.PID5.PID51 == null ? string.Empty : Root.HL7Message.PID.PID5.PID51;
        //                }
        //                else
        //                {
        //                    last_name = null;
        //                }
        //            }
        //            else
        //            {
        //                first_name = null;
        //                last_name = null;
        //            }
        //        }

        //        if (Root.HL7Message.OBX != null)
        //        {
        //            oprator_mode = Root.HL7Message.OBR.OBR32 == null ? string.Empty : Root.HL7Message.OBR.OBR32;
        //            var age = Root.HL7Message.OBX.Where(x => x.OBX3.OBX31 == "Age" && x.OBX2 == "NM").ToArray();
        //            if (age != null)
        //            {
        //                var Age = age.Select(x => x.OBX5).FirstOrDefault();
        //                AGE = Age == null ? string.Empty : Age;
        //            }

        //            var testResult = Root.HL7Message.OBX.Where(x => x.OBX2 == "NM").ToList();

        //            if (testResult.Count > 0)
        //            {
        //                foreach (var Obx in testResult)
        //                {
        //                    _testValues.Add(new TestValues()
        //                    {
        //                        test_name = Obx.OBX3.OBX31,
        //                        test_result = Obx.OBX5
        //                    });
        //                }
        //            }
        //            test_details = _testValues.Count > 0 ? _testValues : _testValues = null;
        //            var testMode = Root.HL7Message.OBX.Where(x => x.OBX2 == "IS").ToArray();
        //            var TestMode = testMode.Where(x => x.OBX5 == "CBC" || x.OBX5 == "CBC+DIFF" || x.OBX5 == "WB-CBC+DIFF" || x.OBX5 == "WB+CBC").ToArray();
        //            var testModes = TestMode.Select(x => x.OBX5).FirstOrDefault();
        //            test_mode = testModes == null ? string.Empty : testModes;
        //        }
        //        _GridViewReports.Add(new GridViewObject()
        //        {
        //            MSH = MSH,
        //            MshDate = MshDate,
        //            ORU = ORU,
        //            R01 = R01,
        //            PID = PID,
        //            first_name = first_name,
        //            last_name = last_name,
        //            Gender = Gender,
        //            age = AGE,
        //            oprator_mode = oprator_mode,
        //            test_mode = test_mode,
        //            test_details = test_details
        //        });
        //        _testGridDetails.barcode = PID;
        //        _testGridDetails.GridViewObject = _GridViewReports;
        //        //}
        //        var serialize = JsonConvert.SerializeObject(_testGridDetails, Newtonsoft.Json.Formatting.Indented);
        //        string path = @"C:\ProgramData\NigDignosticSolutionManager\cellcounter.txt";
        //        if (!File.Exists(path))
        //        {
        //            File.Create(path);
        //        }
        //        File.AppendAllText(path, serialize);
        //        _testValues.Clear();
        //        _testGridDetails.GridViewObject.Clear();
        //    }
        //}
        private void DeserializeJsonReports()
        {
            if (Roots.HL7Message != null)
            {
                if (Roots.HL7Message.MSH != null)
                {
                    string[] format = { "yyyyMMddHHmmss" };
                    string date = Roots.HL7Message.MSH.MSH6;
                    DateTime.TryParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dates);
                    MSH = Roots.HL7Message.MSH.MSH0 == null ? string.Empty : Roots.HL7Message.MSH.MSH0;
                    MshDate = dates.ToString() == null ? string.Empty : dates.ToString();
                    ORU = Roots.HL7Message.MSH.MSH8.MSH80 == null ? string.Empty : Roots.HL7Message.MSH.MSH8.MSH80;
                    R01 = Roots.HL7Message.MSH.MSH8.MSH81 == null ? string.Empty : Roots.HL7Message.MSH.MSH8.MSH81;
                }

                if (Roots.HL7Message.PID != null)
                {
                    PID = Roots.HL7Message.PID.PID3.PID30 == null ? string.Empty : Roots.HL7Message.PID.PID3.PID30;
                    var Gend = Roots.HL7Message.PID == null ? string.Empty : Roots.HL7Message.PID.PID5;
                    if ((Gend.ToLower() == "male") || (Gend.ToLower() == "female"))
                    {
                        Gender = Roots.HL7Message.PID == null ? string.Empty : Roots.HL7Message.PID.PID5;
                    }
                    else
                    {
                        //List<PatientDetails> _patientDetails = new List<PatientDetails>();
                        //var gender = _patientDetails.Select(x => x.gender).FirstOrDefault();
                        //Gender = gender;                        
                        Gender = "";
                    }

                    if (Roots.HL7Message.PID.PID5 != null)
                    {
                        if (Roots.HL7Message.PID.PID5 != null)
                        {
                            first_name = Roots.HL7Message.PID.PID5 == null ? string.Empty : Roots.HL7Message.PID.PID5;
                        }
                        else
                        {
                            first_name = null;
                        }
                        if (Roots.HL7Message.PID.PID5 != null)
                        {
                            last_name = Roots.HL7Message.PID.PID5 == null ? string.Empty : Roots.HL7Message.PID.PID5;
                        }
                        else
                        {
                            last_name = null;
                        }
                    }
                    else
                    {
                        first_name = null;
                        last_name = null;
                    }
                }

                if (Roots.HL7Message.OBX != null)
                {
                    oprator_mode = Roots.HL7Message.OBR.OBR32 == null ? string.Empty : Roots.HL7Message.OBR.OBR32;
                    var age = Roots.HL7Message.OBX.Where(x => x.OBX3.OBX31 == "Age" && x.OBX2 == "NM").ToArray();
                    if (age != null)
                    {
                        var Age = age.Select(x => x.OBX5).FirstOrDefault();
                        AGE = Age == null ? string.Empty : Age;
                    }

                    var testResult = Roots.HL7Message.OBX.Where(x => x.OBX2 == "NM").ToList();

                    if (testResult.Count > 0)
                    {
                        foreach (var Obx in testResult)
                        {
                            _testValues.Add(new TestValues()
                            {
                                test_name = Obx.OBX3.OBX31,
                                test_result = Obx.OBX5
                            });
                        }
                    }
                    test_details = _testValues.Count > 0 ? _testValues : _testValues = null;
                    var testMode = Roots.HL7Message.OBX.Where(x => x.OBX2 == "IS").ToArray();
                    var TestMode = testMode.Where(x => x.OBX5 == "CBC" || x.OBX5 == "CBC+DIFF" || x.OBX5 == "WB-CBC+DIFF" || x.OBX5 == "WB+CBC").ToArray();
                    var testModes = TestMode.Select(x => x.OBX5).FirstOrDefault();
                    test_mode = testModes == null ? string.Empty : testModes;
                }

                _GridViewReports.Add(new GridViewObject()
                {
                    MSH = MSH,
                    MshDate = MshDate,
                    ORU = ORU,
                    R01 = R01,
                    PID = PID,
                    first_name = first_name,
                    last_name = last_name,
                    Gender = Gender,
                    age = AGE,
                    oprator_mode = oprator_mode,
                    test_mode = test_mode,
                    test_details = test_details
                });
                _testGridDetails.barcode = PID;
                _testGridDetails.GridViewObject = _GridViewReports;

                var serialize = JsonConvert.SerializeObject(_testGridDetails, Newtonsoft.Json.Formatting.Indented);
                string path = @"C:\ProgramData\NigDignosticSolutionManager\cellcounter.txt";
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                File.AppendAllText(path, serialize);
                _testValues.Clear();
                _testGridDetails.GridViewObject.Clear();
            }
        }

    }

    public class GeneralMessageUpdateEventArgs : System.EventArgs
    {
        // add local member variables to hold text
        private string messages;
        public GeneralMessageUpdateEventArgs(string messages)
        {
            this.messages = messages;
        }
        //Properties - Viewable by Each Listener
        public string Messages
        {
            get
            {
                return messages;
            }
        }
    }
}
