<<<<<<< HEAD
﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aria_project_server
{
    class USERS
    {
        public string user_id { set; get; }
        public string pass_word { set; get; }
        public int level { set; get; }
        public string e_mail { set; get; }
        public string first_name { set; get; }
        public string last_name { set; get; }

    }

    public class TBL_PRODUCTS
    {
        public string Lot_id { set; get; }
        public int Model { set; get; }
        public string Line_id { set; get; }
        public int Total_product_count { set; get; }
        public int Product_speed_warn { set; get; }
        public float Product_fail_rate_warn { set; get; }
        public string Product_color { set; get; }
        public float Temp_margin { set; get; }
        public float Humid_margin { set; get; }
        public string Oper_id { set; get; }
        public int Working_state { set; get; }
        public int Lot_created_time { set; get; }
        public int Lot_start_time { set; get; }
        public int Lot_end_time { set; get; }
    }

    public class TBL_MODEL
    {
        public int Model_id { set; get; }
        public float Model_temp { set; get; }
        public float Model_humidity { set; get; }
        public string Aname { set; get; }
    }

    public class TBL_LOT
    {
        private static string Lot_id;
        public int Model_id { set; get; }
        public string Line_id { set; get; }
        public int Total_product_count { set; get; }
        public int Product_speed_warn { set; get; }
        public float Product_fail_rate_warn { set; get; }
        public string Product_color { set; get; }
        public float Temp_margin { set; get; }
        public float Humid_margin { set; get; }
        public string Oper_id { set; get; }
        public int Working_state { set; get; }
        public int Lot_created_time { set; get; }
        public int Lot_start_time { set; get; }
        public int Lot_end_time { set; get; }
    }

    public class TBL_LINE
    {
        public int _Id { set; get; }
        public string Aname { set; get; }
        public string State { set; get; }
        public string Working_lot { set; get; }
        public float Line_temp { set; get; }
        public float Line_humidity { set; get; }
    }

    public class TBL_LINE2
    {
        public int _Id { set; get; }
        public string Aname { set; get; }
        public string State { set; get; }
        public string Working_lot { set; get; }
        public float Line_temp { set; get; }
        public float Line_humidity { set; get; }
    }

    class CDbMgr
    {
        // 접속관리
        public MySqlConnection Connection()
        {
            MySqlConnection conn;
            string strconn = "Server=192.168.111.226;Database=Aria;Uid=root;Pwd=1234;";
            conn = new MySqlConnection(strconn);
            conn.Open();
            return conn;
            
        }
        /// <summary>
        /// 접속 해제
        /// </summary>
        /// <param name="conn">MySQL연결 함수 객체</param>
        public void disConnect(MySqlConnection conn)
        {
            // 접속 해제
            conn.Close();
        }
        // 테이블관리
        // USERR
    }


    class USER_SET
    {
        public void DB_USERS_INS()
        {
            MySqlConnection conn;
            string strconn = "Server=192.168.111.226;Database=Aria;Uid=root;Pwd=1234;";
            conn = new MySqlConnection(strconn);
            conn.Open();
            string SQL = "INSERT INTO USERS values('m2','123',1,'3@e','3','3');";
            MySqlCommand cmd = new MySqlCommand(SQL, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public string DB_USERS_SEL(string user_id)
        {
            // select * from USERS where id = "user_id";
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public string DB_USERS_DEL(string user_id)
        {
            return "";
        }

        public string DB_USERS_UP(string user_id)
        {
            return "";
        }
        // TBL_PRODUCTS
        // TBL_MODEL
        // TBL_LOT
        // LINE

        public string Login_Form(string user_id, string user_pw)
        {
            return "no, 1, 2, 비밀번호가 틀렸습니다";
        }
    }
}

=======
﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aria_project_server
{
    class USERS
    {
        public string user_id { set; get; }
        public string pass_word { set; get; }
        public int level { set; get; }
        public string e_mail { set; get; }
        public string first_name { set; get; }
        public string last_name { set; get; }

    }

    public class TBL_PRODUCTS
    {
        public string Lot_id { set; get; }
        public int Model { set; get; }
        public string Line_id { set; get; }
        public int Total_product_count { set; get; }
        public int Product_speed_warn { set; get; }
        public float Product_fail_rate_warn { set; get; }
        public string Product_color { set; get; }
        public float Temp_margin { set; get; }
        public float Humid_margin { set; get; }
        public string Oper_id { set; get; }
        public int Working_state { set; get; }
        public int Lot_created_time { set; get; }
        public int Lot_start_time { set; get; }
        public int Lot_end_time { set; get; }
    }

    public class TBL_MODEL
    {
        public int Model_id { set; get; }
        public float Model_temp { set; get; }
        public float Model_humidity { set; get; }
        public string Aname { set; get; }
    }

    public class TBL_LOT
    {
        public string Lot_id;
        public int Model_id { set; get; }
        public string Line_id { set; get; }
        public int Total_product_count { set; get; }
        public int Product_speed_warn { set; get; }
        public float Product_fail_rate_warn { set; get; }
        public string Product_color { set; get; }
        public float Temp_margin { set; get; }
        public float Humid_margin { set; get; }
        public string Oper_id { set; get; }
        public int Working_state { set; get; }
        public int Lot_created_time { set; get; }
        public int Lot_start_time { set; get; }
        public int Lot_end_time { set; get; }
    }

    public class TBL_LINE
    {
        public int _Id { set; get; }
        public string Aname { set; get; }
        public string State { set; get; }
        public string Working_lot { set; get; }
        public float Line_temp { set; get; }
        public float Line_humidity { set; get; }
    }

    public class TBL_LINE2
    {
        public int _Id { set; get; }
        public string Aname { set; get; }
        public string State { set; get; }
        public string Working_lot { set; get; }
        public float Line_temp { set; get; }
        public float Line_humidity { set; get; }
    }

    class CDbMgr
    {
        // 접속관리
        public MySqlConnection Connection()
        {
            MySqlConnection conn;
            string strconn = "Server=192.168.111.226;Database=Aria;Uid=root;Pwd=1234;";
            conn = new MySqlConnection(strconn);
            conn.Open();
            return conn;
            
        }
        /// <summary>
        /// 접속 해제
        /// </summary>
        /// <param name="conn">MySQL연결 함수 객체</param>
        public void disConnect(MySqlConnection conn)
        {
            // 접속 해제
            conn.Close();
        }
        // 테이블관리
        // USERR
    }


    class USER_SET
    {
        public void DB_USERS_INS()
        {
            MySqlConnection conn;
            string strconn = "Server=192.168.111.226;Database=Aria;Uid=root;Pwd=1234;";
            conn = new MySqlConnection(strconn);
            conn.Open();
            string SQL = "INSERT INTO USERS values('m2','123',1,'3@e','3','3');";
            MySqlCommand cmd = new MySqlCommand(SQL, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public string DB_USERS_SEL(string user_id)
        {
            // select * from USERS where id = "user_id";
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public string DB_USERS_DEL(string user_id)
        {
            return "";
        }

        public string DB_USERS_UP(string user_id)
        {
            return "";
        }
        // TBL_PRODUCTS
        // TBL_MODEL
        // TBL_LOT
        // LINE

        public string Login_Form(string user_id, string user_pw)
        {
            return "no, 1, 2, 비밀번호가 틀렸습니다";
        }
    }
}

>>>>>>> 8fcdb440467b3c6c2b1a84567e6bd7f35a6dc628
