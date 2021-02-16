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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameWindow));
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
            this.quitJobButton = new System.Windows.Forms.Button();
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
            this.readButton = new System.Windows.Forms.Button();
            this.workOutButton = new System.Windows.Forms.Button();
            this.universityPanel = new System.Windows.Forms.Panel();
            this.applyToUniButton = new System.Windows.Forms.Button();
            this.universityComboBox = new System.Windows.Forms.ComboBox();
            this.universityLabel = new System.Windows.Forms.Label();
            this.lovePanel = new System.Windows.Forms.Panel();
            this.tryForChildButton = new System.Windows.Forms.Button();
            this.breakUpButton = new System.Windows.Forms.Button();
            this.tryRelationshipButton = new System.Windows.Forms.Button();
            this.newLoveButton = new System.Windows.Forms.Button();
            this.newLoveLabel = new System.Windows.Forms.Label();
            this.currentLoveLabel = new System.Windows.Forms.Label();
            this.universityPanelButton = new System.Windows.Forms.Button();
            this.lovePanelButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.jobPanel.SuspendLayout();
            this.homePanel.SuspendLayout();
            this.leisurePanel.SuspendLayout();
            this.universityPanel.SuspendLayout();
            this.lovePanel.SuspendLayout();
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
            this.jobPanel.Controls.Add(this.quitJobButton);
            this.jobPanel.Controls.Add(this.tryJobButton);
            this.jobPanel.Controls.Add(this.jobComboBox);
            this.jobPanel.Controls.Add(this.jobLabel);
            this.jobPanel.Location = new System.Drawing.Point(12, 12);
            this.jobPanel.Name = "jobPanel";
            this.jobPanel.Size = new System.Drawing.Size(776, 346);
            this.jobPanel.TabIndex = 8;
            // 
            // quitJobButton
            // 
            this.quitJobButton.Location = new System.Drawing.Point(15, 62);
            this.quitJobButton.Name = "quitJobButton";
            this.quitJobButton.Size = new System.Drawing.Size(75, 23);
            this.quitJobButton.TabIndex = 9;
            this.quitJobButton.Text = "Felmondás";
            this.quitJobButton.UseVisualStyleBackColor = true;
            this.quitJobButton.Visible = false;
            this.quitJobButton.Click += new System.EventHandler(this.quitJobButton_Click);
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
            this.jobComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.homeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // readButton
            // 
            this.readButton.Image = ((System.Drawing.Image)(resources.GetObject("readButton.Image")));
            this.readButton.Location = new System.Drawing.Point(14, 115);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(163, 85);
            this.readButton.TabIndex = 15;
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // workOutButton
            // 
            this.workOutButton.Image = ((System.Drawing.Image)(resources.GetObject("workOutButton.Image")));
            this.workOutButton.Location = new System.Drawing.Point(14, 16);
            this.workOutButton.Name = "workOutButton";
            this.workOutButton.Size = new System.Drawing.Size(163, 85);
            this.workOutButton.TabIndex = 14;
            this.workOutButton.UseVisualStyleBackColor = true;
            this.workOutButton.Click += new System.EventHandler(this.workOutButton_Click);
            // 
            // universityPanel
            // 
            this.universityPanel.Controls.Add(this.applyToUniButton);
            this.universityPanel.Controls.Add(this.universityComboBox);
            this.universityPanel.Controls.Add(this.universityLabel);
            this.universityPanel.Location = new System.Drawing.Point(12, 12);
            this.universityPanel.Name = "universityPanel";
            this.universityPanel.Size = new System.Drawing.Size(776, 346);
            this.universityPanel.TabIndex = 16;
            // 
            // applyToUniButton
            // 
            this.applyToUniButton.Location = new System.Drawing.Point(344, 189);
            this.applyToUniButton.Name = "applyToUniButton";
            this.applyToUniButton.Size = new System.Drawing.Size(75, 23);
            this.applyToUniButton.TabIndex = 2;
            this.applyToUniButton.Text = "Jelentkezés";
            this.applyToUniButton.UseVisualStyleBackColor = true;
            this.applyToUniButton.Click += new System.EventHandler(this.applyToUniButton_Click);
            // 
            // universityComboBox
            // 
            this.universityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.universityComboBox.FormattingEnabled = true;
            this.universityComboBox.Location = new System.Drawing.Point(323, 158);
            this.universityComboBox.Name = "universityComboBox";
            this.universityComboBox.Size = new System.Drawing.Size(121, 23);
            this.universityComboBox.TabIndex = 1;
            // 
            // universityLabel
            // 
            this.universityLabel.AutoSize = true;
            this.universityLabel.Location = new System.Drawing.Point(14, 16);
            this.universityLabel.Name = "universityLabel";
            this.universityLabel.Size = new System.Drawing.Size(240, 15);
            this.universityLabel.TabIndex = 0;
            this.universityLabel.Text = "Jelenleg nem veszel részt egyetemi képzésen";
            // 
            // lovePanel
            // 
            this.lovePanel.Controls.Add(this.tryForChildButton);
            this.lovePanel.Controls.Add(this.breakUpButton);
            this.lovePanel.Controls.Add(this.tryRelationshipButton);
            this.lovePanel.Controls.Add(this.newLoveButton);
            this.lovePanel.Controls.Add(this.newLoveLabel);
            this.lovePanel.Controls.Add(this.currentLoveLabel);
            this.lovePanel.Location = new System.Drawing.Point(12, 12);
            this.lovePanel.Name = "lovePanel";
            this.lovePanel.Size = new System.Drawing.Size(776, 345);
            this.lovePanel.TabIndex = 18;
            // 
            // tryForChildButton
            // 
            this.tryForChildButton.Enabled = false;
            this.tryForChildButton.Location = new System.Drawing.Point(15, 100);
            this.tryForChildButton.Name = "tryForChildButton";
            this.tryForChildButton.Size = new System.Drawing.Size(162, 23);
            this.tryForChildButton.TabIndex = 5;
            this.tryForChildButton.Text = "Próbálkozás gyermekkel";
            this.tryForChildButton.UseVisualStyleBackColor = true;
            this.tryForChildButton.Visible = false;
            this.tryForChildButton.Click += new System.EventHandler(this.tryForChildButton_Click);
            // 
            // breakUpButton
            // 
            this.breakUpButton.Location = new System.Drawing.Point(15, 71);
            this.breakUpButton.Name = "breakUpButton";
            this.breakUpButton.Size = new System.Drawing.Size(162, 23);
            this.breakUpButton.TabIndex = 4;
            this.breakUpButton.Text = "Szakítás";
            this.breakUpButton.UseVisualStyleBackColor = true;
            this.breakUpButton.Visible = false;
            this.breakUpButton.Click += new System.EventHandler(this.breakUpButton_Click);
            // 
            // tryRelationshipButton
            // 
            this.tryRelationshipButton.Location = new System.Drawing.Point(323, 282);
            this.tryRelationshipButton.Name = "tryRelationshipButton";
            this.tryRelationshipButton.Size = new System.Drawing.Size(108, 44);
            this.tryRelationshipButton.TabIndex = 3;
            this.tryRelationshipButton.Text = "Kapcsolat megpróbálása";
            this.tryRelationshipButton.UseVisualStyleBackColor = true;
            this.tryRelationshipButton.Visible = false;
            this.tryRelationshipButton.Click += new System.EventHandler(this.tryRelationshipButton_Click);
            // 
            // newLoveButton
            // 
            this.newLoveButton.Location = new System.Drawing.Point(323, 252);
            this.newLoveButton.Name = "newLoveButton";
            this.newLoveButton.Size = new System.Drawing.Size(108, 23);
            this.newLoveButton.TabIndex = 2;
            this.newLoveButton.Text = "Partner keresése";
            this.newLoveButton.UseVisualStyleBackColor = true;
            this.newLoveButton.Click += new System.EventHandler(this.newLoveButton_Click);
            // 
            // newLoveLabel
            // 
            this.newLoveLabel.AutoSize = true;
            this.newLoveLabel.Location = new System.Drawing.Point(323, 158);
            this.newLoveLabel.Name = "newLoveLabel";
            this.newLoveLabel.Size = new System.Drawing.Size(0, 15);
            this.newLoveLabel.TabIndex = 1;
            // 
            // currentLoveLabel
            // 
            this.currentLoveLabel.AutoSize = true;
            this.currentLoveLabel.Location = new System.Drawing.Point(14, 15);
            this.currentLoveLabel.Name = "currentLoveLabel";
            this.currentLoveLabel.Size = new System.Drawing.Size(141, 15);
            this.currentLoveLabel.TabIndex = 0;
            this.currentLoveLabel.Text = "Jelenleg egyedülálló vagy";
            // 
            // universityPanelButton
            // 
            this.universityPanelButton.Enabled = false;
            this.universityPanelButton.Location = new System.Drawing.Point(403, 374);
            this.universityPanelButton.Name = "universityPanelButton";
            this.universityPanelButton.Size = new System.Drawing.Size(75, 23);
            this.universityPanelButton.TabIndex = 14;
            this.universityPanelButton.Text = "Egyetem";
            this.universityPanelButton.UseVisualStyleBackColor = true;
            this.universityPanelButton.Click += new System.EventHandler(this.universityPanelButton_Click);
            // 
            // lovePanelButton
            // 
            this.lovePanelButton.Enabled = false;
            this.lovePanelButton.Location = new System.Drawing.Point(499, 374);
            this.lovePanelButton.Name = "lovePanelButton";
            this.lovePanelButton.Size = new System.Drawing.Size(75, 23);
            this.lovePanelButton.TabIndex = 17;
            this.lovePanelButton.Text = "Szerelem";
            this.lovePanelButton.UseVisualStyleBackColor = true;
            this.lovePanelButton.Click += new System.EventHandler(this.lovePanelButton_Click);
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.jobPanel);
            this.Controls.Add(this.lovePanel);
            this.Controls.Add(this.lovePanelButton);
            this.Controls.Add(this.universityPanel);
            this.Controls.Add(this.universityPanelButton);
            this.Controls.Add(this.leisurePanel);
            this.Controls.Add(this.leisurePanelButton);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.homePanelButton);
            this.Controls.Add(this.mainPanelButton);
            this.Controls.Add(this.jobPanelButton);
            this.Controls.Add(this.mainPanel);
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
            this.universityPanel.ResumeLayout(false);
            this.universityPanel.PerformLayout();
            this.lovePanel.ResumeLayout(false);
            this.lovePanel.PerformLayout();
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
        private System.Windows.Forms.Button universityPanelButton;
        private System.Windows.Forms.Panel universityPanel;
        private System.Windows.Forms.ComboBox universityComboBox;
        private System.Windows.Forms.Label universityLabel;
        private System.Windows.Forms.Button applyToUniButton;
        private System.Windows.Forms.Button lovePanelButton;
        private System.Windows.Forms.Panel lovePanel;
        private System.Windows.Forms.Label currentLoveLabel;
        private System.Windows.Forms.Label newLoveLabel;
        private System.Windows.Forms.Button newLoveButton;
        private System.Windows.Forms.Button tryRelationshipButton;
        private System.Windows.Forms.Button breakUpButton;
        private System.Windows.Forms.Button tryForChildButton;
        private System.Windows.Forms.Button quitJobButton;
    }
}