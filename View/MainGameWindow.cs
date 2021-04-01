using LifeSim.Model;
using LifeSim.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            model.SmartUniChangedEvent += new EventHandler<EventArgs>(Model_SmartUniChangedEvent);
            model.DumbUniChangedEvent += new EventHandler<LifeSimEventArgs>(Model_DumbUniChangedEvent);
            model.SmartGraduateEvent += new EventHandler<EventArgs>(Model_SmartGraduateEvent);
            model.DumbGraduateEvent += new EventHandler<LifeSimEventArgs>(Model_DumbGraduateEvent);
            model.HealthRefreshEvent += new EventHandler<EventArgs>(Model_HealthRefreshEvent);
            model.IntelligenceRefreshEvent += new EventHandler<EventArgs>(Model_IntelligenceRefreshEvent);
            model.HappinessRefreshEvent += new EventHandler<EventArgs>(Model_HappinessRefreshEvent);
            model.AppearanceRefreshEvent += new EventHandler<EventArgs>(Model_AppearanceRefreshEvent);
            model.MoneyRefreshEvent += new EventHandler<EventArgs>(Model_MoneyRefreshEvent);
            model.RelationshipFailEvent += new EventHandler<EventArgs>(Model_RelationshipFailEvent);
            model.RelationshipSuccessEvent += new EventHandler<EventArgs>(Model_RelationshipSuccessEvent);
            model.BreakUpEvent += new EventHandler<LifeSimEventArgs>(Model_BreakUpEvent);
            model.ChildFailEvent += new EventHandler<EventArgs>(Model_ChildFailEvent);
            model.ChildSuccessEvent += new EventHandler<EventArgs>(Model_ChildSuccessEvent);
            model.ChildBornEvent += new EventHandler<EventArgs>(Model_ChildBornEvent);
            model.QuitJobEvent += new EventHandler<EventArgs>(Model_QuitJobEvent);
            model.PromotionEvent += new EventHandler<EventArgs>(Model_PromotionEvent);
            model.RetirementEvent += new EventHandler<EventArgs>(Model_RetirementEvent);
            model.VacationFailedEvent += new EventHandler<EventArgs>(Model_VacationFailedEvent);
            model.VacationSuccessEvent += new EventHandler<EventArgs>(Model_VacationSuccessEvent);
            model.WorkOutSuccessEvent += new EventHandler<EventArgs>(Model_WorkOutSuccessEvent);
            model.WorkOutFailedEvent += new EventHandler<EventArgs>(Model_WorkOutFailedEvent);
            model.ReadSuccessEvent += new EventHandler<EventArgs>(Model_ReadSuccessEvent);
            model.ReadFailedEvent += new EventHandler<EventArgs>(Model_ReadFailedEvent);
            model.ProgramWithAcquaintanceEvent += new EventHandler<LifeSimEventArgs>(Model_ProgramWithAcquaintanceEvent);
            model.QuarrelWithAcquaintanceEvent += new EventHandler<LifeSimEventArgs>(Model_QuarrelWithAcquaintanceEvent);
            model.NoMoneyForLotteryEvent += new EventHandler<EventArgs>(Model_NoMoneyForLotteryEvent);
            model.LotteryWinEvent += new EventHandler<EventArgs>(Model_LotteryWinEvent);
            model.LotteryLoseEvent += new EventHandler<EventArgs>(Model_LotteryLoseEvent);
            model.MilitaryMissionEvent += new EventHandler<EventArgs>(Model_MilitaryMissionEvent);
            model.MakeFriendFailedEvent += new EventHandler<EventArgs>(Model_MakeFriendFailedEvent);
            model.MakeFriendSuccessEvent += new EventHandler<LifeSimEventArgs>(Model_MakeFriendSuccessEvent);
            model.MilitaryMissionCompleteEvent += new EventHandler<EventArgs>(Model_MilitaryMissionCompleteEvent);
            model.PlaneCrashEvent += new EventHandler<EventArgs>(Model_PlaneCrashEvent);
            model.CaughtSicknessEvent += new EventHandler<LifeSimEventArgs>(Model_CaughtSicknessEvent);
            model.DoctorsVisitEvent += new EventHandler<LifeSimEventArgs>(Model_DoctorsVisitEvent);

            nameLabel.Text = "Neved: " + model.You.FirstName + " " + model.You.LastName;
            intelligenceLabel.Text = "Intelligencia: " + model.You.Intelligence.ToString();
            appearanceLabel.Text = "Kinézet: " + model.You.Appearance.ToString();
            happinessLabel.Text = "Boldogság: " + model.You.Happiness.ToString();
            if (model.You.Gender == 0)
                genderLabel.Text = "Nő";
            else
                genderLabel.Text = "Férfi";

            foreach (Job job in model.Jobs)
            {
                jobComboBox.Items.Add(job.JobLevels.Keys.ElementAt(0));
            }
            jobComboBox.SelectedIndex = 0;

            foreach (Home home in model.Homes)
            {
                homeComboBox.Items.Add(home.Type);
            }
            homeComboBox.SelectedIndex = 0;

            foreach (University uni in model.Universities)
            {
                universityComboBox.Items.Add(uni.Type);
            }

            acquaintanceListBox.Items.Add(model.People[1].FirstName + " " + model.People[1].LastName + " - " + model.People[1].Relationship.ToString());
            acquaintanceListBox.Items.Add(model.People[2].FirstName + " " + model.People[2].LastName + " - " + model.People[2].Relationship.ToString());

            universityComboBox.SelectedIndex = 0;

            jobLabel.Text = "Munkanélküli";

            MessageBox.Show("Édesapád: " + model.Parents[0].FirstName + " " + model.Parents[0].LastName + ", kora: " + model.Parents[0].Age + ", kinézete: " + model.Parents[0].Appearance + ", intelligencia: " + model.Parents[0].Intelligence
                + Environment.NewLine + "Édesanyád: " + model.Parents[1].FirstName + " " + model.Parents[1].LastName + ", kora: " + model.Parents[1].Age + ", kinézete: " + model.Parents[1].Appearance + ", intelligencia: " + model.Parents[1].Intelligence
                + Environment.NewLine + "Te: " + model.You.FirstName + " " + model.You.LastName + ", kinézet: " + model.You.Appearance.ToString() + ", intelligencia: " + model.You.Intelligence.ToString());
        }

        #endregion

        #region Model event handlers

        private void Model_DeathEvent(object sender, LifeSimEventArgs e)
        {
            if(e.Person.GetType() == typeof(Player))
            {
                MessageBox.Show("Meghaltál!" + Environment.NewLine + e.Person.Age.ToString() + " évig éltél.");
                DialogResult result = MessageBox.Show("Szeretnél új játékot kezdeni?", "Új játék", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if(model.You.Children.Count == 0)
                    {
                        model.newGame();

                        MessageBox.Show("Édesapád: " + model.Parents[0].FirstName + " " + model.Parents[0].LastName + ", kora: " + model.Parents[0].Age + ", kinézete: " + model.Parents[0].Appearance + ", intelligencia: " + model.Parents[0].Intelligence
                        + Environment.NewLine + "Édesanyád: " + model.Parents[1].FirstName + " " + model.Parents[1].LastName + ", kora: " + model.Parents[1].Age + ", kinézete: " + model.Parents[1].Appearance + ", intelligencia: " + model.Parents[1].Intelligence
                        + Environment.NewLine + "Te: " + model.You.FirstName + " " + model.You.LastName + ", kinézet: " + model.You.Appearance.ToString() + ", intelligencia: " + model.You.Intelligence.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Átvetted az irányítást gyermeked felett.");
                        model.takeControlOfChild();
                    }
                    nameLabel.Text = "Neved: " + model.You.FirstName + " " + model.You.LastName;
                    intelligenceLabel.Text = "Intelligencia: " + model.You.Intelligence.ToString();
                    appearanceLabel.Text = "Kinézet: " + model.You.Appearance.ToString();
                    if (model.You.Gender == Gender.Male)
                        genderLabel.Text = "Férfi";
                    else
                        genderLabel.Text = "Nő";
                    ageLabel.Text = model.You.Age.ToString() + " éves vagy";
                    moneyLabel.Text = "Jelenleg " + model.You.Money + " forintod van";
                    if (model.You.Age < 3)
                        acquaintancePanelButton.Enabled = false;
                    if (model.You.Age < 12)
                        leisurePanelButton.Enabled = false;
                    if (model.You.Age < 14)
                        lovePanelButton.Enabled = false;
                    if (model.You.Age < 18)
                    {
                        jobPanelButton.Enabled = false;
                        homePanelButton.Enabled = false;
                        universityPanelButton.Enabled = false;
                        acquaintancePanelButton.Enabled = false;
                        lotteryButton.Enabled = false;
                    }
                    jobComboBox.Visible = true;
                    tryJobButton.Visible = true;
                    quitJobButton.Visible = false;
                    homeComboBox.Visible = true;
                    buyHomeButton.Visible = true;
                    acquaintanceListBox.Items.Add(model.People[1].FirstName + " " + model.People[1].LastName + " - " + model.People[1].Relationship.ToString());
                    acquaintanceListBox.Items.Add(model.People[2].FirstName + " " + model.People[2].LastName + " - " + model.People[2].Relationship.ToString());
                    vacationButton.Enabled = false;
                    foreach (Control child in this.Controls)
                    {
                        if (child.GetType() == typeof(Button))
                            child.Enabled = false;
                    }
                    ageButton.Enabled = true;
                    visitDoctorButton.Enabled = true;
                    universityComboBox.Visible = true;
                    applyToUniButton.Visible = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Meghalt " + e.Person.FirstName + " " + e.Person.LastName + "!" + Environment.NewLine + e.Person.Age.ToString() + " évig élt.");
                acquaintanceListBox.Items.Remove(e.Person.FirstName + " " + e.Person.LastName + " - " + e.Person.Relationship.ToString());
            }
        }

        private void Model_JobChangedEvent(object sender, EventArgs e)
        {
            String job = model.You.Job.JobLevels.Keys.ElementAt(0);
            if (jobLabel.InvokeRequired)
                jobLabel.Invoke(new MethodInvoker(delegate { jobLabel.Text = job; }));
            else
                jobLabel.Text = job;
        }

        private void Model_HomeChangedEvent(object sender, EventArgs e)
        {
            String home = model.You.Home.Type;
            if (jobLabel.InvokeRequired)
                jobLabel.Invoke(new MethodInvoker(delegate { homeLabel.Text = home; }));
            else
                homeLabel.Text = home;
        }
        private void Model_SmartUniChangedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok! Bekerültél államilag finanszírozott képzésre!");
            String uni = model.You.University.Type;
            if (jobLabel.InvokeRequired)
                jobLabel.Invoke(new MethodInvoker(delegate { universityLabel.Text = uni; }));
            else
                universityLabel.Text = uni;
        }

        private void Model_DumbUniChangedEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Sajnos csak önköltséges képzésre sikerült bejutnod. A képzés befejezése után el kell kezdened fizetni a költségeket, ami " + e.UniversityCost + " forint/félév!");
            String uni = model.You.University.Type;
            if (jobLabel.InvokeRequired)
                jobLabel.Invoke(new MethodInvoker(delegate { universityLabel.Text = uni; }));
            else
                universityLabel.Text = uni;
        }

        private void Model_SmartGraduateEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok, elvégezted a(z) " + model.You.University.Type + " képzést!");
            universityLabel.Text = "Jelenleg nem veszel részt egyetemi képzésen";
        }

        private void Model_DumbGraduateEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Gratulálok, elvégezted a(z) " + model.You.University.Type + " képzést! Sajnos viszont el kell kezdened törleszteni a Diákhitel 2-t. Ez " + e.YearsToPayBack + " évig évente " + e.UniversityCost + " forintodba fog kerülni.");
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

        private void Model_HappinessRefreshEvent(object sender, EventArgs e)
        {
            String happiness = "Boldogság: " + model.You.Happiness.ToString();
            if (happinessLabel.InvokeRequired)
                happinessLabel.Invoke(new MethodInvoker(delegate { happinessLabel.Text = happiness; }));
            else
                happinessLabel.Text = happiness;
        }

        private void Model_AppearanceRefreshEvent(object sender, EventArgs e)
        {
            String appearance = "Kinézet: " + model.You.Appearance.ToString();
            if (appearanceLabel.InvokeRequired)
                appearanceLabel.Invoke(new MethodInvoker(delegate { appearanceLabel.Text = appearance; }));
            else
                appearanceLabel.Text = appearance;
        }

        private void Model_MoneyRefreshEvent(object sender, EventArgs e)
        {
            String money = "Jelenleg " + model.You.Money.ToString() + " forintod van";
            if (moneyLabel.InvokeRequired)
                moneyLabel.Invoke(new MethodInvoker(delegate { moneyLabel.Text = money; }));
            else
                moneyLabel.Text = money;
        }

        private void Model_RelationshipFailEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nem volt meg köztetek a kémia.");
            tryRelationshipButton.Enabled = false;
        }

        private void Model_RelationshipSuccessEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok! Mostantól " + model.You.Partner.FirstName + " " + model.You.Partner.LastName + " a párod!");
            currentLoveLabel.Text = "Párod: " + Environment.NewLine
                + "Név: " + model.You.Partner.FirstName + " " + model.You.Partner.LastName;
            newLoveLabel.Visible = false;
            newLoveLabel.Text = "";
            newLoveButton.Visible = false;
            tryRelationshipButton.Visible = false;
            breakUpButton.Visible = true;
            tryForChildButton.Visible = true;
        }

        private void Model_BreakUpEvent(object sender, LifeSimEventArgs e)
        {
            if(e.Death == false)
                MessageBox.Show("Szakítottál a pároddal!");
            currentLoveLabel.Text = "Jelenleg egyedülálló vagy";
            breakUpButton.Visible = false;
            tryForChildButton.Visible = false;
            newLoveButton.Visible = true;
        }

        private void Model_ChildFailEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos most nem jött össze a gyermekvállalás! Próbálkozz újra.");
        }

        private void Model_ChildSuccessEvent(object sender, EventArgs e)
        {
            tryForChildButton.Enabled = false;
            if (model.You.Gender == Gender.Male)
                MessageBox.Show("Gratulálok! Párod várandós.");
            else
                MessageBox.Show("Gratulálok! Várandós vagy.");
        }

        private void Model_ChildBornEvent(object sender, EventArgs e)
        {
            tryForChildButton.Enabled = true;
            String childName = model.You.Children[model.You.Children.Count - 1].FirstName + " " + model.You.Children[model.You.Children.Count - 1].LastName;
            MessageBox.Show("Gratulálok, gyermeked született! Neve: " + childName);
            acquaintanceListBox.Items.Add(childName + " - " + model.You.Children[model.You.Children.Count - 1].Relationship.ToString());
        }

        private void Model_QuitJobEvent(object sender, EventArgs e)
        {
            quitJobButton.Visible = false;
            jobComboBox.Visible = true;
            tryJobButton.Visible = true;
            MessageBox.Show("Kiléptél a munkahelyedről.");
            jobLabel.Text = model.You.Job.Name;
        }

        private void Model_PromotionEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok, előléptettek! Fizetésed magasabb lett.");
            jobLabel.Text = model.You.Job.JobLevels.Keys.ElementAt(model.You.CurrentJobLevel);
        }

        private void Model_RetirementEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Nyugdíjba vonultál.");
            jobLabel.Text = model.You.Job.JobLevels.Keys.ElementAt(model.You.CurrentJobLevel);
        }

        private void Model_VacationFailedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nincs elég pénzed elmenni nyaralni. Ehhez minden családtagod után (magadat is beleértve) 300000 forintot kéne fizetned.");
        }

        private void Model_VacationSuccessEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Elmentél nyaralni. Boldogságod megnőtt.");
            vacationButton.Enabled = false;
        }

        private void Model_WorkOutSuccessEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Elmentél edzeni. Egészséged, kinézeted és boldogásgod megnőtt.");
            workOutButton.Enabled = false;
        }

        private void Model_WorkOutFailedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nem volt pénzed kondibérletre.");
        }

        private void Model_ReadSuccessEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Vettél egy pár könyvet, és elolvastad őket. Intelligenciád és boldogságod megnőtt.");
            readButton.Enabled = false;
        }

        private void Model_ReadFailedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nem volt pénzed új könyvekre.");
        }

        private void Model_ProgramWithAcquaintanceEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Elmentél egy közös programra " + e.Person.FirstName + " " + e.Person.LastName + " ismerősöddel. Új kapcsolatpont: " + e.Person.Relationship.ToString());
            acquaintanceListBox.Items[e.PersonIndex] = e.Person.FirstName + " " + e.Person.LastName + " - " + e.Person.Relationship.ToString();
            acquaintanceListBox.Update();
        }

        private void Model_QuarrelWithAcquaintanceEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Összevesztél " + e.Person.FirstName + " " + e.Person.LastName + " ismerősöddel. Új kapcsolatpont: " + e.Person.Relationship.ToString());
            acquaintanceListBox.Items[e.PersonIndex] = e.Person.FirstName + " " + e.Person.LastName + " - " + e.Person.Relationship.ToString();
            acquaintanceListBox.Update();
        }

        private void Model_NoMoneyForLotteryEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nincs elég pénzed lottójegyre. 5000 forintra van szükséged.");
        }

        private void Model_LotteryWinEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok, nyertél a lottón!");
        }

        private void Model_LotteryLoseEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nem nyertél a lottón.");
        }

        private void Model_MilitaryMissionEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Bevetésre hívtak egy háború sújtotta övezetbe. Keresd meg az aknákat az aknamezőn, és hatástalanítsd őket!");
            foreach (Control child in this.Controls)
            {
                if (child.GetType() == typeof(Button))
                    child.Enabled = false;
            }
            MinesweeperWindow mine = new MinesweeperWindow(model);
            mine.Show();
        }

        private void Model_MakeFriendFailedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos senki nem akart most barátkozni veled.");
            makeFriendButton.Enabled = false;
        }

        private void Model_MakeFriendSuccessEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Sikeresen összebarátkoztál vele: " + e.Person.FirstName + " " + e.Person.LastName + "!");
            makeFriendButton.Enabled = false;
            acquaintanceListBox.Items.Add(e.Person.FirstName + " " + e.Person.LastName + " - " + e.Person.Relationship.ToString());
        }

        private void Model_MilitaryMissionCompleteEvent(object sender, EventArgs e)
        {
            foreach (Control child in this.Controls)
            {
                if (child.GetType() == typeof(Button) && child.Text != "Fő menü")
                    child.Enabled = true;
            }
        }

        private void Model_PlaneCrashEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos a gép, amin utaztál repülőgép-szerencsétlenség áldozata lett.");
            mainPanel.BringToFront();
        }

        private void Model_CaughtSicknessEvent(object sender, LifeSimEventArgs e)
        {
            if (!e.Sickness.NeedsMedicalAttention)
            {
                MessageBox.Show("Elkaptad a következő betegséget: " + e.Sickness.Name + ". Nincs okod az aggodalomra, egy pár nap lábadozás után meggyógyultál.");
            }
            else
            {
                MessageBox.Show("Nem érzed túl jól magad. Jobban teszed, ha minél előbb meglátogatsz egy orvost!");
            }
        }

        private void Model_DoctorsVisitEvent(object sender, LifeSimEventArgs e)
        {
            if (e.Sicknesses.Length == 0)
            {
                MessageBox.Show("Az orvosod nem diagnosztizált nálad semmilyen betegséget.");
            }
            else
            {
                MessageBox.Show("Az orvosod a következő betegségeket diagnosztizálta: " + e.Sicknesses + ".");
            }
        }

        #endregion

        private void MainGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ageButton_Click(object sender, EventArgs e)
        {
            model.age();
            if (model.You.Age == 3)
                acquaintancePanelButton.Enabled = true;

            if (model.You.Age == 12)
                leisurePanelButton.Enabled = true;

            if (model.You.Age > 12)
            {
                workOutButton.Enabled = true;
                readButton.Enabled = true;
            }

            if (model.You.Age == 14)
                lovePanelButton.Enabled = true;

            if (model.You.Age == 18)
            {
                jobPanelButton.Enabled = true;
                jobLabel.Text = model.You.Job.Name;
                homePanelButton.Enabled = true;
                homeLabel.Text = model.You.Home.Type;
                universityPanelButton.Enabled = true;
                universityLabel.Text = model.You.University.Type;
                acquaintancePanelButton.Enabled = true;
                lotteryButton.Enabled = true;
            }

            if (model.You.Age >= 18)
            {
                tryForChildButton.Enabled = true;
                vacationButton.Enabled = true;
            }

            makeFriendButton.Enabled = true;

            ageLabel.Text = model.You.Age.ToString() + " éves vagy";
            healthLabel.Text = "Egészség: " + model.You.Health.ToString();
            intelligenceLabel.Text = "Intelligencia: " + model.You.Intelligence.ToString();
            appearanceLabel.Text = "Kinézet: " + model.You.Appearance.ToString();
            happinessLabel.Text = "Boldogság: " + model.You.Happiness.ToString();
            moneyLabel.Text = "Jelenleg " + model.You.Money.ToString() + " forintod van";
            acquaintanceListBox.Items.Clear();

            if (model.You.Partner is null)
            {
                tryRelationshipButton.Visible = false;
                tryRelationshipButton.Enabled = false;
                newLoveLabel.Visible = false;
            }

            foreach (Person p in model.People)
            {
                if (p != model.You)
                    acquaintanceListBox.Items.Add(p.FirstName + " " + p.LastName + " - " + p.Relationship.ToString());
            }
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
            acquaintancePanelButton.Enabled = true;
        }

        private void mainPanelButton_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
            mainPanelButton.Enabled = false;
            ageButton.Enabled = true;
            acquaintancePanelButton.Enabled = true;
            if (model.You.Age >= 12)
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
            quitJobButton.Visible = true;
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
            acquaintancePanelButton.Enabled = true;
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
            acquaintancePanelButton.Enabled = true;
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
            model.workOut();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            model.read();
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
            acquaintancePanelButton.Enabled = true;
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
            acquaintancePanelButton.Enabled = true;
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
                model.breakUp(false);
        }

        private void tryForChildButton_Click(object sender, EventArgs e)
        {
            model.tryForChild();
        }

        private void quitJobButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Biztos vagy benne, hogy fel akarsz mondani a munkahelyeden?",
                                      "Figyelmeztetés!",
                                      MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                model.quitJob();
        }

        private void vacationButton_Click(object sender, EventArgs e)
        {
            model.vacation();
        }

        private void acquaintancePanelButton_Click(object sender, EventArgs e)
        {
            acquaintancePanel.BringToFront();
            ageButton.Enabled = false;
            acquaintancePanelButton.Enabled = false;
            mainPanelButton.Enabled = true;
            if (model.You.Age >= 12)
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

        private void programWithAcquaintanceButton_Click(object sender, EventArgs e)
        {
            if (acquaintanceListBox.Text == "")
            {
                MessageBox.Show("Válassz ki valakit az ismerőseid közül!");
                return;
            }
            model.programWithAcquaintance(acquaintanceListBox.SelectedIndex + 1);
        }

        private void quarrelButton_Click(object sender, EventArgs e)
        {
            if (acquaintanceListBox.Text == "")
            {
                MessageBox.Show("Válassz ki valakit az ismerőseid közül!");
                return;
            }
            model.quarrelWithAcquaintance(acquaintanceListBox.SelectedIndex + 1);
        }

        private void lotteryButton_Click(object sender, EventArgs e)
        {
            model.lottery();
        }

        private void makeFriendButton_Click(object sender, EventArgs e)
        {
            model.makeFriend();
        }

        private void visitDoctorButton_Click(object sender, EventArgs e)
        {
            model.visitDoctor();
        }
    }
}
