using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Class
{
    class DB_TBL_LINE1
    {
        public string _Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Working_Lot { get; set; }
        public string Line_Temp { get; set; }
        public string Line_Humidity { get; set; }
        public string Lot_Reserve { get; set; }
        public static string Line1_All_Info { get; set; }

        public static List<string> List_Line1_Id = new List<string>();
        public static List<string> List_Name = new List<string>();
        public static List<string> List_State = new List<string>();
        public static List<string> List_Working_Lot = new List<string>();
        public static List<string> List_Line_Temp = new List<string>();
        public static List<string> List_Line_Humidity = new List<string>();
        public static List<string> List_Line_All_Info = new List<string>();

        public static string strconn = "Server=192.168.111.226;Database=Aria;Uid=root;Pwd=1234;"; // mysql 연동 변수
        public static MySqlConnection conn = new MySqlConnection(strconn); // mysql 연결 함수 conn 정의

        public static void Line1_Insert(string id, string aname, string state, string working_lot, string line_temp, string line_humidity) // Model Insert 메소드
        {
            conn.Open(); // Mysql Open
            string Line1_Insert_Sql = "INSERT INTO TBL_LINE (_id, aname, state, working_lot, line_temp, line_humidity) VALUES('" + id + "','" + aname + "','" + state + "','" + working_lot + "','"+line_temp+"','"+line_humidity+"');"; // Insert 쿼리문
            MySqlCommand Command_Line1_Insert = new MySqlCommand(Line1_Insert_Sql, conn); // Insert Command문
            Command_Line1_Insert.ExecuteNonQuery(); // Insert 실행
            conn.Close(); // mysql Close
        }
        public static void Line1_Name_Update(string aname, string change_name) // Model Update 메소드
        {
            conn.Open();
            string Line1_Name_Update_Sql = "update TBL_LINE set aname = '" + change_name + "' where aname = '" + aname + "';";
            MySqlCommand Command_Line1_Name_Update = new MySqlCommand(Line1_Name_Update_Sql, conn);
            Command_Line1_Name_Update.ExecuteNonQuery();
            conn.Close();
        }
        public static void Line1_State_Update_0(string _id) // Line1 State 작업중 메소드
        {
            conn.Open();
            string Line1_State_Update_Sql0 = "update TBL_LINE set state = '작업중' where _id = '" + _id + "';";
            MySqlCommand Command_Line1_State_Update0 = new MySqlCommand(Line1_State_Update_Sql0, conn);
            Command_Line1_State_Update0.ExecuteNonQuery();
            conn.Close();
        }
        public static void Line1_State_Update_1(string _id) // Line1 State 대기중 메소드
        {
            conn.Open();
            string Line1_State_Update_Sql1 = "update TBL_LINE set state = '대기중' where _id = '" + _id + "';";
            MySqlCommand Command_Line1_State_Update1 = new MySqlCommand(Line1_State_Update_Sql1, conn);
            Command_Line1_State_Update1.ExecuteNonQuery();
            conn.Close();
        }
        public static void Line1_State_Update_2(string _id) // Line1 State 정비중 메소드
        {
            conn.Open();
            string Line1_State_Update_Sql2 = "update TBL_LINE set state = '정비중' where _id = '" + _id + "';";
            MySqlCommand Command_Line1_State_Update2 = new MySqlCommand(Line1_State_Update_Sql2, conn);
            Command_Line1_State_Update2.ExecuteNonQuery();
            conn.Close();
        }
        public static void Line1_Working_Lot_Update(string _id, string working_lot) // Line1 Working Lot Lot Start, End 시점에 업데이트 메소드
        {
            conn.Open();
            string Line1_Working_Lot_Update_Sql = "update TBL_LINE set working_lot = '" + working_lot + "' where _id = '" + _id + "';";
            MySqlCommand Command_Line1_Working_Lot_Update = new MySqlCommand(Line1_Working_Lot_Update_Sql, conn);
            Command_Line1_Working_Lot_Update.ExecuteNonQuery();
            conn.Close();
        }
        public static void Line1_temp_humid_Update(string temp, string humidity, string _id) // Line1 temp, humditiy 10초마다 업데이트 메소드
        {
            conn.Open();
            string Line1_temp_humid_Update_Sql = "update TBL_LINE set line_temp = '"+temp+"', line_humidity = '"+humidity+"' where _id = '" + _id + "';";
            MySqlCommand Command_Line1_temp_humid_Update = new MySqlCommand(Line1_temp_humid_Update_Sql, conn);
            Command_Line1_temp_humid_Update.ExecuteNonQuery();
            conn.Close();
        }
        public static void Line1_Lot_Reserve_Update(string _id, string reserve) // Line1 temp, humditiy 10초마다 업데이트 메소드
        {
            conn.Open();
            string Line1_temp_humid_Update_Sql = "update TBL_LINE set lot_reserve = '" + reserve + "' where _id = '" + _id + "';";
            MySqlCommand Command_Line1_temp_humid_Update = new MySqlCommand(Line1_temp_humid_Update_Sql, conn);
            Command_Line1_temp_humid_Update.ExecuteNonQuery();
            conn.Close();
        }
        public static void Line1_Delete(string _id) // Model Delete 메소드
        {
            conn.Open();
            string Line1_Delete_Sql = "delete from TBL_LINE where _id = " + _id + ";";
            MySqlCommand Command_Line1_Delete = new MySqlCommand(Line1_Delete_Sql, conn);
            Command_Line1_Delete.ExecuteNonQuery();
            conn.Close();
        }

        public static void Line1_All_Select()
        {
            Line1_All_Info = "";
            List_Line1_Id.RemoveRange(0, List_Line1_Id.Count);
            List_Name.RemoveRange(0, List_Name.Count);
            List_State.RemoveRange(0, List_State.Count);
            List_Working_Lot.RemoveRange(0, List_Working_Lot.Count);
            List_Line_Temp.RemoveRange(0, List_Line_Temp.Count);
            List_Line_Humidity.RemoveRange(0, List_Line_Humidity.Count);
            List_Line_All_Info.RemoveRange(0, List_Line_All_Info.Count);
            conn.Open();
            string Line1_All_Select_Sql = "SELECT * FROM TBL_LINE;";
            MySqlCommand Command_Line1_All_Select = new MySqlCommand(Line1_All_Select_Sql, conn);
            MySqlDataReader Reader_Line1_All_Select = Command_Line1_All_Select.ExecuteReader(); 
            ArrayList Arraylist_Line1_Select = new ArrayList();

            while (Reader_Line1_All_Select.Read()) 
            {
                DB_TBL_LINE1 Line1_Select = new DB_TBL_LINE1(); 
                Line1_Select._Id =              Reader_Line1_All_Select["_id"].ToString(); 
                Line1_Select.Name =             Reader_Line1_All_Select["aname"].ToString(); 
                Line1_Select.State =            Reader_Line1_All_Select["state"].ToString(); 
                Line1_Select.Working_Lot =      Reader_Line1_All_Select["working_lot"].ToString();
                Line1_Select.Line_Temp =        Reader_Line1_All_Select["line_temp"].ToString();
                Line1_Select.Line_Humidity =    Reader_Line1_All_Select["line_humidity"].ToString();
                Line1_Select.Lot_Reserve =      Reader_Line1_All_Select["lot_reserve"].ToString();

                List_Line1_Id.Add(Line1_Select._Id); // 불러온 model_id 리스트에 담기
                List_Name.Add(Line1_Select.Name); // 불러온 model_temp 리스트에 담기
                List_State.Add(Line1_Select.State); // 불러온 model_humidity 리스트에 댐기
                List_Working_Lot.Add(Line1_Select.Working_Lot); // 불러온 aname 리스트에 담기
                List_Line_Temp.Add(Line1_Select.Line_Temp); // 불러온 model_temp 리스트에 담기
                List_Line_Humidity.Add(Line1_Select.Line_Humidity); // 불러온 model_humidity 리스트에 댐기
                List_Line_All_Info.Add(Line1_Select.Lot_Reserve); // 불러온 aname 리스트에 담기

                Arraylist_Line1_Select.Add(Line1_Select); // 모든 정보 ArrayList 담기
            }
            int IndexA = 0;
            IEnumerator LINE1_ALL = Arraylist_Line1_Select.GetEnumerator(); // ArrayList를 반복 할 수 있도록 함.
            while (LINE1_ALL.MoveNext())
            {
                IndexA++;
                Object obj                  = LINE1_ALL.Current;
                DB_TBL_LINE1 Line1_Select   = (DB_TBL_LINE1)obj;
                if (IndexA == Arraylist_Line1_Select.Count)
                {
                    Line1_All_Info = Line1_All_Info + Line1_Select._Id + "\t" + Line1_Select.Name + "\t" + Line1_Select.State + "\t" + Line1_Select.Working_Lot + "\t" + Line1_Select.Line_Temp + "\t" + Line1_Select.Line_Humidity + "\t" + Line1_Select.Lot_Reserve;
                }
                else
                {
                    Line1_All_Info = Line1_All_Info + Line1_Select._Id + "\t" + Line1_Select.Name + "\t" + Line1_Select.State + "\t" + Line1_Select.Working_Lot + "\t" + Line1_Select.Line_Temp + "\t" + Line1_Select.Line_Humidity + "\t" + Line1_Select.Lot_Reserve + "\n";
                } 
            }
            conn.Close();
        }
        public static void Line1_Select(String _id) // Model 선택 검색 메소드
        {
            string[] String_List_Line1_All = Line1_All_Info.Split(new char[] { '\n' }); // List_Model_All_Info 문자열을 , 기준으로 나누어서 배열에 적재

            int Index_i = 0; // foreach에서 증가값 변수
            int Index_e = 0; // 선택한 문자가 리스트의 몇번째인지 찾는 변수
            foreach (string number in List_Line1_Id) // Model_Id_Info 리스트 반복
            {
                if (number == _id) // 선택값과 User_id가 같은지 판단
                {
                    Index_e = Index_i; // 같을 시 Index_e에 Index_i값 저장
                }
                Index_i++; // Index_i 증가
            }
            Console.WriteLine(String_List_Line1_All[Index_e]); // 찾은 Index_e번째 리스트 불러오기
        }
    }
}
