using System;
using System.Windows.Forms;

namespace app2
{
    public partial class Form1 : Form
    {
        private bool botChatActive = false;
        private readonly string supportOptions =
            "1: Unable to start the game\n" +
            "2: Unable to complete the payment process\n" +
            "3: Change email/phone number link\n" +
            "Please enter the number to select the support option:";

        public Form1()
        {
            InitializeComponent();
            SetupBotChat();
        }

        private void SetupBotChat()
        {
            textBoxBotChatHistory.Text = "Press 'Start Chat' to request support from the bot.\n";
        }

        private void buttonStartBotChat_Click(object sender, EventArgs e)
        {
            if (!botChatActive)
            {
                botChatActive = true;
                textBoxBotChatHistory.AppendText("Bot: Hello! How can I assist you?\n" + supportOptions + "\n");
            }
            else
            {
                textBoxBotChatHistory.AppendText("Bot: The support session has ended. Press 'Start Chat' to start again.\n");
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
                    textBoxBotChatHistory.AppendText("You: " + userInput + "\n");
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
                    textBoxBotChatHistory.AppendText("Bot: To fix the game startup issue, please check your connection and try again.\n");
                    EndBotSession();
                    break;
                case "2":
                    textBoxBotChatHistory.AppendText("Bot: For payment processing issues, please check your payment details or contact support if the issue persists.\n");
                    EndBotSession();
                    break;
                case "3":
                    textBoxBotChatHistory.AppendText("Bot: To change your email/phone number, please access the account settings section.\n");
                    EndBotSession();
                    break;
                default:
                    textBoxBotChatHistory.AppendText("Bot: Invalid option. " + supportOptions + "\n");
                    break;
            }
        }

        private void EndBotSession()
        {
            textBoxBotChatHistory.AppendText("Bot: The support session has ended. Press 'Start Chat' to start again.\n");
            botChatActive = false;
        }
    }
}
