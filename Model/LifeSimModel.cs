using System;
using System.Collections.Generic;
using System.IO;

namespace LifeSim.Model
{
    public enum Gender { Male, Female }
    public class LifeSimModel
    {
        #region Fields

        private Random rnd;
        private List<string> familyNames = new List<string> { "Molnár", "Varga", "Poór", "Kovács", "Kiss", "Pósa", "Tóth", "Madaras", "Balogh", "Papp", "Major", "Jászai", "Fodor", "Takács", "Elek", "Horváth", "Nagy", "Fábián", "Kis", "Fehér", "Katona", "Pintér", "Kecskés", "Lakatos", "Szalai", "Gál", "Szűcs", "Bencsik", "Szücsi", "Bartók", "Király", "Lengyel", "Barta", "Fazekas", "Sándor", "Simon", "Soós", "Fekete", "Deák", "Székely", "Faragó", "Kelemen", "Szilágyi", "Pataki", "Csaba", "Cserepes", "Csiszár", "Sárközi", "Dóra", "Berkes", "Jakab", "Péter", "Rézműves", "Rácz", "Berki", "Kocsis", "Fülöp", "Ágoston", "Németh", "Dévényi", "Bátorfi", "Balázs", "Benedek", "Pásztor", "Károlyi", "Bogdán", "Fenyő", "Váradi", "Ribár", "Juhász", "Fésűs", "Somodi", "Kolompár", "Szekeres", "Széles", "Orosz", "Ferenc", "Kónya", "Szalay", "Puskás", "Győri", "Szigetvári", "Herczeg", "Veres", "Győző", "Orsós", "Bodnár", "Vörös", "Darai", "Vígh", "Radics", "Mészáros", "Babos", "Geszti", "Erős", "Hegedüs", "Képes", "Szeles", "Sebestyén", "Borbély", "Kövesdy", "Sátori", "Mihály", "Csiki", "Végh", "Somogyi", "Budai" };
        private List<string> maleNames = new List<string> { "Péter", "János", "László", "Jakab", "József", "Gábor", "Sándor", "Bálint", "Richárd", "Bence", "Balázs", "Jácint", "Erik", "Zoltán", "Zsolt", "Kristóf", "Viktor", "Róbert", "Szilárd", "Szabolcs", "Martin", "Marcell", "Kázmér", "Benedek", "Máté", "Botond", "András", "Roland", "Ferenc", "István", "Krisztián", "Győző", "Farkas", "Ákos", "Béla", "Mihály", "Károly", "Gergely", "Ágoston", "Boldizsár", "Gergő", "Mózes", "Márió", "Ádám", "Dénes", "Ábel", "Tamás", "Szilveszter", "György", "Elek", "Áron", "Pál", "Márton", "Álmos", "Kornél", "Lőrinc", "Dániel", "Oszkár", "Márk", "Koppány", "Ernő", "Lázár", "Mátyás", "Aladár", "Lajos", "Attila", "Benjámin", "Csaba", "Csanád", "Olivér", "Gyula", "Henrik", "Sámuel", "Tivadar", "Antal", "Vilmos", "Hugó", "Arnold", "Tibor", "Levente", "Géza", "Dezső", "Albert", "Csongor", "Iván", "Ottó", "Endre", "Dávid", "Zalán", "Nándor", "Imre", "Domonkos", "Zsombor", "Norbert", "Patrik", "Kevin", "Vince", "Kelemen", "Xavér", "Zebulon" };
        private List<string> femaleNames = new List<string> { "Petra", "Katalin", "Jázmin", "Melinda", "Vanda", "Zsófia", "Eszter", "Kamilla", "Sára", "Cecília", "Viktória", "Emese", "Erika", "Alexandra", "Barbara", "Zsuzsanna", "Linda", "Mária", "Emma", "Alíz", "Ibolya", "Erzsébet", "Tamara", "Virág", "Alma", "Réka", "Andrea", "Dóra", "Vivien", "Bernadett", "Karina", "Krisztina", "Lívia", "Anett", "Bella", "Edit", "Karolina", "Fruzsina", "Edina", "Beáta", "Boglárka", "Anna", "Éva", "Daniella", "Anita", "Veronika", "Csenge", "Adrienn", "Diána", "Júlia", "Katica", "Fanni", "Lilla", "Mónika", "Nóra", "Napsugár", "Márta", "Flóra", "Hanna", "Hajnalka", "Kincső", "Amanda", "Beatrix", "Dalma", "Dorina", "Johanna", "Laura", "Míra", "Nikoletta", "Orsolya", "Roxána", "Zsanett", "Viola", "Zita", "Tekla", "Olívia", "Mirtill", "Ilona", "Anikó", "Gabriella", "Tünde", "Szilvia", "Evelin", "Bianka", "Klaudia", "Kitti", "Léna", "Szonja", "Borbála", "Tímea", "Enikő", "Ramóna", "Dorottya", "Leila", "Hanga", "Adél", "Bettina", "Hortenzia", "Izabella" };
        private String yourName;
        private bool maleOrFemale;
        private int yearsInUni;
        private bool inUni;
        private bool childOnWay;

