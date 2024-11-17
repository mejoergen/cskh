namespace app2
{
    partial class server
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
            textBoxChatHistory = new TextBox();
            textBoxInput = new TextBox();
            buttonStartServer = new Button();
            buttonStopServer = new Button();
            SuspendLayout();
            // 
            // textBoxChatHistory
            // 
            textBoxChatHistory.Location = new Point(12, 12);
            textBoxChatHistory.Multiline = true;
            textBoxChatHistory.Name = "textBoxChatHistory";
            textBoxChatHistory.ReadOnly = true;
            textBoxChatHistory.ScrollBars = ScrollBars.Vertical;
            textBoxChatHistory.Size = new Size(776, 322);
            textBoxChatHistory.TabIndex = 0;
            // 
            // textBoxInput
            // 
            textBoxInput.Font = new Font("Segoe UI", 15F);
            textBoxInput.Location = new Point(12, 380);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(508, 34);
            textBoxInput.TabIndex = 1;
            textBoxInput.KeyDown += textBoxInput_KeyDown;
            // 
            // buttonStartServer
            // 
            buttonStartServer.Location = new Point(559, 380);
            buttonStartServer.Name = "buttonStartServer";
            buttonStartServer.Size = new Size(89, 34);
            buttonStartServer.TabIndex = 2;
            buttonStartServer.Text = "Start";
            buttonStartServer.UseVisualStyleBackColor = true;
            buttonStartServer.Click += buttonStartServer_Click;
            // 
            // buttonStopServer
            // 
            buttonStopServer.Location = new Point(672, 380);
            buttonStopServer.Name = "buttonStopServer";
            buttonStopServer.Size = new Size(89, 34);
            buttonStopServer.TabIndex = 3;
            buttonStopServer.Text = "Stop";
            buttonStopServer.UseVisualStyleBackColor = true;
            buttonStopServer.Click += buttonStopServer_Click;
            // 
            // server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonStopServer);
            Controls.Add(buttonStartServer);
            Controls.Add(textBoxInput);
            Controls.Add(textBoxChatHistory);
            Name = "server";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxChatHistory;
        private TextBox textBoxInput;
        private Button buttonStartServer;
        private Button buttonStopServer;
    }
}
