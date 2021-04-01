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
            this.SuspendLayout();
            // 
            // minefieldPanel
            // 
            this.minefieldPanel.Location = new System.Drawing.Point(13, 13);
            this.minefieldPanel.Name = "minefieldPanel";
            this.minefieldPanel.Size = new System.Drawing.Size(403, 369);
            this.minefieldPanel.TabIndex = 0;
            // 
            // MinesweeperWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 429);
            this.Controls.Add(this.minefieldPanel);
            this.Name = "MinesweeperWindow";
            this.Text = "Bevetés";
            this.Shown += new System.EventHandler(this.MinesweeperWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel minefieldPanel;
    }
}