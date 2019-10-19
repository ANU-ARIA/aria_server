using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES_COMM_PI.SECS2
{

    // 참고: 생성된 코드에 .NET Framework 4.5 또는 .NET Core/Standard 2.0이(가) 필요할 수 있습니다.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class SECS2_XML_MESSAGE
    {

        private SECS2_XML_MESSAGEHEAD hEADField;

        private SECS2_XML_MESSAGEBODY bODYField;

        /// <remarks/>
        public SECS2_XML_MESSAGEHEAD HEAD
        {
            get
            {
                return this.hEADField;
            }
            set
            {
                this.hEADField = value;
            }
        }

        /// <remarks/>
        public SECS2_XML_MESSAGEBODY BODY
        {
            get
            {
                return this.bODYField;
            }
            set
            {
                this.bODYField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SECS2_XML_MESSAGEHEAD
    {

        private int systemByteField;

        private int cMDField;

        private int streamField;

        private int functionField;

        /// <remarks/>
        public int SystemByte
        {
            get
            {
                return this.systemByteField;
            }
            set
            {
                this.systemByteField = value;
            }
        }

        /// <remarks/>
        public int CMD
        {
            get
            {
                return this.cMDField;
            }
            set
            {
                this.cMDField = value;
            }
        }

        /// <remarks/>
        public int Stream
        {
            get
            {
                return this.streamField;
            }
            set
            {
                this.streamField = value;
            }
        }

        /// <remarks/>
        public int Function
        {
            get
            {
                return this.functionField;
            }
            set
            {
                this.functionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SECS2_XML_MESSAGEBODY
    {

        private int aCKC6Field;

        private bool aCKC6FieldSpecified;

        private byte cEIDField;

        private bool cEIDFieldSpecified;

        private SECS2_XML_MESSAGEBODYREPORTS rEPORTSField;

        private int hCACKField;

        private bool hCACKFieldSpecified;

        private string rCMDField;

        private SECS2_XML_MESSAGEBODYCMD_PARAM[] pARAMETERSField;

        /// <remarks/>
        public int ACKC6
        {
            get
            {
                return this.aCKC6Field;
            }
            set
            {
                this.aCKC6Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ACKC6Specified
        {
            get
            {
                return this.aCKC6FieldSpecified;
            }
            set
            {
                this.aCKC6FieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CEID
        {
            get
            {
                return this.cEIDField;
            }
            set
            {
                this.cEIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CEIDSpecified
        {
            get
            {
                return this.cEIDFieldSpecified;
            }
            set
            {
                this.cEIDFieldSpecified = value;
            }
        }

        /// <remarks/>
        public SECS2_XML_MESSAGEBODYREPORTS REPORTS
        {
            get
            {
                return this.rEPORTSField;
            }
            set
            {
                this.rEPORTSField = value;
            }
        }

        /// <remarks/>
        public int HCACK
        {
            get
            {
                return this.hCACKField;
            }
            set
            {
                this.hCACKField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HCACKSpecified
        {
            get
            {
                return this.hCACKFieldSpecified;
            }
            set
            {
                this.hCACKFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string RCMD
        {
            get
            {
                return this.rCMDField;
            }
            set
            {
                this.rCMDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("CMD_PARAM", IsNullable = false)]
        public SECS2_XML_MESSAGEBODYCMD_PARAM[] PARAMETERS
        {
            get
            {
                return this.pARAMETERSField;
            }
            set
            {
                this.pARAMETERSField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SECS2_XML_MESSAGEBODYREPORTS
    {

        private SECS2_XML_MESSAGEBODYREPORTSREPORT rEPORTField;

        /// <remarks/>
        public SECS2_XML_MESSAGEBODYREPORTSREPORT REPORT
        {
            get
            {
                return this.rEPORTField;
            }
            set
            {
                this.rEPORTField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SECS2_XML_MESSAGEBODYREPORTSREPORT
    {

        private ushort rEPORTIDField;

        private string[] vARIABLESField;

        /// <remarks/>
        public ushort REPORTID
        {
            get
            {
                return this.rEPORTIDField;
            }
            set
            {
                this.rEPORTIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("V", IsNullable = false)]
        public string[] VARIABLES
        {
            get
            {
                return this.vARIABLESField;
            }
            set
            {
                this.vARIABLESField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SECS2_XML_MESSAGEBODYCMD_PARAM
    {

        private string cPNAMEField;

        private string cPVALUEField;

        /// <remarks/>
        public string CPNAME
        {
            get
            {
                return this.cPNAMEField;
            }
            set
            {
                this.cPNAMEField = value;
            }
        }

        /// <remarks/>
        public string CPVALUE
        {
            get
            {
                return this.cPVALUEField;
            }
            set
            {
                this.cPVALUEField = value;
            }
        }
    }


}
