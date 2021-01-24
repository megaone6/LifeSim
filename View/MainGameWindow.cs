using LifeSim.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LifeSim.View
{
    public partial class MainGameWindow : Form
    {
        #region Fields

        private LifeSimModel model;
        List<Panel> panelList;

        #endregion

        #region Constructor

        public MainGameWindow()
        {
            InitializeComponent();

            panelList = new List<Panel>();
            panelList.Add(mainPanel);
            mainPanel.BringToFront();

            model = new LifeSimModel();
            model.newGame();

            model.DeathEvent += new EventHandler<LifeSimEventArgs>(Model_DeathEvent);

            nameLabel.Text = "Neved: " + model.You.FirstName + " " + model.You.LastName;
            intelligenceLabel.Text = "Intelligencia: " + model.You.Intelligence.ToString();
            appearanceLabel.Text = "Kinézet: " + model.You.Appearance.ToString();
            if (model.You.Gender == 0)
                genderLabel.Text = "Férfi";
            else
                genderLabel.Text = "Nő";

            MessageBox.Show("Édesapád: " + model.Parents[0].FirstName + " " + model.Parents[0].LastName + ", kora: " + model.Parents[0].Age + ", kinézete: " + model.Parents[0].Appearance + ", intelligencia: " + model.Parents[0].Intelligence
                + Environment.NewLine + "Édesanyád: " + model.Parents[1].FirstName + " " + model.Parents[1].LastName + ", kora: " + model.Parents[1].Age + ", kinézete: " + model.Parents[1].Appearance + ", intelligencia: " + model.Parents[1].Intelligence
                + Environment.NewLine + "Te: " + model.You.FirstName + " " + model.You.LastName + ", kinézet: " + model.You.Appearance.ToString() + ", intelligencia: " + model.You.Intelligence.ToString());
        }

        #endregion

        #region Model event handlers

        private void Model_DeathEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Meghaltál!" + Environment.NewLine + model.You.Age.ToString() + " évig éltél.");
        }

        #endregion

        private void MainGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ageButton_Click(object sender, EventArgs e)
        {
            model.age();
            ageLabel.Text = model.You.Age.ToString() + " éves vagy";
            healthLabel.Text = "Egészség: " + model.You.Health.ToString();
            intelligenceLabel.Text = "Intelligencia: " + model.You.Intelligence.ToString();
            appearanceLabel.Text = "Kinézet: " + model.You.Appearance.ToString();
        }

        private void testPanelButton_Click(object sender, EventArgs e)
        {
            testPanel.BringToFront();
            testPanelButton.Enabled = false;
            mainPanelButton.Enabled = true;
        }

        private void mainPanelButton_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
            mainPanelButton.Enabled = false;
            testPanelButton.Enabled = true;
        }
    }
}
