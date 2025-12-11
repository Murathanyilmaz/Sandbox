namespace Sandbox {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.deviceList = new System.Windows.Forms.ComboBox();
            this.deviceLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.modeLabel = new System.Windows.Forms.Label();
            this.modeList = new System.Windows.Forms.ComboBox();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.fishKeyLabel = new System.Windows.Forms.Label();
            this.intKeyLabel = new System.Windows.Forms.Label();
            this.fishKey = new System.Windows.Forms.Label();
            this.intKey = new System.Windows.Forms.Label();
            this.fishKeyButton = new System.Windows.Forms.Button();
            this.intKeyButton = new System.Windows.Forms.Button();
            this.logSound = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // deviceList
            // 
            this.deviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceList.Location = new System.Drawing.Point(149, 161);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(305, 24);
            this.deviceList.TabIndex = 1;
            this.deviceList.TabStop = false;
            this.deviceList.SelectedIndexChanged += new System.EventHandler(this.deviceList_SelectedIndexChanged);
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deviceLabel.Location = new System.Drawing.Point(16, 163);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(113, 20);
            this.deviceLabel.TabIndex = 0;
            this.deviceLabel.Text = "Audio Device:";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.startButton.Location = new System.Drawing.Point(342, 211);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(113, 59);
            this.startButton.TabIndex = 2;
            this.startButton.TabStop = false;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.modeLabel.Location = new System.Drawing.Point(16, 28);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(114, 20);
            this.modeLabel.TabIndex = 0;
            this.modeLabel.Text = "Fishing Mode:";
            // 
            // modeList
            // 
            this.modeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeList.Location = new System.Drawing.Point(149, 26);
            this.modeList.Name = "modeList";
            this.modeList.Size = new System.Drawing.Size(120, 24);
            this.modeList.TabIndex = 3;
            this.modeList.TabStop = false;
            // 
            // volumeBar
            // 
            this.volumeBar.LargeChange = 1;
            this.volumeBar.Location = new System.Drawing.Point(13, 214);
            this.volumeBar.Maximum = 5;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(290, 56);
            this.volumeBar.TabIndex = 5;
            this.volumeBar.TabStop = false;
            // 
            // fishKeyLabel
            // 
            this.fishKeyLabel.AutoSize = true;
            this.fishKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fishKeyLabel.Location = new System.Drawing.Point(16, 73);
            this.fishKeyLabel.Name = "fishKeyLabel";
            this.fishKeyLabel.Size = new System.Drawing.Size(101, 20);
            this.fishKeyLabel.TabIndex = 0;
            this.fishKeyLabel.Text = "Fishing Key:";
            // 
            // intKeyLabel
            // 
            this.intKeyLabel.AutoSize = true;
            this.intKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.intKeyLabel.Location = new System.Drawing.Point(16, 118);
            this.intKeyLabel.Name = "intKeyLabel";
            this.intKeyLabel.Size = new System.Drawing.Size(103, 20);
            this.intKeyLabel.TabIndex = 0;
            this.intKeyLabel.Text = "Interact Key:";
            // 
            // fishKey
            // 
            this.fishKey.AutoSize = true;
            this.fishKey.Location = new System.Drawing.Point(146, 76);
            this.fishKey.Name = "fishKey";
            this.fishKey.Size = new System.Drawing.Size(75, 16);
            this.fishKey.TabIndex = 7;
            this.fishKey.Text = "F4 (Default)";
            // 
            // intKey
            // 
            this.intKey.AutoSize = true;
            this.intKey.Location = new System.Drawing.Point(146, 121);
            this.intKey.Name = "intKey";
            this.intKey.Size = new System.Drawing.Size(75, 16);
            this.intKey.TabIndex = 7;
            this.intKey.Text = "F5 (Default)";
            // 
            // fishKeyButton
            // 
            this.fishKeyButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.fishKeyButton.Location = new System.Drawing.Point(261, 69);
            this.fishKeyButton.Name = "fishKeyButton";
            this.fishKeyButton.Size = new System.Drawing.Size(153, 35);
            this.fishKeyButton.TabIndex = 8;
            this.fishKeyButton.Text = "Bind Fishing";
            this.fishKeyButton.UseVisualStyleBackColor = false;
            this.fishKeyButton.Click += new System.EventHandler(this.fishKeyButton_Click);
            // 
            // intKeyButton
            // 
            this.intKeyButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.intKeyButton.Location = new System.Drawing.Point(261, 112);
            this.intKeyButton.Name = "intKeyButton";
            this.intKeyButton.Size = new System.Drawing.Size(153, 35);
            this.intKeyButton.TabIndex = 8;
            this.intKeyButton.Text = "Bind Interact";
            this.intKeyButton.UseVisualStyleBackColor = false;
            this.intKeyButton.Click += new System.EventHandler(this.intKeyButton_Click);
            // 
            // logSound
            // 
            this.logSound.AutoSize = true;
            this.logSound.Location = new System.Drawing.Point(20, 260);
            this.logSound.Name = "logSound";
            this.logSound.Size = new System.Drawing.Size(130, 20);
            this.logSound.TabIndex = 9;
            this.logSound.TabStop = false;
            this.logSound.Text = "Log Sound Level";
            this.logSound.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(478, 302);
            this.Controls.Add(this.logSound);
            this.Controls.Add(this.intKeyButton);
            this.Controls.Add(this.fishKeyButton);
            this.Controls.Add(this.intKey);
            this.Controls.Add(this.fishKey);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.modeList);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.intKeyLabel);
            this.Controls.Add(this.fishKeyLabel);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.deviceLabel);
            this.Controls.Add(this.deviceList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sandbox";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox deviceList;
        private System.Windows.Forms.Label deviceLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.ComboBox modeList;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Label fishKeyLabel;
        private System.Windows.Forms.Label intKeyLabel;
        private System.Windows.Forms.Label fishKey;
        private System.Windows.Forms.Label intKey;
        private System.Windows.Forms.Button fishKeyButton;
        private System.Windows.Forms.Button intKeyButton;
        private System.Windows.Forms.CheckBox logSound;
    }
}

