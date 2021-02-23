using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LifeSim.Model
{
    public enum Gender { Female, Male }
    public class LifeSimModel
    {
        #region Fields

        private Random rnd;
        private List<string> familyNames = new List<string> { "Molnár", "Varga", "Poór", "Kovács", "Kiss", "Pósa", "Tóth", "Madaras", "Balogh", "Papp", "Major", "Jászai", "Fodor", "Takács", "Elek", "Horváth", "Nagy", "Fábián", "Kis", "Fehér", "Katona", "Pintér", "Kecskés", "Lakatos", "Szalai", "Gál", "Szűcs", "Bencsik", "Szücsi", "Bartók", "Király", "Lengyel", "Barta", "Fazekas", "Sándor", "Simon", "Soós", "Fekete", "Deák", "Székely", "Faragó", "Kelemen", "Szilágyi", "Pataki", "Csaba", "Cserepes", "Csiszár", "Sárközi", "Dóra", "Berkes", "Jakab", "Péter", "Rézműves", "Rácz", "Berki", "Kocsis", "Fülöp", "Ágoston", "Németh", "Dévényi", "Bátorfi", "Balázs", "Benedek", "Pásztor", "Károlyi", "Bogdán", "Fenyő", "Váradi", "Ribár", "Juhász", "Fésűs", "Somodi", "Kolompár", "Szekeres", "Széles", "Orosz", "Ferenc", "Kónya", "Szalay", "Puskás", "Győri", "Szigetvári", "Herczeg", "Veres", "Győző", "Orsós", "Bodnár", "Vörös", "Darai", "Vígh", "Radics", "Mészáros", "Babos", "Geszti", "Erős", "Hegedüs", "Képes", "Szeles", "Sebestyén", "Borbély", "Kövesdy", "Sátori", "Mihály", "Csiki", "Végh", "Somogyi", "Budai" };
        private List<string> maleNames = new List<string> { "Péter", "János", "László", "Jakab", "József", "Gábor", "Sándor", "Bálint", "Richárd", "Bence", "Balázs", "Jácint", "Erik", "Zoltán", "Zsolt", "Kristóf", "Viktor", "Róbert", "Szilárd", "Szabolcs", "Martin", "Marcell", "Kázmér", "Benedek", "Máté", "Botond", "András", "Roland", "Ferenc", "István", "Krisztián", "Győző", "Farkas", "Ákos", "Béla", "Mihály", "Károly", "Gergely", "Ágoston", "Boldizsár", "Gergő", "Mózes", "Márió", "Ádám", "Dénes", "Ábel", "Tamás", "Szilveszter", "György", "Elek", "Áron", "Pál", "Márton", "Álmos", "Kornél", "Lőrinc", "Dániel", "Oszkár", "Márk", "Koppány", "Ernő", "Lázár", "Mátyás", "Aladár", "Lajos", "Attila", "Benjámin", "Csaba", "Csanád", "Olivér", "Gyula", "Henrik", "Sámuel", "Tivadar", "Antal", "Vilmos", "Hugó", "Arnold", "Tibor", "Levente", "Géza", "Dezső", "Albert", "Csongor", "Iván", "Ottó", "Endre", "Dávid", "Zalán", "Nándor", "Imre", "Domonkos", "Zsombor", "Norbert", "Patrik", "Kevin", "Vince", "Kelemen", "Xavér", "Zebulon" };
        private List<string> femaleNames = new List<string> { "Petra", "Katalin", "Jázmin", "Melinda", "Vanda", "Zsófia", "Eszter", "Kamilla", "Sára", "Cecília", "Viktória", "Emese", "Erika", "Alexandra", "Barbara", "Zsuzsanna", "Linda", "Mária", "Emma", "Alíz", "Ibolya", "Erzsébet", "Tamara", "Virág", "Alma", "Réka", "Andrea", "Dóra", "Vivien", "Bernadett", "Karina", "Krisztina", "Lívia", "Anett", "Bella", "Edit", "Karolina", "Fruzsina", "Edina", "Beáta", "Boglárka", "Anna", "Éva", "Daniella", "Anita", "Veronika", "Csenge", "Adrienn", "Diána", "Júlia", "Katica", "Fanni", "Lilla", "Mónika", "Nóra", "Napsugár", "Márta", "Flóra", "Hanna", "Hajnalka", "Kincső", "Amanda", "Beatrix", "Dalma", "Dorina", "Johanna", "Laura", "Míra", "Nikoletta", "Orsolya", "Roxána", "Zsanett", "Viola", "Zita", "Tekla", "Olívia", "Mirtill", "Ilona", "Anikó", "Gabriella", "Tünde", "Szilvia", "Evelin", "Bianka", "Klaudia", "Kitti", "Léna", "Szonja", "Borbála", "Tímea", "Enikő", "Ramóna", "Dorottya", "Leila", "Hanga", "Adél", "Bettina", "Hortenzia", "Izabella" };
        private String yourName;
        private bool maleOrFemale;
        private bool smartUni;
        private int yearsInUni;
        private bool inUni;
        private bool isWorking;
        private bool childOnWay;
        private Person otherParent;
        private int universityCosts;
        private int timeToPayBack;

        #endregion

        #region Properties

        public Player You { get; set; }

        public List<Person> People { get; set; }

        public Tuple<Person,int> PotentialPartner { get; set; }

        public List<Person> Parents { get; private set; }

        public List<Job> Jobs { get; private set; }

        public List<University> Universities { get; private set; }

        public List<University> Degrees { get; private set; }

        public List<Home> Homes { get; private set; }

        public Job DefaultJob { get; private set; }

        public University DefaultUniversity { get; private set; }

        public Home DefaultHome { get; private set; }

        public int PromotionMeter { get; private set; }

        #endregion

        #region Events

        public event EventHandler<LifeSimEventArgs> DeathEvent;

        public event EventHandler<EventArgs> JobChangedEvent;

        public event EventHandler<EventArgs> HomeChangedEvent;

        public event EventHandler<EventArgs> SmartUniChangedEvent;

        public event EventHandler<LifeSimEventArgs> DumbUniChangedEvent;

        public event EventHandler<EventArgs> SmartGraduateEvent;

        public event EventHandler<LifeSimEventArgs> DumbGraduateEvent;

        public event EventHandler<EventArgs> HealthRefreshEvent;

        public event EventHandler<EventArgs> IntelligenceRefreshEvent;

        public event EventHandler<EventArgs> RelationshipFailEvent;

        public event EventHandler<EventArgs> RelationshipSuccessEvent;

        public event EventHandler<LifeSimEventArgs> BreakUpEvent;

        public event EventHandler<EventArgs> ChildFailEvent;

        public event EventHandler<EventArgs> ChildSuccessEvent;

        public event EventHandler<EventArgs> ChildBornEvent;

        public event EventHandler<EventArgs> QuitJobEvent;

        public event EventHandler<EventArgs> PromotionEvent;

        public event EventHandler<EventArgs> RetirementEvent;

        #endregion

        #region Constructor

        public LifeSimModel()
        {
            rnd = new Random();
            Universities = new List<University>() { new University("Informatikus", 3, 325000), new University("Orvosi", 6, 1045000) };
            Jobs = new List<Job>() { new Job(new Dictionary<String, int> { {"Junior programozó", 3240000 }, {"Medior programozó", 6600000}, {"Senior programozó", 9600000} }, Universities[0], 2), new Job(new Dictionary<String, int> { { "Járőr", 2040000 }, { "Zászlós", 2811960 }, { "Rendőrtiszt", 4397520 } }, null, 2), new Job(new Dictionary<String, int> { { "Fogorvos", 3780000 } }, Universities[1], 0) };
            Homes = new List<Home>() { new Home("Albérlet", 165000, 1980000), new Home("30 négyzetméteres, egyszerű lakás", 12450000, 470000), new Home("50 négyzetméteres, szép lakás", 25500000, 580000) };
            yourName = "";
            familyNames = new List<string> { "Molnár", "Varga", "Poór", "Kovács", "Kiss", "Pósa", "Tóth", "Madaras", "Balogh", "Papp", "Major", "Jászai", "Fodor", "Takács", "Elek", "Horváth", "Nagy", "Fábián", "Kis", "Fehér", "Katona", "Pintér", "Kecskés", "Lakatos", "Szalai", "Gál", "Szűcs", "Bencsik", "Szücsi", "Bartók", "Király", "Lengyel", "Barta", "Fazekas", "Sándor", "Simon", "Soós", "Fekete", "Deák", "Székely", "Faragó", "Kelemen", "Szilágyi", "Pataki", "Csaba", "Cserepes", "Csiszár", "Sárközi", "Dóra", "Berkes", "Jakab", "Péter", "Rézműves", "Rácz", "Berki", "Kocsis", "Fülöp", "Ágoston", "Németh", "Dévényi", "Bátorfi", "Balázs", "Benedek", "Pásztor", "Károlyi", "Bogdán", "Fenyő", "Váradi", "Ribár", "Juhász", "Fésűs", "Somodi", "Kolompár", "Szekeres", "Széles", "Orosz", "Ferenc", "Kónya", "Szalay", "Puskás", "Győri", "Szigetvári", "Herczeg", "Veres", "Győző", "Orsós", "Bodnár", "Vörös", "Darai", "Vígh", "Radics", "Mészáros", "Babos", "Geszti", "Erős", "Hegedüs", "Képes", "Szeles", "Sebestyén", "Borbély", "Kövesdy", "Sátori", "Mihály", "Csiki", "Végh", "Somogyi", "Budai" };
            maleNames = new List<string> { "Péter", "János", "László", "Jakab", "József", "Gábor", "Sándor", "Bálint", "Richárd", "Bence", "Balázs", "Jácint", "Erik", "Zoltán", "Zsolt", "Kristóf", "Viktor", "Róbert", "Szilárd", "Szabolcs", "Martin", "Marcell", "Kázmér", "Benedek", "Máté", "Botond", "András", "Roland", "Ferenc", "István", "Krisztián", "Győző", "Farkas", "Ákos", "Béla", "Mihály", "Károly", "Gergely", "Ágoston", "Boldizsár", "Gergő", "Mózes", "Márió", "Ádám", "Dénes", "Ábel", "Tamás", "Szilveszter", "György", "Elek", "Áron", "Pál", "Márton", "Álmos", "Kornél", "Lőrinc", "Dániel", "Oszkár", "Márk", "Koppány", "Ernő", "Lázár", "Mátyás", "Aladár", "Lajos", "Attila", "Benjámin", "Csaba", "Csanád", "Olivér", "Gyula", "Henrik", "Sámuel", "Tivadar", "Antal", "Vilmos", "Hugó", "Arnold", "Tibor", "Levente", "Géza", "Dezső", "Albert", "Csongor", "Iván", "Ottó", "Endre", "Dávid", "Zalán", "Nándor", "Imre", "Domonkos", "Zsombor", "Norbert", "Patrik", "Kevin", "Vince", "Kelemen", "Xavér", "Zebulon" };
            femaleNames = new List<string> { "Petra", "Katalin", "Jázmin", "Melinda", "Vanda", "Zsófia", "Eszter", "Kamilla", "Sára", "Cecília", "Viktória", "Emese", "Erika", "Alexandra", "Barbara", "Zsuzsanna", "Linda", "Mária", "Emma", "Alíz", "Ibolya", "Erzsébet", "Tamara", "Virág", "Alma", "Réka", "Andrea", "Dóra", "Vivien", "Bernadett", "Karina", "Krisztina", "Lívia", "Anett", "Bella", "Edit", "Karolina", "Fruzsina", "Edina", "Beáta", "Boglárka", "Anna", "Éva", "Daniella", "Anita", "Veronika", "Csenge", "Adrienn", "Diána", "Júlia", "Katica", "Fanni", "Lilla", "Mónika", "Nóra", "Napsugár", "Márta", "Flóra", "Hanna", "Hajnalka", "Kincső", "Amanda", "Beatrix", "Dalma", "Dorina", "Johanna", "Laura", "Míra", "Nikoletta", "Orsolya", "Roxána", "Zsanett", "Viola", "Zita", "Tekla", "Olívia", "Mirtill", "Ilona", "Anikó", "Gabriella", "Tünde", "Szilvia", "Evelin", "Bianka", "Klaudia", "Kitti", "Léna", "Szonja", "Borbála", "Tímea", "Enikő", "Ramóna", "Dorottya", "Leila", "Hanga", "Adél", "Bettina", "Hortenzia", "Izabella" };
            DefaultJob = new Job(new Dictionary<String, int> { { "Munkanélküli", 0 } }, null, 0);
            DefaultHome = new Home("Szülői lakás", 0, 0);
            DefaultUniversity = new University("Jelenleg nem végzel egyetemi képzést", 0, 0);
    }

        public LifeSimModel(String yourName, bool maleOrFemale)
        {
            rnd = new Random();
            Universities = new List<University>() { new University("Informatikus", 3, 325000), new University("Orvosi", 6, 1045000) };
            Jobs = new List<Job>() { new Job(new Dictionary<String, int> { { "Junior programozó", 3240000 }, { "Medior programozó", 6600000 }, { "Senior programozó", 9600000 } }, Universities[0], 2), new Job(new Dictionary<String, int> { { "Járőr", 2040000 }, { "Zászlós", 2811960 }, { "Rendőrtiszt", 4397520 } }, null, 2), new Job(new Dictionary<String, int> { { "Fogorvos", 3780000 } }, Universities[1], 0) };
            Homes = new List<Home>() { new Home("Albérlet", 165000, 1980000), new Home("30 négyzetméteres, egyszerű lakás", 12450000, 470000), new Home("50 négyzetméteres, szép lakás", 25500000, 580000) };
            this.yourName = yourName;
            this.maleOrFemale = maleOrFemale;
            DefaultJob = new Job(new Dictionary<String, int> { { "Munkanélküli", 0 } }, null, 0);
            DefaultHome = new Home("Szülői lakás", 0, 0);
            DefaultUniversity = new University("Jelenleg nem végzel egyetemi képzést", 0, 0);
        }

        #endregion

        #region Public game methods

        public void newGame()
        {
            People = new List<Person>();
            PromotionMeter = 0;
            String familyName;
            String name;
            Gender gender;
            if (yourName == "")
            {
                familyName = familyNames[rnd.Next(familyNames.Count)];
                gender = (Gender)rnd.Next(2);
                if (gender == 0)
                    name = femaleNames[rnd.Next(femaleNames.Count)];
                else
                    name = maleNames[rnd.Next(maleNames.Count)];
            }
            else
            {
                familyName = yourName.Split(' ')[0];
                name = yourName.Split(' ')[1];
                if (maleOrFemale)
                    gender = Gender.Male;
                else
                    gender = Gender.Female;
            }
            Parents = new List<Person>() { new Person(familyName, maleNames[rnd.Next(maleNames.Count)], rnd.Next(18,50), Gender.Male, rnd.Next(30,101), rnd.Next(101), rnd.Next(101)),
                                            new Person(familyNames[rnd.Next(familyNames.Count)], femaleNames[rnd.Next(femaleNames.Count)], rnd.Next(18,50), Gender.Female, rnd.Next(30,101), rnd.Next(101), rnd.Next(101))};

            int appearance = calculateStartingStat(Parents[0].Appearance, Parents[1].Appearance);
            int intelligence = calculateStartingStat(Parents[0].Intelligence, Parents[1].Intelligence);

            if (appearance < 0)
                appearance = 0;
            if (intelligence < 0)
                intelligence = 0;

            if (appearance > 100)
                appearance = 100;
            if (intelligence > 100)
                intelligence = 100;

            You = new Player(familyName, name, 0, gender, 100, intelligence, appearance, DefaultJob, DefaultHome, DefaultUniversity);
            People.Add(You);
            People.Add(Parents[0]);
            People.Add(Parents[1]);
            Degrees = new List<University>();
            inUni = false;
            childOnWay = false;
            isWorking = false;
            universityCosts = 0;
            timeToPayBack = 0;
        }
        public void age()
        {
            foreach (Person p in People.ToList())
            {
                p.Age++;

                p.Intelligence += rnd.Next(-3, 4);
                if (p.Intelligence > 100)
                    p.Intelligence = 100;
                else if (p.Intelligence < 0)
                    p.Intelligence = 0;

                p.Appearance += rnd.Next(-3, 4);
                if (p.Appearance > 100)
                    p.Appearance = 100;
                else if (p.Appearance < 0)
                    p.Appearance = 0;

                if (p.Age < 18)
                    p.Health += rnd.Next(-3, 8);

                else if (p.Age >= 18 && p.Age < 36)
                    p.Health += rnd.Next(-5, 6);

                else if (p.Age >= 36 && p.Age < 55)
                    p.Health += rnd.Next(-6, 3);

                else
                    p.Health += rnd.Next(-8, 2);

                if (p.Health > 100)
                    p.Health = 100;

                if (p.Age == 110 || p.Health <= 0)
                {
                    p.Health = 0;
                    People.Remove(p);
                    OnDeathEvent(p);
                    if (p == You.Partner)
                    {
                        breakUp(true);
                    }
                }
            }

            Debug.WriteLine(You.Job.JobLevels.Values.ElementAt(You.CurrentJobLevel));
            Debug.WriteLine(You.Home.YearlyExpenses);
            Debug.WriteLine(universityCosts);
            You.Money += You.Job.JobLevels.Values.ElementAt(You.CurrentJobLevel) - You.Home.YearlyExpenses - universityCosts;
            if (timeToPayBack > 0)
                timeToPayBack--;
            if (timeToPayBack == 0)
            {
                universityCosts = 0;
            }

            if (inUni)
            {
                yearsInUni++;
                if (yearsInUni == You.University.YearsToFinish)
                {
                    if (!smartUni)
                    {
                        do
                        {
                            timeToPayBack = rnd.Next(4, 25);
                            universityCosts = You.University.CostPerSemester * 2 * yearsInUni / timeToPayBack;
                        } while (25000 * 12 > universityCosts || universityCosts > 60000 * 12);
                        OnDumbGraduateEvent(universityCosts, timeToPayBack);
                    }
                    else
                        OnSmartGraduateEvent();
                    inUni = false;
                    yearsInUni = 0;
                    Degrees.Add(You.University);
                    You.University = DefaultUniversity;
                }
            }

            if (isWorking && You.CurrentJobLevel != You.Job.MaxJobLevel)
            {
                PromotionMeter += rnd.Next(6, 13);
                if (PromotionMeter >= 100)
                {
                    You.CurrentJobLevel += 1;
                    PromotionMeter = 0;
                    OnPromotionEvent();
                }
            }

            if (childOnWay)
            {
                childOnWay = false;
                Gender gender = (Gender)rnd.Next(2);
                String name;

                if (gender == 0)
                    name = femaleNames[rnd.Next(femaleNames.Count)];
                else
                    name = maleNames[rnd.Next(maleNames.Count)];

                String firstName;

                if (You.Gender == Gender.Male)
                    firstName = You.FirstName;
                else
                    firstName = otherParent.FirstName;

                int appearance = calculateStartingStat(You.Appearance, otherParent.Appearance);
                int intelligence = calculateStartingStat(You.Intelligence, otherParent.Intelligence);

                if (appearance < 0)
                    appearance = 0;
                if (intelligence < 0)
                    intelligence = 0;

                if (appearance > 100)
                    appearance = 100;
                if (intelligence > 100)
                    intelligence = 100;

                You.Children.Add(new Person(firstName, name, 0, gender, 100, intelligence, appearance));
                People.Add(You.Children[You.Children.Count - 1]);
                OnChildBornEvent();
            }

            if(You.Age == 65 && isWorking)
            {
                isWorking = false;
                int pension = Convert.ToInt32(Math.Round(You.Job.JobLevels.Values.ElementAt(You.CurrentJobLevel)*0.67));
                You.Job = new Job(new Dictionary<String, int> { { "Nyugdíjas", pension } }, null, 0);
                You.CurrentJobLevel = 0;
                OnRetirementEvent();
            }
        }

        public void workOut()
        {
            int randomGain = rnd.Next(1, 6);
            if (You.Health + randomGain <= 100)
                You.Health += randomGain;
            else
            {
                You.Health = 100;
            }
            OnHealthRefreshEvent();
        }

        public void read()
        {
            int randomGain = rnd.Next(1, 6);
            if (You.Intelligence + randomGain <= 100)
                You.Intelligence += randomGain;
            else
            {
                You.Intelligence = 100;
            }
            OnIntelligenceRefreshEvent();
        }

        public void jobRefresh(Job job)
        {
            if (job != DefaultJob)
                isWorking = true;
            else
                isWorking = false;
            You.Job = job;
            OnJobChangedEvent();
        }

        public void homeRefresh(Home home)
        {
            You.Home = home;
            OnHomeChangedEvent();
        }

        public void uniRefresh(University uni)
        {
            if (uni != DefaultUniversity)
                inUni = true;
            else
                inUni = false;
            yearsInUni = 0;
            You.University = uni;
            if (You.Intelligence >= 70)
            {
                smartUni = true;
                OnSmartUniChangedEvent();
            }
            else
            {
                smartUni = false;
                OnDumbUniChangedEvent(uni.CostPerSemester);
            }
        }

        public Tuple<Person,int> newLove()
        {
            String randomName;
            Gender loveGender;
            if (You.Gender == Gender.Male)
            {
                randomName = femaleNames[rnd.Next(0, femaleNames.Count)];
                loveGender = Gender.Female;
            }
            else
            {
                randomName = maleNames[rnd.Next(0, maleNames.Count)];
                loveGender = Gender.Male;
            }
            int randomAge = rnd.Next(-2, 3);
            Person crush =  new Person(familyNames[rnd.Next(0, familyNames.Count)], randomName, You.Age + randomAge, loveGender, rnd.Next(1, 101), rnd.Next(0, 101), rnd.Next(0, 101));
            int chanceOfLove = chanceOfMutualLove(crush);
            PotentialPartner = new Tuple<Person, int>(crush, chanceOfLove);
            return PotentialPartner;
        }

        public void tryRelationship()
        {
            int randomNum = rnd.Next(0, 5);
            bool fail = false;
            switch (PotentialPartner.Item2)
            {
                case 0:
                    fail = true;
                    OnRelationshipFailEvent();
                    break;
                case 20:
                    if (randomNum > 0)
                    {
                        fail = true;
                        OnRelationshipFailEvent();
                    } 
                    break;
                case 40:
                    if (randomNum > 1)
                    {
                        fail = true;
                        OnRelationshipFailEvent();
                    }
                    break;
                case 60:
                    if (randomNum > 2)
                    {
                        fail = true;
                        OnRelationshipFailEvent();
                    }
                    break;
                case 80:
                    if (randomNum > 3)
                    {
                        fail = true;
                        OnRelationshipFailEvent();
                    }
                    break;
            }
            if (!fail)
            {
                You.Partner = PotentialPartner.Item1;
                People.Add(PotentialPartner.Item1);
                PotentialPartner = null;
                OnRelationshipSuccessEvent();
            }
        }

        public void breakUp(bool death)
        {
            You.Partner = null;
            OnBreakUpEvent(death);
        }

        public void quitJob()
        {
            You.Job = DefaultJob;
            isWorking = false;
            OnQuitJobEvent();
        }

        public void tryForChild()
        {
            int childSuccess = rnd.Next(0, 2);
            switch (childSuccess)
            {
                case 0:
                    OnChildFailEvent();
                    break;
                case 1:
                    childOnWay = true;
                    otherParent = You.Partner;
                    OnChildSuccessEvent();
                    break;
            }
        }

        public void takeControlOfChild()
        {
            People.Remove(You.Children[0]);
            You = You.Children[0].changeToPlayer(DefaultJob, DefaultHome, DefaultUniversity);
            People.Add(You);
            breakUp(true);
            jobRefresh(DefaultJob);
            homeRefresh(DefaultHome);
            uniRefresh(DefaultUniversity);
            PromotionMeter = 0;
            childOnWay = false;
        }
        #endregion

        #region Private methods

        private int chanceOfMutualLove(Person crush)
        {
            int appearanceDifference = You.Appearance - crush.Appearance;
            int intelligenceDifference = You.Intelligence - crush.Intelligence;
            if (appearanceDifference < -40 || intelligenceDifference < -40)
                return 0;
            else if (appearanceDifference < -30 || intelligenceDifference < -30)
                return 20;
            else if (appearanceDifference < -20 || intelligenceDifference < -20)
                return 40;
            else if (appearanceDifference < 0 || intelligenceDifference < 0)
                return 60;
            else if (appearanceDifference < 10 || intelligenceDifference < 10)
                return 80;
            else
                return 100;
        }

        private int calculateStartingStat(int stat1, int stat2)
        {
            return (stat1 + stat2) / 2 + rnd.Next(-10, 11);
        }

        #endregion

        #region Private event methods

        private void OnDeathEvent(Person p)
        {
            DeathEvent?.Invoke(this, new LifeSimEventArgs(p));
        }

        private void OnJobChangedEvent()
        {
            JobChangedEvent?.Invoke(this, new EventArgs());
        }

        private void OnHomeChangedEvent()
        {
            HomeChangedEvent?.Invoke(this, new EventArgs());
        }

        private void OnSmartUniChangedEvent()
        {
            SmartUniChangedEvent?.Invoke(this, new EventArgs());
        }

        private void OnDumbUniChangedEvent(int CostOfUni)
        {
            DumbUniChangedEvent?.Invoke(this, new LifeSimEventArgs(CostOfUni));
        }

        private void OnSmartGraduateEvent()
        {
            SmartGraduateEvent?.Invoke(this, new EventArgs());
        }

        private void OnDumbGraduateEvent(int CostPerYear, int YearsToPayBack)
        {
            DumbGraduateEvent?.Invoke(this, new LifeSimEventArgs(CostPerYear, YearsToPayBack));
        }

        private void OnHealthRefreshEvent()
        {
            HealthRefreshEvent?.Invoke(this, new EventArgs());
        }

        private void OnIntelligenceRefreshEvent()
        {
            IntelligenceRefreshEvent?.Invoke(this, new EventArgs());
        }

        private void OnRelationshipFailEvent()
        {
            RelationshipFailEvent?.Invoke(this, new EventArgs());
        }

        private void OnRelationshipSuccessEvent()
        {
            RelationshipSuccessEvent?.Invoke(this, new EventArgs());
        }

        private void OnBreakUpEvent(bool death)
        {
            BreakUpEvent?.Invoke(this, new LifeSimEventArgs(death));
        }

        private void OnChildFailEvent()
        {
            ChildFailEvent?.Invoke(this, new EventArgs());
        }

        private void OnChildSuccessEvent()
        {
            ChildSuccessEvent?.Invoke(this, new EventArgs());
        }

        private void OnChildBornEvent()
        {
            ChildBornEvent?.Invoke(this, new EventArgs());
        }

        private void OnQuitJobEvent()
        {
            QuitJobEvent?.Invoke(this, new EventArgs());
        }

        private void OnPromotionEvent()
        {
            PromotionEvent?.Invoke(this, new EventArgs());
        }

        private void OnRetirementEvent()
        {
            RetirementEvent?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}
