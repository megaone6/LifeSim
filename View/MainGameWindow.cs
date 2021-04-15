using LifeSim.Model;
using LifeSim.Persistence;
using LifeSim.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LifeSim.View
{
    /// <summary>
    /// LifeSim játékablak típusa.
    /// </summary>
    public partial class MainGameWindow : Form
    {
        #region Fields

        private LifeSimModel model; // játékmodell
        private int textLength; // temp String hossza (RichTextBox-hoz)
        private String tmpText; // temp String (RichTextBox-hoz)

        #endregion

        #region Constructor

        /// <summary>
        /// Játékablak példányosítása.
        /// </summary>
        /// <param name="model">Játékmodell a példányosításhoz.</param>
        public MainGameWindow(LifeSimModel model)
        {
            InitializeComponent();
            this.model = model; 
        }

        #endregion

        #region Form event handlers

        /// <summary>
        /// Játékablak betöltésének eseménykezelője.
        /// </summary>
        private void MainGameWindow_Load(Object sender, EventArgs e)
        {
            model.newGame(); // új játék indítása

            // eseménykezelők társítása
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
            model.AchievementUnlockedEvent += new EventHandler<LifeSimEventArgs>(Model_AchievementUnlockedEvent);

            refreshControls();

            // képek betöltése
            jobPanelButton.Image = Resources.job;
            homePanelButton.Image = Resources.home;
            leisurePanelButton.Image = Resources.leisure;
            universityPanelButton.Image = Resources.university;
            lovePanelButton.Image = Resources.love;
            acquaintancePanelButton.Image = Resources.acquaintances;
            lotteryButton.Image = Resources.lottery;
            visitDoctorButton.Image = Resources.doctor;
            breakUpButton.Image = Resources.breakup;
            tryForChildButton.Image = Resources.child;

            // munka Combo Box feltöltése
            foreach (Job job in model.Jobs)
                {
                    jobComboBox.Items.Add(job.JobLevels.Keys.ElementAt(0));
                }
            jobComboBox.SelectedIndex = 0;

            // lakás Combo Box feltöltése
            foreach (Home home in model.Homes)
            {
                homeComboBox.Items.Add(home.Type);
            }
            homeComboBox.SelectedIndex = 0;

            // egyetem Combo Box feltöltése
            foreach (University uni in model.Universities)
            {
                universityComboBox.Items.Add(uni.Type);
            }
            universityComboBox.SelectedIndex = 0;

            // ismerősök hozzáadása a hozzájuk tartozó List Boxhoz (először csak a szüleink)
            acquaintanceListBox.Items.Add(model.People[1].FirstName + " " + model.People[1].LastName + " - " + model.People[1].Relationship.ToString());
            acquaintanceListBox.Items.Add(model.People[2].FirstName + " " + model.People[2].LastName + " - " + model.People[2].Relationship.ToString());

            // szüleink és a mi statisztikánk kiírása egy MessageBoxba
            MessageBox.Show("Édesapád: " + model.Parents[0].FirstName + " " + model.Parents[0].LastName + ", kora: " + model.Parents[0].Age + ", kinézete: " +
                model.Parents[0].Appearance + ", intelligencia: " + model.Parents[0].Intelligence + Environment.NewLine + "Édesanyád: " + model.Parents[1].FirstName + " " +
                model.Parents[1].LastName + ", kora: " + model.Parents[1].Age + ", kinézete: " + model.Parents[1].Appearance + ", intelligencia: " + model.Parents[1].Intelligence
                + Environment.NewLine + "Te: " + model.You.FirstName + " " + model.You.LastName + ", kinézet: " + model.You.Appearance.ToString() + ", intelligencia: " +
                model.You.Intelligence.ToString());
        }

        /// <summary>
        /// Játékablak bezárásának eseménykezelője.
        /// </summary>
        private void MainGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Model event handlers

        /// <summary>
        /// Halál eseménykezelője.
        /// </summary>
        private void Model_DeathEvent(object sender, LifeSimEventArgs e)
        {
            if (e.Person.GetType() == typeof(Player)) // ha a halott személy a játékos karakter
            {
                MessageBox.Show("Meghaltál!" + Environment.NewLine + e.Person.Age.ToString() + " évig éltél.");
                DialogResult result = MessageBox.Show("Szeretnél új játékot kezdeni?", "Új játék", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) // ha igent választunk új játék kezdésére
                {
                    if (model.You.Children.Count == 0) // ha nincs gyermekünk, akkor egy teljesen új karakterrel kezdünk
                    {
                        model.newGame();

                        MessageBox.Show("Édesapád: " + model.Parents[0].FirstName + " " + model.Parents[0].LastName + ", kora: " + model.Parents[0].Age + ", kinézete: " +
                            model.Parents[0].Appearance + ", intelligencia: " + model.Parents[0].Intelligence+ Environment.NewLine + "Édesanyád: " + model.Parents[1].FirstName +
                            " " + model.Parents[1].LastName + ", kora: " + model.Parents[1].Age + ", kinézete: " + model.Parents[1].Appearance + ", intelligencia: " +
                            model.Parents[1].Intelligence + Environment.NewLine + "Te: " + model.You.FirstName + " " + model.You.LastName + ", kinézet: " +
                            model.You.Appearance.ToString() + ", intelligencia: " + model.You.Intelligence.ToString());
                    }
                    else // különben átvesszük az irányítást legidősebb gyermekünk felett
                    {
                        MessageBox.Show("Átvetted az irányítást gyermeked felett.");
                        model.takeControlOfChild();
                    }

                    refreshControls();
                }
                else // ha nemet választunk, akkor csak szimplán kilépünk a programból
                {
                    Application.Exit();
                }
            }
            else // ha nem játékos halt meg, akkor csak kiírjuk, hogy ki halt meg és töröljük az ismerősök listájából
            {
                eventsRichTextBox.AppendText("Meghalt " + e.Person.FirstName + " " + e.Person.LastName + "!" + Environment.NewLine + e.Person.Age.ToString() + " évig élt." +
                    Environment.NewLine + Environment.NewLine);
                acquaintanceListBox.Items.Remove(e.Person.FirstName + " " + e.Person.LastName + " - " + e.Person.Relationship.ToString());
            }
        }

        /// <summary>
        /// Munkaváltozás eseménykezelője.
        /// </summary>
        private void Model_JobChangedEvent(object sender, EventArgs e)
        {
            String job = model.You.Job.JobLevels.Keys.ElementAt(0); // lekérjük az új pozíciónk nevét
            eventsRichTextBox.AppendText("Elkezdtél dolgozni a következő pozícióban: " + job + Environment.NewLine + Environment.NewLine);
            if (jobLabel.InvokeRequired) // megváltoztatjuk a jobLabel szövegét
                jobLabel.Invoke(new MethodInvoker(delegate { jobLabel.Text = job; }));
            else
                jobLabel.Text = job;
        }

        /// <summary>
        /// Lakásváltozás eseménykezelője.
        /// </summary>
        private void Model_HomeChangedEvent(object sender, EventArgs e)
        {
            String home = model.You.Home.Type; //lekérjük az új lakásunk típusát
            eventsRichTextBox.AppendText("Megvetted a következő lakást: " + home + Environment.NewLine + Environment.NewLine);
            if (jobLabel.InvokeRequired) // megváltoztatjuk a homeLabel szövegét
                jobLabel.Invoke(new MethodInvoker(delegate { homeLabel.Text = home; }));
            else
                homeLabel.Text = home;
        }

        /// <summary>
        /// Egyetemváltozás eseménykezelője (magas intelligencia).
        /// </summary>
        private void Model_SmartUniChangedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok! Bekerültél államilag finanszírozott képzésre!");
            eventsRichTextBox.AppendText("Gratulálok! Bekerültél államilag finanszírozott képzésre!" + Environment.NewLine + Environment.NewLine);
            String uni = model.You.University.Type; // lekérjük az egyertem típusát
            if (universityLabel.InvokeRequired) // megváltoztatjuk a universityLabel szövegét
                universityLabel.Invoke(new MethodInvoker(delegate { universityLabel.Text = uni; }));
            else
                universityLabel.Text = uni;
        }

        /// <summary>
        /// Egyetemváltozás eseménykezelője (alacsony intelligencia).
        /// </summary>
        private void Model_DumbUniChangedEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Sajnos csak önköltséges képzésre sikerült bejutnod. A képzés befejezése után el kell kezdened fizetni a költségeket, ami " + e.UniversityCost +
                " forint/félév!");
            eventsRichTextBox.AppendText("Sajnos csak önköltséges képzésre sikerült bejutnod. A képzés befejezése után el kell kezdened fizetni a költségeket, ami " +
                e.UniversityCost + " forint/félév!" + Environment.NewLine + Environment.NewLine);
            String uni = model.You.University.Type; // lekérjük az egyertem típusát
            if (universityLabel.InvokeRequired) // megváltoztatjuk a universityLabel szövegét
                universityLabel.Invoke(new MethodInvoker(delegate { universityLabel.Text = uni; }));
            else
                universityLabel.Text = uni;
        }

        /// <summary>
        /// Egyetem elvégzés eseménykezelője (alacsony intelligencia).
        /// </summary>
        private void Model_SmartGraduateEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok, elvégezted a(z) " + model.You.University.Type + " képzést!");
            eventsRichTextBox.AppendText("Gratulálok, elvégezted a(z) " + model.You.University.Type + " képzést!" + Environment.NewLine + Environment.NewLine);
            universityLabel.Text = "Jelenleg nem veszel részt egyetemi képzésen";
        }

        /// <summary>
        /// Egyetem elvégzés eseménykezelője (alacsony intelligencia).
        /// </summary>
        private void Model_DumbGraduateEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Gratulálok, elvégezted a(z) " + model.You.University.Type + " képzést! Sajnos viszont el kell kezdened törleszteni a Diákhitel 2-t. Ez " +
                e.YearsToPayBack + " évig évente " + e.UniversityCost + " forintodba fog kerülni.");
            eventsRichTextBox.AppendText("Gratulálok, elvégezted a(z) " + model.You.University.Type + " képzést! Sajnos viszont el kell kezdened törleszteni a Diákhitel 2-t. Ez " +
                e.YearsToPayBack + " évig évente " + e.UniversityCost + " forintodba fog kerülni." + Environment.NewLine + Environment.NewLine);
            universityLabel.Text = "Jelenleg nem veszel részt egyetemi képzésen";
        }

        /// <summary>
        /// Egészség változás eseménykezelője.
        /// </summary>
        private void Model_HealthRefreshEvent(object sender, EventArgs e)
        {
            String health = "Egészség: " + model.You.Health.ToString(); // lekérjük karakterünk egészségét
            if (healthLabel.InvokeRequired) // ha szükséges, akkor változtatjuk a healthLabel szövegét
                healthLabel.Invoke(new MethodInvoker(delegate { healthLabel.Text = health; }));
            else
                healthLabel.Text = health;

            if (model.You.Health >= 50)
                healthLabel.Image = Resources.healthy;
            else
                healthLabel.Image = Resources.unhealthy;
        }

        /// <summary>
        /// Intelligencia változás eseménykezelője.
        /// </summary>
        private void Model_IntelligenceRefreshEvent(object sender, EventArgs e)
        {
            String intelligence = "Intelligencia: " + model.You.Intelligence.ToString(); // lekérjük karakterünk intelligenciáját
            if (healthLabel.InvokeRequired) // ha szükséges, akkor változtatjuk az intelligenceLabel szövegét
                intelligenceLabel.Invoke(new MethodInvoker(delegate { intelligenceLabel.Text = intelligence; }));
            else
                intelligenceLabel.Text = intelligence;

            if (model.You.Intelligence >= 50)
                intelligenceLabel.Image = Resources.smart;
            else
                intelligenceLabel.Image = Resources.dumb;
        }

        /// <summary>
        /// Boldogság változás eseménykezelője.
        /// </summary>
        private void Model_HappinessRefreshEvent(object sender, EventArgs e)
        {
            String happiness = "Boldogság: " + model.You.Happiness.ToString(); // lekérjük karakterünk boldogságát
            if (happinessLabel.InvokeRequired) // ha szükséges, akkor változtatjuk a happinessLabel szövegét
                happinessLabel.Invoke(new MethodInvoker(delegate { happinessLabel.Text = happiness; }));
            else
                happinessLabel.Text = happiness;

            if (model.You.Health >= 50)
                happinessLabel.Image = Resources.happy;
            else
                happinessLabel.Image = Resources.sad;
        }

        /// <summary>
        /// Kinézet változás eseménykezelője.
        /// </summary>
        private void Model_AppearanceRefreshEvent(object sender, EventArgs e)
        {
            String appearance = "Kinézet: " + model.You.Appearance.ToString(); // lekérjük karakterünk kinézetét
            if (appearanceLabel.InvokeRequired) // ha szükséges, akkor változtatjuk az appearanceLabel szövegét
                appearanceLabel.Invoke(new MethodInvoker(delegate { appearanceLabel.Text = appearance; }));
            else
                appearanceLabel.Text = appearance;

            if (model.You.Health >= 50)
                appearanceLabel.Image = Resources.beautiful;
            else
                appearanceLabel.Image = Resources.ugly;
        }

        /// <summary>
        /// Pénz változás eseménykezelője.
        /// </summary>
        private void Model_MoneyRefreshEvent(object sender, EventArgs e)
        {
            String money = "Jelenleg " + model.You.Money.ToString() + " forintod van"; // lekérjük karakterünk vagyonát
            if (moneyLabel.InvokeRequired) // ha szükséges, akkor változtatjuk a moneyLabel szövegét
                moneyLabel.Invoke(new MethodInvoker(delegate { moneyLabel.Text = money; }));
            else
                moneyLabel.Text = money;
        }

        /// <summary>
        /// Sikertelen kapcsolat eseménykezelője.
        /// </summary>
        private void Model_RelationshipFailEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nem volt meg köztetek a kémia.");
            tryRelationshipButton.Enabled = false; // kikapcsoljuk a gombot, hogy ne tudjunk összejönni azzal, aki elutasított
        }

        /// <summary>
        /// Sikeres kapcsolat eseménykezelője.
        /// </summary>
        private void Model_RelationshipSuccessEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Gratulálok! Mostantól " + model.You.Partner.FirstName + " " + model.You.Partner.LastName + " a párod!");

            // frissítjük a currentLoveLabel szövegét a jelenlegi partnerünk adataival
            currentLoveLabel.Text = "Párod: " + Environment.NewLine
                + "Név: " + model.You.Partner.FirstName + " " + model.You.Partner.LastName;

            // feljegyezzük az eseményt a RichTextBoxba
            eventsRichTextBox.AppendText("Gratulálok! Mostantól " + model.You.Partner.FirstName + " " + model.You.Partner.LastName + " a párod!" + Environment.NewLine +
                Environment.NewLine);

            // hozzáadjuk a partnerünket az ismerőseink ListBoxához
            acquaintanceListBox.Items.Add(model.You.Partner.FirstName + " " + model.You.Partner.LastName + " - " + model.You.Partner.Relationship.ToString());

            // eltüntetünk minden opciót, amit csak partner nélkül lehet csinálni, és előhozzuk azokat, amiket csak partnerrel
            newLoveLabel.Visible = false;
            newLoveLabel.Text = "";
            newLoveButton.Visible = false;
            tryRelationshipButton.Visible = false;
            breakUpButton.Visible = true;
            tryForChildButton.Visible = true;
        }

        /// <summary>
        /// Különválás eseménykezelője.
        /// </summary>
        private void Model_BreakUpEvent(object sender, LifeSimEventArgs e)
        {
            if (e.Death == false) // ha a különválás nem a partner halála miatt történt, akkor szakításként tartjuk nyilván
            {
                MessageBox.Show("Szakítottál a pároddal!");
                eventsRichTextBox.AppendText("Szakítottál a pároddal!" + Environment.NewLine + Environment.NewLine);
            }

            // frissítjük a currentLoveLabel szövegét, és láthatatlanná tesszük a fölösleges gombokat
            currentLoveLabel.Text = "Jelenleg egyedülálló vagy";
            breakUpButton.Visible = false;
            tryForChildButton.Visible = false;
            newLoveButton.Visible = true;
        }

        /// <summary>
        /// Sikertelen gyermekvállalás eseménykezelője.
        /// </summary>
        private void Model_ChildFailEvent(object sender, EventArgs e)
        {
            // jelezzük, hogy sikertelen volt a gyermekvállalás
            MessageBox.Show("Sajnos most nem jött össze a gyermekvállalás! Próbálkozz újra.");
            eventsRichTextBox.AppendText("Sajnos most nem jött össze a gyermekvállalás! Próbálkozz újra." + Environment.NewLine + Environment.NewLine);
        }

        /// <summary>
        /// Sikeres gyermekvállalás eseménykezelője.
        /// </summary>
        private void Model_ChildSuccessEvent(object sender, EventArgs e)
        {
            tryForChildButton.Enabled = false; // kikapcsoljuk a gyermekvállalás gombot az adott évre

            if (model.You.Gender == Gender.Male) // ha férfiak vagyunk, akkor a párunk lesz várandós
            {
                MessageBox.Show("Gratulálok! Párod várandós.");
                eventsRichTextBox.AppendText("Gratulálok! Párod várandós." + Environment.NewLine + Environment.NewLine);
            }

            else // ha nők, akkor mi leszünk azok
            {
                MessageBox.Show("Gratulálok! Várandós vagy.");
                eventsRichTextBox.AppendText("Gratulálok! Várandós vagy." + Environment.NewLine + Environment.NewLine);
            }
        }

        /// <summary>
        /// Gyermek születésének eseménykezelője.
        /// </summary>
        private void Model_ChildBornEvent(object sender, EventArgs e)
        {
            tryForChildButton.Enabled = true; // bekapcsoljuk a gyermekvállalás gombot

            String childName = model.You.Children[model.You.Children.Count - 1].FirstName + " " + model.You.Children[model.You.Children.Count - 1].LastName; // lekérjük a gyermek nevét

            // jelezzük, hogy gyermek született
            MessageBox.Show("Gratulálok, gyermeked született! Neve: " + childName);
            eventsRichTextBox.AppendText("Gratulálok, gyermeked született! Neve: " + childName + Environment.NewLine + Environment.NewLine);

            acquaintanceListBox.Items.Add(childName + " - " + model.You.Children[model.You.Children.Count - 1].Relationship.ToString()); // hozzáadjuk az ismerősök ListBoxhoz
        }

        /// <summary>
        /// Munkahelyről való kilépés eseménykezelője.
        /// </summary>
        private void Model_QuitJobEvent(object sender, EventArgs e)
        {
            // be- és kikapcsoljuk a különböző gombok láthatóságát
            quitJobButton.Visible = false;
            jobComboBox.Visible = true;
            tryJobButton.Visible = true;

            // jelezzük, hogy kiléptünk a munkahelyről
            MessageBox.Show("Kiléptél a munkahelyedről.");
            eventsRichTextBox.AppendText("Kiléptél a munkahelyedről." + Environment.NewLine + Environment.NewLine);

            jobLabel.Text = model.You.Job.JobLevels.Keys.ElementAt(model.You.CurrentJobLevel); // frissítjük a jobLabel szövegét
        }

        /// <summary>
        /// Előléptetés eseménykezelője.
        /// </summary>
        private void Model_PromotionEvent(object sender, EventArgs e)
        {
            // jelezzük az előléptetést
            MessageBox.Show("Gratulálok, előléptettek! Fizetésed magasabb lett.");
            eventsRichTextBox.AppendText("Gratulálok, előléptettek! Fizetésed magasabb lett." + Environment.NewLine + Environment.NewLine);

            jobLabel.Text = model.You.Job.JobLevels.Keys.ElementAt(model.You.CurrentJobLevel); // frissítjük a jobLabel szövegét, hogy jelezze új pozíciónkat
        }

        /// <summary>
        /// Nyugdíjba vonulás eseménykezelője.
        /// </summary>
        private void Model_RetirementEvent(object sender, EventArgs e)
        {
            // jelezzük a nyugdíjba vonulást
            MessageBox.Show("Nyugdíjba vonultál.");
            eventsRichTextBox.AppendText("Nyugdíjba vonultál." + Environment.NewLine + Environment.NewLine);

            jobLabel.Text = model.You.Job.JobLevels.Keys.ElementAt(model.You.CurrentJobLevel); // frissítjük a jobLabel szövegét
            quitJobButton.Visible = false;
        }

        /// <summary>
        /// Sikertelen vakáció eseménykezelője.
        /// </summary>
        private void Model_VacationFailedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nincs elég pénzed elmenni nyaralni. Ehhez minden családtagod után (magadat is beleértve) 300000 forintot kéne fizetned.");
        }

        /// <summary>
        /// Sikeres vakáció eseménykezelője.
        /// </summary>
        private void Model_VacationSuccessEvent(object sender, EventArgs e)
        {
            // jelezzük a sikeres vakációt
            MessageBox.Show("Elmentél nyaralni. Boldogságod megnőtt.");
            eventsRichTextBox.AppendText("Elmentél nyaralni. Boldogságod megnőtt." + Environment.NewLine + Environment.NewLine);
            
            vacationButton.Enabled = false; // kapcsoljuk ki a vakáció gombot az adott évre
        }

        /// <summary>
        /// Sikeres edzés eseménykezelője.
        /// </summary>
        private void Model_WorkOutSuccessEvent(object sender, EventArgs e)
        {
            // jelezzük a sikeres edzést
            MessageBox.Show("Elmentél edzeni. Egészséged, kinézeted és boldogásgod megnőtt.");
            eventsRichTextBox.AppendText("Elmentél edzeni. Egészséged, kinézeted és boldogásgod megnőtt." + Environment.NewLine + Environment.NewLine);

            workOutButton.Enabled = false; // kapcsoljuk ki az edzés gombot az adott évre
        }

        /// <summary>
        /// Sikertelen edzés eseménykezelője.
        /// </summary>
        private void Model_WorkOutFailedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nem volt pénzed kondibérletre.");
        }

        /// <summary>
        /// Sikeres olvasás eseménykezelője.
        /// </summary>
        private void Model_ReadSuccessEvent(object sender, EventArgs e)
        {
            // jelezzük a sikeres olvasást
            MessageBox.Show("Vettél egy pár könyvet, és elolvastad őket. Intelligenciád és boldogságod megnőtt.");
            eventsRichTextBox.AppendText("Vettél egy pár könyvet, és elolvastad őket. Intelligenciád és boldogságod megnőtt." + Environment.NewLine + Environment.NewLine);

            readButton.Enabled = false; // kapcsoljuk ki az olvasás gombot az adott évre
        }

        /// <summary>
        /// Sikertelen olvasás eseménykezelője.
        /// </summary>
        private void Model_ReadFailedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nem volt pénzed új könyvekre.");
        }

        /// <summary>
        /// Ismerőssel való közös program eseménykezelője.
        /// </summary>
        private void Model_ProgramWithAcquaintanceEvent(object sender, LifeSimEventArgs e)
        {
            // jelezzük a program sikerességét, és az új kapcsolatpontot
            MessageBox.Show("Elmentél egy közös programra " + e.Person.FirstName + " " + e.Person.LastName + " ismerősöddel. Új kapcsolatpont: " + e.Person.Relationship.ToString());
            eventsRichTextBox.AppendText("Elmentél egy közös programra " + e.Person.FirstName + " " + e.Person.LastName + " ismerősöddel. Új kapcsolatpont: " +
                e.Person.Relationship.ToString() + Environment.NewLine + Environment.NewLine);

            // frissítjük az adott ismerőshöz tartozó kapcsolatpontot a ListBoxban
            acquaintanceListBox.Items[e.PersonIndex] = e.Person.FirstName + " " + e.Person.LastName + " - " + e.Person.Relationship.ToString();
            acquaintanceListBox.Update();
        }

        /// <summary>
        /// Ismerőssel való összeveszés eseménykezelője.
        /// </summary>
        private void Model_QuarrelWithAcquaintanceEvent(object sender, LifeSimEventArgs e)
        {
            //jelezzük az összeveszést
            eventsRichTextBox.AppendText("Összevesztél " + e.Person.FirstName + " " + e.Person.LastName + " ismerősöddel. Új kapcsolatpont: " + e.Person.Relationship.ToString() +
                Environment.NewLine + Environment.NewLine);

            // frissítjük az adott ismerőshöz tartozó kapcsolatpontot a ListBoxban
            acquaintanceListBox.Update();
        }

        /// <summary>
        /// Lottószelvény sikertelen vételének eseménykezelője.
        /// </summary>
        private void Model_NoMoneyForLotteryEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nincs elég pénzed lottójegyre. 5000 forintra van szükséged.");
        }

        /// <summary>
        /// Lottó megnyerésének eseménykezelője.
        /// </summary>
        private void Model_LotteryWinEvent(object sender, EventArgs e)
        {
            // jegyezzük fel, hogy nyertünk a lottón
            MessageBox.Show("Gratulálok, nyertél a lottón!");
            eventsRichTextBox.AppendText("Gratulálok, nyertél a lottón!" + Environment.NewLine + Environment.NewLine);
        }

        /// <summary>
        /// Lottó elvesztésének eseménykezelője.
        /// </summary>
        private void Model_LotteryLoseEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos nem nyertél a lottón.");
        }

        /// <summary>
        /// Katonai bevetés eseménykezelője.
        /// </summary>
        private void Model_MilitaryMissionEvent(object sender, EventArgs e)
        {
            // jelezzük, hogy behívtak misszióra
            MessageBox.Show("Bevetésre hívtak egy háború sújtotta övezetbe. Keresd meg az aknákat az aknamezőn, és hatástalanítsd őket!");
            eventsRichTextBox.AppendText("Bevetésre hívtak egy háború sújtotta övezetbe." + Environment.NewLine + Environment.NewLine);

            foreach (Control child in this.Controls) // kikapcsoljuk az összes gombot a Form-on
            {
                if (child.GetType() == typeof(Button))
                    child.Enabled = false;
            }

            // létrehozunk egy új MinesweeperWindow formot, és ezt megjelenítjük
            MinesweeperWindow mine = new MinesweeperWindow(model);
            mine.Show();
        }


        /// <summary>
        /// Sikertelen barátkozás eseménykezelője.
        /// </summary>
        private void Model_MakeFriendFailedEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos senki nem akart most barátkozni veled.");
            makeFriendButton.Enabled = false; // kikapcsoljuk a barátkozás gombot az adott évre
        }

        /// <summary>
        /// Sikeres barátkozás eseménykezelője.
        /// </summary>
        private void Model_MakeFriendSuccessEvent(object sender, LifeSimEventArgs e)
        {
            // jelezzük a barátkozás sikerességét
            MessageBox.Show("Sikeresen összebarátkoztál vele: " + e.Person.FirstName + " " + e.Person.LastName + "!");
            eventsRichTextBox.AppendText("Sikeresen összebarátkoztál vele: " + e.Person.FirstName + " " + e.Person.LastName + "!" + Environment.NewLine + Environment.NewLine);

            makeFriendButton.Enabled = false; // kikapcsoljuk a barátkozás gombot az adott évre

            acquaintanceListBox.Items.Add(e.Person.FirstName + " " + e.Person.LastName + " - " + e.Person.Relationship.ToString()); //hozzáadjuk a ListBoxhoz az új barátunkat
        }

        /// <summary>
        /// Katonai bevetés végének eseménykezelője.
        /// </summary>
        private void Model_MilitaryMissionCompleteEvent(object sender, EventArgs e)
        {
            foreach (Control child in this.Controls) // visszakapcsoljuk a szükséges gombokat
            {
                if (child.GetType() == typeof(Button) && child.Text != "Fő menü")
                    child.Enabled = true;
            }
        }

        /// <summary>
        /// Repülőgép-szerencsétlenség eseménykezelője.
        /// </summary>
        private void Model_PlaneCrashEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Sajnos a gép, amin utaztál repülőgép-szerencsétlenség áldozata lett.");
            mainPanel.BringToFront();
        }

        /// <summary>
        /// Betegség elkapásának eseménykezelője.
        /// </summary>
        private void Model_CaughtSicknessEvent(object sender, LifeSimEventArgs e)
        {
            if (!e.Sickness.NeedsMedicalAttention) // ha nincs szükség orvosi beavatkozásra, akkor kiírja a betegség nevét
            {
                eventsRichTextBox.AppendText("Elkaptad a következő betegséget: " + e.Sickness.Name + ". Nincs okod az aggodalomra, egy pár nap lábadozás után meggyógyultál." +
                    Environment.NewLine + Environment.NewLine);
            }

            else // különben titok marad, amíg meg nem látogatunk egy orvost
            {
                eventsRichTextBox.AppendText("Nem érzed túl jól magad. Jobban teszed, ha minél előbb meglátogatsz egy orvost!" + Environment.NewLine + Environment.NewLine);

            }
        }

        /// <summary>
        /// Orvos meglátogatásának eseménykezelője.
        /// </summary>
        private void Model_DoctorsVisitEvent(object sender, LifeSimEventArgs e)
        {
            visitDoctorButton.Enabled = false; // kikapcsoljuk az orvos meglátogatása gombot az adott évre

            if (e.Sicknesses.Length == 0) // ha nincs betegségünk, akkor ezt kiírjuk
            {
                eventsRichTextBox.AppendText("Az orvosod nem diagnosztizált nálad semmilyen betegséget." + Environment.NewLine + Environment.NewLine);
                return;
            }

            if (e.SicknessesHealed.Length == 0) // ha az orvos nem tudta gyógyítani a betegségünket, akkor ezt kiírjuk
            {
                eventsRichTextBox.AppendText("Az orvosod a következő betegségeket diagnosztizálta: " + e.Sicknesses + "." + Environment.NewLine +
                    "Sajnos egyiket sem tudta gyógyítani. Nincs elég pénzed/nem sikerült a kezelés." + Environment.NewLine + Environment.NewLine);
                return;
            }

            eventsRichTextBox.AppendText("Az orvosod a következő betegségeket diagnosztizálta: " + e.Sicknesses + "." + Environment.NewLine + "A következőket tudta gyógyítani: " +
                e.SicknessesHealed + Environment.NewLine + Environment.NewLine); // kiírjuk a gyógyított betegségeket
        }

        /// <summary>
        /// Achievement feloldásának eseménykezelője.
        /// </summary>
        private void Model_AchievementUnlockedEvent(object sender, LifeSimEventArgs e)
        {
            MessageBox.Show("Gratulálok! Elérted a következő teljesítményt: " + e.AchievementName + "!");
        }

        #endregion

        #region Control event handlers

        /// <summary>
        /// Előrehaladás gomb eseménykezelője.
        /// </summary>
        private void ageButton_Click(object sender, EventArgs e)
        {
            // új részt kezdünk a RichTextBoxban az adott évnek
            tmpText = (model.You.Age + 1).ToString() + " éves" + Environment.NewLine + Environment.NewLine;
            textLength = eventsRichTextBox.Text.Length;
            eventsRichTextBox.AppendText(tmpText);
            eventsRichTextBox.Select(textLength, tmpText.Length);
            eventsRichTextBox.SelectionFont = new Font(eventsRichTextBox.Font, FontStyle.Bold);

            model.age(); // meghívjuk a Modelben a játék előrehaladásához tartozó függvényt

            // változtatjuk a tulajdonsághoz tartozó ikont, ha szükséges
            if (model.You.Health >= 50)
                healthLabel.Image = Resources.healthy;
            else
                healthLabel.Image = Resources.unhealthy;
            if (model.You.Intelligence >= 50)
                intelligenceLabel.Image = Resources.smart;
            else
                intelligenceLabel.Image = Resources.dumb;
            if (model.You.Appearance >= 50)
                appearanceLabel.Image = Resources.beautiful;
            else
                appearanceLabel.Image = Resources.ugly;
            if (model.You.Happiness >= 50)
                happinessLabel.Image = Resources.happy;
            else
                happinessLabel.Image = Resources.sad;

            // korunktól függően bekapcsoljuk a megfelelő gombokat
            visitDoctorButton.Enabled = true;
            if (model.You.Age == 3)
                acquaintancePanelButton.Enabled = true;
            if (model.You.Age == 12)
                leisurePanelButton.Enabled = true;
            if (model.You.Age >= 12)
            {
                workOutButton.Enabled = true;
                readButton.Enabled = true;
            }
            if (model.You.Age == 14)
                lovePanelButton.Enabled = true;
            if (model.You.Age == 18)
            {
                jobPanelButton.Enabled = true;
                jobLabel.Text = model.You.Job.JobLevels.Keys.ElementAt(model.You.CurrentJobLevel);
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

            // frissítjük a labeleket
            ageLabel.Text = model.You.Age.ToString() + " éves vagy";
            healthLabel.Text = "Egészség: " + model.You.Health.ToString();
            intelligenceLabel.Text = "Intelligencia: " + model.You.Intelligence.ToString();
            appearanceLabel.Text = "Kinézet: " + model.You.Appearance.ToString();
            happinessLabel.Text = "Boldogság: " + model.You.Happiness.ToString();
            moneyLabel.Text = "Jelenleg " + model.You.Money.ToString() + " forintod van";

            // frissítjük a kapcsolatpontokat
            acquaintanceListBox.Items.Clear();
            foreach (Person p in model.People)
            {
                if (p != model.You)
                    acquaintanceListBox.Items.Add(p.FirstName + " " + p.LastName + " - " + p.Relationship.ToString());
            }
        }

        /// <summary>
        /// Munka panelhez tartozó gomb eseménykezelője.
        /// </summary>
        private void jobPanelButton_Click(object sender, EventArgs e)
        {
            jobPanel.BringToFront(); // előtérbe hozzuk a jobPanelt

            // ki- és bekapcsoljuk a szükséges gombokat
            jobPanelButton.Enabled = false;
            ageButton.Enabled = false;
            mainPanelButton.Enabled = true;
            homePanelButton.Enabled = true;
            leisurePanelButton.Enabled = true;
            universityPanelButton.Enabled = true;
            lovePanelButton.Enabled = true;
            acquaintancePanelButton.Enabled = true;
        }

        /// <summary>
        /// Fő panelhez tartozó gomb eseménykezelője.
        /// </summary>
        private void mainPanelButton_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront(); // előtérbe hozzuk a mainPanelt

            // ki- és bekapcsoljuk a szükséges gombokat (némelyiket kortól függően)
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

        /// <summary>
        /// Munkára jelentkezés gomb eseménykezelője.
        /// </summary>
        private void tryJobButton_Click(object sender, EventArgs e)
        {
            Job job = model.Jobs[jobComboBox.SelectedIndex]; // beolvassuk a Modelből a kiválasztott munkát

            if ((!model.You.Degrees.Contains(job.DegreeNeeded)) && !(job.DegreeNeeded is null)) // ha nincs meg a szükséges diploma a munkához, akkor ezt írjuk ki
            {
                MessageBox.Show("Nincs meg a szükséges képzésed ehhez a munkához!");
                return;
            }

            // frissítjük a Modelben a munkánkat, és a munkajelentkezéssel kapcsolatos Controlokat kikapcsoljuk, a felmondás gombot pedig bekapcsoljuk
            model.jobRefresh(job);
            jobImageLabel.Image = job.Image;
            jobComboBox.Visible = false;
            tryJobButton.Visible = false;
            quitJobButton.Visible = true;
        }

        /// <summary>
        /// Lakás panelhez tartozó gomb eseménykezelője.
        /// </summary>
        private void homePanelButton_Click(object sender, EventArgs e)
        {
            homePanel.BringToFront(); // előtérbe hozzuk a homePanelt

            // ki- és bekapcsoljuk a szükséges gombokat
            homePanelButton.Enabled = false;
            ageButton.Enabled = false;
            mainPanelButton.Enabled = true;
            jobPanelButton.Enabled = true;
            leisurePanelButton.Enabled = true;
            universityPanelButton.Enabled = true;
            lovePanelButton.Enabled = true;
            acquaintancePanelButton.Enabled = true;
        }

        /// <summary>
        /// Lakásvásárlás gomb eseménykezelője.
        /// </summary>
        private void buyHomeButton_Click(object sender, EventArgs e)
        {
            Home home = model.Homes[homeComboBox.SelectedIndex]; // beolvassuk a Modelből a kiválasztott lakást

            if (model.You.Money < home.Price) // ha nincs elég pénzünk a lakásra, akkor ezt jelezzük
            {
                MessageBox.Show("Nincs elég pénzed erre a lakásra. Gyűjts még rá " + (home.Price - model.You.Money).ToString() + " forintot!");
                return;
            }

            DialogResult dr = MessageBox.Show("Biztos vagy benne, hogy meg akarod venni ezt a lakást? " + home.Price.ToString() + " forintodba fog kerülni.",
                                      "Figyelmeztetés!",
                                      MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                // frissítjük a Modelben a lakást, a lakás képét és a lakásvétellel kapcsolatos funkciókat kikapcsoljuk
                model.homeRefresh(home);
                homeImageLabel.Image = home.Image;
                homeComboBox.Visible = false;
                buyHomeButton.Visible = false;
                sellHomeButton.Visible = true;
            }
        }

        /// <summary>
        /// Lakáseladás gomb eseménykezelője.
        /// </summary>
        private void sellHomeButton_Click(object sender, EventArgs e)
        {
            int sellPrice;

            if (model.You.Home == model.Homes[0])
                sellPrice = 0;

            else
                sellPrice = (int)(model.You.Home.Price * 0.75);

            DialogResult dr = MessageBox.Show("Biztos vagy benne, hogy el akarod adni a lakásodat? " + sellPrice.ToString() + " forintért tudod eladni.",
                                      "Figyelmeztetés!",
                                      MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                model.sellHome();
                sellHomeButton.Visible = false;
                homeComboBox.Visible = true;
                buyHomeButton.Visible = true;
                homeImageLabel.Image = model.You.Home.Image;
            }
        }

        /// <summary>
        /// Szabadidő panelhez tartozó gomb eseménykezelője.
        /// </summary>
        private void leisurePanelButton_Click(object sender, EventArgs e)
        {
            leisurePanel.BringToFront(); // előtérbe hozzuk a leisurePanelt

            // ki- és bekapcsoljuk a szükséges gombokat (némelyiket kortól függően)
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

        /// <summary>
        /// Edzés gomb eseménykezelője.
        /// </summary>
        private void workOutButton_Click(object sender, EventArgs e)
        {
            model.workOut();
        }

        /// <summary>
        /// Olvasás gomb eseménykezelője.
        /// </summary>
        private void readButton_Click(object sender, EventArgs e)
        {
            model.read();
        }

        /// <summary>
        /// Egyetem panelhez tartozó gomb eseménykezelője.
        /// </summary>
        private void universityPanelButton_Click(object sender, EventArgs e)
        {
            universityPanel.BringToFront(); // előtérbe hozzuk a universityPanelt

            // ki- és bekapcsoljuk a szükséges gombokat
            ageButton.Enabled = false;
            universityPanelButton.Enabled = false;
            homePanelButton.Enabled = true;
            mainPanelButton.Enabled = true;
            jobPanelButton.Enabled = true;
            leisurePanelButton.Enabled = true;
            lovePanelButton.Enabled = true;
            acquaintancePanelButton.Enabled = true;
        }

        /// <summary>
        /// Egyetemre jelentkezés gomb eseménykezelője.
        /// </summary>
        private void applyToUniButton_Click(object sender, EventArgs e)
        {
            University uni = model.Universities[universityComboBox.SelectedIndex]; // beolvassuk a Modelből a kiválasztott egyetemet

            // frissítjük a Modelben az egyetemet, és az egyetemre jelentkezéssel kapcsolatos funkciókat kikapcsoljuk
            model.uniRefresh(uni);
            universityComboBox.Visible = false;
            applyToUniButton.Visible = false;
        }

        /// <summary>
        /// Szerelem panelhez tartozó gomb eseménykezelője.
        /// </summary>
        private void lovePanelButton_Click(object sender, EventArgs e)
        {
            lovePanel.BringToFront(); // előtérbe hozzuk a universityPanelt

            // ki- és bekapcsoljuk a szükséges gombokat (némelyiket kortól függően)
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

        /// <summary>
        /// Új potenciális partnert generáló gomb eseménykezelője.
        /// </summary>
        private void newLoveButton_Click(object sender, EventArgs e)
        {
            // bekapcsoljuk a kapcsolat megpróbálásához tartozó gombot, és az adatait tartalmazó labelt láthatóra állítjuk
            tryRelationshipButton.Visible = true;
            tryRelationshipButton.Enabled = true;
            newLoveLabel.Visible = true;

            Tuple<Person, int> newLove = model.newLove(); // létrehozzuk a Modelben az új partnerünket

            // frissítjük a label-jét
            newLoveLabel.Text = "Név: " + newLove.Item1.FirstName + " " + newLove.Item1.LastName + Environment.NewLine
                + "Kor: " + newLove.Item1.Age + Environment.NewLine
                + "Kinézet: " + newLove.Item1.Appearance.ToString() + Environment.NewLine
                + "Intelligencia: " + newLove.Item1.Intelligence + Environment.NewLine
                + "Esélyed: " + newLove.Item2.ToString();
        }

        /// <summary>
        /// Kapcsolat megpróbálás gomb eseménykezelője.
        /// </summary>
        private void tryRelationshipButton_Click(object sender, EventArgs e)
        {
            model.tryRelationship();
        }

        /// <summary>
        /// Kapcsolat megpróbálás gomb eseménykezelője.
        /// </summary>
        private void breakUpButton_Click(object sender, EventArgs e)
        {
            // megkérdezzük a játékost, hogy biztos akar-e szakítani
            DialogResult dr = MessageBox.Show("Biztos vagy benne, hogy szakítani akarsz a pároddal?",
                                      "Figyelmeztetés!",
                                      MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes) // ha igen, akkor meghívjuk a Modelben ennek a függvényét
                model.breakUp(false);
        }

        /// <summary>
        /// Gyermekkel próbálkozás gomb eseménykezelője.
        /// </summary>
        private void tryForChildButton_Click(object sender, EventArgs e)
        {
            model.tryForChild();
        }

        /// <summary>
        /// Felmondás gomb eseménykezelője.
        /// </summary>
        private void quitJobButton_Click(object sender, EventArgs e)
        {
            // megkérdezzük a játékost, hogy biztos fel akar-e mondani
            DialogResult dr = MessageBox.Show("Biztos vagy benne, hogy fel akarsz mondani a munkahelyeden?",
                                      "Figyelmeztetés!",
                                      MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes) // ha igen, akkor meghívjuk a Modelben ennek a függvényét
            {
                model.quitJob();
                jobImageLabel.Image = model.You.Job.Image;
            }
        }

        /// <summary>
        /// Vakáció gomb eseménykezelője.
        /// </summary>
        private void vacationButton_Click(object sender, EventArgs e)
        {
            model.vacation();
        }

        /// <summary>
        /// Ismerős panelhez tartozó gomb eseménykezelője.
        /// </summary>
        private void acquaintancePanelButton_Click(object sender, EventArgs e)
        {
            acquaintancePanel.BringToFront(); // előtérbe hozzuk az acquaintancePanelt

            // ki- és bekapcsoljuk a szükséges gombokat (némelyiket kortól függően)
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

        /// <summary>
        /// Közös program gomb eseménykezelője.
        /// </summary>
        private void programWithAcquaintanceButton_Click(object sender, EventArgs e)
        {
            if (acquaintanceListBox.Text == "") // ha nincs kiválasztva ismerős, ezt jelezzük
            {
                MessageBox.Show("Válassz ki valakit az ismerőseid közül!");
                return;
            }
            model.programWithAcquaintance(acquaintanceListBox.SelectedIndex + 1);
        }

        /// <summary>
        /// Lottó gomb eseménykezelője.
        /// </summary>
        private void lotteryButton_Click(object sender, EventArgs e)
        {
            model.lottery();
        }

        /// <summary>
        /// Barátkozás gomb eseménykezelője.
        /// </summary>
        private void makeFriendButton_Click(object sender, EventArgs e)
        {
            model.makeFriend();
        }

        /// <summary>
        /// Orvos gomb eseménykezelője.
        /// </summary>
        private void visitDoctorButton_Click(object sender, EventArgs e)
        {
            model.visitDoctor();
        }

        /// <summary>
        /// Mentés gomb eseménykezelője.
        /// </summary>
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) // ha kiválasztottuk, hogy hova szeretnénk menteni és megerősítettük
            {
                try // megpróbáljuk végrehajtani a mentést
                {
                    model.saveGame(saveFileDialog.FileName);
                }
                catch (DataException) // ha nem sikerül, akkor kivételt dobunk
                {
                    MessageBox.Show("Hiba történt a mentés során.", "Életszimulátor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Betöltés gomb eseménykezelője.
        /// </summary>
        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) // ha kiválasztottuk, hogy honnan szeretnénk betölteni és megerősítettük
            {
                try // megpróbáljuk végrehajtani a betöltést
                {
                    model.loadGame(openFileDialog.FileName);
                }
                catch (DataException) // ha nem sikerül, akkor kivételt dobunk
                {
                    MessageBox.Show("Hiba történt a betöltés során.", "Életszimulátor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshControls(); // frissítjük a Controlokat az új adatokkal
        }

        /// <summary>
        /// Achievement menü gomb eseménykezelője.
        /// </summary>
        private void achievementMenuItem_Click(object sender, EventArgs e)
        {
            AchievementsWindow ach = new AchievementsWindow(model);
            ach.Show();
        }

        /// <summary>
        /// RichTextBox szövegének változásához tartozó eseménykezelő.
        /// </summary>
        private void eventsRichTextBox_TextChanged(object sender, EventArgs e)
        {
            // mindig az aljára lapozunk automatikusan
            eventsRichTextBox.SelectionStart = eventsRichTextBox.Text.Length;
            eventsRichTextBox.ScrollToCaret();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Controlok (gombok, labelek stb.) frissítésére szolgáló függvény.
        /// </summary>
        private void refreshControls()
        {
            ageButton.Enabled = true;
            // kortól függően gombok be- és kikapcsolása
            if (model.You.Age < 3)
                acquaintancePanelButton.Enabled = false;
            else
                acquaintancePanelButton.Enabled = true;
            if (model.You.Age < 12)
            {
                leisurePanelButton.Enabled = false;
                workOutButton.Enabled = false;
                readButton.Enabled = false;
            }
            else
            {
                leisurePanelButton.Enabled = true;
                workOutButton.Enabled = true;
                readButton.Enabled = true;
            }
            if (model.You.Age < 14)
                lovePanelButton.Enabled = false;
            else
                lovePanelButton.Enabled = true;
            if (model.You.Age < 18)
            {
                jobPanelButton.Enabled = false;
                homePanelButton.Enabled = false;
                universityPanelButton.Enabled = false;
                acquaintancePanelButton.Enabled = false;
                lotteryButton.Enabled = false;
                tryForChildButton.Enabled = false;
                vacationButton.Enabled = false;
            }
            else
            {
                jobPanelButton.Enabled = true;
                homePanelButton.Enabled = true;
                homeLabel.Text = model.You.Home.Type;
                universityPanelButton.Enabled = true;
                universityLabel.Text = model.You.University.Type;
                acquaintancePanelButton.Enabled = true;
                lotteryButton.Enabled = true;
                tryForChildButton.Enabled = true;
                vacationButton.Enabled = true;
            }
            if (model.You.Job != model.DefaultJob)
            {
                quitJobButton.Visible = true;
                jobComboBox.Visible = false;
                tryJobButton.Visible = false;
            }
            else
            {
                quitJobButton.Visible = false;
                jobComboBox.Visible = true;
                tryJobButton.Visible = true;
            }
            if (model.You.Home != model.DefaultHome)
            {
                homeComboBox.Visible = false;
                buyHomeButton.Visible = false;
            }
            else
            {
                homeComboBox.Visible = true;
                buyHomeButton.Visible = true;
            }
            if (model.You.University != model.DefaultUniversity)
            {
                applyToUniButton.Visible = false;
                universityComboBox.Visible = false;
            }
            else
            {
                applyToUniButton.Visible = true;
                universityComboBox.Visible = true;
            }
            homeLabel.Text = model.You.Home.Type;
            universityLabel.Text = model.You.University.Type;
            if (model.You.Job.JobLevels.ElementAt(0).Key == "Nyugdíjas")
            {
                quitJobButton.Visible = false;
            }

            // képek betöltése
            if (model.You.Health >= 50)
                healthLabel.Image = Resources.healthy;
            else
                healthLabel.Image = Resources.unhealthy;
            if (model.You.Intelligence >= 50)
                intelligenceLabel.Image = Resources.smart;
            else
                intelligenceLabel.Image = Resources.dumb;
            if (model.You.Appearance >= 50)
                appearanceLabel.Image = Resources.beautiful;
            else
                appearanceLabel.Image = Resources.ugly;
            if (model.You.Happiness >= 50)
                happinessLabel.Image = Resources.happy;
            else
                happinessLabel.Image = Resources.sad;
            if (model.You.Gender == Gender.Male)
            {
                genderLabel.Image = Resources.male;
                genderLabel.Size = new Size(55, 18);
            }
            else
            {
                genderLabel.Image = Resources.female;
                genderLabel.Size = new Size(45, 15);
            }

            // labelek frissítése
            nameLabel.Text = "Neved: " + model.You.FirstName + " " + model.You.LastName;
            if (model.You.Gender == 0)
                genderLabel.Text = "Nő";
            else
                genderLabel.Text = "Férfi";
            ageLabel.Text = model.You.Age.ToString() + " éves vagy";
            moneyLabel.Text = "Jelenleg " + model.You.Money.ToString() + " forintod van";
            healthLabel.Text = "Egészség: " + model.You.Health.ToString();
            intelligenceLabel.Text = "Intelligencia: " + model.You.Intelligence.ToString();
            appearanceLabel.Text = "Kinézet: " + model.You.Appearance.ToString();
            happinessLabel.Text = "Boldogság: " + model.You.Happiness.ToString();
            jobLabel.Text = model.You.Job.JobLevels.Keys.ElementAt(model.You.CurrentJobLevel);
            homeLabel.Text = model.You.Home.Type;
            universityLabel.Text = model.You.University.Type;
            homeImageLabel.Image = model.You.Home.Image;
            jobImageLabel.Image = model.You.Job.Image;

            // partnertől függően a hozzá tartozó labelek és gombok frissítése, be- és kikapcsolása
            if (model.You.Partner is null)
            {
                currentLoveLabel.Text = "Jelenleg egyedülálló vagy";
                newLoveButton.Visible = true;
                tryRelationshipButton.Visible = false;
                breakUpButton.Visible = false;
                tryForChildButton.Visible = false;
            }
            else
            {
                currentLoveLabel.Text = "Párod: " + Environment.NewLine + "Név: " + model.You.Partner.FirstName + " " + model.You.Partner.LastName;
                newLoveButton.Visible = false;
                tryRelationshipButton.Visible = false;
                breakUpButton.Visible = true;
                tryForChildButton.Visible = true;
            }

            // ismerősök újrainicializálása
            acquaintanceListBox.Items.Clear();
            foreach (Person p in model.People)
            {
                if (p != model.You)
                    acquaintanceListBox.Items.Add(p.FirstName + " " + p.LastName + " - " + p.Relationship.ToString());
            }

            // RichTextBox újrainicializálása
            eventsRichTextBox.Clear();
            tmpText = model.You.Age + " éves" + Environment.NewLine + Environment.NewLine;
            textLength = eventsRichTextBox.Text.Length;
            eventsRichTextBox.AppendText(tmpText);
            eventsRichTextBox.Select(textLength, tmpText.Length);
            eventsRichTextBox.SelectionFont = new Font(eventsRichTextBox.Font, FontStyle.Bold);
        }

        #endregion

        
    }
}
