using LifeSim.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LifeSim.View
{
    public partial class MinesweeperWindow : Form
    {
        bool newGame;
        MinesweeperModel model;

        public MinesweeperWindow()
        {
            InitializeComponent();

            model = new MinesweeperModel();
        }

        private void MinesweeperWindow_Shown(object sender, EventArgs e)
        {
            for (int i = 0; i <= 64; i++)
            {
                Button btn = new Button();
                btn.Name = "btn" + i.ToString();
                btn.Size = new System.Drawing.Size(40, 40);
                btn.UseVisualStyleBackColor = true;

                btn.Click += btn_Click;
                minefieldPanel.Controls.Add(btn);
            }
            newGame = true;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int number = Int32.Parse(btn.Name.Replace("btn", ""));
            if (newGame)
            {
                model.newGame(number);
                for (int i = 0; i < 64; i++)
                {
                    if (model.MineField[i / 8, i % 8].Revealed)
                    {
                        minefieldPanel.Controls[i].BackColor = Color.White;
                        if (model.MineField[i / 8, i % 8].MinesInProximity != 0)
                            minefieldPanel.Controls[i].Text = model.MineField[i / 8, i % 8].MinesInProximity.ToString();
                    }
                }
                newGame = false;
            }
            else
            {

            }
        }
    }
}
