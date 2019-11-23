using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_real_server.PI
{
    class Pi
    {
        public static int Ceid1_index { get; set; }
        public static int Ceid4_index { get; set; }
        public string Pi_lot_id { get; set; }
        public string Pi_model_name { get; set; }
        public string Pi_prod_count { get; set; }
        public string Pi_model_temp { get; set; }
        public string Pi_model_humid { get; set; }
        public string Pi_line { get; set; }
        public string Pi_prod_color { get; set; }
        public static string Product_number { get; set; }
        public static string Model_name { get; set; }
        public static string Prod_Percent { get; set; }
        public static string Result { get; set; }
        public static string Fail_reason { get; set; }
        public static string CV_move_state { get; set; }
        public static string Robot_gripper_state { get; set; }
        public static string temp { get; set; }
        public static string humid { get; set; }
    }
}
