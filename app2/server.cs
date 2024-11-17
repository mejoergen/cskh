using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace app2
{
    public partial class server : Form
    {
        private TcpListener serverListener;
        private Thread serverThread;
        private Dictionary<Socket, string> clients = new Dictionary<Socket, string>();
        private bool isRunning = false;

        public server()
        {
            InitializeComponent();
            FormClosed += Server_FormClosed;
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopServer();
        }

        private void StartServer()
        {
            serverListener = new TcpListener(IPAddress.Any, 8888);
            serverListener.Start();
            isRunning = true;
            serverThread = new Thread(AcceptClients);
            serverThread.Start();
            AppendChatHistory("Server started...");
        }

        private void StopServer()
        {
            isRunning = false;

            // Đóng tất cả các kết nối client
            foreach (var client in clients.Keys)
            {
                client.Close();
            }
            clients.Clear();

            // Dừng TcpListener và đóng serverThread một cách an toàn
            serverListener?.Stop();
            serverListener = null;

            // Đợi serverThread hoàn thành trước khi kết thúc
            if (serverThread != null && serverThread.IsAlive)
            {
                serverThread.Join();
                serverThread = null;
            }

            AppendChatHistory("Server stopped...");
        }

        private void AcceptClients()
        {
            while (isRunning)
            {
                try
                {
                    Socket clientSocket = serverListener.AcceptSocket();
                    string clientIP = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();
                    clients[clientSocket] = clientIP;
                    AppendChatHistory($"Client connected from IP: {clientIP}");

                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.Start();
                }
                catch (SocketException ex)
                {
                    if (isRunning)
                    {
                        AppendChatHistory("Error: " + ex.Message);
                    }
                    break;
                }
            }
        }

        private void HandleClient(Socket clientSocket)
        {
            try
            {
                while (isRunning)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = clientSocket.Receive(buffer);
                    if (bytesRead == 0) break; // Client disconnected

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    AppendChatHistory($"Client {clients[clientSocket]}: {message}");
                    BroadcastMessage(message, clientSocket);
                }
            }
            catch (SocketException)
            {
                // Xử lý ngắt kết nối hoặc lỗi kết nối khác
            }
            finally
            {
                // Đảm bảo đóng kết nối khi kết thúc luồng
                AppendChatHistory($"Client {clients[clientSocket]} disconnected.");
                clients.Remove(clientSocket);
                clientSocket.Close();
            }
        }

        private void AppendChatHistory(string message)
        {
            textBoxChatHistory.Invoke((MethodInvoker)(() =>
            {
                textBoxChatHistory.AppendText(message + Environment.NewLine);
            }));
        }

        private void BroadcastMessage(string message, Socket excludeClient)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            foreach (var client in clients.Keys)
            {
                if (client != excludeClient)
                {
                    client.Send(data);
                }
            }
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && clients.Count > 0)
            {
                string message = textBoxInput.Text.Trim();
                if (!string.IsNullOrEmpty(message))
                {
                    foreach (var client in clients.Keys)
                    {
                        SendMessageToClient(client, message);
                    }
                    textBoxInput.Clear();
                }
                e.SuppressKeyPress = true;
            }
        }

        private void SendMessageToClient(Socket clientSocket, string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            clientSocket.Send(data);
            AppendChatHistory("You: " + message);
        }
    }
}
