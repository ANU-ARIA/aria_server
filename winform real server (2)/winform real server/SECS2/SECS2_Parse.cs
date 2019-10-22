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



        private string MakeXml_S2F41(SECS2_XML_MESSAGE _packet) // @김동우
        {
            string sXml = "";

            // PacketS
            {
                // Head
                {
                    // SystemBytem
                    // CMD
                    // Stream
                    // Fucntion
                }
                // Body
                {
                    // RCMD
                    // PARAMETERS
                    {
                        // CMD_PARAM n개
                        {
                            // CPNAME
                            // CPVALUE
                        }
                    }
                }
            }
            return sXml;
        }

        private string MakeXml_S6F12(SECS2_XML_MESSAGE _msg) // @신수영
        {
            string sXml = "";
            return sXml;
        }

        public int LoadXml(string _sXml, ref SECS2_XML_MESSAGE _rVal)
        {
            int nErr = 0;

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(_sXml);

            int nS = 0, nF = 0;
            // Head (@김성현)
            {
                // systembyte
                // cmd
                // stream
                // function
            }

            // Body
            // s2f42, host command ack (@김성현)
            if( nS == 2 && nF == 42)
            {
                // HCACK
            }

            // s6f11, event report (@김동우)
            if( nS == 6 && nF == 11)
            {
                // CEID
                // RPTID
                // Vs
            }
            return nErr;
        }
    }
}
