using LifeSim.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeSim.View
{
    public partial class MinesweeperWindow : Form
    {
        bool newGame;
        MinesweeperModel msmodel;
        LifeSimModel lsmodel;

        public MinesweeperWindow(LifeSimModel lsmodel)
        {
            InitializeComponent();

            msmodel = new MinesweeperModel();
            this.lsmodel = lsmodel;

            msmodel.GameOverEvent += new EventHandler<EventArgs>(Model_GameOverEvent);
            msmodel.GameWonEvent += new EventHandler<EventArgs>(Model_GameWonEvent);
        }

        #region Model event handlers

        private void Model_GameOverEvent(object sender, EventArgs e)
        {
            MessageBox.Show("A bevetés sikertelen volt.");
            lsmodel.endOfMission(false);
            this.Close();
        }

        private void Model_GameWonEvent(object sender, EventArgs e)
        {
            MessageBox.Show("A bevetés sikeres volt");
            lsmodel.endOfMission(true);
            this.Close();
        }

        #endregion

        private void MinesweeperWindow_Shown(object sender, EventArgs e)
        {
            for (int i = 0; i <= 64; i++)
            {
                Button btn = new Button();
                btn.Name = "btn" + i.ToString();
                btn.Size = new System.Drawing.Size(40, 40);
                btn.UseVisualStyleBackColor = true;
                btn.BackColor = Color.Gray;

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
                msmodel.newGame(number);
                panelRefresh();
                newGame = false;
                markButton.Enabled = true;
            }
            else
            {
                if (msmodel.Recon)
                {
                    msmodel.recon(number);
                    if(!msmodel.gameOver)
                        panelRefresh();
                }
                else
                {
                    msmodel.mark(number);
                    if (!msmodel.gameOver)
                        panelRefresh();
                }
            }
        }

        private void reconButton_Click(object sender, EventArgs e)
        {
            msmodel.Recon = true;
            reconButton.Enabled = false;
            markButton.Enabled = true;
        }

        private void markButton_Click(object sender, EventArgs e)
        {
            msmodel.Recon = false;
            reconButton.Enabled = true;
            markButton.Enabled = false;
        }

        private void panelRefresh()
        {
            for (int i = 0; i < 64; i++)
            {
                if (msmodel.MineField[i / 8, i % 8].Revealed && !msmodel.MineField[i / 8, i % 8].Mine)
                {
                    minefieldPanel.Controls[i].BackColor = Color.White;
                    if (msmodel.MineField[i / 8, i % 8].MinesInProximity != 0)
                        minefieldPanel.Controls[i].Text = msmodel.MineField[i / 8, i % 8].MinesInProximity.ToString();
                }
                else if (msmodel.MineField[i / 8, i % 8].Revealed && msmodel.MineField[i / 8, i % 8].Mine)
                {
                    minefieldPanel.Controls[i].BackColor = Color.Red;
                }
                else if (msmodel.MineField[i / 8, i % 8].Marked)
                {
                    minefieldPanel.Controls[i].BackColor = Color.Yellow;
                }
                else
                {
                    minefieldPanel.Controls[i].BackColor = Color.Gray;
                }
            }
        }
    }
}
