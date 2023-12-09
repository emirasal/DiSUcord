﻿using System;
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
                    connected = true;
                    button_connect.Enabled = false;
                    button_disconnect.Enabled = true;
                    checkBox_IF100.Enabled = true;
                    checkBox_SPS101.Enabled = true;
                    logs.AppendText("You have connected to the server!\n");

                    // Sending the Username
                    username = textBox_username.Text;
                    byte[] usernameData = Encoding.ASCII.GetBytes(username);
                    clientSocket.Send(usernameData);

                    // Inside the thread first we will check for the duplicate username
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

                    // Checking for duplicate usernames first
                    if (incomingMessage == "Duplicate username")
                    {
                        logs.AppendText("Duplicate username, disconnecting from the server");
                        button_connect.Enabled = true;
                        button_disconnect.Enabled = false;
                        checkBox_IF100.Enabled = false;
                        checkBox_SPS101.Enabled = false;
                        connected = false;
                    }
                    else
                    {             
                        // Handling recieved messages:

                        string roomName = incomingMessage.Substring(0, 6);
                        string message = incomingMessage.Substring(6);
                        // Distingusing between channels after the message is recieved
                        if (roomName == "SPS101")
                        {
                            richTextBox_SPS101.AppendText(message);
                        }
                        else
                        {
                            richTextBox_IF100.AppendText(message);
                        }
                    }
                    
                }
                catch
                {
                    disconnect();
                }

            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // First we let the server know we are disconnecting
            disconnect();

            terminating = true;
            Environment.Exit(0);
        }

        private void disconnect()
        {
            Convert_and_Send("Server, disconnect me");
            connected = false;
            button_connect.Enabled = true;
            button_disconnect.Enabled = false;
            checkBox_IF100.Enabled = false;
            checkBox_SPS101.Enabled = false;

            // We also need to make sure to disable the chat fields (similar to unsubscribe)
            textBox_messageIF100.Enabled = false;
            button_sendIF100.Enabled = false;
            textBox_messageSPS101.Enabled = false;
            button_sendSPS101.Enabled = false;

            // Unchecking the subscribtion boxes if necessray
            checkBox_IF100.Checked = false;
            checkBox_SPS101.Checked = false;

            clientSocket.Close();
            logs.AppendText("You have been disconnected.\n");
        }

        private bool Convert_and_Send(string message)
        {
            if (message.Length <= 64)
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
                }
            }
            return false;
            
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
            Convert_and_Send(message);
            textBox_messageSPS101.Clear();

        }

        private void button_sendIF100_Click(object sender, EventArgs e)
        {
            string message = "IF100 " + textBox_messageIF100.Text + "\n";
            Convert_and_Send(message);
            textBox_messageIF100.Clear();
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            disconnect();
        }
    }
}
