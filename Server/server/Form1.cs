using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        struct User
        {
            public string username;
            public Socket socket;
        }

        List<User> connectedUsers = new List<User>();
        List<User> IF100Subscribers = new List<User>();
        List<User> SPS101Subscribers = new List<User>();

        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private bool Convert_and_Send(Socket socket, string message)
        {
            byte[] messageBytes = Encoding.Default.GetBytes(message);
            try
            {
                socket.Send(messageBytes);
                return true;
            }
            catch
            {
                logs.AppendText("There is a problem! Check the connection...\n");
                terminating = true;
                textBox_port.Enabled = true;
                button_listen.Enabled = true;
                serverSocket.Close();
                return false;
            }
        }

        private void Display_Username_List(List<User> users, RichTextBox textBox)
        {
            textBox.Clear();
            foreach (User user in users)
            {
                textBox.AppendText(user.username + "\n");
            }
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if(Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                logs.AppendText("Please check port number! \n");
            }
        }

        private void Accept()
        {
            while(listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    

                    // Receiving the username
                    byte[] usernameBuffer = new byte[newClient.SendBufferSize];
                    int usernameBytes = newClient.Receive(usernameBuffer);
                    string name = Encoding.Default.GetString(usernameBuffer, 0, usernameBytes);

                    // Checking for duplicate usernames
                    if (connectedUsers.Any(user => user.username == name))
                    {
                        // name is in the list (Problem)
                        Convert_and_Send(newClient, "Duplicate username");
                    }
                    else
                    {
                        // name is not in the list
                        logs.AppendText("User connected: " + name + "\n");
                        User newUser = new User { socket = newClient, username = name };
                        connectedUsers.Add(newUser);

                        Thread receiveThread = new Thread(() => Receive(newUser));
                        receiveThread.Start();

                        // Updating the connected users list
                        Display_Username_List(connectedUsers, richTextBox_connectedUsers);
                    }
                    
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }

        private void Receive(User thisClient)
        {
            bool connected = true;

            while(connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.socket.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    // Distingusing Between Message and Subscription Change
                    if (incomingMessage == "Server, subscribe me to IF100")
                    {
                        IF100Subscribers.Add(thisClient);
                        logs.AppendText(thisClient.username + " subscribed to channel IF 100\n");
                        Display_Username_List(IF100Subscribers, richTextBox_IF100Subscribers);
                    } else if (incomingMessage == "Server, unsubscribe me from IF100")
                    {
                        IF100Subscribers.Remove(thisClient);
                        logs.AppendText(thisClient.username + " unsubscribed from channel IF 100\n");
                        Display_Username_List(IF100Subscribers, richTextBox_IF100Subscribers);
                    } else if (incomingMessage == "Server, subscribe me to SPS101")
                    {
                        SPS101Subscribers.Add(thisClient);
                        logs.AppendText(thisClient.username + " subscribed to channel SPS 101\n");
                        Display_Username_List(SPS101Subscribers, richTextBox_SPS101Subscribers);
                    } else if (incomingMessage == "Server, unsubscribe me from SPS101")
                    {
                        SPS101Subscribers.Remove(thisClient);
                        logs.AppendText(thisClient.username + " unsubscribed from channel SPS 101\n");
                        Display_Username_List(SPS101Subscribers, richTextBox_SPS101Subscribers);
                    } else if (incomingMessage == "Server, disconnect me")
                    {
                        // Removing the disconnected user from all lists
                        connectedUsers.Remove(thisClient);
                        IF100Subscribers.Remove(thisClient);
                        SPS101Subscribers.Remove(thisClient);
                        logs.AppendText("User disconnected: " + thisClient.username + "\n");

                        // Updating the information boxes
                        Display_Username_List(connectedUsers, richTextBox_connectedUsers);
                        Display_Username_List(IF100Subscribers, richTextBox_IF100Subscribers);
                        Display_Username_List(SPS101Subscribers, richTextBox_SPS101Subscribers);

                        thisClient.socket.Close();
                    } 
                    else
                    {
                        // It's a regular message
                        string Room = incomingMessage.Substring(0, 6);
                        string Message = incomingMessage.Substring(6);           

                        if (Room == "SPS101")
                        {
                            // Sending the message to everyone subscribed to SPS101
                            string MessageToSend = Room + thisClient.username + ": " + Message;
                            foreach (User subscriber in SPS101Subscribers)
                            {
                                Convert_and_Send(subscriber.socket, MessageToSend);
                            }
                            logs.AppendText("Channel SPS 101 -> " + MessageToSend);
                        }
                        else
                        {
                            // Sending the message to everyone subscribed to IF100
                            string MessageToSend = Room + thisClient.username + ": " + Message;
                            foreach (User subscriber in IF100Subscribers)
                            { 
                                Convert_and_Send(subscriber.socket, MessageToSend);
                            }
                            logs.AppendText("Channel IF 100 -> " + MessageToSend);
                        }
                    }

                }
                catch
                {
                    if(!terminating)
                    {
                        logs.AppendText("A client has disconnected\n");
                    }
                    thisClient.socket.Close();
                    connectedUsers.Remove(thisClient);
                    connected = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_port_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
