namespace LifeSim.View
{
    partial class LicenseQuestionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseQuestionsWindow));
            this.questionLabel = new System.Windows.Forms.Label();
            this.aButton = new System.Windows.Forms.Button();
            this.bButton = new System.Windows.Forms.Button();
            this.cButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.BackColor = System.Drawing.Color.Transparent;
            this.questionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionLabel.Location = new System.Drawing.Point(0, 0);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(672, 325);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aButton
            // 
            this.aButton.BackColor = System.Drawing.Color.Transparent;
            this.aButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aButton.Location = new System.Drawing.Point(76, 286);
            this.aButton.Name = "aButton";
            this.aButton.Size = new System.Drawing.Size(75, 23);
            this.aButton.TabIndex = 1;
            this.aButton.Text = "a";
            this.aButton.UseVisualStyleBackColor = false;
            this.aButton.Click += new System.EventHandler(this.aButton_Click);
            // 
            // bButton
            // 
            this.bButton.BackColor = System.Drawing.Color.Transparent;
            this.bButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bButton.Location = new System.Drawing.Point(307, 286);
            this.bButton.Name = "bButton";
            this.bButton.Size = new System.Drawing.Size(75, 23);
            this.bButton.TabIndex = 2;
            this.bButton.Text = "b";
            this.bButton.UseVisualStyleBackColor = false;
            this.bButton.Click += new System.EventHandler(this.bButton_Click);
            // 
            // cButton
            // 
            this.cButton.BackColor = System.Drawing.Color.Transparent;
            this.cButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cButton.Location = new System.Drawing.Point(513, 286);
            this.cButton.Name = "cButton";
            this.cButton.Size = new System.Drawing.Size(75, 23);
            this.cButton.TabIndex = 3;
            this.cButton.Text = "c";
            this.cButton.UseVisualStyleBackColor = false;
            this.cButton.Click += new System.EventHandler(this.cButton_Click);
            // 
            // LicenseQuestionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(672, 325);
            this.Controls.Add(this.cButton);
            this.Controls.Add(this.bButton);
            this.Controls.Add(this.aButton);
            this.Controls.Add(this.questionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LicenseQuestionsWindow";
            this.Text = "Jogosítvány";
            this.Shown += new System.EventHandler(this.LicenseQuestionsWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Button aButton;
        private System.Windows.Forms.Button bButton;
        private System.Windows.Forms.Button cButton;
    }
}