        #endregion

        #region Properties

        public Person You { get; set; }

        public Tuple<Person,int> PotentialPartner { get; set; }

        public Person Partner { get; set; }

        public List<Person> Parents { get; private set; }

        public List<Job> Jobs { get; private set; }

        public List<University> Universities { get; private set; }

        public List<University> Degrees { get; private set; }

        public List<Home> Homes { get; private set; }

        public Job Job { get; set; }

        public University University { get; set; }

        public Home Home { get; set; }

        public List<Person> Children { get; private set; }

        #endregion

        #region Events

        public event EventHandler<LifeSimEventArgs> DeathEvent;

        public event EventHandler<EventArgs> JobChangedEvent;

        public event EventHandler<EventArgs> HomeChangedEvent;

        public event EventHandler<EventArgs> UniChangedEvent;

        public event EventHandler<EventArgs> GraduateEvent;

        public event EventHandler<EventArgs> HealthRefreshEvent;

        public event EventHandler<EventArgs> IntelligenceRefreshEvent;

        public event EventHandler<EventArgs> RelationshipFailEvent;

        public event EventHandler<EventArgs> RelationshipSuccessEvent;

        public event EventHandler<EventArgs> BreakUpEvent;

        public event EventHandler<EventArgs> ChildFailEvent;

        public event EventHandler<EventArgs> ChildSuccessEvent;

        #endregion

        #region Constructor

