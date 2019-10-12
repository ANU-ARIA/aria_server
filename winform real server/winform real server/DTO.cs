using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_real_server
{
    class DTO
    {
        /// <summary>
        /// user DTO(Data Transfer Object) - 데이터 객체
        /// </summary>
        public class users
        {
            public string user_id { get; set; }
            public string pass_word { get; set; }
            public string e_mail { get; set; }
            public string level { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
        }
    }
}
