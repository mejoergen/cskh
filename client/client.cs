using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace client
{
    public partial class client : Form
    {
        private bool botChatActive = false;
        private TcpClient employeeClient;
        private NetworkStream networkStream;
        private Thread receiveThread;
        private readonly string supportOptions =
            "1: Unable to start the game" + Environment.NewLine +
            "2: Unable to complete the payment process" + Environment.NewLine +
            "3: Change email/phone number link" + Environment.NewLine +
            "Please enter the number to select the support option:";

        public client()
        {
            InitializeComponent();
            SetupBotChat();
        }

        // Chat với bot
        private void SetupBotChat()
        {
            textBoxBotChatHistory.Text = "Press 'Start Chat' to request support from the bot." + Environment.NewLine;
        }

        private void buttonStartBotChat_Click(object sender, EventArgs e)
        {
            if (!botChatActive)
            {
                botChatActive = true;
                textBoxBotChatHistory.AppendText("Bot: Hello! How can I assist you?" + Environment.NewLine + supportOptions + Environment.NewLine);
            }
            else
            {
                textBoxBotChatHistory.AppendText("Bot: The support session has ended. Press 'Start Chat' to start again." + Environment.NewLine);
                botChatActive = false;
            }
        }

        private void textBoxBotInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && botChatActive)
            {
                string userInput = textBoxBotInput.Text.Trim();
                if (!string.IsNullOrEmpty(userInput))
                {
                    textBoxBotChatHistory.AppendText("You: " + userInput + Environment.NewLine);
                    ProcessBotResponse(userInput);
                    textBoxBotInput.Clear();
                }
                e.SuppressKeyPress = true;
            }
        }

        private void ProcessBotResponse(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    textBoxBotChatHistory.AppendText("Bot: To fix the game startup issue, please check your connection and try again." + Environment.NewLine);
                    EndBotSession();
                    break;
                case "2":
                    textBoxBotChatHistory.AppendText("Bot: For payment processing issues, please check your payment details or contact support if the issue persists." + Environment.NewLine);
                    EndBotSession();
                    break;
                case "3":
                    textBoxBotChatHistory.AppendText("Bot: To change your email/phone number, please access the account settings section." + Environment.NewLine);
                    EndBotSession();
                    break;
                default:
                    textBoxBotChatHistory.AppendText("Bot: Invalid option. " + supportOptions + Environment.NewLine);
                    break;
            }
        }

        private void EndBotSession()
        {
            textBoxBotChatHistory.AppendText("Bot: The support session has ended. Press 'Start Chat' to start again." + Environment.NewLine);
            botChatActive = false;
        }

        // Chat với nhân viên
        private void buttonStartEmployeeChat_Click(object sender, EventArgs e)
        {
            try
            {
                employeeClient = new TcpClient("127.0.0.1", 8888);
                networkStream = employeeClient.GetStream();
                receiveThread = new Thread(ReceiveEmployeeMessages);
                receiveThread.Start();
                textBoxEmployeeChatHistory.AppendText("Connected to server for employee chat." + Environment.NewLine);
            }
            catch (Exception ex)
            {
                textBoxEmployeeChatHistory.AppendText("Error: Unable to connect to server." + Environment.NewLine + ex.Message);
            }
        }

        private void ReceiveEmployeeMessages()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    textBoxEmployeeChatHistory.Invoke((MethodInvoker)(() =>
                        textBoxEmployeeChatHistory.AppendText("Employee: " + message + Environment.NewLine)));
                }
            }
            catch (Exception)
            {
                textBoxEmployeeChatHistory.Invoke((MethodInvoker)(() =>
                    textBoxEmployeeChatHistory.AppendText("Disconnected from server." + Environment.NewLine)));
            }
        }

        private void textBoxEmployeeInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && networkStream != null)
            {
                string message = textBoxEmployeeInput.Text.Trim();
                if (!string.IsNullOrEmpty(message))
                {
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    networkStream.Write(data, 0, data.Length);
                    textBoxEmployeeChatHistory.AppendText("You: " + message + Environment.NewLine);
                    textBoxEmployeeInput.Clear();
                }
                e.SuppressKeyPress = true;
            }
        }

        private void client_FormClosed(object sender, FormClosedEventArgs e)
        {
            networkStream?.Close();
            employeeClient?.Close();
            receiveThread?.Abort();
        }
    }
}
