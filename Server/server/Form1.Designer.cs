﻿namespace server
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
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.richTextBox_connectedUsers = new System.Windows.Forms.RichTextBox();
            this.richTextBox_IF100Subscribers = new System.Windows.Forms.RichTextBox();
            this.richTextBox_SPS101Subscribers = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(211, 45);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(64, 20);
            this.textBox_port.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(287, 43);
            this.button_listen.Margin = new System.Windows.Forms.Padding(2);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(56, 22);
            this.button_listen.TabIndex = 2;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DiSUcord - Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Server Information:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Connected users:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Channel IF 100 Subcribers:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Channel SPS 101 Subscribers:";
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(21, 118);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(321, 161);
            this.logs.TabIndex = 18;
            this.logs.Text = "";
            // 
            // richTextBox_connectedUsers
            // 
            this.richTextBox_connectedUsers.Location = new System.Drawing.Point(368, 118);
            this.richTextBox_connectedUsers.Name = "richTextBox_connectedUsers";
            this.richTextBox_connectedUsers.ReadOnly = true;
            this.richTextBox_connectedUsers.Size = new System.Drawing.Size(160, 347);
            this.richTextBox_connectedUsers.TabIndex = 19;
            this.richTextBox_connectedUsers.Text = "";
            // 
            // richTextBox_IF100Subscribers
            // 
            this.richTextBox_IF100Subscribers.Location = new System.Drawing.Point(23, 309);
            this.richTextBox_IF100Subscribers.Name = "richTextBox_IF100Subscribers";
            this.richTextBox_IF100Subscribers.ReadOnly = true;
            this.richTextBox_IF100Subscribers.Size = new System.Drawing.Size(150, 156);
            this.richTextBox_IF100Subscribers.TabIndex = 20;
            this.richTextBox_IF100Subscribers.Text = "";
            // 
            // richTextBox_SPS101Subscribers
            // 
            this.richTextBox_SPS101Subscribers.Location = new System.Drawing.Point(193, 309);
            this.richTextBox_SPS101Subscribers.Name = "richTextBox_SPS101Subscribers";
            this.richTextBox_SPS101Subscribers.ReadOnly = true;
            this.richTextBox_SPS101Subscribers.Size = new System.Drawing.Size(150, 156);
            this.richTextBox_SPS101Subscribers.TabIndex = 21;
            this.richTextBox_SPS101Subscribers.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 477);
            this.Controls.Add(this.richTextBox_SPS101Subscribers);
            this.Controls.Add(this.richTextBox_IF100Subscribers);
            this.Controls.Add(this.richTextBox_connectedUsers);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_port);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.RichTextBox richTextBox_connectedUsers;
        private System.Windows.Forms.RichTextBox richTextBox_IF100Subscribers;
        private System.Windows.Forms.RichTextBox richTextBox_SPS101Subscribers;
    }
}

