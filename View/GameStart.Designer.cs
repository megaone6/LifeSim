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
            this.inputName = new System.Windows.Forms.TextBox();
            this.acceptNameButton = new System.Windows.Forms.Button();
            this.maleRadioButton = new System.Windows.Forms.RadioButton();
            this.femaleRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(50, 44);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(123, 23);
            this.randomButton.TabIndex = 0;
            this.randomButton.Text = "Random ember";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // inputButton
            // 
            this.inputButton.Location = new System.Drawing.Point(206, 44);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(124, 23);
            this.inputButton.TabIndex = 1;
            this.inputButton.Text = "Ember testreszabása";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.inputButton_Click);
            // 
            // inputName
            // 
            this.inputName.Location = new System.Drawing.Point(117, 42);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(164, 23);
            this.inputName.TabIndex = 2;
            this.inputName.Visible = false;
            // 
            // acceptNameButton
            // 
            this.acceptNameButton.Location = new System.Drawing.Point(150, 80);
            this.acceptNameButton.Name = "acceptNameButton";
            this.acceptNameButton.Size = new System.Drawing.Size(102, 23);
            this.acceptNameButton.TabIndex = 3;
            this.acceptNameButton.Text = "Név megadása";
            this.acceptNameButton.UseVisualStyleBackColor = true;
            this.acceptNameButton.Visible = false;
            this.acceptNameButton.Click += new System.EventHandler(this.acceptNameButton_Click);
            // 
            // maleRadioButton
            // 
            this.maleRadioButton.AutoSize = true;
            this.maleRadioButton.Location = new System.Drawing.Point(287, 46);
            this.maleRadioButton.Name = "maleRadioButton";
            this.maleRadioButton.Size = new System.Drawing.Size(48, 19);
            this.maleRadioButton.TabIndex = 4;
            this.maleRadioButton.TabStop = true;
            this.maleRadioButton.Text = "Férfi";
            this.maleRadioButton.UseVisualStyleBackColor = true;
            this.maleRadioButton.Visible = false;
            // 
            // femaleRadioButton
            // 
            this.femaleRadioButton.AutoSize = true;
            this.femaleRadioButton.Location = new System.Drawing.Point(287, 73);
            this.femaleRadioButton.Name = "femaleRadioButton";
            this.femaleRadioButton.Size = new System.Drawing.Size(41, 19);
            this.femaleRadioButton.TabIndex = 5;
            this.femaleRadioButton.TabStop = true;
            this.femaleRadioButton.Text = "Nő";
            this.femaleRadioButton.UseVisualStyleBackColor = true;
            this.femaleRadioButton.Visible = false;
            // 
            // GameStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 115);
            this.Controls.Add(this.femaleRadioButton);
            this.Controls.Add(this.maleRadioButton);
            this.Controls.Add(this.acceptNameButton);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.randomButton);
            this.Name = "GameStart";
            this.Text = "Válassz!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Button acceptNameButton;
        private System.Windows.Forms.RadioButton maleRadioButton;
        private System.Windows.Forms.RadioButton femaleRadioButton;
    }
}

