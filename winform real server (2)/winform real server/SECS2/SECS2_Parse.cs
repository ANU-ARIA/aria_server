using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace MES_COMM_PI.SECS2
{   
    class SECS2_Parse
    {
        public string MakeXml(SECS2_XML_MESSAGE _msg)
        {
            string sXml = "";

            if (_msg.HEAD.Stream == 2 && _msg.HEAD.Function == 41) sXml = MakeXml_S2F41(_msg);
            else if (_msg.HEAD.Stream == 6 && _msg.HEAD.Function == 12) sXml = MakeXml_S6F12(_msg);
            else {
               // error message 출력.
            }

            return sXml;
        }

        private string MakeXml_S2F41(SECS2_XML_MESSAGE _packet)
        {
            string sXml = "";
            return sXml;
        }

        private string MakeXml_S6F12(SECS2_XML_MESSAGE _msg)
        {
            string sXml = "";
            return sXml;
        }

        public int LoadXml(string _sXml, ref SECS2_XML_MESSAGE _rVal)
        {
            int nErr = 0;

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(_sXml);

            // Head
            XmlNodeList Node_Head = xml.GetElementsByTagName("HEAD");

            foreach (XmlNode node in Node_Head)
            {
                string sValue = node["SystemByte"].InnerText;
            }
            // systembyte
           
            // cmd
            // stream
            // function

            // Body
            // s2f42, host command ack

            // s6f11, event report

            return nErr;
        }
    }
}
