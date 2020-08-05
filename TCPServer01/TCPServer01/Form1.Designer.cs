namespace TCPServer01
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
            this.tbConsoleOutput = new System.Windows.Forms.TextBox();
            this.tbIPAdress = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbStartListening = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSendClient = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbConsoleOutput
            // 
            this.tbConsoleOutput.Location = new System.Drawing.Point(12, 12);
            this.tbConsoleOutput.Multiline = true;
            this.tbConsoleOutput.Name = "tbConsoleOutput";
            this.tbConsoleOutput.ReadOnly = true;
            this.tbConsoleOutput.Size = new System.Drawing.Size(669, 285);
            this.tbConsoleOutput.TabIndex = 0;
            // 
            // tbIPAdress
            // 
            this.tbIPAdress.Location = new System.Drawing.Point(62, 312);
            this.tbIPAdress.Name = "tbIPAdress";
            this.tbIPAdress.Size = new System.Drawing.Size(172, 20);
            this.tbIPAdress.TabIndex = 1;
            this.tbIPAdress.Text = "192.168.1.104";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(240, 312);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "23000";
            // 
            // tbStartListening
            // 
            this.tbStartListening.Location = new System.Drawing.Point(62, 338);
            this.tbStartListening.Name = "tbStartListening";
            this.tbStartListening.Size = new System.Drawing.Size(278, 23);
            this.tbStartListening.TabIndex = 3;
            this.tbStartListening.Text = "Start Listening";
            this.tbStartListening.UseVisualStyleBackColor = true;
            this.tbStartListening.Click += new System.EventHandler(this.tbStartListening_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP/Port:";
            // 
            // tbSendClient
            // 
            this.tbSendClient.Location = new System.Drawing.Point(535, 312);
            this.tbSendClient.Name = "tbSendClient";
            this.tbSendClient.Size = new System.Drawing.Size(146, 20);
            this.tbSendClient.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(535, 338);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(146, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 389);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbSendClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbStartListening);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIPAdress);
            this.Controls.Add(this.tbConsoleOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsoleOutput;
        private System.Windows.Forms.TextBox tbIPAdress;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button tbStartListening;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSendClient;
        private System.Windows.Forms.Button btnSend;
    }
}

