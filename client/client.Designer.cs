namespace client
{
    partial class client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            buttonStartBotChat = new Button();
            textBoxBotInput = new TextBox();
            textBoxBotChatHistory = new TextBox();
            tabPage2 = new TabPage();
            buttonStartEmployeeChat = new Button();
            textBoxEmployeeInput = new TextBox();
            textBoxEmployeeChatHistory = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(buttonStartBotChat);
            tabPage1.Controls.Add(textBoxBotInput);
            tabPage1.Controls.Add(textBoxBotChatHistory);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 398);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ho tro tu dong";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonStartBotChat
            // 
            buttonStartBotChat.Location = new Point(625, 315);
            buttonStartBotChat.Name = "buttonStartBotChat";
            buttonStartBotChat.Size = new Size(87, 34);
            buttonStartBotChat.TabIndex = 5;
            buttonStartBotChat.Text = "Start";
            buttonStartBotChat.UseVisualStyleBackColor = true;
            buttonStartBotChat.Click += buttonStartBotChat_Click;
            // 
            // textBoxBotInput
            // 
            textBoxBotInput.Font = new Font("Segoe UI", 15F);
            textBoxBotInput.Location = new Point(6, 315);
            textBoxBotInput.Name = "textBoxBotInput";
            textBoxBotInput.Size = new Size(576, 34);
            textBoxBotInput.TabIndex = 4;
            textBoxBotInput.KeyDown += textBoxBotInput_KeyDown;
            // 
            // textBoxBotChatHistory
            // 
            textBoxBotChatHistory.Location = new Point(6, 6);
            textBoxBotChatHistory.Multiline = true;
            textBoxBotChatHistory.Name = "textBoxBotChatHistory";
            textBoxBotChatHistory.ReadOnly = true;
            textBoxBotChatHistory.ScrollBars = ScrollBars.Vertical;
            textBoxBotChatHistory.Size = new Size(756, 272);
            textBoxBotChatHistory.TabIndex = 3;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(buttonStartEmployeeChat);
            tabPage2.Controls.Add(textBoxEmployeeInput);
            tabPage2.Controls.Add(textBoxEmployeeChatHistory);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 398);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ho tro truc tuyen";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonStartEmployeeChat
            // 
            buttonStartEmployeeChat.Location = new Point(625, 337);
            buttonStartEmployeeChat.Name = "buttonStartEmployeeChat";
            buttonStartEmployeeChat.Size = new Size(87, 34);
            buttonStartEmployeeChat.TabIndex = 8;
            buttonStartEmployeeChat.Text = "Start";
            buttonStartEmployeeChat.UseVisualStyleBackColor = true;
            buttonStartEmployeeChat.Click += buttonStartEmployeeChat_Click;
            // 
            // textBoxEmployeeInput
            // 
            textBoxEmployeeInput.Font = new Font("Segoe UI", 15F);
            textBoxEmployeeInput.Location = new Point(6, 337);
            textBoxEmployeeInput.Name = "textBoxEmployeeInput";
            textBoxEmployeeInput.Size = new Size(576, 34);
            textBoxEmployeeInput.TabIndex = 7;
            textBoxEmployeeInput.KeyDown += textBoxEmployeeInput_KeyDown;
            // 
            // textBoxEmployeeChatHistory
            // 
            textBoxEmployeeChatHistory.Location = new Point(6, 28);
            textBoxEmployeeChatHistory.Multiline = true;
            textBoxEmployeeChatHistory.Name = "textBoxEmployeeChatHistory";
            textBoxEmployeeChatHistory.ReadOnly = true;
            textBoxEmployeeChatHistory.ScrollBars = ScrollBars.Vertical;
            textBoxEmployeeChatHistory.Size = new Size(756, 272);
            textBoxEmployeeChatHistory.TabIndex = 6;
            // 
            // client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "client";
            Text = "Form1";
            FormClosed += client_FormClosed;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button buttonStartBotChat;
        private TextBox textBoxBotInput;
        private TextBox textBoxBotChatHistory;
        private TabPage tabPage2;
        private Button buttonStartEmployeeChat;
        private TextBox textBoxEmployeeInput;
        private TextBox textBoxEmployeeChatHistory;
    }
}