        public LifeSimModel()
        {
            rnd = new Random();
            Universities = new List<University>() { new University("Informatikus", 3), new University("Orvosi", 6) };
            Jobs = new List<Job>() { new Job("Pályakezdő programozó", 3180000, Universities[0]), new Job("Járőr", 2040000, null), new Job("Fogorvos", 3780000, Universities[1]) };
            Homes = new List<Home>() { new Home("Albérlet", 165000, 1980000), new Home("30 négyzetméteres, egyszerű lakás", 12450000, 470000), new Home("50 négyzetméteres, szép lakás", 25500000, 580000) };
            yourName = "";
            familyNames = new List<string> { "Molnár", "Varga", "Poór", "Kovács", "Kiss", "Pósa", "Tóth", "Madaras", "Balogh", "Papp", "Major", "Jászai", "Fodor", "Takács", "Elek", "Horváth", "Nagy", "Fábián", "Kis", "Fehér", "Katona", "Pintér", "Kecskés", "Lakatos", "Szalai", "Gál", "Szűcs", "Bencsik", "Szücsi", "Bartók", "Király", "Lengyel", "Barta", "Fazekas", "Sándor", "Simon", "Soós", "Fekete", "Deák", "Székely", "Faragó", "Kelemen", "Szilágyi", "Pataki", "Csaba", "Cserepes", "Csiszár", "Sárközi", "Dóra", "Berkes", "Jakab", "Péter", "Rézműves", "Rácz", "Berki", "Kocsis", "Fülöp", "Ágoston", "Németh", "Dévényi", "Bátorfi", "Balázs", "Benedek", "Pásztor", "Károlyi", "Bogdán", "Fenyő", "Váradi", "Ribár", "Juhász", "Fésűs", "Somodi", "Kolompár", "Szekeres", "Széles", "Orosz", "Ferenc", "Kónya", "Szalay", "Puskás", "Győri", "Szigetvári", "Herczeg", "Veres", "Győző", "Orsós", "Bodnár", "Vörös", "Darai", "Vígh", "Radics", "Mészáros", "Babos", "Geszti", "Erős", "Hegedüs", "Képes", "Szeles", "Sebestyén", "Borbély", "Kövesdy", "Sátori", "Mihály", "Csiki", "Végh", "Somogyi", "Budai" };
            maleNames = new List<string> { "Péter", "János", "László", "Jakab", "József", "Gábor", "Sándor", "Bálint", "Richárd", "Bence", "Balázs", "Jácint", "Erik", "Zoltán", "Zsolt", "Kristóf", "Viktor", "Róbert", "Szilárd", "Szabolcs", "Martin", "Marcell", "Kázmér", "Benedek", "Máté", "Botond", "András", "Roland", "Ferenc", "István", "Krisztián", "Győző", "Farkas", "Ákos", "Béla", "Mihály", "Károly", "Gergely", "Ágoston", "Boldizsár", "Gergő", "Mózes", "Márió", "Ádám", "Dénes", "Ábel", "Tamás", "Szilveszter", "György", "Elek", "Áron", "Pál", "Márton", "Álmos", "Kornél", "Lőrinc", "Dániel", "Oszkár", "Márk", "Koppány", "Ernő", "Lázár", "Mátyás", "Aladár", "Lajos", "Attila", "Benjámin", "Csaba", "Csanád", "Olivér", "Gyula", "Henrik", "Sámuel", "Tivadar", "Antal", "Vilmos", "Hugó", "Arnold", "Tibor", "Levente", "Géza", "Dezső", "Albert", "Csongor", "Iván", "Ottó", "Endre", "Dávid", "Zalán", "Nándor", "Imre", "Domonkos", "Zsombor", "Norbert", "Patrik", "Kevin", "Vince", "Kelemen", "Xavér", "Zebulon" };
            femaleNames = new List<string> { "Petra", "Katalin", "Jázmin", "Melinda", "Vanda", "Zsófia", "Eszter", "Kamilla", "Sára", "Cecília", "Viktória", "Emese", "Erika", "Alexandra", "Barbara", "Zsuzsanna", "Linda", "Mária", "Emma", "Alíz", "Ibolya", "Erzsébet", "Tamara", "Virág", "Alma", "Réka", "Andrea", "Dóra", "Vivien", "Bernadett", "Karina", "Krisztina", "Lívia", "Anett", "Bella", "Edit", "Karolina", "Fruzsina", "Edina", "Beáta", "Boglárka", "Anna", "Éva", "Daniella", "Anita", "Veronika", "Csenge", "Adrienn", "Diána", "Júlia", "Katica", "Fanni", "Lilla", "Mónika", "Nóra", "Napsugár", "Márta", "Flóra", "Hanna", "Hajnalka", "Kincső", "Amanda", "Beatrix", "Dalma", "Dorina", "Johanna", "Laura", "Míra", "Nikoletta", "Orsolya", "Roxána", "Zsanett", "Viola", "Zita", "Tekla", "Olívia", "Mirtill", "Ilona", "Anikó", "Gabriella", "Tünde", "Szilvia", "Evelin", "Bianka", "Klaudia", "Kitti", "Léna", "Szonja", "Borbála", "Tímea", "Enikő", "Ramóna", "Dorottya", "Leila", "Hanga", "Adél", "Bettina", "Hortenzia", "Izabella" };
    }

        public LifeSimModel(String yourName, bool maleOrFemale)
        {
            rnd = new Random();
            Universities = new List<University>() { new University("Informatikus", 3), new University("Orvosi", 6) };
            Jobs = new List<Job>() { new Job("Pályakezdő programozó", 3180000, Universities[0]), new Job("Járőr", 2040000, null), new Job("Fogorvos", 3780000, Universities[1]) };
            Homes = new List<Home>() { new Home("Albérlet", 165000, 1980000), new Home("30 négyzetméteres, egyszerű lakás", 12450000, 470000), new Home("50 négyzetméteres, szép lakás", 25500000, 580000) };
            this.yourName = yourName;
            this.maleOrFemale = maleOrFemale;
        }

        #endregion

        #region Public game methods

