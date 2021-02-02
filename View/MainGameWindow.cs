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
            model.HomeChangedEvent += new EventHandler<EventArgs>(Model_HomeChangedEvent);
            model.UniChangedEvent += new EventHandler<EventArgs>(Model_UniChangedEvent);
            model.GraduateEvent += new EventHandler<EventArgs>(Model_GraduateEvent);
            model.HealthRefreshEvent += new EventHandler<EventArgs>(Model_HealthRefreshEvent);
            model.IntelligenceRefreshEvent += new EventHandler<EventArgs>(Model_IntelligenceRefreshEvent);
            model.RelationshipFailEvent += new EventHandler<EventArgs>(Model_RelationshipFailEvent);
            model.RelationshipSuccessEvent += new EventHandler<EventArgs>(Model_RelationshipSuccessEvent);
            model.BreakUpEvent += new EventHandler<EventArgs>(Model_BreakUpEvent);

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

            foreach (Home home in model.Homes)
            {
                homeComboBox.Items.Add(home.Type);
            }

            foreach (University uni in model.Universities)
            {
                universityComboBox.Items.Add(uni.Type);
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

        private void Model_HomeChangedEvent(object sender, EventArgs e)
        {
            String home = model.Home.Type;
            if (jobLabel.InvokeRequired)
                jobLabel.Invoke(new MethodInvoker(delegate { homeLabel.Text = home; }));
            else
                homeLabel.Text = home;
        }
        private void Model_UniChangedEvent(object sender, EventArgs e)
        {
            String uni = model.University.Type;
            if (jobLabel.InvokeRequired)
                jobLabel.Invoke(new MethodInvoker(delegate { universityLabel.Text = uni; }));
            else
                universityLabel.Text = uni;
        }

        private void Model_GraduateEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok, elvégezted a(z) " + model.University.Type + " képzést!");
            universityLabel.Text = "Jelenleg nem veszel részt egyetemi képzésen";
        }

        private void Model_HealthRefreshEvent(object sender, EventArgs e)
        {
            String health = "Egészség: " + model.You.Health.ToString();
            if (healthLabel.InvokeRequired)
                healthLabel.Invoke(new MethodInvoker(delegate { healthLabel.Text = health; }));
            else
                healthLabel.Text = health;
        }

        private void Model_IntelligenceRefreshEvent(object sender, EventArgs e)
        {
            String intelligence = "Intelligencia: " + model.You.Intelligence.ToString();
            if (healthLabel.InvokeRequired)
                intelligenceLabel.Invoke(new MethodInvoker(delegate { intelligenceLabel.Text = intelligence; }));
            else
                intelligenceLabel.Text = intelligence;
        }

        private void Model_RelationshipFailEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nem volt meg köztetek a kémia.");
            tryRelationshipButton.Enabled = false;
        }

        private void Model_RelationshipSuccessEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok! Mostantól " + model.Partner.FirstName + " " + model.Partner.LastName + " a párod!");
            currentLoveLabel.Text = "Párod: " + Environment.NewLine
                + "Név: " + model.Partner.FirstName + " " + model.Partner.LastName;
            newLoveLabel.Visible = false;
            newLoveLabel.Text = "";
            newLoveButton.Visible = false;
            tryRelationshipButton.Visible = false;
            breakUpButton.Visible = true;
        }

        private void Model_BreakUpEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Szakítottál a pároddal!");
            currentLoveLabel.Text = "Jelenleg egyedülálló vagy";
            breakUpButton.Visible = false;
            newLoveButton.Visible = true;
        }

        #endregion

        private void MainGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ageButton_Click(object sender, EventArgs e)
        {
            model.age();
            if(model.You.Age == 12)
            {
                leisurePanelButton.Enabled = true;
            }
            if (model.You.Age == 14)
            {
                lovePanelButton.Enabled = true;
            }
            if (model.You.Age > 12)
            {
                workOutButton.Enabled = true;
                readButton.Enabled = true;
            }
            if (model.You.Age == 18)
            {
                jobPanelButton.Enabled = true;
                jobLabel.Text = model.Job.Name;
                homePanelButton.Enabled = true;
                homeLabel.Text = model.Home.Type;
                universityPanelButton.Enabled = true;
                universityLabel.Text = model.University.Type;
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
            ageButton.Enabled = false;
            mainPanelButton.Enabled = true;
            homePanelButton.Enabled = true;
            leisurePanelButton.Enabled = true;
            universityPanelButton.Enabled = true;
            lovePanelButton.Enabled = true;
        }

        private void mainPanelButton_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
            mainPanelButton.Enabled = false;
            ageButton.Enabled = true;
            leisurePanelButton.Enabled = true;
            if (model.You.Age >= 14)
                lovePanelButton.Enabled = true;
            if (model.You.Age >= 18)
            {
                jobPanelButton.Enabled = true;
                homePanelButton.Enabled = true;
                universityPanelButton.Enabled = true;
            }
        }

        private void tryJobButton_Click(object sender, EventArgs e)
        {
            Job job = model.Jobs[jobComboBox.SelectedIndex];
            if ((!model.Degrees.Contains(job.DegreeNeeded)) && !(job.DegreeNeeded is null))
            {
                MessageBox.Show("Nincs meg a szükséges képzésed ehhez a munkához!");
                return;
            }
            model.jobRefresh(job);
            jobComboBox.Visible = false;
            tryJobButton.Visible = false;
        }

        private void homePanelButton_Click(object sender, EventArgs e)
        {
            homePanel.BringToFront();
            homePanelButton.Enabled = false;
            ageButton.Enabled = false;
            mainPanelButton.Enabled = true;
            jobPanelButton.Enabled = true;
            leisurePanelButton.Enabled = true;
            universityPanelButton.Enabled = true;
            lovePanelButton.Enabled = true;
        }

        private void buyHomeButton_Click(object sender, EventArgs e)
        {
            Home home = model.Homes[homeComboBox.SelectedIndex];
            if(model.You.Money < home.Price)
            {
                MessageBox.Show("Nincs elég pénzed erre a lakásra. Gyűjts még egy kicsit rá!");
                return;
            }
            model.homeRefresh(home);
            homeComboBox.Visible = false;
            buyHomeButton.Visible = false;
        }

        private void leisurePanelButton_Click(object sender, EventArgs e)
        {
            leisurePanel.BringToFront();
            mainPanelButton.Enabled = true;
            ageButton.Enabled = false;
            leisurePanelButton.Enabled = false;
            if (model.You.Age >= 14)
                lovePanelButton.Enabled = true;
            if (model.You.Age >= 18)
            {
                jobPanelButton.Enabled = true;
                homePanelButton.Enabled = true;
                universityPanelButton.Enabled = true;
            }
        }

        private void workOutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Egészség edzés előtt: " + model.You.Health);
            model.workOut();
            MessageBox.Show("Egészség edzés után: " + model.You.Health);
            workOutButton.Enabled = false;
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Intelligencia olvasás előtt: " + model.You.Intelligence);
            model.read();
            MessageBox.Show("Intelligencia olvasás után: " + model.You.Intelligence);
            readButton.Enabled = false;
        }

        private void universityPanelButton_Click(object sender, EventArgs e)
        {
            universityPanel.BringToFront();
            ageButton.Enabled = false;
            universityPanelButton.Enabled = false;
            homePanelButton.Enabled = true;
            mainPanelButton.Enabled = true;
            jobPanelButton.Enabled = true;
            leisurePanelButton.Enabled = true;
            lovePanelButton.Enabled = true;
        }

        private void applyToUniButton_Click(object sender, EventArgs e)
        {
            University uni = model.Universities[universityComboBox.SelectedIndex];
            model.uniRefresh(uni);
            universityComboBox.Visible = false;
            applyToUniButton.Visible = false;
        }

        private void lovePanelButton_Click(object sender, EventArgs e)
        {
            lovePanel.BringToFront();
            ageButton.Enabled = false;
            lovePanelButton.Enabled = false;
            mainPanelButton.Enabled = true;
            leisurePanelButton.Enabled = true;
            if (model.You.Age >= 18)
            {
                jobPanelButton.Enabled = true;
                homePanelButton.Enabled = true;
                universityPanelButton.Enabled = true;
            }
        }

        private void newLoveButton_Click(object sender, EventArgs e)
        {
            tryRelationshipButton.Visible = true;
            tryRelationshipButton.Enabled = true;
            newLoveLabel.Visible = true;
            Tuple<Person,int> newLove = model.newLove();
            newLoveLabel.Text = "Név: " + newLove.Item1.FirstName + " " + newLove.Item1.LastName + Environment.NewLine
                + "Kor: " + newLove.Item1.Age + Environment.NewLine
                + "Kinézet: " + newLove.Item1.Appearance.ToString() + Environment.NewLine
                + "Intelligencia: " + newLove.Item1.Intelligence + Environment.NewLine
                + "Esélyed: " + newLove.Item2.ToString();
        }

        private void tryRelationshipButton_Click(object sender, EventArgs e)
        {
            model.tryRelationship();
        }

        private void breakUpButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Biztos vagy benne, hogy szakítani akarsz a pároddal?",
                                      "Figyelmeztetés!",
                                      MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                model.breakUp();
        }
    }
}
