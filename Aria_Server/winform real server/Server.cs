using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace winform_real_server
{
    class Server
    {
        public int Pi_on;

        public static int number = 0;
        Form1 fm;
        public static string bintIp = "220.69.249.226";
        const int bindPort = 4000;
        const int bindPort2 = 5000;

        public static IPEndPoint localAddress2 = new IPEndPoint(IPAddress.Parse(bintIp), bindPort2);
        public static TcpListener server2 = new TcpListener(localAddress2);


        public static IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bintIp), bindPort);
        public static TcpListener server = new TcpListener(localAddress);

        Receive_User r_user = new Receive_User();

        public string lotid;

        public static int go_index = 0;
        public static string go_txt = "000000000000";
        public static string go1 = "0";
        public static string go2 = "0";
        public static string go3 = "0";
        public static string go4 = "0";
        public static string go5 = "0";
        public static string go6 = "0";
        public static string go7 = "0";
        public static string go8 = "0";
        public static string go9 = "0";
        public static string go10 = "0";
        public static string go11 = "0";
        public static string go12 = "0";
        public static int bo1 = 0;
        public static int bo2 = 0;
        public static int bo3 = 0;
        public static int bo4 = 0;
        public static int bo5 = 0;
        public static int bo6 = 0;
        public static int bo7 = 0;
        public static int bo8 = 0;
        public static int bo9 = 0;
        public static int bo10 = 0;
        public static int bo11 = 0;
        public static int bo12 = 0;

        public Server(Form1 ff)
        {
            fm = ff;
        }
        public Server()
        {

        }

        /* 아래는 함수 리스트 */
        public void Proc_req_user_login(string[] receive_data_division, ref NetworkStream stream)
        {
            string send_data = null;
            List<DB_USERS> List_Users = new List<DB_USERS>();
            DB_MGR.Users_Select(ref List_Users);
            string Yes_Or_No = "";
            string user_id = "";
            string pw = "";
            string level = "";

            for (int i = 0; i < List_Users.Count; i++)
            {
                if (receive_data_division[2] == List_Users[i].User_Id && receive_data_division[3] == List_Users[i].Pass_Word) // 아이디 비밀번호 일치 판단문
                {
                    Req_User_Log_In.result = "OK";
                    Yes_Or_No = "OK";

                    user_id = List_Users[i].User_Id;
                    pw = List_Users[i].Pass_Word;
                    level = List_Users[i].Level;

                    Req_User_Log_In.level = List_Users[i].Level;
                    if (Req_User_Log_In.level == "1")
                    {
                        Req_User_Log_In.right = "OPER";
                    }
                    else if (Req_User_Log_In.level == "2")
                    {
                        Req_User_Log_In.right = "ADMIN";
                    }
                    break;
                }
                else
                {
                    Req_User_Log_In.result = "NG";
                    Yes_Or_No = "NO";
                }

            }
            if (Req_User_Log_In.result == "NG")
            {
                Req_User_Log_In.nak_reason = "오류남";
            }
            send_data = Yes_Or_No +","+ user_id +","+ pw +","+ level;
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
            fm.textBox3.Text = send_data + Req_User_Log_In.level;

        } // 로그인 관리
        public void Proc_req_user_all_select(string [] receive_data_division, ref NetworkStream stream)
        {
            List<DB_USERS> User = new List<DB_USERS>();
            DB_MGR.Users_Select(ref User);
            string send_data = null;
            int a = 0;
            foreach (DB_USERS ee in User)
            {
                a++;
                if (User.Count == a)
                {
                    send_data = send_data + ee.User_Id + "," + ee.Pass_Word + "," + ee.Level + "," + ee.E_Mail + "," +
                        ee.First_Name + "," + ee.Last_Name;
                }
                else
                {
                    send_data = send_data + ee.User_Id + "," + ee.Pass_Word + "," + ee.Level + "," + ee.E_Mail + "," +
                        ee.First_Name + "," + ee.Last_Name + ",\n";
                }
            }
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // user 전체 검색
        public void Proc_req_user_select(string[] receive_data_division, ref NetworkStream stream)
        {
            List<DB_USERS> User = new List<DB_USERS>();
            DB_MGR.Users_Select(ref User);
            string send_data = null;
            foreach (DB_USERS ee in User)
            {
                if (receive_data_division[3] == ee.User_Id)
                {
                    send_data = ee.User_Id + "," + ee.Pass_Word + "," + ee.Level + "," + ee.E_Mail + "," + ee.First_Name + "," + ee.Last_Name;
                }
            }
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // user 선택 검색
        public void Proc_req_user_create(string[] receive_data_division, ref NetworkStream stream)
        {
            DB_USERS User = new DB_USERS(receive_data_division[2], receive_data_division[3], receive_data_division[4], receive_data_division[5], receive_data_division[6], receive_data_division[7]);
            DB_MGR.Users_Insert(ref User);

            string send_data = "유저생성 완료";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // user 생성
        public void Proc_req_user_update(string[] receive_data_division, ref NetworkStream stream)
        {
            DB_USERS User = new DB_USERS(receive_data_division[2], receive_data_division[3], receive_data_division[4], receive_data_division[5], receive_data_division[6], receive_data_division[7]);
            DB_MGR.Users_Update(ref User);

            string send_data = "유저변경 완료";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // user 변경
        public void Proc_req_user_all_delete(string[] receive_data_division, ref NetworkStream stream)
        {
            string send_data = "유저 전체삭제";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // user 전체 삭제
        public void Proc_req_user_delete(string[] receive_data_division, ref NetworkStream stream)
        {
            DB_USERS use = new DB_USERS(receive_data_division[2], receive_data_division[3], receive_data_division[4], receive_data_division[5], receive_data_division[6], receive_data_division[7]);
            DB_MGR.Users_Delete(ref use);

            string send_data = "유저 부분삭제";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // user 선택 삭제
        public void Proc_req_model_all_select(string[] receive_data_division, ref NetworkStream stream)
        {
            List<DB_TBL_MODEL> Model = new List<DB_TBL_MODEL>();
            DB_MGR.Model_Select(ref Model);
            int a = 0;
            string send_data = null;
            foreach (DB_TBL_MODEL ee in Model)
            {
                a++;
                if (Model.Count == a)
                {
                    send_data = send_data + ee.Model_Id + "," + ee.Model_Temp + "," + ee.Model_Humidity + "," + ee.Model_Aname;
                }
                else
                {
                    send_data = send_data + ee.Model_Id + "," + ee.Model_Temp + "," + ee.Model_Humidity + "," + ee.Model_Aname + ",\n";
                }
            }
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // model 전체 검색
        public void Proc_req_model_select(string[] receive_data_division, ref NetworkStream stream)
        {
            List<DB_TBL_MODEL> Model = new List<DB_TBL_MODEL>();
            DB_MGR.Model_Select(ref Model);
            string send_data = null;

            foreach (DB_TBL_MODEL ee in Model)
            {
                if (receive_data_division[3] == ee.Model_Id)
                {
                    send_data = ee.Model_Id + "," + ee.Model_Temp + "," + ee.Model_Humidity + "," + ee.Model_Aname;
                }
            }
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // model 선택 검색
        public void Proc_req_model_create(string[] receive_data_division, ref NetworkStream stream)
        {
            DB_TBL_MODEL Model = new DB_TBL_MODEL(receive_data_division[2], receive_data_division[3], receive_data_division[4], receive_data_division[5]);
            DB_MGR.Model_Insert(ref Model);

            string send_data = "모델생성 완료";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // model 생성
        public void Proc_req_model_updata(string[] receive_data_division, ref NetworkStream stream)
        {
            DB_TBL_MODEL Model = new DB_TBL_MODEL(receive_data_division[2], receive_data_division[3], receive_data_division[4], receive_data_division[5]);
            DB_MGR.Model_Update(ref Model);

            string send_data = "모델업데이트 완료";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // model 변경
        public void Proc_req_model_delete(string[] receive_data_division, ref NetworkStream stream)
        {
            try
            {
                DB_TBL_MODEL model = new DB_TBL_MODEL();
                DB_MGR.Model_Delete(receive_data_division[2]);

                string send_data = "모델 삭제완료";
                byte[] Response_Data = Encoding.Default.GetBytes(send_data);
                stream.Write(Response_Data, 0, Response_Data.Length);
            }
            catch(Exception gg)
            {
                string send_data = "모델 삭제실패";
                byte[] Response_Data = Encoding.Default.GetBytes(send_data);
                stream.Write(Response_Data, 0, Response_Data.Length);
            }
        } // model 삭제
        public void Proc_req_lot_all_select(string[] receive_data_division, ref NetworkStream stream)
        {
            List<DB_TBL_LOT> Lot = new List<DB_TBL_LOT>();
            DB_MGR.Lot_Select(ref Lot);
            int a = 0;
            string send_data = "";
            foreach (DB_TBL_LOT ee in Lot)
            {
                a++;
                if (Lot.Count == a)
                {
                    send_data = send_data + ee.Lot_Id + "," + ee.Model_Id + "," + ee.Line_Id + "," + ee.Total_Product_Count + "," + ee.Product_Speed_Warn
                        + "," + ee.Product_Fail_Rate_Warn + "," + ee.Product_Color + "," + ee.Temp_Margin + "," + ee.Humid_Margin + "," + ee.Oper_Id + ","
                        + ee.Working_State + "," + ee.Lot_Created_Time;
                }
                else
                {
                    send_data = send_data + ee.Lot_Id + "," + ee.Model_Id + "," + ee.Line_Id + "," + ee.Total_Product_Count + "," + ee.Product_Speed_Warn
                        + "," + ee.Product_Fail_Rate_Warn + "," + ee.Product_Color + "," + ee.Temp_Margin + "," + ee.Humid_Margin + "," + ee.Oper_Id + ","
                        + ee.Working_State + "," + ee.Lot_Created_Time + ",\n";
                }
            }
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // lot 전체 검색
        public void Proc_req_lot_all_select1(string[] receive_data_division, ref NetworkStream stream)
        {
            int receive = receive_data_division[2].Length - 1;
            //string send_data = ee.Length.ToString() + "{"+ee+"}";
            string send_data;
            if (receive_data_division[2].Substring(0, 1) == "\n")
            {
                DB_MGR.Lot_Start_Time_Update(receive_data_division[2].Substring(1, receive));
                send_data = "Lot Start Time 갱신";
            }
            else
            {
                DB_MGR.Lot_Start_Time_Update(receive_data_division[2]);
                send_data = "Lot Start Time 갱신";
            }
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        }  // 작업시작 후 model start time 갱신
        public void Proc_req_lot_create(string[] receive_data_division, ref NetworkStream stream)
        {
            DB_TBL_LOT Lot = new DB_TBL_LOT(receive_data_division[2], receive_data_division[3], receive_data_division[4], receive_data_division[5], receive_data_division[6], receive_data_division[7],
                receive_data_division[8], receive_data_division[9], receive_data_division[10], receive_data_division[11], receive_data_division[12], "-","-","-");
            DB_MGR.Lot_Insert(ref Lot);

            string send_data = "lot생성";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // lot 생성
        public void Proc_req_lot_delete(string[] receive_data_division, ref NetworkStream stream)
        {
            string send_data = "lot삭제";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // lot 삭제
        public void Proc_req_line_create(string[] receive_data_division, ref NetworkStream stream)
        {
            DB_TBL_LINE1 Line = new DB_TBL_LINE1(receive_data_division[2], receive_data_division[3], receive_data_division[4], receive_data_division[5], receive_data_division[6],
                receive_data_division[7], "0");
            DB_MGR.Line1_Insert(ref Line);

            string send_data = "line생성";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // 작업시작시 line 생성
        public void Proc_req_products_create(string[] receive_data_division, ref NetworkStream stream)
        {
            
            for (int i = 0; i < Convert.ToInt32(receive_data_division[5]); i++)
            {
                DB_TBL_PRODUCTS Products = new DB_TBL_PRODUCTS(go_txt,receive_data_division[2],receive_data_division[3],receive_data_division[4],
                    "30","20","0","-","-");
                DB_MGR.Products_Insert(ref Products);
                bo12 = Convert.ToInt32(go12);
                bo11 = Convert.ToInt32(go11);
                bo10 = Convert.ToInt32(go10);
                bo9 = Convert.ToInt32(go9);
                bo8 = Convert.ToInt32(go8);
                bo7 = Convert.ToInt32(go7);
                bo6 = Convert.ToInt32(go6);
                bo5 = Convert.ToInt32(go5);
                bo4 = Convert.ToInt32(go4);
                bo3 = Convert.ToInt32(go3);
                bo2 = Convert.ToInt32(go2);
                bo1 = Convert.ToInt32(go1);
                bo12++;
                go12 = bo12.ToString();
                go_txt = go1 + go2 + go3 + go4 + go5 + go6 + go7 + go8 + go9 + go10 + go11 + go12;
                if (go12 == "0")
                {
                    bo11++;
                    go_index++;
                }
                if (go11 == "0" && go_index == 1)
                {
                    bo10++;
                    go_index++;
                }
                if (go10 == "0" && go_index == 2)
                {
                    bo9++;
                    go_index++;
                }
                if (go9 == "0" && go_index == 3)
                {
                    bo8++;
                    go_index++;
                }
                if (go8 == "0" && go_index == 4)
                {
                    bo7++;
                    go_index++;
                }
                if (go7 == "0" && go_index == 5)
                {
                    bo6++;
                    go_index++;
                }
                if (go6 == "0" && go_index == 6)
                {
                    bo5++;
                    go_index++;
                }
                if (go5 == "0" && go_index == 7)
                {
                    bo4++;
                    go_index++;
                }
                if (go4 == "0" && go_index == 8)
                {
                    bo3++;
                    go_index++;
                }
                if (go3 == "0" && go_index == 9)
                {
                    bo2++;
                    go_index++;
                }
                if (go2 == "0" && go_index == 10)
                {
                    bo1++;
                    go_index++;
                }
                if (go1 == "0" && go_index == 11)
                {
                    bo1 = 0;
                    bo2 = 0;
                    bo3 = 0;
                    bo4 = 0;
                    bo5 = 0;
                    bo6 = 0;
                    bo7 = 0;
                    bo8 = 0;
                    bo9 = 0;
                    bo10 = 0;
                    bo11 = 0;
                    bo12 = 0;
                    go_index = 0;
                }

                go12 = bo12.ToString();
                go11 = bo11.ToString();
                go10 = bo10.ToString();
                go9 = bo9.ToString();
                go8 = bo8.ToString();
                go7 = bo7.ToString();
                go6 = bo6.ToString();
                go5 = bo5.ToString();
                go4 = bo4.ToString();
                go3 = bo3.ToString();
                go2 = bo2.ToString();
                go1 = bo1.ToString();
            }
            string send_data = "products 생성";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        } // lot 작업시작시 product count 갯수 만큼 생성
        public void Proc_Pi_info(string[] receive_data_division, ref NetworkStream stream)
        {
            Pi_on = 1;
            PI.Pi p = new PI.Pi();
            p.Pi_lot_id = receive_data_division[2];
            p.Pi_prod_model = receive_data_division[3];
            p.Pi_prod_count = receive_data_division[4];
            p.Pi_line = receive_data_division[5];
            p.Pi_prod_color = receive_data_division[6];

            string send_data = "Pi정보 받음";
            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
            stream.Write(Response_Data, 0, Response_Data.Length);
        }

        public void Server_Pi()
        {
            server2.Start();
            fm.textBox1.Text = "Aria Project Server Open Pi";

            while (true)
            {

                TcpClient client = server2.AcceptTcpClient();

                ((IPEndPoint)client.Client.RemoteEndPoint).ToString();

                NetworkStream stream = client.GetStream();

                int length;
                string receive_data = null; // 클라이언트로부터 수신되는 값이 저장 될 변수
                string send_data = null; // 클라이언트에게 송신할 값이 저장 될 변수
                byte[] bytes = new byte[256];
                length = stream.Read(bytes, 0, bytes.Length);

                receive_data = "";

                receive_data = Encoding.Default.GetString(bytes, 0, length);// 데이터 수신

                fm.textBox2.Text = fm.textBox2.Text + receive_data + "pi에서 받은 값";

                send_data = "이상한값";
                byte[] Response_Data = Encoding.Default.GetBytes(send_data);
                stream.Write(Response_Data, 0, Response_Data.Length);
                fm.textBox3.Text = send_data + Req_User_Log_In.level;

            }
        } // Pi Server Open

        public void Server_Open()
        {
            server.Start();
            fm.textBox1.Text = "Aria Project Server Open";

            while (true)
            {

                TcpClient client = server.AcceptTcpClient();

                ((IPEndPoint)client.Client.RemoteEndPoint).ToString();

                NetworkStream stream = client.GetStream();

                int length;
                string receive_data = null; // 클라이언트로부터 수신되는 값이 저장 될 변수
                string send_data = null; // 클라이언트에게 송신할 값이 저장 될 변수
                byte[] bytes = new byte[1024];
                length = stream.Read(bytes, 0, bytes.Length); // 데이터 수신 (byte 형식으로)

                receive_data = ""; // 수신 될 값이 저장 될 string 변수
                try
                {
                    receive_data = Encoding.Default.GetString(bytes, 0, length); // byte 형식으로 받은 데이터를 string으로 변환
                fm.textBox2.Text = fm.textBox2.Text + receive_data; // 받은 데이터 textbox에 보여주기

                    if (receive_data.Substring(0, 2) == "{{")
                    {

                        int nLen = receive_data.Length; // 받은 data의 길이 nLen 변수에 저장
                        string sMsgBody = receive_data.Substring(3, nLen - 6); // receive_data 자르기
                        string[] receive_data_division = sMsgBody.Split(new char[] { ',' }); // receive_data , 기준으로 자르기


                        if (receive_data_division[1] == "req_user_log_in") // user_login 프로토콜
                        {
                            Proc_req_user_login(receive_data_division, ref stream);
                        }
                        //else if (receive_data_division[1] == "req_log_in") // 로그인 폼
                        //{
                        //    Proc_req_log_in(receive_data_division, ref stream);
                        //}                    
                        else if (receive_data_division[1] == "req_user_select") // 유저 검색
                        {
                            if (receive_data_division[2] == "0") // 유저 전체 검색
                            {
                                Proc_req_user_all_select(receive_data_division, ref stream);
                            }
                            else if (receive_data_division[2] == "1") // 유저 부분 검색
                            {
                                Proc_req_user_select(receive_data_division, ref stream);
                            }
                        }
                        else if (receive_data_division[1] == "req_user_update") // 유저 생성 & 유저 변경
                        {
                            if (receive_data_division[8] != "변경") // 유저 생성
                            {
                                Proc_req_user_create(receive_data_division, ref stream);
                            }
                            else if (receive_data_division[8] == "변경") // 유저 변경
                            {
                                Proc_req_user_update(receive_data_division, ref stream);
                            }
                        }
                        else if (receive_data_division[1] == "req_user_delete") // 유저 삭제
                        {
                            if (receive_data_division[2] == "전부 삭제") // 유저 전체 삭제
                            {
                                Proc_req_user_all_delete(receive_data_division, ref stream);
                            }
                            else // 유저 부분 삭제
                            {
                                Proc_req_user_delete(receive_data_division, ref stream);
                            }
                        }
                        else if (receive_data_division[1] == "req_model_select") // 모델 검색
                        {
                            if (receive_data_division[2] == "0") // 모델 전체 검색
                            {
                                Proc_req_model_all_select(receive_data_division, ref stream);
                            }
                            else if (receive_data_division[2] == "1") // 모델 부분 검색
                            {
                                Proc_req_model_select(receive_data_division, ref stream);
                            }
                        }
                        else if (receive_data_division[1] == "req_model_create") // 모델 생성 & 수정
                        {
                            Proc_req_model_create(receive_data_division, ref stream);
                        }
                        else if (receive_data_division[1] == "req_model_update")
                        {
                            Proc_req_model_updata(receive_data_division, ref stream);
                        }
                        else if (receive_data_division[1] == "req_model_delete") // 모델 삭제
                        {
                            Proc_req_model_delete(receive_data_division, ref stream);
                        }
                        // lot 관리
                        else if (receive_data_division[1] == "req_lot_select") // lot 전체 검색
                        {
                            Proc_req_lot_all_select(receive_data_division, ref stream);
                        }
                        else if (receive_data_division[1] == "req_lot_select1") // lot start 시간 update
                        {
                            Proc_req_lot_all_select1(receive_data_division, ref stream);
                        }
                        else if (receive_data_division[1] == "req_lot_update") // lot 생성 / 수정
                        {
                            Proc_req_lot_create(receive_data_division, ref stream);
                        }
                        else if (receive_data_division[1] == "req_lot_delete") // lot 삭제
                        {
                            Proc_req_lot_delete(receive_data_division, ref stream);
                        }

                        // 라인 관리
                        else if (receive_data_division[1] == "req_line_select") // 라인 검색
                        {

                        }
                        else if (receive_data_division[1] == "req_line_update") // 라인 생성, 수정
                        {
                            Proc_req_line_create(receive_data_division, ref stream);
                        }
                        else if (receive_data_division[1] == "req_line_delete") // 라인 삭제
                        {

                        }
                        else if (receive_data_division[1] == "req_products_update") // products 작업전 생성
                        {
                            Proc_req_products_create(receive_data_division, ref stream);
                        }
                        else if (receive_data_division[1] == "Pi_info") // pi에 보낼 정보 저장
                        {
                            Proc_Pi_info(receive_data_division, ref stream);
                        }
                        else
                        {
                            send_data = "이상한 값이 들어왔습니다.";
                            byte[] Response_Data = Encoding.Default.GetBytes(send_data);
                            stream.Write(Response_Data, 0, Response_Data.Length);
                        }
                        fm.textBox3.Text = send_data;
                    }

                    else if (receive_data.Substring(0,2) == "<S") // Pi 데이터가 들어왔을 시
                    {
                        MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(receive_data));
                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.Load(ms);
                        fm.textBox3.Text = receive_data + Req_User_Log_In.level;

                        string aa = "aa = " + xmldoc.DocumentElement.OuterXml;

                        byte[] Response_Data = Encoding.Default.GetBytes(aa);
                        stream.Write(Response_Data, 0, Response_Data.Length);
                        fm.textBox3.Text = aa + receive_data.Length;
                    }

                    else if (receive_data == "value = ?") // Pi에서 작업시작을 받는 부분
                    {
                        if (Pi_on != 1) // 클라이언트에서 작업을 보낼경우 1 아닐경우 0
                        {
                            string aa = "false";

                            byte[] Response_Data = Encoding.UTF8.GetBytes(aa);
                            stream.Write(Response_Data, 0, Response_Data.Length);
                            fm.textBox3.Text = aa;
                        }
                        else if (Pi_on == 1)
                        {
                            string aa = "true";

                            byte[] Response_Data = Encoding.UTF8.GetBytes(aa);
                            stream.Write(Response_Data, 0, Response_Data.Length);
                            fm.textBox3.Text = aa;
                        }
                    }
                }
                catch (Exception error)
                {
                    MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(receive_data));
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(ms);
                    fm.textBox3.Text = receive_data + Req_User_Log_In.level;

                    string aa = "aa = " + xmldoc.DocumentElement.OuterXml;

                    byte[] Response_Data = Encoding.Default.GetBytes(aa+"eeqeqe");
                    stream.Write(Response_Data, 0, Response_Data.Length);
                    fm.textBox3.Text = aa + receive_data.Length;
                    
                }

            }
            } // Client Server Open
        }
    }

