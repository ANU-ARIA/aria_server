namespace winform_real_server
{
    partial class fmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btn_send_s2f41 = new System.Windows.Forms.Button();
            this.btn_send_s6f12 = new System.Windows.Forms.Button();
            this.btn_receive_s2f42 = new System.Windows.Forms.Button();
            this.btn_receive_s6f11 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 39);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(434, 353);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(546, 71);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(245, 321);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(915, 71);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(245, 321);
            this.textBox3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(625, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(866, 446);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(317, 189);
            this.textBox4.TabIndex = 4;
            // 
            // btn_send_s2f41
            // 
            this.btn_send_s2f41.Location = new System.Drawing.Point(97, 435);
            this.btn_send_s2f41.Name = "btn_send_s2f41";
            this.btn_send_s2f41.Size = new System.Drawing.Size(155, 73);
            this.btn_send_s2f41.TabIndex = 5;
            this.btn_send_s2f41.Text = "send s2f41";
            this.btn_send_s2f41.UseVisualStyleBackColor = true;
            this.btn_send_s2f41.Click += new System.EventHandler(this.btn_send_s2f41_Click);
            // 
            // btn_send_s6f12
            // 
            this.btn_send_s6f12.Location = new System.Drawing.Point(97, 539);
            this.btn_send_s6f12.Name = "btn_send_s6f12";
            this.btn_send_s6f12.Size = new System.Drawing.Size(155, 73);
            this.btn_send_s6f12.TabIndex = 6;
            this.btn_send_s6f12.Text = "send s6f12";
            this.btn_send_s6f12.UseVisualStyleBackColor = true;
            this.btn_send_s6f12.Click += new System.EventHandler(this.btn_send_s6f12_Click);
            // 
            // btn_receive_s2f42
            // 
            this.btn_receive_s2f42.Location = new System.Drawing.Point(326, 435);
            this.btn_receive_s2f42.Name = "btn_receive_s2f42";
            this.btn_receive_s2f42.Size = new System.Drawing.Size(155, 73);
            this.btn_receive_s2f42.TabIndex = 7;
            this.btn_receive_s2f42.Text = "receive s2f42";
            this.btn_receive_s2f42.UseVisualStyleBackColor = true;
            this.btn_receive_s2f42.Click += new System.EventHandler(this.btn_receive_s2f42_Click);
            // 
            // btn_receive_s6f11
            // 
            this.btn_receive_s6f11.Location = new System.Drawing.Point(326, 539);
            this.btn_receive_s6f11.Name = "btn_receive_s6f11";
            this.btn_receive_s6f11.Size = new System.Drawing.Size(155, 73);
            this.btn_receive_s6f11.TabIndex = 8;
            this.btn_receive_s6f11.Text = "receive s6f11";
            this.btn_receive_s6f11.UseVisualStyleBackColor = true;
            this.btn_receive_s6f11.Click += new System.EventHandler(this.btn_receive_s6f11_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 690);
            this.Controls.Add(this.btn_receive_s6f11);
            this.Controls.Add(this.btn_receive_s2f42);
            this.Controls.Add(this.btn_send_s6f12);
            this.Controls.Add(this.btn_send_s2f41);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "fmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btn_send_s2f41;
        private System.Windows.Forms.Button btn_send_s6f12;
        private System.Windows.Forms.Button btn_receive_s2f42;
        private System.Windows.Forms.Button btn_receive_s6f11;
    }
}

