using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LifeSim.View
{
    public partial class MinesweeperWindow : Form
    {
        public MinesweeperWindow()
        {
            InitializeComponent();
        }

        private void MinesweeperWindow_Shown(object sender, EventArgs e)
        {
            for (int i = 0; i <= 36; i++)
            {
                Button btn = new Button();
                btn.Name = "btn" + i.ToString();
                btn.Size = new System.Drawing.Size(40, 40);
                btn.UseVisualStyleBackColor = true;

                minefieldPanel.Controls.Add(btn);
            }
        }
    }
}
