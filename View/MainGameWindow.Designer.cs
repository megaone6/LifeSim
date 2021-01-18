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
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(26, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(34, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Név: ";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Location = new System.Drawing.Point(26, 56);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(39, 15);
            this.genderLabel.TabIndex = 1;
            this.genderLabel.Text = "Nem: ";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(26, 84);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(67, 15);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "0 éves vagy";
            // 
            // ageButton
            // 
            this.ageButton.Location = new System.Drawing.Point(347, 415);
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
            this.healthLabel.Location = new System.Drawing.Point(682, 28);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(78, 15);
            this.healthLabel.TabIndex = 4;
            this.healthLabel.Text = "Egészség: 100";
            // 
            // intelligenceLabel
            // 
            this.intelligenceLabel.AutoSize = true;
            this.intelligenceLabel.Location = new System.Drawing.Point(682, 56);
            this.intelligenceLabel.Name = "intelligenceLabel";
            this.intelligenceLabel.Size = new System.Drawing.Size(77, 15);
            this.intelligenceLabel.TabIndex = 5;
            this.intelligenceLabel.Text = "Intelligencia: ";
            // 
            // appearanceLabel
            // 
            this.appearanceLabel.AutoSize = true;
            this.appearanceLabel.Location = new System.Drawing.Point(682, 84);
            this.appearanceLabel.Name = "appearanceLabel";
            this.appearanceLabel.Size = new System.Drawing.Size(51, 15);
            this.appearanceLabel.TabIndex = 6;
            this.appearanceLabel.Text = "Kinézet: ";
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.appearanceLabel);
            this.Controls.Add(this.intelligenceLabel);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.ageButton);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "MainGameWindow";
            this.Text = "Életszimulátor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGameWindow_FormClosing);
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
    }
}