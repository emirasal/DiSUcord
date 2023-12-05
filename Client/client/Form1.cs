using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {

        bool terminating = false;
        bool connected = false;
        Socket clientSocket;
        string username;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_ip.Text;

            int portNum;
            if(Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    button_connect.Enabled = false;
                    
                    
                    connected = true;
                    checkBox_IF100.Enabled = true;
                    checkBox_SPS101.Enabled = true;
                    logs.AppendText("Connected to the server!\n");

                    // Sending Username
                    username = textBox_username.Text;
                    byte[] usernameData = Encoding.ASCII.GetBytes(username);
                    clientSocket.Send(usernameData);

                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();

                }
                catch
                {
                    logs.AppendText("Could not connect to the server!\n");
                }
            }
            else
            {
                logs.AppendText("Check the port\n");
            }

        }

        private void Receive()
        {
            while(connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    string roomName = incomingMessage.Substring(0, 6);
                    string message = incomingMessage.Substring(6);
                    // Distingusing between channels after the message is recieved
                    logs.AppendText(roomName);
                    if (roomName == "SPS101")
                    {
                        richTextBox_SPS101.AppendText(message);
                    } else
                    {
                        richTextBox_IF100.AppendText(message);
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("The server has disconnected\n");
                        button_connect.Enabled = true;
                        textBox_messageIF100.Enabled = false;
                        button_sendIF100.Enabled = false;
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private bool Convert_and_Send(string message)
        {
            byte[] messageBytes = Encoding.Default.GetBytes(message);
            try
            {
                clientSocket.Send(messageBytes);
                return true;
            }
            catch
            {
                logs.AppendText("Server Error\n");
                return false;
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox_ip_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label_disconnected_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox_IF100_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                if (Convert_and_Send("Server, subscribe me to IF100"))
                {
                    textBox_messageIF100.Enabled = true;
                    button_sendIF100.Enabled = true;
                    logs.AppendText("You've subscribed to channel IF100\n");
                }
                else checkBox.Checked = false;
            }   
            else
            {
                if (Convert_and_Send("Server, unsubscribe me from IF100"))
                {
                    textBox_messageIF100.Enabled = false;
                    button_sendIF100.Enabled = false;
                    logs.AppendText("You've unsubscribed from channel IF100\n");
                }
                else checkBox.Checked = true;
            }
        }

        private void checkBox_SPS101_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                if (Convert_and_Send("Server, subscribe me to SPS101"))
                {
                    textBox_messageSPS101.Enabled = true;
                    button_sendSPS101.Enabled = true;
                    logs.AppendText("You've subscribed to channel SPS101\n");
                }
                else checkBox.Checked = false;
            }
            else
            {
                if (Convert_and_Send("Server, unsubscribe me from SPS101"))
                {
                    textBox_messageSPS101.Enabled = false;
                    button_sendSPS101.Enabled = false;
                    logs.AppendText("You've unsubscribed from channel SPS101\n");
                }
                else checkBox.Checked = true;
            }
        }

        private void button_sendSPS101_Click(object sender, EventArgs e)
        {
            string message = "SPS101" + textBox_messageSPS101.Text + "\n";
            
            if (message != "" && message.Length <= 64)
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
        }

        private void button_sendIF100_Click(object sender, EventArgs e)
        {
            string message = "IF100 " + textBox_messageIF100.Text + "\n";

            if (message != "" && message.Length <= 64)
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
        }
    }
}
