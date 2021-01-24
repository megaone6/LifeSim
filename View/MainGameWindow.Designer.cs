namespace LifeSim.View
{
    partial class MainGameWindow
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.ageButton = new System.Windows.Forms.Button();
            this.healthLabel = new System.Windows.Forms.Label();
            this.intelligenceLabel = new System.Windows.Forms.Label();
            this.appearanceLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.testPanel = new System.Windows.Forms.Panel();
            this.testPanelButton = new System.Windows.Forms.Button();
            this.mainPanelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.testPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(8, 16);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(34, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Név: ";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Location = new System.Drawing.Point(8, 44);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(39, 15);
            this.genderLabel.TabIndex = 1;
            this.genderLabel.Text = "Nem: ";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(8, 71);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(67, 15);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "0 éves vagy";
            // 
            // ageButton
            // 
            this.ageButton.Location = new System.Drawing.Point(356, 415);
            this.ageButton.Name = "ageButton";
            this.ageButton.Size = new System.Drawing.Size(75, 23);
            this.ageButton.TabIndex = 3;
            this.ageButton.Text = "+1 év";
            this.ageButton.UseVisualStyleBackColor = true;
            this.ageButton.Click += new System.EventHandler(this.ageButton_Click);
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Location = new System.Drawing.Point(643, 16);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(78, 15);
            this.healthLabel.TabIndex = 4;
            this.healthLabel.Text = "Egészség: 100";
            // 
            // intelligenceLabel
            // 
            this.intelligenceLabel.AutoSize = true;
            this.intelligenceLabel.Location = new System.Drawing.Point(643, 44);
            this.intelligenceLabel.Name = "intelligenceLabel";
            this.intelligenceLabel.Size = new System.Drawing.Size(77, 15);
            this.intelligenceLabel.TabIndex = 5;
            this.intelligenceLabel.Text = "Intelligencia: ";
            // 
            // appearanceLabel
            // 
            this.appearanceLabel.AutoSize = true;
            this.appearanceLabel.Location = new System.Drawing.Point(643, 71);
            this.appearanceLabel.Name = "appearanceLabel";
            this.appearanceLabel.Size = new System.Drawing.Size(51, 15);
            this.appearanceLabel.TabIndex = 6;
            this.appearanceLabel.Text = "Kinézet: ";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.nameLabel);
            this.mainPanel.Controls.Add(this.appearanceLabel);
            this.mainPanel.Controls.Add(this.genderLabel);
            this.mainPanel.Controls.Add(this.intelligenceLabel);
            this.mainPanel.Controls.Add(this.ageLabel);
            this.mainPanel.Controls.Add(this.healthLabel);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(776, 346);
            this.mainPanel.TabIndex = 7;
            // 
            // testPanel
            // 
            this.testPanel.Controls.Add(this.label1);
            this.testPanel.Location = new System.Drawing.Point(12, 12);
            this.testPanel.Name = "testPanel";
            this.testPanel.Size = new System.Drawing.Size(776, 346);
            this.testPanel.TabIndex = 8;
            // 
            // testPanelButton
            // 
            this.testPanelButton.Location = new System.Drawing.Point(20, 375);
            this.testPanelButton.Name = "testPanelButton";
            this.testPanelButton.Size = new System.Drawing.Size(75, 23);
            this.testPanelButton.TabIndex = 0;
            this.testPanelButton.Text = "Test Panel";
            this.testPanelButton.UseVisualStyleBackColor = true;
            this.testPanelButton.Click += new System.EventHandler(this.testPanelButton_Click);
            // 
            // mainPanelButton
            // 
            this.mainPanelButton.Enabled = false;
            this.mainPanelButton.Location = new System.Drawing.Point(114, 375);
            this.mainPanelButton.Name = "mainPanelButton";
            this.mainPanelButton.Size = new System.Drawing.Size(75, 23);
            this.mainPanelButton.TabIndex = 9;
            this.mainPanelButton.Text = "Fő panel";
            this.mainPanelButton.UseVisualStyleBackColor = true;
            this.mainPanelButton.Click += new System.EventHandler(this.mainPanelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "panel teszt";
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanelButton);
            this.Controls.Add(this.testPanelButton);
            this.Controls.Add(this.testPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.ageButton);
            this.Name = "MainGameWindow";
            this.Text = "Életszimulátor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGameWindow_FormClosing);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.testPanel.ResumeLayout(false);
            this.testPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Button ageButton;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label intelligenceLabel;
        private System.Windows.Forms.Label appearanceLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel testPanel;
        private System.Windows.Forms.Button testPanelButton;
        private System.Windows.Forms.Button mainPanelButton;
        private System.Windows.Forms.Label label1;
    }
}