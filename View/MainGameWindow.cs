using LifeSim.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LifeSim.View
{
    public partial class MainGameWindow : Form
    {
        #region Fields

        private LifeSimModel model;

        #endregion

        #region Constructor

        public MainGameWindow(LifeSimModel model)
        {
            InitializeComponent();

            mainPanel.BringToFront();

            this.model = model;
            model.newGame();

            model.DeathEvent += new EventHandler<LifeSimEventArgs>(Model_DeathEvent);
            model.JobChangedEvent += new EventHandler<EventArgs>(Model_JobChangedEvent);

            nameLabel.Text = "Neved: " + model.You.FirstName + " " + model.You.LastName;
            intelligenceLabel.Text = "Intelligencia: " + model.You.Intelligence.ToString();
            appearanceLabel.Text = "Kinézet: " + model.You.Appearance.ToString();
            if (model.You.Gender == 0)
                genderLabel.Text = "Férfi";
            else
                genderLabel.Text = "Nő";

            foreach (Job job in model.Jobs)
            {
                jobComboBox.Items.Add(job.Name);
            }

            MessageBox.Show("Édesapád: " + model.Parents[0].FirstName + " " + model.Parents[0].LastName + ", kora: " + model.Parents[0].Age + ", kinézete: " + model.Parents[0].Appearance + ", intelligencia: " + model.Parents[0].Intelligence
                + Environment.NewLine + "Édesanyád: " + model.Parents[1].FirstName + " " + model.Parents[1].LastName + ", kora: " + model.Parents[1].Age + ", kinézete: " + model.Parents[1].Appearance + ", intelligencia: " + model.Parents[1].Intelligence
                + Environment.NewLine + "Te: " + model.You.FirstName + " " + model.You.LastName + ", kinézet: " + model.You.Appearance.ToString() + ", intelligencia: " + model.You.Intelligence.ToString());
        }

        #endregion

        #region Model event handlers

        private void Model_DeathEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Meghaltál!" + Environment.NewLine + model.You.Age.ToString() + " évig éltél.");
            DialogResult result = MessageBox.Show("Szeretnél új játékot kezdeni?", "Új játék", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                model.newGame();

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
            else
            {
                Application.Exit();
            }
        }

        private void Model_JobChangedEvent(object sender, EventArgs e)
        {
            String job = model.Job.Name;
            if (jobLabel.InvokeRequired)
                jobLabel.Invoke(new MethodInvoker(delegate { jobLabel.Text = job; }));
            else
                jobLabel.Text = job;
        }

        #endregion

        private void MainGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ageButton_Click(object sender, EventArgs e)
        {
            model.age();
            if(model.You.Age == 18)
            {
                jobPanelButton.Enabled = true;
                jobLabel.Text = model.Job.Name;
            }
            ageLabel.Text = model.You.Age.ToString() + " éves vagy";
            healthLabel.Text = "Egészség: " + model.You.Health.ToString();
            intelligenceLabel.Text = "Intelligencia: " + model.You.Intelligence.ToString();
            appearanceLabel.Text = "Kinézet: " + model.You.Appearance.ToString();
            moneyLabel.Text = "Jelenleg " + model.You.Money.ToString() + " forintod van";
        }

        private void jobPanelButton_Click(object sender, EventArgs e)
        {
            jobPanel.BringToFront();
            jobPanelButton.Enabled = false;
            mainPanelButton.Enabled = true;
        }

        private void mainPanelButton_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
            mainPanelButton.Enabled = false;
            jobPanelButton.Enabled = true;
        }

        private void tryJobButton_Click(object sender, EventArgs e)
        {
            model.Job = model.Jobs[jobComboBox.SelectedIndex];
            model.jobRefresh();
            jobComboBox.Visible = false;
            tryJobButton.Visible = false;
        }
    }
}
