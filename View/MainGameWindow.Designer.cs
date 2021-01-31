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
            this.moneyLabel = new System.Windows.Forms.Label();
            this.jobPanel = new System.Windows.Forms.Panel();
            this.tryJobButton = new System.Windows.Forms.Button();
            this.jobComboBox = new System.Windows.Forms.ComboBox();
            this.jobLabel = new System.Windows.Forms.Label();
            this.jobPanelButton = new System.Windows.Forms.Button();
            this.mainPanelButton = new System.Windows.Forms.Button();
            this.homePanelButton = new System.Windows.Forms.Button();
            this.homePanel = new System.Windows.Forms.Panel();
            this.homeLabel = new System.Windows.Forms.Label();
            this.buyHomeButton = new System.Windows.Forms.Button();
            this.homeComboBox = new System.Windows.Forms.ComboBox();
            this.leisurePanelButton = new System.Windows.Forms.Button();
            this.leisurePanel = new System.Windows.Forms.Panel();
            this.workOutButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.jobPanel.SuspendLayout();
            this.homePanel.SuspendLayout();
            this.leisurePanel.SuspendLayout();
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
            this.mainPanel.Controls.Add(this.moneyLabel);
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
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(9, 97);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(126, 15);
            this.moneyLabel.TabIndex = 9;
            this.moneyLabel.Text = "Jelenleg 0 forintod van";
            // 
            // jobPanel
            // 
            this.jobPanel.Controls.Add(this.tryJobButton);
            this.jobPanel.Controls.Add(this.jobComboBox);
            this.jobPanel.Controls.Add(this.jobLabel);
            this.jobPanel.Location = new System.Drawing.Point(12, 12);
            this.jobPanel.Name = "jobPanel";
            this.jobPanel.Size = new System.Drawing.Size(776, 346);
            this.jobPanel.TabIndex = 8;
            // 
            // tryJobButton
            // 
            this.tryJobButton.Location = new System.Drawing.Point(344, 190);
            this.tryJobButton.Name = "tryJobButton";
            this.tryJobButton.Size = new System.Drawing.Size(75, 23);
            this.tryJobButton.TabIndex = 8;
            this.tryJobButton.Text = "Jelentkezés";
            this.tryJobButton.UseVisualStyleBackColor = true;
            this.tryJobButton.Click += new System.EventHandler(this.tryJobButton_Click);
            // 
            // jobComboBox
            // 
            this.jobComboBox.FormattingEnabled = true;
            this.jobComboBox.Location = new System.Drawing.Point(323, 159);
            this.jobComboBox.Name = "jobComboBox";
            this.jobComboBox.Size = new System.Drawing.Size(121, 23);
            this.jobComboBox.TabIndex = 1;
            // 
            // jobLabel
            // 
            this.jobLabel.AutoSize = true;
            this.jobLabel.Location = new System.Drawing.Point(8, 16);
            this.jobLabel.Name = "jobLabel";
            this.jobLabel.Size = new System.Drawing.Size(0, 15);
            this.jobLabel.TabIndex = 0;
            // 
            // jobPanelButton
            // 
            this.jobPanelButton.Enabled = false;
            this.jobPanelButton.Location = new System.Drawing.Point(20, 375);
            this.jobPanelButton.Name = "jobPanelButton";
            this.jobPanelButton.Size = new System.Drawing.Size(75, 23);
            this.jobPanelButton.TabIndex = 0;
            this.jobPanelButton.Text = "Munka";
            this.jobPanelButton.UseVisualStyleBackColor = true;
            this.jobPanelButton.Click += new System.EventHandler(this.jobPanelButton_Click);
            // 
            // mainPanelButton
            // 
            this.mainPanelButton.Enabled = false;
            this.mainPanelButton.Location = new System.Drawing.Point(114, 375);
            this.mainPanelButton.Name = "mainPanelButton";
            this.mainPanelButton.Size = new System.Drawing.Size(75, 23);
            this.mainPanelButton.TabIndex = 9;
            this.mainPanelButton.Text = "Fő menü";
            this.mainPanelButton.UseVisualStyleBackColor = true;
            this.mainPanelButton.Click += new System.EventHandler(this.mainPanelButton_Click);
            // 
            // homePanelButton
            // 
            this.homePanelButton.Enabled = false;
            this.homePanelButton.Location = new System.Drawing.Point(213, 375);
            this.homePanelButton.Name = "homePanelButton";
            this.homePanelButton.Size = new System.Drawing.Size(75, 23);
            this.homePanelButton.TabIndex = 10;
            this.homePanelButton.Text = "Lakás";
            this.homePanelButton.UseVisualStyleBackColor = true;
            this.homePanelButton.Click += new System.EventHandler(this.homePanelButton_Click);
            // 
            // homePanel
            // 
            this.homePanel.Controls.Add(this.homeLabel);
            this.homePanel.Controls.Add(this.buyHomeButton);
            this.homePanel.Controls.Add(this.homeComboBox);
            this.homePanel.Location = new System.Drawing.Point(12, 12);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(776, 346);
            this.homePanel.TabIndex = 11;
            // 
            // homeLabel
            // 
            this.homeLabel.AutoSize = true;
            this.homeLabel.Location = new System.Drawing.Point(15, 16);
            this.homeLabel.Name = "homeLabel";
            this.homeLabel.Size = new System.Drawing.Size(0, 15);
            this.homeLabel.TabIndex = 2;
            // 
            // buyHomeButton
            // 
            this.buyHomeButton.Location = new System.Drawing.Point(344, 190);
            this.buyHomeButton.Name = "buyHomeButton";
            this.buyHomeButton.Size = new System.Drawing.Size(75, 23);
            this.buyHomeButton.TabIndex = 1;
            this.buyHomeButton.Text = "Vásárlás";
            this.buyHomeButton.UseVisualStyleBackColor = true;
            this.buyHomeButton.Click += new System.EventHandler(this.buyHomeButton_Click);
            // 
            // homeComboBox
            // 
            this.homeComboBox.FormattingEnabled = true;
            this.homeComboBox.Location = new System.Drawing.Point(323, 158);
            this.homeComboBox.Name = "homeComboBox";
            this.homeComboBox.Size = new System.Drawing.Size(121, 23);
            this.homeComboBox.TabIndex = 0;
            // 
            // leisurePanelButton
            // 
            this.leisurePanelButton.Enabled = false;
            this.leisurePanelButton.Location = new System.Drawing.Point(310, 375);
            this.leisurePanelButton.Name = "leisurePanelButton";
            this.leisurePanelButton.Size = new System.Drawing.Size(75, 23);
            this.leisurePanelButton.TabIndex = 12;
            this.leisurePanelButton.Text = "Szabadidő";
            this.leisurePanelButton.UseVisualStyleBackColor = true;
            this.leisurePanelButton.Click += new System.EventHandler(this.leisurePanelButton_Click);
            // 
            // leisurePanel
            // 
            this.leisurePanel.Controls.Add(this.readButton);
            this.leisurePanel.Controls.Add(this.workOutButton);
            this.leisurePanel.Location = new System.Drawing.Point(12, 12);
            this.leisurePanel.Name = "leisurePanel";
            this.leisurePanel.Size = new System.Drawing.Size(776, 346);
            this.leisurePanel.TabIndex = 13;
            // 
            // workOutButton
            // 
            this.workOutButton.Location = new System.Drawing.Point(14, 18);
            this.workOutButton.Name = "workOutButton";
            this.workOutButton.Size = new System.Drawing.Size(75, 23);
            this.workOutButton.TabIndex = 14;
            this.workOutButton.Text = "Edzés";
            this.workOutButton.UseVisualStyleBackColor = true;
            this.workOutButton.Click += new System.EventHandler(this.workOutButton_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(14, 63);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(75, 23);
            this.readButton.TabIndex = 15;
            this.readButton.Text = "Olvasás";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.leisurePanel);
            this.Controls.Add(this.leisurePanelButton);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.homePanelButton);
            this.Controls.Add(this.mainPanelButton);
            this.Controls.Add(this.jobPanelButton);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.jobPanel);
            this.Controls.Add(this.ageButton);
            this.Name = "MainGameWindow";
            this.Text = "Életszimulátor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGameWindow_FormClosing);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.jobPanel.ResumeLayout(false);
            this.jobPanel.PerformLayout();
            this.homePanel.ResumeLayout(false);
            this.homePanel.PerformLayout();
            this.leisurePanel.ResumeLayout(false);
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
        private System.Windows.Forms.Panel jobPanel;
        private System.Windows.Forms.Button jobPanelButton;
        private System.Windows.Forms.Button mainPanelButton;
        private System.Windows.Forms.Label jobLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.ComboBox jobComboBox;
        private System.Windows.Forms.Button tryJobButton;
        private System.Windows.Forms.Button homePanelButton;
        private System.Windows.Forms.Panel homePanel;
        private System.Windows.Forms.ComboBox homeComboBox;
        private System.Windows.Forms.Label homeLabel;
        private System.Windows.Forms.Button buyHomeButton;
        private System.Windows.Forms.Button leisurePanelButton;
        private System.Windows.Forms.Panel leisurePanel;
        private System.Windows.Forms.Button workOutButton;
        private System.Windows.Forms.Button readButton;
    }
}