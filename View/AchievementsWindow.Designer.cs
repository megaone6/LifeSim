namespace LifeSim.View
{
    partial class AchievementsWindow
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
            this.achievementsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // achievementsPanel
            // 
            this.achievementsPanel.Location = new System.Drawing.Point(12, 12);
            this.achievementsPanel.Name = "achievementsPanel";
            this.achievementsPanel.Size = new System.Drawing.Size(787, 319);
            this.achievementsPanel.TabIndex = 0;
            // 
            // AchievementsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 343);
            this.Controls.Add(this.achievementsPanel);
            this.Name = "AchievementsWindow";
            this.Text = "Elért achievementek";
            this.Shown += new System.EventHandler(this.AchievementsWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel achievementsPanel;
    }
}