<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aria_project_Server_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USER_SET u = new USER_SET();
            u.DB_USERS_INS();
            label1.Text = textBox1.Text+""+textBox2.Text+""+textBox3.Text+""+textBox4.Text+""+textBox5.Text+""+textBox6.Text;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aria_project_Server_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USER_SET u = new USER_SET();
            u.DB_USERS_INS(textBox1.Text,textBox2.Text,textBox4.Text,textBox5.Text,textBox6.Text);
        }
    }
}
>>>>>>> 8fcdb440467b3c6c2b1a84567e6bd7f35a6dc628