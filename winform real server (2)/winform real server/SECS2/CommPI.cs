using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES_COMM_PI.SECS2;

namespace MES_COMM_PI
{
    public enum eACKC6 { Accepted = 0, NotAccepted = 1}
    public enum eHCACK { Acknowledge = 0, Command_does_not_exist = 1,
        Cannot_perform_now = 2, parameter_is_invalid = 3, Acknowledge_will_be_performed = 4,
        Rejected = 5, No_object_exists = 6
    }

    class CommPI
    {
        private int m_nSystemByte = 0;

        private SECS2_Parse m_parser = new SECS2_Parse();

        public void Server_Open()
        {

        }

        public void Server_Close()
        {

        }

        public int MakeSystemByte()
        {
            if (m_nSystemByte > 9999999) m_nSystemByte = 0;
            return m_nSystemByte++;
        }
        public void OnReceive(string _rcv_msg)
        {
            SECS2_XML_MESSAGE item = new SECS2_XML_MESSAGE();

            m_parser.LoadXml(_rcv_msg, ref item);
        }

        private int Send(SECS2_XML_MESSAGE _msg)
        {
            int nErr = 0;

            string sMsg = m_parser.MakeXml(_msg);

            // client_stream.Wirte( sMsg );

            return 0;
        }

        public int Send_HostCommand(string _HostCmd, List<SECS2_XML_MESSAGEBODYCMD_PARAM> _CmdParams)
        {
            int nErr = 0;

            SECS2_XML_MESSAGE _msg = new SECS2_XML_MESSAGE();
            _msg.HEAD.SystemByte = MakeSystemByte();
            _msg.HEAD.CMD = 3;
            _msg.HEAD.Stream = 2;
            _msg.HEAD.Function = 41;

            _msg.BODY.RCMD = _HostCmd;
            int i = 0;
            foreach (SECS2_XML_MESSAGEBODYCMD_PARAM it in _CmdParams )
            {
                _msg.BODY.PARAMETERS[i].CPNAME  = it.CPNAME;
                _msg.BODY.PARAMETERS[i].CPVALUE = it.CPVALUE;
                i++;
            }

            nErr = Send(_msg);

            return nErr;
        }

        public int Send_EventReportAck(eACKC6 _nACKC6)
        {
            int nErr = 0;
            SECS2_XML_MESSAGE _msg = new SECS2_XML_MESSAGE();
            _msg.HEAD.SystemByte = MakeSystemByte();
            _msg.HEAD.CMD = 3;
            _msg.HEAD.Stream = 6;
            _msg.HEAD.Function = 12;

            _msg.BODY.ACKC6 = (int)_nACKC6;            

            nErr = Send(_msg);
            return nErr;
        }
    }
}