        public void newGame()
        {
            
            String familyName;
            String name;
            Gender gender;
            if (yourName == "")
            {
                familyName = familyNames[rnd.Next(familyNames.Count)];
                gender = (Gender)rnd.Next(2);
                if (gender == 0)
                    name = maleNames[rnd.Next(maleNames.Count)];
                else
                    name = femaleNames[rnd.Next(femaleNames.Count)];
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
            Parents = new List<Person>() { new Person(familyName, maleNames[rnd.Next(maleNames.Count)], rnd.Next(18,55), Gender.Male, rnd.Next(1,101), rnd.Next(101), rnd.Next(101)),
                                            new Person(familyNames[rnd.Next(familyNames.Count)], femaleNames[rnd.Next(femaleNames.Count)], rnd.Next(18,55), Gender.Female, rnd.Next(1,101), rnd.Next(101), rnd.Next(101))};

            int appearance = (Parents[0].Intelligence + Parents[1].Intelligence) / 2 + rnd.Next(-10, 11);
            int intelligence = (Parents[0].Appearance + Parents[1].Appearance) / 2 + rnd.Next(-10, 11);

            if (appearance < 0)
                appearance = 0;
            if (intelligence < 0)
                intelligence = 0;

            if (appearance > 100)
                appearance = 100;
            if (intelligence > 100)
                intelligence = 100;

            You = new Person(familyName, name, 0, gender, 100, intelligence, appearance);
            Job = new Job("Munkanélküli", 0, null);
            Home = new Home("Szülői lakás", 0, 0);
            University = new University("Jelenleg nem végzel egyetemi képzést", 0);
            Degrees = new List<University>();
            Children = new List<Person>();
            inUni = false;
            childOnWay = false;
            Partner = null;
        }
        public void age()
        {
            You.Age++;

            You.Intelligence += rnd.Next(-3, 4);
            if (You.Intelligence > 100)
                You.Intelligence = 100;
            else if (You.Intelligence < 0)
                You.Intelligence = 0;

            You.Appearance += rnd.Next(-3, 4);
            if (You.Appearance > 100)
                You.Appearance = 100;
            else if (You.Appearance < 0)
                You.Appearance = 0;

            if (You.Age < 18)
                You.Health += rnd.Next(-3, 8);

            else if (You.Age >= 18 && You.Age < 36)
                You.Health += rnd.Next(-5, 6);

            else if (You.Age >= 36 && You.Age < 55)
                You.Health += rnd.Next(-6, 3);

            else
                You.Health += rnd.Next(-8, 2);

            if (You.Health > 100)
                You.Health = 100;

            if (You.Age == 110 || You.Health <= 0)
            {
                You.Health = 0;
                OnDeathEvent();
            }

            if (inUni)
            {
                yearsInUni++;
                if (yearsInUni == University.YearsToFinish)
                {
                    OnGraduateEvent();
                    yearsInUni = 0;
                    Degrees.Add(University);
                    University = new University("Jelenleg nem végzel egyetemi képzést", 0);
                }
            }

            You.Money += Job.Salary - Home.YearlyExpenses;
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
            Job = job;
            OnJobChangedEvent();
        }

        public void homeRefresh(Home home)
        {
            Home = home;
            OnHomeChangedEvent();
        }

        public void uniRefresh(University uni)
        {
            yearsInUni = 0;
            inUni = true;
            University = uni;
            OnUniChangedEvent();
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
                Partner = PotentialPartner.Item1;
                PotentialPartner = null;
                OnRelationshipSuccessEvent();
            }
        }

        public void breakUp()
        {
            Partner = null;
            OnBreakUpEvent();
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
                    OnChildSuccessEvent();
                    break;
            }
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

        #endregion

        #region Private event methods

        private void OnDeathEvent()
        {
            DeathEvent?.Invoke(this, new LifeSimEventArgs(You.Age));
        }

        private void OnJobChangedEvent()
        {
            JobChangedEvent?.Invoke(this, new EventArgs());
        }

        private void OnHomeChangedEvent()
        {
            HomeChangedEvent?.Invoke(this, new EventArgs());
        }

        private void OnUniChangedEvent()
        {
            UniChangedEvent?.Invoke(this, new EventArgs());
        }

        private void OnGraduateEvent()
        {
            inUni = false;
            GraduateEvent?.Invoke(this, new EventArgs());
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

        private void OnBreakUpEvent()
        {
            BreakUpEvent?.Invoke(this, new EventArgs());
        }

        private void OnChildFailEvent()
        {
            ChildFailEvent?.Invoke(this, new EventArgs());
        }

        private void OnChildSuccessEvent()
        {
            ChildSuccessEvent?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}
