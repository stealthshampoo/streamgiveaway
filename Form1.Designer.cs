namespace StreamGiveaway
{
    partial class InputForm
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
            this.subBox = new System.Windows.Forms.CheckBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.followBox = new System.Windows.Forms.CheckBox();
            this.chatBox = new System.Windows.Forms.CheckBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.clientLabel = new System.Windows.Forms.Label();
            this.clientInput = new System.Windows.Forms.TextBox();
            this.accessLabel = new System.Windows.Forms.Label();
            this.accessInput = new System.Windows.Forms.TextBox();
            this.customButtonInput = new System.Windows.Forms.RadioButton();
            this.customButtonText = new System.Windows.Forms.RadioButton();
            this.customLabel = new System.Windows.Forms.Label();
            this.customInput = new System.Windows.Forms.RichTextBox();
            this.modIgnoreBox = new System.Windows.Forms.CheckBox();
            this.ignoreLabel = new System.Windows.Forms.Label();
            this.ignoreInput = new System.Windows.Forms.RichTextBox();
            this.ignoreButtonInput = new System.Windows.Forms.RadioButton();
            this.ignoreButtonText = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.customFileButton = new System.Windows.Forms.Button();
            this.ignoreFileButton = new System.Windows.Forms.Button();
            this.streamerIgnoreBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // subBox
            // 
            this.subBox.AutoSize = true;
            this.subBox.Location = new System.Drawing.Point(12, 12);
            this.subBox.Name = "subBox";
            this.subBox.Size = new System.Drawing.Size(81, 17);
            this.subBox.TabIndex = 0;
            subBox.Text = "Subscribers";
            this.subBox.UseVisualStyleBackColor = true;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(12, 317);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 1;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // followBox
            // 
            this.followBox.AutoSize = true;
            this.followBox.Location = new System.Drawing.Point(12, 35);
            this.followBox.Name = "followBox";
            this.followBox.Size = new System.Drawing.Size(70, 17);
            this.followBox.TabIndex = 2;
            this.followBox.Text = "Followers";
            this.followBox.UseVisualStyleBackColor = true;
            // 
            // chatBox
            // 
            this.chatBox.AutoSize = true;
            this.chatBox.Location = new System.Drawing.Point(12, 59);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(48, 17);
            this.chatBox.TabIndex = 3;
            this.chatBox.Text = "Chat";
            this.chatBox.UseVisualStyleBackColor = true;
            this.chatBox.CheckedChanged += new System.EventHandler(this.chatBox_CheckedChanged);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(9, 134);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(58, 13);
            this.userLabel.TabIndex = 4;
            this.userLabel.Text = "Username:";
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(12, 150);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(136, 20);
            this.usernameInput.TabIndex = 5;
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(9, 173);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(50, 13);
            this.clientLabel.TabIndex = 6;
            this.clientLabel.Text = "Client ID:";
            // 
            // clientInput
            // 
            this.clientInput.Location = new System.Drawing.Point(12, 189);
            this.clientInput.Name = "clientInput";
            this.clientInput.Size = new System.Drawing.Size(136, 20);
            this.clientInput.TabIndex = 7;
            this.clientInput.UseSystemPasswordChar = true;
            // 
            // accessLabel
            // 
            this.accessLabel.AutoSize = true;
            this.accessLabel.Location = new System.Drawing.Point(9, 212);
            this.accessLabel.Name = "accessLabel";
            this.accessLabel.Size = new System.Drawing.Size(79, 13);
            this.accessLabel.TabIndex = 8;
            this.accessLabel.Text = "Access Token:";
            // 
            // accessInput
            // 
            this.accessInput.Location = new System.Drawing.Point(12, 228);
            this.accessInput.Name = "accessInput";
            this.accessInput.Size = new System.Drawing.Size(136, 20);
            this.accessInput.TabIndex = 9;
            this.accessInput.UseSystemPasswordChar = true;
            // 
            // customButtonInput
            // 
            this.customButtonInput.AutoSize = true;
            this.customButtonInput.Checked = true;
            this.customButtonInput.Location = new System.Drawing.Point(11, 29);
            this.customButtonInput.Name = "customButtonInput";
            this.customButtonInput.Size = new System.Drawing.Size(70, 17);
            this.customButtonInput.TabIndex = 10;
            this.customButtonInput.TabStop = true;
            this.customButtonInput.Text = "Input Box";
            this.customButtonInput.UseVisualStyleBackColor = true;
            this.customButtonInput.CheckedChanged += new System.EventHandler(this.customButtonInput_CheckedChanged);
            // 
            // customButtonText
            // 
            this.customButtonText.AutoSize = true;
            this.customButtonText.Location = new System.Drawing.Point(222, 29);
            this.customButtonText.Name = "customButtonText";
            this.customButtonText.Size = new System.Drawing.Size(65, 17);
            this.customButtonText.TabIndex = 11;
            this.customButtonText.Text = "Text File";
            this.customButtonText.UseVisualStyleBackColor = true;
            this.customButtonText.CheckedChanged += new System.EventHandler(this.customButtonText_CheckedChanged);
            // 
            // customLabel
            // 
            this.customLabel.AutoSize = true;
            this.customLabel.Location = new System.Drawing.Point(8, 13);
            this.customLabel.Name = "customLabel";
            this.customLabel.Size = new System.Drawing.Size(77, 13);
            this.customLabel.TabIndex = 12;
            this.customLabel.Text = "Custom Entries";
            // 
            // customInput
            // 
            this.customInput.Location = new System.Drawing.Point(219, 59);
            this.customInput.Name = "customInput";
            this.customInput.Size = new System.Drawing.Size(156, 108);
            this.customInput.TabIndex = 13;
            this.customInput.Text = "";
            // 
            // modIgnoreBox
            // 
            this.modIgnoreBox.AutoSize = true;
            this.modIgnoreBox.Enabled = false;
            this.modIgnoreBox.Location = new System.Drawing.Point(31, 82);
            this.modIgnoreBox.Name = "modIgnoreBox";
            this.modIgnoreBox.Size = new System.Drawing.Size(85, 17);
            this.modIgnoreBox.TabIndex = 14;
            this.modIgnoreBox.Text = "Ignore Mods";
            this.modIgnoreBox.UseVisualStyleBackColor = true;
            // 
            // ignoreLabel
            // 
            this.ignoreLabel.AutoSize = true;
            this.ignoreLabel.Location = new System.Drawing.Point(8, 12);
            this.ignoreLabel.Name = "ignoreLabel";
            this.ignoreLabel.Size = new System.Drawing.Size(56, 13);
            this.ignoreLabel.TabIndex = 15;
            this.ignoreLabel.Text = "Ignore List";
            // 
            // ignoreInput
            // 
            this.ignoreInput.Location = new System.Drawing.Point(219, 230);
            this.ignoreInput.Name = "ignoreInput";
            this.ignoreInput.Size = new System.Drawing.Size(156, 110);
            this.ignoreInput.TabIndex = 16;
            this.ignoreInput.Text = "";
            // 
            // ignoreButtonInput
            // 
            this.ignoreButtonInput.AutoSize = true;
            this.ignoreButtonInput.Checked = true;
            this.ignoreButtonInput.Location = new System.Drawing.Point(11, 28);
            this.ignoreButtonInput.Name = "ignoreButtonInput";
            this.ignoreButtonInput.Size = new System.Drawing.Size(70, 17);
            this.ignoreButtonInput.TabIndex = 17;
            this.ignoreButtonInput.TabStop = true;
            this.ignoreButtonInput.Text = "Input Box";
            this.ignoreButtonInput.UseVisualStyleBackColor = true;
            this.ignoreButtonInput.CheckedChanged += new System.EventHandler(this.ignoreButtonInput_CheckedChanged);
            // 
            // ignoreButtonText
            // 
            this.ignoreButtonText.AutoSize = true;
            this.ignoreButtonText.Location = new System.Drawing.Point(222, 28);
            this.ignoreButtonText.Name = "ignoreButtonText";
            this.ignoreButtonText.Size = new System.Drawing.Size(65, 17);
            this.ignoreButtonText.TabIndex = 18;
            this.ignoreButtonText.Text = "Text File";
            this.ignoreButtonText.UseVisualStyleBackColor = true;
            this.ignoreButtonText.CheckedChanged += new System.EventHandler(this.ignoreButtonText_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customButtonInput);
            this.groupBox1.Controls.Add(this.customButtonText);
            this.groupBox1.Controls.Add(this.customLabel);
            this.groupBox1.Location = new System.Drawing.Point(208, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 53);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ignoreButtonInput);
            this.groupBox2.Controls.Add(this.ignoreLabel);
            this.groupBox2.Controls.Add(this.ignoreButtonText);
            this.groupBox2.Location = new System.Drawing.Point(208, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 51);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // customFileButton
            // 
            this.customFileButton.Enabled = false;
            this.customFileButton.Location = new System.Drawing.Point(430, 99);
            this.customFileButton.Name = "customFileButton";
            this.customFileButton.Size = new System.Drawing.Size(86, 23);
            this.customFileButton.TabIndex = 21;
            this.customFileButton.Text = "File";
            this.customFileButton.UseVisualStyleBackColor = true;
            this.customFileButton.Click += new System.EventHandler(this.customFileButton_Click);
            // 
            // ignoreFileButton
            // 
            this.ignoreFileButton.Enabled = false;
            this.ignoreFileButton.Location = new System.Drawing.Point(430, 271);
            this.ignoreFileButton.Name = "ignoreFileButton";
            this.ignoreFileButton.Size = new System.Drawing.Size(86, 23);
            this.ignoreFileButton.TabIndex = 22;
            this.ignoreFileButton.Text = "File";
            this.ignoreFileButton.UseVisualStyleBackColor = true;
            this.ignoreFileButton.Click += new System.EventHandler(this.ignoreFileButton_Click);
            // 
            // streamerIgnoreBox
            // 
            this.streamerIgnoreBox.AutoSize = true;
            this.streamerIgnoreBox.Location = new System.Drawing.Point(12, 104);
            this.streamerIgnoreBox.Name = "streamerIgnoreBox";
            this.streamerIgnoreBox.Size = new System.Drawing.Size(101, 17);
            this.streamerIgnoreBox.TabIndex = 23;
            this.streamerIgnoreBox.Text = "Ignore Streamer";
            this.streamerIgnoreBox.UseVisualStyleBackColor = true;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 352);
            this.Controls.Add(this.streamerIgnoreBox);
            this.Controls.Add(this.ignoreFileButton);
            this.Controls.Add(this.customFileButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ignoreInput);
            this.Controls.Add(this.modIgnoreBox);
            this.Controls.Add(this.customInput);
            this.Controls.Add(this.accessInput);
            this.Controls.Add(this.accessLabel);
            this.Controls.Add(this.clientInput);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.followBox);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.subBox);
            this.Name = "InputForm";
            this.Text = "StealthShampoo Giveaway";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox subBox;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.CheckBox followBox;
        private System.Windows.Forms.CheckBox chatBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.TextBox clientInput;
        private System.Windows.Forms.Label accessLabel;
        private System.Windows.Forms.TextBox accessInput;
        private System.Windows.Forms.RadioButton customButtonInput;
        private System.Windows.Forms.RadioButton customButtonText;
        private System.Windows.Forms.Label customLabel;
        private System.Windows.Forms.RichTextBox customInput;
        private System.Windows.Forms.CheckBox modIgnoreBox;
        private System.Windows.Forms.Label ignoreLabel;
        private System.Windows.Forms.RichTextBox ignoreInput;
        private System.Windows.Forms.RadioButton ignoreButtonInput;
        private System.Windows.Forms.RadioButton ignoreButtonText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button customFileButton;
        private System.Windows.Forms.Button ignoreFileButton;
        private System.Windows.Forms.CheckBox streamerIgnoreBox;
    }
}

