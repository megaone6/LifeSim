using LifeSim.Model;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LifeSim.View
{
    public partial class GameStart : Form
    {
        private LifeSimModel model;

        public GameStart()
        {
            InitializeComponent();
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            model = new LifeSimModel();
            var window = new MainGameWindow(model);
            window.Show();
            this.Close();
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            inputName.Visible = true;
            acceptNameButton.Visible = true;
            maleRadioButton.Visible = true;
            femaleRadioButton.Visible = true;
            inputButton.Visible = false;
            randomButton.Visible = false;
            this.Text = "Ember testreszabása";
        }

        private void acceptNameButton_Click(object sender, EventArgs e)
        {
            if (maleRadioButton.Checked)
                model = new LifeSimModel(inputName.Text, true);

            else if (femaleRadioButton.Checked)
                model = new LifeSimModel(inputName.Text, false);

            else
            {
                MessageBox.Show("Válassz egy nemet!");
                return;
            }

            String[] foolproof = inputName.Text.Split(' ');

            if (foolproof.Length != 2)
            {
                MessageBox.Show("2 szó megadása szükségses: vezeték- és keresztnév!");
                return;
            }

            if(foolproof[0].Trim() == "" || foolproof[1].Trim() == "")
            {
                MessageBox.Show("Nem adtál meg vezeték- vagy keresztnevet!");
                return;
            }

            Debug.Write(inputName.Text);
            var window = new MainGameWindow(model);
            window.Show();
            this.Close();
        }
    }
}
