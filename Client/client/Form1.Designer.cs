namespace client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.richTextBox_IF100 = new System.Windows.Forms.RichTextBox();
            this.textBox_messageIF100 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox_SPS101 = new System.Windows.Forms.RichTextBox();
            this.checkBox_IF100 = new System.Windows.Forms.CheckBox();
            this.checkBox_SPS101 = new System.Windows.Forms.CheckBox();
            this.button_sendSPS101 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_messageSPS101 = new System.Windows.Forms.TextBox();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_sendIF100 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(86, 42);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(100, 20);
            this.textBox_ip.TabIndex = 2;
            this.textBox_ip.TextChanged += new System.EventHandler(this.textBox_ip_TextChanged);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(86, 78);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(100, 20);
            this.textBox_port.TabIndex = 3;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(288, 78);
            this.button_connect.Margin = new System.Windows.Forms.Padding(2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(70, 22);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // richTextBox_IF100
            // 
            this.richTextBox_IF100.Location = new System.Drawing.Point(33, 207);
            this.richTextBox_IF100.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_IF100.Name = "richTextBox_IF100";
            this.richTextBox_IF100.Size = new System.Drawing.Size(232, 261);
            this.richTextBox_IF100.TabIndex = 5;
            this.richTextBox_IF100.Text = "";
            // 
            // textBox_messageIF100
            // 
            this.textBox_messageIF100.Enabled = false;
            this.textBox_messageIF100.Location = new System.Drawing.Point(87, 492);
            this.textBox_messageIF100.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_messageIF100.Name = "textBox_messageIF100";
            this.textBox_messageIF100.Size = new System.Drawing.Size(109, 20);
            this.textBox_messageIF100.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 495);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "DiSUcord - Client";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Username:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(288, 42);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 20);
            this.textBox_username.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Channel IF 100";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Channel SPS 101";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // richTextBox_SPS101
            // 
            this.richTextBox_SPS101.Location = new System.Drawing.Point(326, 207);
            this.richTextBox_SPS101.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_SPS101.Name = "richTextBox_SPS101";
            this.richTextBox_SPS101.Size = new System.Drawing.Size(236, 261);
            this.richTextBox_SPS101.TabIndex = 14;
            this.richTextBox_SPS101.Text = "";
            // 
            // checkBox_IF100
            // 
            this.checkBox_IF100.AutoSize = true;
            this.checkBox_IF100.Enabled = false;
            this.checkBox_IF100.Location = new System.Drawing.Point(51, 185);
            this.checkBox_IF100.Name = "checkBox_IF100";
            this.checkBox_IF100.Size = new System.Drawing.Size(73, 17);
            this.checkBox_IF100.TabIndex = 15;
            this.checkBox_IF100.Text = "Subscribe";
            this.checkBox_IF100.UseVisualStyleBackColor = true;
            this.checkBox_IF100.CheckedChanged += new System.EventHandler(this.checkBox_IF100_CheckedChanged);
            // 
            // checkBox_SPS101
            // 
            this.checkBox_SPS101.AutoSize = true;
            this.checkBox_SPS101.Enabled = false;
            this.checkBox_SPS101.Location = new System.Drawing.Point(340, 185);
            this.checkBox_SPS101.Name = "checkBox_SPS101";
            this.checkBox_SPS101.Size = new System.Drawing.Size(73, 17);
            this.checkBox_SPS101.TabIndex = 16;
            this.checkBox_SPS101.Text = "Subscribe";
            this.checkBox_SPS101.UseVisualStyleBackColor = true;
            this.checkBox_SPS101.CheckedChanged += new System.EventHandler(this.checkBox_SPS101_CheckedChanged);
            // 
            // button_sendSPS101
            // 
            this.button_sendSPS101.Enabled = false;
            this.button_sendSPS101.Location = new System.Drawing.Point(497, 487);
            this.button_sendSPS101.Margin = new System.Windows.Forms.Padding(2);
            this.button_sendSPS101.Name = "button_sendSPS101";
            this.button_sendSPS101.Size = new System.Drawing.Size(65, 21);
            this.button_sendSPS101.TabIndex = 19;
            this.button_sendSPS101.Text = "send";
            this.button_sendSPS101.UseVisualStyleBackColor = true;
            this.button_sendSPS101.Click += new System.EventHandler(this.button_sendSPS101_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 491);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Message:";
            // 
            // textBox_messageSPS101
            // 
            this.textBox_messageSPS101.Enabled = false;
            this.textBox_messageSPS101.Location = new System.Drawing.Point(384, 488);
            this.textBox_messageSPS101.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_messageSPS101.Name = "textBox_messageSPS101";
            this.textBox_messageSPS101.Size = new System.Drawing.Size(109, 20);
            this.textBox_messageSPS101.TabIndex = 17;
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(424, 44);
            this.logs.Margin = new System.Windows.Forms.Padding(2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(129, 81);
            this.logs.TabIndex = 20;
            this.logs.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(421, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Status:";
            this.label9.Click += new System.EventHandler(this.label9_Click_1);
            // 
            // button_sendIF100
            // 
            this.button_sendIF100.Enabled = false;
            this.button_sendIF100.Location = new System.Drawing.Point(200, 492);
            this.button_sendIF100.Margin = new System.Windows.Forms.Padding(2);
            this.button_sendIF100.Name = "button_sendIF100";
            this.button_sendIF100.Size = new System.Drawing.Size(65, 21);
            this.button_sendIF100.TabIndex = 22;
            this.button_sendIF100.Text = "send";
            this.button_sendIF100.UseVisualStyleBackColor = true;
            this.button_sendIF100.Click += new System.EventHandler(this.button_sendIF100_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 533);
            this.Controls.Add(this.button_sendIF100);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_sendSPS101);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_messageSPS101);
            this.Controls.Add(this.checkBox_SPS101);
            this.Controls.Add(this.checkBox_IF100);
            this.Controls.Add(this.richTextBox_SPS101);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_messageIF100);
            this.Controls.Add(this.richTextBox_IF100);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox richTextBox_IF100;
        private System.Windows.Forms.TextBox textBox_messageIF100;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox_SPS101;
        private System.Windows.Forms.CheckBox checkBox_IF100;
        private System.Windows.Forms.CheckBox checkBox_SPS101;
        private System.Windows.Forms.Button button_sendSPS101;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_messageSPS101;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_sendIF100;
    }
}

