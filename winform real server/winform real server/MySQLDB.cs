using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_real_server
{

    class MySQLDB
    {
        /// <summary>
        /// 검색
        /// </summary>
        public void Selection()
        {
            //MySqlConnection conn;
            //string strconn = "Server=192.168.111.226;Database=Aria;Uid=root;Pwd=1234;";
            //conn = new MySqlConnection(strconn);
            //conn.Open();
            //string strSelect = "SELECT * FROM TBL_MODEL;";//본인의 DB이름 
            //MySqlCommand cmd = new MySqlCommand(strSelect, conn);
            //MySqlDataReader rdr = cmd.ExecuteReader();
            //ArrayList model_all = new ArrayList();
            //string ad = "";

            //while (rdr.Read())
            //{
            //    Model dbmo = new Model();
            //    dbmo.f_mode_id = rdr["model_id"].ToString();
            //    dbmo.f_mode_temp = rdr["model_temp"].ToString();
            //    dbmo.f_mode_humidity = rdr["model_humidity"].ToString();
            //    dbmo.anam = rdr["aname"].ToString();
            //    model_all.Add(dbmo);
            //}
            //IEnumerator users_all = model_all.GetEnumerator();
            //while (users_all.MoveNext())
            //{
            //    Object obj = users_all.Current;
            //    Model dbmo = (Model)obj;

            //    ad = ad + dbmo.f_mode_id + dbmo.f_mode_temp + dbmo.f_mode_humidity + dbmo.anam + "\n";
            //}

            //Model.ada = ad;

        }


        /// <summary>
        /// 삽입
        /// </summary>
        /// <param name="user_id">아이디</param>
        /// <param name="pass_word">비밀번호</param>
        /// <param name="level">권한</param>
        /// <param name="e_mail">이메일</param>
        /// <param name="f_name">성</param>
        /// <param name="l_name">이름</param>
        public void Insert(string user_id, string pass_word, int level, string e_mail, string f_name, string l_name)
        {
            // MySQL 연결 객체
            MySqlConnection conn;
            string strconn = "Server=192.168.111.226;Database=Aria;Uid=root;Pwd=1234;";
            conn = new MySqlConnection(strconn);
            conn.Open();    // DB 연동

            // 쿼리문 - INSERT 삽입
            string SQL = $"INSERT INTO users VALUES(" +
                $"'{user_id}', '{pass_word}', '{level}', '{e_mail}', '{f_name}', '{l_name}')";

            // 데이터베이스 명령 수행
            MySqlCommand cmd = new MySqlCommand(SQL, conn);

            // ExecuteReader = SQL와 연결을 유지한 상태에서 한번에 한 레코드씩(Row) 데이터를 가져오는데 사용
            // ExecuteNonQuery = 데이터 삽입/삭제 시 사용
            cmd.ExecuteNonQuery();
            conn.Close();   // DB 종료
        }

        /// <summary>
        /// 수정(이름 기준)
        /// </summary>
        /// <param name="before_user_id">수정하기 전 이름</param>
        /// <param name="after_user_id">수정한 후 이름</param>
        public void Update(string before_user_id, string after_user_id)
        {
            // MySQL 연결 객체
            MySqlConnection conn;
            string strconn = "Server=192.168.111.226;Database=Aria;Uid=root;Pwd=1234;";
            conn = new MySqlConnection(strconn);
            conn.Open();    // DB 연동

            // 쿼리문 - UPDATE 수정
            string SQL = $"UPDATE users SET user_id = '{after_user_id}' WHERE user_id = '{before_user_id}'";

            // 데이터베이스 명령 수행
            MySqlCommand cmd = new MySqlCommand(SQL, conn);

            // ExecuteReader = SQL와 연결을 유지한 상태에서 한번에 한 레코드씩(Row) 데이터를 가져오는데 사용
            // ExecuteNonQuery = 데이터 삽입/삭제 시 사용
            cmd.ExecuteNonQuery();
            conn.Close();   // DB 종료

        }

        /// <summary>
        /// 삭제(이름 기준)
        /// </summary>
        /// <param name="user_id">이름</param>
        public void Delete(string user_id)
        {
            // MySQL 연결 객체
            MySqlConnection conn;
            string strconn = "Server=192.168.111.226;Database=Aria;Uid=root;Pwd=1234;";
            conn = new MySqlConnection(strconn);
            conn.Open();    // DB 연동

            // 쿼리문 - DELETE 삭제
            string SQL = $"DELETE FROM users WHERE user_id = '{user_id}'";
            // 데이터베이스 명령 수행
            MySqlCommand cmd = new MySqlCommand(SQL, conn);

            // ExecuteReader = SQL와 연결을 유지한 상태에서 한번에 한 레코드씩(Row) 데이터를 가져오는데 사용
            // ExecuteNonQuery = 데이터 삽입/삭제 시 사용
            cmd.ExecuteNonQuery();
            conn.Close();   // DB 종료
        }


    }
}
