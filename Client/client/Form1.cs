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
                    // First we try to connect and change the buttons (if username is duplicate user gets disconnected)
                    clientSocket.Connect(IP, portNum);
                    connected = true;
                    button_connect.Enabled = false;
                    button_disconnect.Enabled = true;
                    button_subscribeIF100.Enabled = true;
                    button_subscribeSPS101.Enabled = true;
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
                        logs.AppendText("Duplicate username, disconnecting from the server...\n");
                        button_connect.Enabled = true;
                        button_disconnect.Enabled = false;
                        button_subscribeSPS101.Enabled = false;
                        button_subscribeIF100.Enabled = false;
                        connected = false;
                    }
                    else
                    {             
                        // Handling recieved messages and assigning them the text box:
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
                    // If anything goes wrong we disconnect the user 
                    disconnect();
                }

            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // When we turn off the socket, Recieve function will iniate the disconnect function.
            clientSocket.Close();
            Environment.Exit(0);
        }

        private void disconnect()
        {       
            connected = false;
            button_connect.Enabled = true;
            button_disconnect.Enabled = false;

            // Setting the subscription buttons to default
            button_subscribeIF100.Enabled = false;
            button_subscribeSPS101.Enabled = false;
            button_unsubscribeIF100.Enabled = false;
            button_unsubscribeSPS101.Enabled = false;

            // We also need to make sure to disable the chat fields (similar to unsubscribe)
            textBox_messageIF100.Enabled = false;
            button_sendIF100.Enabled = false;
            textBox_messageSPS101.Enabled = false;
            button_sendSPS101.Enabled = false;

            clientSocket.Close();
            logs.AppendText("You have been disconnected.\n");
        }

        private void Convert_and_Send(string message)
        {
            // This function is implemented to make it easier to convert the strings and send it to the server
            if (message.Length <= 64)
            {
                byte[] messageBytes = Encoding.Default.GetBytes(message);
                try
                {
                    clientSocket.Send(messageBytes);
                }
                catch
                {
                    disconnect();
                }
            }       
        }

        private void button_sendSPS101_Click(object sender, EventArgs e)
        {
            // Room keyword added at the beginning of the message so that the server will understand which room we are sending it to
            string message = "SPS101" + textBox_messageSPS101.Text + "\n";
            Convert_and_Send(message);
            textBox_messageSPS101.Clear();
        }

        private void button_sendIF100_Click(object sender, EventArgs e)
        {
            // Room keyword added at the beginning of the message so that the server will understand which room we are sending it to
            string message = "IF100 " + textBox_messageIF100.Text + "\n";
            Convert_and_Send(message);
            textBox_messageIF100.Clear();
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            // When we close the socket Recieve function will enter the catch block and terminate the connection
            clientSocket.Close();
        }

        private void button_subscribeIF100_Click(object sender, EventArgs e)
        {
            // Special strings are used to subscribe or unsubscribe
            Convert_and_Send("Server, subscribe me to IF100");

            // Necessary button are arranged
            textBox_messageIF100.Enabled = true;
            button_sendIF100.Enabled = true;

            button_subscribeIF100.Enabled = false;
            button_unsubscribeIF100.Enabled = true;
            logs.AppendText("You've subscribed to channel IF100\n");
        }

        private void button_unsubscribeIF100_Click(object sender, EventArgs e)
        {
            Convert_and_Send("Server, unsubscribe me from IF100");

            textBox_messageIF100.Enabled = false;
            button_sendIF100.Enabled = false;

            button_subscribeIF100.Enabled = true;
            button_unsubscribeIF100.Enabled = false;
            logs.AppendText("You've unsubscribed from channel IF100\n");
        }

        private void buton_subscribeSPS101_Click(object sender, EventArgs e)
        {
            Convert_and_Send("Server, subscribe me to SPS101");
            // If cannot send the message, the code does not pass here
            textBox_messageSPS101.Enabled = true;
            button_sendSPS101.Enabled = true;

            button_subscribeSPS101.Enabled = false;
            button_unsubscribeSPS101.Enabled = true;
            logs.AppendText("You've subscribed to channel SPS101\n");
        }

        private void button_unsubscribeSPS101_Click(object sender, EventArgs e)
        {
            Convert_and_Send("Server, unsubscribe me from SPS101");

            textBox_messageSPS101.Enabled = false;
            button_sendSPS101.Enabled = false;

            button_subscribeSPS101.Enabled = true;
            button_unsubscribeSPS101.Enabled = false;
            logs.AppendText("You've unsubscribed from channel SPS101\n");
        }
    }
}
