using System.Drawing;

namespace LifeSim.LSView
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
            this.eventsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.happinessLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.jobPanel = new System.Windows.Forms.Panel();
            this.tryJobButton = new System.Windows.Forms.Button();
            this.jobComboBox = new System.Windows.Forms.ComboBox();
            this.jobImageLabel = new System.Windows.Forms.Label();
            this.quitJobButton = new System.Windows.Forms.Button();
            this.jobLabel = new System.Windows.Forms.Label();
            this.jobPanelButton = new System.Windows.Forms.Button();
            this.mainPanelButton = new System.Windows.Forms.Button();
            this.homePanelButton = new System.Windows.Forms.Button();
            this.homePanel = new System.Windows.Forms.Panel();
            this.buyHomeButton = new System.Windows.Forms.Button();
            this.homeComboBox = new System.Windows.Forms.ComboBox();
            this.homeImageLabel = new System.Windows.Forms.Label();
            this.sellHomeButton = new System.Windows.Forms.Button();
            this.homeLabel = new System.Windows.Forms.Label();
            this.leisurePanelButton = new System.Windows.Forms.Button();
            this.leisurePanel = new System.Windows.Forms.Panel();
            this.vacationLabel = new System.Windows.Forms.Label();
            this.readLabel = new System.Windows.Forms.Label();
            this.workOutLabel = new System.Windows.Forms.Label();
            this.vacationButton = new System.Windows.Forms.Button();
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
            this.acquaintancePanelButton = new System.Windows.Forms.Button();
            this.acquaintancePanel = new System.Windows.Forms.Panel();
            this.makeFriendButton = new System.Windows.Forms.Button();
            this.programWithAcquaintanceButton = new System.Windows.Forms.Button();
            this.acquaintanceListBox = new System.Windows.Forms.ListBox();
            this.lotteryButton = new System.Windows.Forms.Button();
            this.visitDoctorButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.achievementMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.carPanelButton = new System.Windows.Forms.Button();
            this.carPanel = new System.Windows.Forms.Panel();
            this.takeLicenseExamButton = new System.Windows.Forms.Button();
            this.sellCarButton = new System.Windows.Forms.Button();
            this.buyCarButton = new System.Windows.Forms.Button();
            this.vehicleComboBox = new System.Windows.Forms.ComboBox();
            this.vehicleImageLabel = new System.Windows.Forms.Label();
            this.vehicleLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.jobPanel.SuspendLayout();
            this.homePanel.SuspendLayout();
            this.leisurePanel.SuspendLayout();
            this.universityPanel.SuspendLayout();
            this.lovePanel.SuspendLayout();
            this.acquaintancePanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.carPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(9, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(34, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Név: ";
            // 
            // genderLabel
            // 
            this.genderLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.genderLabel.Location = new System.Drawing.Point(8, 44);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(0, 15);
            this.genderLabel.TabIndex = 1;
            this.genderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(9, 75);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(67, 15);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "0 éves vagy";
            // 
            // ageButton
            // 
            this.ageButton.BackColor = System.Drawing.Color.Transparent;
            this.ageButton.FlatAppearance.BorderSize = 0;
            this.ageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ageButton.Location = new System.Drawing.Point(356, 413);
            this.ageButton.Name = "ageButton";
            this.ageButton.Size = new System.Drawing.Size(75, 27);
            this.ageButton.TabIndex = 3;
            this.ageButton.Text = "+1 év";
            this.ageButton.UseVisualStyleBackColor = false;
            this.ageButton.Click += new System.EventHandler(this.ageButton_Click);
            // 
            // healthLabel
            // 
            this.healthLabel.BackColor = System.Drawing.Color.Transparent;
            this.healthLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.healthLabel.Location = new System.Drawing.Point(625, 16);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(115, 15);
            this.healthLabel.TabIndex = 4;
            this.healthLabel.Text = "Egészség: 100";
            this.healthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // intelligenceLabel
            // 
            this.intelligenceLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.intelligenceLabel.Location = new System.Drawing.Point(625, 38);
            this.intelligenceLabel.Name = "intelligenceLabel";
            this.intelligenceLabel.Size = new System.Drawing.Size(115, 27);
            this.intelligenceLabel.TabIndex = 5;
            this.intelligenceLabel.Text = "Intelligencia:";
            this.intelligenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // appearanceLabel
            // 
            this.appearanceLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.appearanceLabel.Location = new System.Drawing.Point(625, 71);
            this.appearanceLabel.Name = "appearanceLabel";
            this.appearanceLabel.Size = new System.Drawing.Size(115, 23);
            this.appearanceLabel.TabIndex = 6;
            this.appearanceLabel.Text = "Kinézet: ";
            this.appearanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.Controls.Add(this.eventsRichTextBox);
            this.mainPanel.Controls.Add(this.happinessLabel);
            this.mainPanel.Controls.Add(this.moneyLabel);
            this.mainPanel.Controls.Add(this.nameLabel);
            this.mainPanel.Controls.Add(this.appearanceLabel);
            this.mainPanel.Controls.Add(this.genderLabel);
            this.mainPanel.Controls.Add(this.intelligenceLabel);
            this.mainPanel.Controls.Add(this.ageLabel);
            this.mainPanel.Controls.Add(this.healthLabel);
            this.mainPanel.Location = new System.Drawing.Point(12, 35);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(776, 320);
            this.mainPanel.TabIndex = 7;
            // 
            // eventsRichTextBox
            // 
            this.eventsRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(216)))), ((int)(((byte)(237)))));
            this.eventsRichTextBox.Location = new System.Drawing.Point(201, 138);
            this.eventsRichTextBox.Name = "eventsRichTextBox";
            this.eventsRichTextBox.ReadOnly = true;
            this.eventsRichTextBox.Size = new System.Drawing.Size(369, 174);
            this.eventsRichTextBox.TabIndex = 11;
            this.eventsRichTextBox.Text = "";
            this.eventsRichTextBox.TextChanged += new System.EventHandler(this.eventsRichTextBox_TextChanged);
            // 
            // happinessLabel
            // 
            this.happinessLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.happinessLabel.Location = new System.Drawing.Point(625, 100);
            this.happinessLabel.Name = "happinessLabel";
            this.happinessLabel.Size = new System.Drawing.Size(115, 23);
            this.happinessLabel.TabIndex = 10;
            this.happinessLabel.Text = "Boldogság: ";
            this.happinessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(8, 104);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(126, 15);
            this.moneyLabel.TabIndex = 9;
            this.moneyLabel.Text = "Jelenleg 0 forintod van";
            // 
            // jobPanel
            // 
            this.jobPanel.BackColor = System.Drawing.Color.Transparent;
            this.jobPanel.Controls.Add(this.tryJobButton);
            this.jobPanel.Controls.Add(this.jobComboBox);
            this.jobPanel.Controls.Add(this.jobImageLabel);
            this.jobPanel.Controls.Add(this.quitJobButton);
            this.jobPanel.Controls.Add(this.jobLabel);
            this.jobPanel.Location = new System.Drawing.Point(12, 35);
            this.jobPanel.Name = "jobPanel";
            this.jobPanel.Size = new System.Drawing.Size(776, 320);
            this.jobPanel.TabIndex = 8;
            // 
            // tryJobButton
            // 
            this.tryJobButton.FlatAppearance.BorderSize = 0;
            this.tryJobButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.jobComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(216)))), ((int)(((byte)(237)))));
            this.jobComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jobComboBox.FormattingEnabled = true;
            this.jobComboBox.Location = new System.Drawing.Point(323, 159);
            this.jobComboBox.Name = "jobComboBox";
            this.jobComboBox.Size = new System.Drawing.Size(121, 23);
            this.jobComboBox.TabIndex = 1;
            // 
            // jobImageLabel
            // 
            this.jobImageLabel.Location = new System.Drawing.Point(246, 12);
            this.jobImageLabel.Name = "jobImageLabel";
            this.jobImageLabel.Size = new System.Drawing.Size(300, 300);
            this.jobImageLabel.TabIndex = 10;
            // 
            // quitJobButton
            // 
            this.quitJobButton.FlatAppearance.BorderSize = 0;
            this.quitJobButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitJobButton.Location = new System.Drawing.Point(15, 62);
            this.quitJobButton.Name = "quitJobButton";
            this.quitJobButton.Size = new System.Drawing.Size(75, 23);
            this.quitJobButton.TabIndex = 9;
            this.quitJobButton.Text = "Felmondás";
            this.quitJobButton.UseVisualStyleBackColor = true;
            this.quitJobButton.Visible = false;
            this.quitJobButton.Click += new System.EventHandler(this.quitJobButton_Click);
            // 
            // jobLabel
            // 
            this.jobLabel.AutoSize = true;
            this.jobLabel.Location = new System.Drawing.Point(8, 16);
            this.jobLabel.Name = "jobLabel";
            this.jobLabel.Size = new System.Drawing.Size(0, 15);
            this.jobLabel.TabIndex = 0;
            this.jobLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // jobPanelButton
            // 
            this.jobPanelButton.AutoSize = true;
            this.jobPanelButton.BackColor = System.Drawing.Color.Transparent;
            this.jobPanelButton.Enabled = false;
            this.jobPanelButton.FlatAppearance.BorderSize = 0;
            this.jobPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jobPanelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.jobPanelButton.Location = new System.Drawing.Point(20, 375);
            this.jobPanelButton.Name = "jobPanelButton";
            this.jobPanelButton.Size = new System.Drawing.Size(75, 27);
            this.jobPanelButton.TabIndex = 0;
            this.jobPanelButton.Text = "Munka";
            this.jobPanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.jobPanelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.jobPanelButton.UseVisualStyleBackColor = false;
            this.jobPanelButton.Click += new System.EventHandler(this.jobPanelButton_Click);
            // 
            // mainPanelButton
            // 
            this.mainPanelButton.BackColor = System.Drawing.Color.Transparent;
            this.mainPanelButton.Enabled = false;
            this.mainPanelButton.FlatAppearance.BorderSize = 0;
            this.mainPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainPanelButton.Location = new System.Drawing.Point(114, 375);
            this.mainPanelButton.Name = "mainPanelButton";
            this.mainPanelButton.Size = new System.Drawing.Size(75, 27);
            this.mainPanelButton.TabIndex = 9;
            this.mainPanelButton.Text = "Fő menü";
            this.mainPanelButton.UseVisualStyleBackColor = false;
            this.mainPanelButton.Click += new System.EventHandler(this.mainPanelButton_Click);
            // 
            // homePanelButton
            // 
            this.homePanelButton.AutoSize = true;
            this.homePanelButton.BackColor = System.Drawing.Color.Transparent;
            this.homePanelButton.Enabled = false;
            this.homePanelButton.FlatAppearance.BorderSize = 0;
            this.homePanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homePanelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homePanelButton.Location = new System.Drawing.Point(208, 375);
            this.homePanelButton.Name = "homePanelButton";
            this.homePanelButton.Size = new System.Drawing.Size(75, 27);
            this.homePanelButton.TabIndex = 10;
            this.homePanelButton.Text = "Lakás";
            this.homePanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.homePanelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.homePanelButton.UseVisualStyleBackColor = false;
            this.homePanelButton.Click += new System.EventHandler(this.homePanelButton_Click);
            // 
            // homePanel
            // 
            this.homePanel.BackColor = System.Drawing.Color.Transparent;
            this.homePanel.Controls.Add(this.buyHomeButton);
            this.homePanel.Controls.Add(this.homeComboBox);
            this.homePanel.Controls.Add(this.homeImageLabel);
            this.homePanel.Controls.Add(this.sellHomeButton);
            this.homePanel.Controls.Add(this.homeLabel);
            this.homePanel.Location = new System.Drawing.Point(12, 35);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(776, 320);
            this.homePanel.TabIndex = 11;
            // 
            // buyHomeButton
            // 
            this.buyHomeButton.FlatAppearance.BorderSize = 0;
            this.buyHomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.homeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(216)))), ((int)(((byte)(237)))));
            this.homeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.homeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeComboBox.FormattingEnabled = true;
            this.homeComboBox.Location = new System.Drawing.Point(323, 158);
            this.homeComboBox.Name = "homeComboBox";
            this.homeComboBox.Size = new System.Drawing.Size(121, 23);
            this.homeComboBox.TabIndex = 0;
            // 
            // homeImageLabel
            // 
            this.homeImageLabel.Location = new System.Drawing.Point(237, 12);
            this.homeImageLabel.Name = "homeImageLabel";
            this.homeImageLabel.Size = new System.Drawing.Size(300, 300);
            this.homeImageLabel.TabIndex = 4;
            // 
            // sellHomeButton
            // 
            this.sellHomeButton.AutoSize = true;
            this.sellHomeButton.FlatAppearance.BorderSize = 0;
            this.sellHomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sellHomeButton.Location = new System.Drawing.Point(15, 49);
            this.sellHomeButton.Name = "sellHomeButton";
            this.sellHomeButton.Size = new System.Drawing.Size(90, 27);
            this.sellHomeButton.TabIndex = 3;
            this.sellHomeButton.Text = "Lakás eladása";
            this.sellHomeButton.UseVisualStyleBackColor = true;
            this.sellHomeButton.Visible = false;
            this.sellHomeButton.Click += new System.EventHandler(this.sellHomeButton_Click);
            // 
            // homeLabel
            // 
            this.homeLabel.AutoSize = true;
            this.homeLabel.Location = new System.Drawing.Point(15, 16);
            this.homeLabel.Name = "homeLabel";
            this.homeLabel.Size = new System.Drawing.Size(0, 15);
            this.homeLabel.TabIndex = 2;
            // 
            // leisurePanelButton
            // 
            this.leisurePanelButton.AutoSize = true;
            this.leisurePanelButton.BackColor = System.Drawing.Color.Transparent;
            this.leisurePanelButton.Enabled = false;
            this.leisurePanelButton.FlatAppearance.BorderSize = 0;
            this.leisurePanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leisurePanelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.leisurePanelButton.Location = new System.Drawing.Point(298, 375);
            this.leisurePanelButton.Name = "leisurePanelButton";
            this.leisurePanelButton.Size = new System.Drawing.Size(89, 27);
            this.leisurePanelButton.TabIndex = 12;
            this.leisurePanelButton.Text = "Szabadidő";
            this.leisurePanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.leisurePanelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.leisurePanelButton.UseVisualStyleBackColor = false;
            this.leisurePanelButton.Click += new System.EventHandler(this.leisurePanelButton_Click);
            // 
            // leisurePanel
            // 
            this.leisurePanel.BackColor = System.Drawing.Color.Transparent;
            this.leisurePanel.Controls.Add(this.vacationLabel);
            this.leisurePanel.Controls.Add(this.readLabel);
            this.leisurePanel.Controls.Add(this.workOutLabel);
            this.leisurePanel.Controls.Add(this.vacationButton);
            this.leisurePanel.Controls.Add(this.readButton);
            this.leisurePanel.Controls.Add(this.workOutButton);
            this.leisurePanel.Location = new System.Drawing.Point(12, 35);
            this.leisurePanel.Name = "leisurePanel";
            this.leisurePanel.Size = new System.Drawing.Size(776, 320);
            this.leisurePanel.TabIndex = 13;
            // 
            // vacationLabel
            // 
            this.vacationLabel.Location = new System.Drawing.Point(184, 219);
            this.vacationLabel.Name = "vacationLabel";
            this.vacationLabel.Size = new System.Drawing.Size(556, 36);
            this.vacationLabel.TabIndex = 19;
            this.vacationLabel.Text = "Nyaralás: Elmész külföldre nyaralni a családoddal. Nagy mértékben növeli a boldog" +
    "ságodat, de sok pénzbe kerül. (300000 * családtagok száma)";
            // 
            // readLabel
            // 
            this.readLabel.Location = new System.Drawing.Point(184, 116);
            this.readLabel.Name = "readLabel";
            this.readLabel.Size = new System.Drawing.Size(556, 31);
            this.readLabel.TabIndex = 18;
            this.readLabel.Text = "Olvasás: Elmész a legközelebbi könyvesboltba, veszel egy pár könyvet és elolvasod" +
    " őket. Növeli az intelligenciádat és a boldogságodat.";
            // 
            // workOutLabel
            // 
            this.workOutLabel.AutoSize = true;
            this.workOutLabel.Location = new System.Drawing.Point(184, 38);
            this.workOutLabel.Name = "workOutLabel";
            this.workOutLabel.Size = new System.Drawing.Size(563, 15);
            this.workOutLabel.TabIndex = 17;
            this.workOutLabel.Text = "Edzés: Elmész edzeni a legközelebbi konditerembe. Növeli az egészségedet, kinézet" +
    "edet és boldogságodat.";
            // 
            // vacationButton
            // 
            this.vacationButton.Enabled = false;
            this.vacationButton.FlatAppearance.BorderSize = 0;
            this.vacationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vacationButton.Image = ((System.Drawing.Image)(resources.GetObject("vacationButton.Image")));
            this.vacationButton.Location = new System.Drawing.Point(15, 199);
            this.vacationButton.Name = "vacationButton";
            this.vacationButton.Size = new System.Drawing.Size(163, 85);
            this.vacationButton.TabIndex = 16;
            this.vacationButton.UseVisualStyleBackColor = true;
            this.vacationButton.Click += new System.EventHandler(this.vacationButton_Click);
            // 
            // readButton
            // 
            this.readButton.FlatAppearance.BorderSize = 0;
            this.readButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readButton.Image = ((System.Drawing.Image)(resources.GetObject("readButton.Image")));
            this.readButton.Location = new System.Drawing.Point(14, 107);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(163, 85);
            this.readButton.TabIndex = 15;
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // workOutButton
            // 
            this.workOutButton.FlatAppearance.BorderSize = 0;
            this.workOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.universityPanel.BackColor = System.Drawing.Color.Transparent;
            this.universityPanel.Controls.Add(this.applyToUniButton);
            this.universityPanel.Controls.Add(this.universityComboBox);
            this.universityPanel.Controls.Add(this.universityLabel);
            this.universityPanel.Location = new System.Drawing.Point(12, 35);
            this.universityPanel.Name = "universityPanel";
            this.universityPanel.Size = new System.Drawing.Size(776, 320);
            this.universityPanel.TabIndex = 16;
            // 
            // applyToUniButton
            // 
            this.applyToUniButton.FlatAppearance.BorderSize = 0;
            this.applyToUniButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.universityComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(216)))), ((int)(((byte)(237)))));
            this.universityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.universityComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.lovePanel.BackColor = System.Drawing.Color.Transparent;
            this.lovePanel.Controls.Add(this.tryForChildButton);
            this.lovePanel.Controls.Add(this.breakUpButton);
            this.lovePanel.Controls.Add(this.tryRelationshipButton);
            this.lovePanel.Controls.Add(this.newLoveButton);
            this.lovePanel.Controls.Add(this.newLoveLabel);
            this.lovePanel.Controls.Add(this.currentLoveLabel);
            this.lovePanel.Location = new System.Drawing.Point(12, 35);
            this.lovePanel.Name = "lovePanel";
            this.lovePanel.Size = new System.Drawing.Size(776, 320);
            this.lovePanel.TabIndex = 18;
            // 
            // tryForChildButton
            // 
            this.tryForChildButton.AutoSize = true;
            this.tryForChildButton.Enabled = false;
            this.tryForChildButton.FlatAppearance.BorderSize = 0;
            this.tryForChildButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tryForChildButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tryForChildButton.Location = new System.Drawing.Point(15, 100);
            this.tryForChildButton.Name = "tryForChildButton";
            this.tryForChildButton.Size = new System.Drawing.Size(162, 25);
            this.tryForChildButton.TabIndex = 5;
            this.tryForChildButton.Text = "Próbálkozás gyermekkel";
            this.tryForChildButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tryForChildButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tryForChildButton.UseVisualStyleBackColor = true;
            this.tryForChildButton.Visible = false;
            this.tryForChildButton.Click += new System.EventHandler(this.tryForChildButton_Click);
            // 
            // breakUpButton
            // 
            this.breakUpButton.AutoSize = true;
            this.breakUpButton.FlatAppearance.BorderSize = 0;
            this.breakUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.breakUpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.breakUpButton.Location = new System.Drawing.Point(15, 71);
            this.breakUpButton.Name = "breakUpButton";
            this.breakUpButton.Size = new System.Drawing.Size(162, 25);
            this.breakUpButton.TabIndex = 4;
            this.breakUpButton.Text = "Szakítás";
            this.breakUpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.breakUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.breakUpButton.UseVisualStyleBackColor = true;
            this.breakUpButton.Visible = false;
            this.breakUpButton.Click += new System.EventHandler(this.breakUpButton_Click);
            // 
            // tryRelationshipButton
            // 
            this.tryRelationshipButton.FlatAppearance.BorderSize = 0;
            this.tryRelationshipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tryRelationshipButton.Location = new System.Drawing.Point(323, 270);
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
            this.newLoveButton.FlatAppearance.BorderSize = 0;
            this.newLoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newLoveButton.Location = new System.Drawing.Point(323, 243);
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
            this.universityPanelButton.AutoSize = true;
            this.universityPanelButton.BackColor = System.Drawing.Color.Transparent;
            this.universityPanelButton.Enabled = false;
            this.universityPanelButton.FlatAppearance.BorderSize = 0;
            this.universityPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.universityPanelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.universityPanelButton.Location = new System.Drawing.Point(400, 374);
            this.universityPanelButton.Name = "universityPanelButton";
            this.universityPanelButton.Size = new System.Drawing.Size(81, 27);
            this.universityPanelButton.TabIndex = 14;
            this.universityPanelButton.Text = "Egyetem";
            this.universityPanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.universityPanelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.universityPanelButton.UseVisualStyleBackColor = false;
            this.universityPanelButton.Click += new System.EventHandler(this.universityPanelButton_Click);
            // 
            // lovePanelButton
            // 
            this.lovePanelButton.AutoSize = true;
            this.lovePanelButton.BackColor = System.Drawing.Color.Transparent;
            this.lovePanelButton.Enabled = false;
            this.lovePanelButton.FlatAppearance.BorderSize = 0;
            this.lovePanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lovePanelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lovePanelButton.Location = new System.Drawing.Point(494, 374);
            this.lovePanelButton.Name = "lovePanelButton";
            this.lovePanelButton.Size = new System.Drawing.Size(82, 27);
            this.lovePanelButton.TabIndex = 17;
            this.lovePanelButton.Text = "Szerelem";
            this.lovePanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lovePanelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.lovePanelButton.UseVisualStyleBackColor = false;
            this.lovePanelButton.Click += new System.EventHandler(this.lovePanelButton_Click);
            // 
            // acquaintancePanelButton
            // 
            this.acquaintancePanelButton.AutoSize = true;
            this.acquaintancePanelButton.BackColor = System.Drawing.Color.Transparent;
            this.acquaintancePanelButton.Enabled = false;
            this.acquaintancePanelButton.FlatAppearance.BorderSize = 0;
            this.acquaintancePanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acquaintancePanelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.acquaintancePanelButton.Location = new System.Drawing.Point(589, 373);
            this.acquaintancePanelButton.Name = "acquaintancePanelButton";
            this.acquaintancePanelButton.Size = new System.Drawing.Size(89, 27);
            this.acquaintancePanelButton.TabIndex = 19;
            this.acquaintancePanelButton.Text = "Ismerősök";
            this.acquaintancePanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.acquaintancePanelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.acquaintancePanelButton.UseVisualStyleBackColor = false;
            this.acquaintancePanelButton.Click += new System.EventHandler(this.acquaintancePanelButton_Click);
            // 
            // acquaintancePanel
            // 
            this.acquaintancePanel.BackColor = System.Drawing.Color.Transparent;
            this.acquaintancePanel.Controls.Add(this.makeFriendButton);
            this.acquaintancePanel.Controls.Add(this.programWithAcquaintanceButton);
            this.acquaintancePanel.Controls.Add(this.acquaintanceListBox);
            this.acquaintancePanel.Location = new System.Drawing.Point(12, 35);
            this.acquaintancePanel.Name = "acquaintancePanel";
            this.acquaintancePanel.Size = new System.Drawing.Size(776, 320);
            this.acquaintancePanel.TabIndex = 10;
            // 
            // makeFriendButton
            // 
            this.makeFriendButton.BackColor = System.Drawing.Color.Transparent;
            this.makeFriendButton.FlatAppearance.BorderSize = 0;
            this.makeFriendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeFriendButton.Location = new System.Drawing.Point(298, 261);
            this.makeFriendButton.Name = "makeFriendButton";
            this.makeFriendButton.Size = new System.Drawing.Size(168, 23);
            this.makeFriendButton.TabIndex = 3;
            this.makeFriendButton.Text = "Új barát keresése";
            this.makeFriendButton.UseVisualStyleBackColor = false;
            this.makeFriendButton.Click += new System.EventHandler(this.makeFriendButton_Click);
            // 
            // programWithAcquaintanceButton
            // 
            this.programWithAcquaintanceButton.FlatAppearance.BorderSize = 0;
            this.programWithAcquaintanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.programWithAcquaintanceButton.Location = new System.Drawing.Point(298, 232);
            this.programWithAcquaintanceButton.Name = "programWithAcquaintanceButton";
            this.programWithAcquaintanceButton.Size = new System.Drawing.Size(168, 23);
            this.programWithAcquaintanceButton.TabIndex = 1;
            this.programWithAcquaintanceButton.Text = "Közös program";
            this.programWithAcquaintanceButton.UseVisualStyleBackColor = true;
            this.programWithAcquaintanceButton.Click += new System.EventHandler(this.programWithAcquaintanceButton_Click);
            // 
            // acquaintanceListBox
            // 
            this.acquaintanceListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(216)))), ((int)(((byte)(237)))));
            this.acquaintanceListBox.FormattingEnabled = true;
            this.acquaintanceListBox.ItemHeight = 15;
            this.acquaintanceListBox.Location = new System.Drawing.Point(298, 116);
            this.acquaintanceListBox.Name = "acquaintanceListBox";
            this.acquaintanceListBox.Size = new System.Drawing.Size(168, 109);
            this.acquaintanceListBox.TabIndex = 0;
            // 
            // lotteryButton
            // 
            this.lotteryButton.AutoSize = true;
            this.lotteryButton.BackColor = System.Drawing.Color.Transparent;
            this.lotteryButton.Enabled = false;
            this.lotteryButton.FlatAppearance.BorderSize = 0;
            this.lotteryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lotteryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lotteryButton.Location = new System.Drawing.Point(691, 373);
            this.lotteryButton.Name = "lotteryButton";
            this.lotteryButton.Size = new System.Drawing.Size(69, 27);
            this.lotteryButton.TabIndex = 20;
            this.lotteryButton.Text = "Lottó";
            this.lotteryButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lotteryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.lotteryButton.UseVisualStyleBackColor = false;
            this.lotteryButton.Click += new System.EventHandler(this.lotteryButton_Click);
            // 
            // visitDoctorButton
            // 
            this.visitDoctorButton.AutoSize = true;
            this.visitDoctorButton.BackColor = System.Drawing.Color.Transparent;
            this.visitDoctorButton.FlatAppearance.BorderSize = 0;
            this.visitDoctorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visitDoctorButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.visitDoctorButton.Location = new System.Drawing.Point(20, 413);
            this.visitDoctorButton.Name = "visitDoctorButton";
            this.visitDoctorButton.Size = new System.Drawing.Size(75, 27);
            this.visitDoctorButton.TabIndex = 21;
            this.visitDoctorButton.Text = "Orvos";
            this.visitDoctorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.visitDoctorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.visitDoctorButton.UseVisualStyleBackColor = false;
            this.visitDoctorButton.Click += new System.EventHandler(this.visitDoctorButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.achievementMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem,
            this.loadMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "Fájl";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(116, 22);
            this.saveMenuItem.Text = "Mentés";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // loadMenuItem
            // 
            this.loadMenuItem.Name = "loadMenuItem";
            this.loadMenuItem.Size = new System.Drawing.Size(116, 22);
            this.loadMenuItem.Text = "Betöltés";
            this.loadMenuItem.Click += new System.EventHandler(this.loadMenuItem_Click);
            // 
            // achievementMenuItem
            // 
            this.achievementMenuItem.Name = "achievementMenuItem";
            this.achievementMenuItem.Size = new System.Drawing.Size(101, 20);
            this.achievementMenuItem.Text = "Achievementek";
            this.achievementMenuItem.Click += new System.EventHandler(this.achievementMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Játékmentések|*.sav";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Játékmentések|*.sav";
            // 
            // carPanelButton
            // 
            this.carPanelButton.BackColor = System.Drawing.Color.Transparent;
            this.carPanelButton.Enabled = false;
            this.carPanelButton.FlatAppearance.BorderSize = 0;
            this.carPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.carPanelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.carPanelButton.Location = new System.Drawing.Point(691, 415);
            this.carPanelButton.Name = "carPanelButton";
            this.carPanelButton.Size = new System.Drawing.Size(75, 23);
            this.carPanelButton.TabIndex = 23;
            this.carPanelButton.Text = "Autó";
            this.carPanelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.carPanelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.carPanelButton.UseVisualStyleBackColor = false;
            this.carPanelButton.Click += new System.EventHandler(this.carPanelButton_Click);
            // 
            // carPanel
            // 
            this.carPanel.BackColor = System.Drawing.Color.Transparent;
            this.carPanel.Controls.Add(this.takeLicenseExamButton);
            this.carPanel.Controls.Add(this.sellCarButton);
            this.carPanel.Controls.Add(this.buyCarButton);
            this.carPanel.Controls.Add(this.vehicleComboBox);
            this.carPanel.Controls.Add(this.vehicleImageLabel);
            this.carPanel.Controls.Add(this.vehicleLabel);
            this.carPanel.Location = new System.Drawing.Point(12, 35);
            this.carPanel.Name = "carPanel";
            this.carPanel.Size = new System.Drawing.Size(776, 320);
            this.carPanel.TabIndex = 24;
            // 
            // takeLicenseExamButton
            // 
            this.takeLicenseExamButton.AutoSize = true;
            this.takeLicenseExamButton.FlatAppearance.BorderSize = 0;
            this.takeLicenseExamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.takeLicenseExamButton.Location = new System.Drawing.Point(15, 49);
            this.takeLicenseExamButton.Name = "takeLicenseExamButton";
            this.takeLicenseExamButton.Size = new System.Drawing.Size(120, 25);
            this.takeLicenseExamButton.TabIndex = 5;
            this.takeLicenseExamButton.Text = "Jogosítvány letétele";
            this.takeLicenseExamButton.UseVisualStyleBackColor = true;
            this.takeLicenseExamButton.Click += new System.EventHandler(this.takeLicenseExamButton_Click);
            // 
            // sellCarButton
            // 
            this.sellCarButton.FlatAppearance.BorderSize = 0;
            this.sellCarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sellCarButton.Location = new System.Drawing.Point(15, 49);
            this.sellCarButton.Name = "sellCarButton";
            this.sellCarButton.Size = new System.Drawing.Size(90, 27);
            this.sellCarButton.TabIndex = 4;
            this.sellCarButton.Text = "Eladás";
            this.sellCarButton.UseVisualStyleBackColor = true;
            this.sellCarButton.Visible = false;
            this.sellCarButton.Click += new System.EventHandler(this.sellCarButton_Click);
            // 
            // buyCarButton
            // 
            this.buyCarButton.FlatAppearance.BorderSize = 0;
            this.buyCarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buyCarButton.Location = new System.Drawing.Point(344, 193);
            this.buyCarButton.Name = "buyCarButton";
            this.buyCarButton.Size = new System.Drawing.Size(75, 23);
            this.buyCarButton.TabIndex = 2;
            this.buyCarButton.Text = "Vásárlás";
            this.buyCarButton.UseVisualStyleBackColor = true;
            this.buyCarButton.Visible = false;
            this.buyCarButton.Click += new System.EventHandler(this.buyCarButton_Click);
            // 
            // vehicleComboBox
            // 
            this.vehicleComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(216)))), ((int)(((byte)(237)))));
            this.vehicleComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vehicleComboBox.FormattingEnabled = true;
            this.vehicleComboBox.Location = new System.Drawing.Point(323, 159);
            this.vehicleComboBox.Name = "vehicleComboBox";
            this.vehicleComboBox.Size = new System.Drawing.Size(121, 23);
            this.vehicleComboBox.TabIndex = 1;
            this.vehicleComboBox.Visible = false;
            // 
            // vehicleImageLabel
            // 
            this.vehicleImageLabel.Location = new System.Drawing.Point(246, 12);
            this.vehicleImageLabel.Name = "vehicleImageLabel";
            this.vehicleImageLabel.Size = new System.Drawing.Size(300, 300);
            this.vehicleImageLabel.TabIndex = 3;
            // 
            // vehicleLabel
            // 
            this.vehicleLabel.AutoSize = true;
            this.vehicleLabel.Location = new System.Drawing.Point(15, 16);
            this.vehicleLabel.Name = "vehicleLabel";
            this.vehicleLabel.Size = new System.Drawing.Size(0, 15);
            this.vehicleLabel.TabIndex = 0;
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.carPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.carPanelButton);
            this.Controls.Add(this.leisurePanel);
            this.Controls.Add(this.jobPanel);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.acquaintancePanel);
            this.Controls.Add(this.lovePanel);
            this.Controls.Add(this.visitDoctorButton);
            this.Controls.Add(this.lotteryButton);
            this.Controls.Add(this.acquaintancePanelButton);
            this.Controls.Add(this.lovePanelButton);
            this.Controls.Add(this.universityPanel);
            this.Controls.Add(this.universityPanelButton);
            this.Controls.Add(this.leisurePanelButton);
            this.Controls.Add(this.homePanelButton);
            this.Controls.Add(this.mainPanelButton);
            this.Controls.Add(this.jobPanelButton);
            this.Controls.Add(this.ageButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainGameWindow";
            this.Text = "Életszimulátor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGameWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainGameWindow_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.jobPanel.ResumeLayout(false);
            this.jobPanel.PerformLayout();
            this.homePanel.ResumeLayout(false);
            this.homePanel.PerformLayout();
            this.leisurePanel.ResumeLayout(false);
            this.leisurePanel.PerformLayout();
            this.universityPanel.ResumeLayout(false);
            this.universityPanel.PerformLayout();
            this.lovePanel.ResumeLayout(false);
            this.lovePanel.PerformLayout();
            this.acquaintancePanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.carPanel.ResumeLayout(false);
            this.carPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel acquaintancePanel;
        private System.Windows.Forms.ListBox acquaintanceListBox;
        private System.Windows.Forms.Label happinessLabel;
        private System.Windows.Forms.Button vacationButton;
        private System.Windows.Forms.Button acquaintancePanelButton;
        private System.Windows.Forms.Button programWithAcquaintanceButton;
        private System.Windows.Forms.Button lotteryButton;
        private System.Windows.Forms.Button makeFriendButton;
        private System.Windows.Forms.Button visitDoctorButton;
        private System.Windows.Forms.RichTextBox eventsRichTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem achievementMenuItem;
        private System.Windows.Forms.Button sellHomeButton;
        private System.Windows.Forms.Label homeImageLabel;
        private System.Windows.Forms.Label jobImageLabel;
        private System.Windows.Forms.Label readLabel;
        private System.Windows.Forms.Label workOutLabel;
        private System.Windows.Forms.Label vacationLabel;
        private System.Windows.Forms.Button carPanelButton;
        private System.Windows.Forms.Panel carPanel;
        private System.Windows.Forms.Label vehicleLabel;
        private System.Windows.Forms.Button buyCarButton;
        private System.Windows.Forms.ComboBox vehicleComboBox;
        private System.Windows.Forms.Label vehicleImageLabel;
        private System.Windows.Forms.Button sellCarButton;
        private System.Windows.Forms.Button takeLicenseExamButton;
    }
}