namespace LifeSim.View
{
    partial class GameStart
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
            this.randomButton = new System.Windows.Forms.Button();
            this.inputButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(84, 44);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(89, 23);
            this.randomButton.TabIndex = 0;
            this.randomButton.Text = "Random név";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(235, 44);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(95, 23);
            this.inputButton.TabIndex = 1;
            this.inputButton.Text = "Név megadása";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // GameStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 115);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.randomButton);
            this.Name = "GameStart";
            this.Text = "Válassz!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.Button inputButton;
    }
}

