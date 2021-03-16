namespace LifeSim.View
{
    partial class MinesweeperWindow
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
            this.minefieldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.reconButton = new System.Windows.Forms.Button();
            this.markButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // minefieldPanel
            // 
            this.minefieldPanel.Location = new System.Drawing.Point(13, 13);
            this.minefieldPanel.Name = "minefieldPanel";
            this.minefieldPanel.Size = new System.Drawing.Size(403, 369);
            this.minefieldPanel.TabIndex = 0;
            // 
            // reconButton
            // 
            this.reconButton.Enabled = false;
            this.reconButton.Location = new System.Drawing.Point(473, 31);
            this.reconButton.Name = "reconButton";
            this.reconButton.Size = new System.Drawing.Size(75, 23);
            this.reconButton.TabIndex = 1;
            this.reconButton.Text = "Felderítés";
            this.reconButton.UseVisualStyleBackColor = true;
            this.reconButton.Click += new System.EventHandler(this.reconButton_Click);
            // 
            // markButton
            // 
            this.markButton.Enabled = false;
            this.markButton.Location = new System.Drawing.Point(473, 71);
            this.markButton.Name = "markButton";
            this.markButton.Size = new System.Drawing.Size(75, 23);
            this.markButton.TabIndex = 2;
            this.markButton.Text = "Megjelölés";
            this.markButton.UseVisualStyleBackColor = true;
            this.markButton.Click += new System.EventHandler(this.markButton_Click);
            // 
            // MinesweeperWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 429);
            this.Controls.Add(this.markButton);
            this.Controls.Add(this.reconButton);
            this.Controls.Add(this.minefieldPanel);
            this.Name = "MinesweeperWindow";
            this.Text = "Bevetés";
            this.Shown += new System.EventHandler(this.MinesweeperWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel minefieldPanel;
        private System.Windows.Forms.Button reconButton;
        private System.Windows.Forms.Button markButton;
    }
}