using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_real_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread c = new Thread(hh);
            c.IsBackground = true;
            c.Start();
        }
        public void hh()
        {
            string bintIp = "220.69.249.226";
            const int bindPort = 4000;
            TcpListener server = null;
            //서버주소 바인딩(ip번호, port번호)


            IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bintIp), bindPort);
            //서버 만들기, 주소바인딩~!!!
            server = new TcpListener(localAddress);

            server.Start();
            textBox1.Text = "ARIA 프로젝트 서버";

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                ((IPEndPoint)client.Client.RemoteEndPoint).ToString();

                NetworkStream stream = client.GetStream();

                int length;
                string data = null;
                byte[] bytes = new byte[256];
                length = stream.Read(bytes, 0, bytes.Length);

                StringBuilder sb = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();
                ArrayList sss = new ArrayList();
                ArrayList sss2 = new ArrayList();

                data = Encoding.Default.GetString(bytes, 0, length);// 데이터 수신
                sss.Add(string.Format("수신 : {0} ", data));
                textBox2.Text = data;
                if (data == "ㅎㅇ")
                {
                    data = "는 하이";
                    byte[] msg = Encoding.Default.GetBytes(data);
                    stream.Write(msg, 0, msg.Length); // 데이터 송신
                    textBox3.Text = data;
                }
                else if (data == "ㅂㅇ")
                {
                    data = "는 바이";
                    byte[] msg = Encoding.Default.GetBytes(data);
                    stream.Write(msg, 0, msg.Length); // 데이터 송신
                    textBox3.Text = data;
                }
                else if (data == "ㅂㅇㄹ")
                {
                    data = "는 바이루";
                    byte[] msg = Encoding.Default.GetBytes(data);
                    stream.Write(msg, 0, msg.Length); // 데이터 송신
                    textBox3.Text = data;
                }
                byte[] msg2 = Encoding.Default.GetBytes(data);
                stream.Write(msg2, 0, msg2.Length); // 데이터 송신
                textBox3.Text = data;



            }
        }
            private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
