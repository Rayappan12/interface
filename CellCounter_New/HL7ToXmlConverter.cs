using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace CellCounter_New
{
    public class HL7ToXmlConverter
    {
        private static XmlDocument xmlDoc;

        public static string ConvertToXml(string sHL7)
        {
            xmlDoc = CreateXmlDoc();

            string[] sHL7Lines = sHL7.Split('\r', '\n');
            //string[] sHL7Lines = sHL7.Split('\n');

            for (int i = 0; i < sHL7Lines.Length; i++)
            {
                sHL7Lines[i] = Regex.Replace(sHL7Lines[i], @"[^ -~]", "");
            }

            for (int i = 0; i < sHL7Lines.Length; i++)
            {
                // Don't care about empty lines
                if (sHL7Lines[i] != string.Empty)
                {
                    // Get the line and get the line's segments
                    string sHL7Line = sHL7Lines[i];
                    string[] sFields = HL7ToXmlConverter.GetMessgeFields(sHL7Line);

                    // Create a new element in the XML for the line                    
                    XmlElement el = xmlDoc.CreateElement(sFields[0]);
                    xmlDoc.DocumentElement.AppendChild(el);

                    // For each field in the line of HL7
                    for (int a = 0; a < sFields.Length; a++)
                    {
                        // Create a new element
                        XmlElement fieldEl = xmlDoc.CreateElement(sFields[0] + "." + a.ToString());

                        /// Part of the HL7 specification is that part
                        /// of the message header defines which characters
                        /// are going to be used to delimit the message
                        /// and since we want to capture the field that
                        /// contains those characters we need
                        /// to just capture them and stick them in an element.
                        if ((sFields[a] != @"^~\&") && (sFields[a] != @"^~\\&") && (sFields[a] != @"^~&"))
                        {
                            /// Get the components within this field, separated by carats (^)
                            /// If there are more than one, go through and create an element for
                            /// each, then check for subcomponents, and repetition in both.
                            string[] sComponents = HL7ToXmlConverter.GetComponents(sFields[a]);

                            if (sComponents.Length > 1)
                            {
                                for (int b = 0; b < sComponents.Length; b++)
                                {
                                    XmlElement componentEl =
                                        xmlDoc.CreateElement(sFields[0] + "." + a.ToString() + "." + b.ToString());

                                    string[] subComponents = GetSubComponents(sComponents[b]);
                                    if (subComponents.Length > 1)
                                    // There were subcomponents
                                    {
                                        for (int c = 0; c < subComponents.Length; c++)
                                        {
                                            // Check for repetition
                                            string[] subComponentRepetitions =
                                                GetRepetitions(subComponents[c]);
                                            if (subComponentRepetitions.Length > 1)
                                            {
                                                for (int d = 0;
                                                     d < subComponentRepetitions.Length;
                                                     d++)
                                                {
                                                    XmlElement subComponentRepEl =
                                                        xmlDoc.CreateElement(sFields[0] +
                                                                              "." + a.ToString() +
                                                                              "." + b.ToString() +
                                                                              "." + c.ToString() +
                                                                              "." + d.ToString());

                                                    subComponentRepEl.InnerText = subComponentRepetitions[d];
                                                    componentEl.AppendChild(subComponentRepEl);
                                                }
                                            }
                                            else
                                            {
                                                XmlElement subComponentEl =
                                                    xmlDoc.CreateElement(sFields[0] +
                                                                          "." + a.ToString() + "." +
                                                                          b.ToString() + "." + c.ToString());
                                                subComponentEl.InnerText = subComponents[c];
                                                componentEl.AppendChild(subComponentEl);
                                            }
                                        }
                                        fieldEl.AppendChild(componentEl);
                                    }
                                    else // There were no subcomponents
                                    {
                                        string[] sRepetitions =
                                            HL7ToXmlConverter.GetRepetitions(sComponents[b]);
                                        if (sRepetitions.Length > 1)
                                        {
                                            XmlElement repetitionEl = null;
                                            for (int c = 0; c < sRepetitions.Length; c++)
                                            {
                                                repetitionEl =
                                                    xmlDoc.CreateElement(sFields[0] + "." +
                                                                          a.ToString() + "." + b.ToString() +
                                                                          "." + c.ToString());
                                                repetitionEl.InnerText = sRepetitions[c];
                                                componentEl.AppendChild(repetitionEl);
                                            }
                                            fieldEl.AppendChild(componentEl);
                                            el.AppendChild(fieldEl);
                                        }
                                        else
                                        {
                                            componentEl.InnerText = sComponents[b];
                                            fieldEl.AppendChild(componentEl);
                                            el.AppendChild(fieldEl);
                                        }
                                    }
                                }
                                el.AppendChild(fieldEl);
                            }
                            else
                            {
                                fieldEl.InnerText = sFields[a];
                                el.AppendChild(fieldEl);
                            }
                        }
                        else
                        {
                            fieldEl.InnerText = sFields[a];
                            el.AppendChild(fieldEl);
                        }
                    }
                }
            }

            return xmlDoc.OuterXml;

        }

        private static string[] GetMessgeFields(string s)
        {
            return s.Split('|');
        }
        private static string[] GetComponents(string s)
        {
            return s.Split('^');
        }
        private static string[] GetSubComponents(string s)
        {
            return s.Split('&');
        }
        private static string[] GetRepetitions(string s)
        {
            return s.Split('~');
        }
        private static XmlDocument CreateXmlDoc()
        {
            XmlDocument output = new XmlDocument();
            XmlElement rootNode = output.CreateElement("HL7Message");
            output.AppendChild(rootNode);
            return output;
        }
    }
}
