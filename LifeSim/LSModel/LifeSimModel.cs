﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LifeSim.Persistence;
using LifeSim.Properties;

namespace LifeSim.LSModel
{
    /// <summary>
    /// Nemek felsorolási típusa.
    /// </summary>
    public enum Gender { Female, Male }

    /// <summary>
    /// LifeSim játék logikájának típusa.
    /// </summary>
    public class LifeSimModel
    {
        #region Name list constants

        private readonly ReadOnlyCollection<String> familyNames = new List<String> { "Molnár", "Varga", "Poór", "Kovács", "Kiss", "Pósa", "Tóth", "Madaras", "Balogh", "Papp",
            "Major", "Jászai", "Fodor", "Takács", "Elek", "Horváth", "Nagy", "Fábián", "Kis", "Fehér", "Katona", "Pintér", "Kecskés", "Lakatos", "Szalai", "Gál", "Szűcs",
            "Bencsik", "Szücsi", "Bartók", "Király", "Lengyel", "Barta", "Fazekas", "Sándor", "Simon", "Soós", "Fekete", "Deák", "Székely", "Faragó", "Kelemen", "Szilágyi",
            "Pataki", "Csaba", "Cserepes", "Csiszár", "Sárközi", "Dóra", "Berkes", "Jakab", "Péter", "Rézműves", "Rácz", "Berki", "Kocsis", "Fülöp", "Ágoston", "Németh",
            "Dévényi", "Bátorfi", "Balázs", "Benedek", "Pásztor", "Károlyi", "Bogdán", "Cserhegyi", "Demeter", "Fenyő", "Váradi", "Ribár", "Juhász", "Fésűs", "Somodi", "Kolompár",
            "Szekeres", "Széles", "Orosz", "Ferenc", "Kónya", "Szalay", "Puskás", "Győri", "Szigetvári", "Herczeg", "Veres", "Győző", "Orsós", "Bodnár", "Vörös", "Darai", "Vígh",
            "Radics", "Mészáros", "Babos", "Geszti", "Erős", "Hegedüs", "Képes", "Szeles", "Sebestyén", "Borbély", "Kövesdy", "Sátori", "Mihály", "Csiki", "Végh", "Somogyi",
            "Budai" }.AsReadOnly(); // családnevek
        private readonly ReadOnlyCollection<String> maleNames = new List<String> { "Péter", "János", "László", "Jakab", "József", "Gábor", "Sándor", "Bálint", "Richárd", "Bence",
            "Balázs", "Jácint", "Erik", "Zoltán", "Zsolt", "Kristóf", "Viktor", "Róbert", "Szilárd", "Szabolcs", "Martin", "Marcell", "Kázmér", "Benedek", "Máté", "Botond",
            "András", "Roland", "Ferenc", "István", "Krisztián", "Győző", "Farkas", "Ákos", "Béla", "Mihály", "Károly", "Gergely", "Ágoston", "Boldizsár", "Gergő", "Mózes",
            "Márió", "Ádám", "Dénes", "Ábel", "Tamás", "Szilveszter", "György", "Elek", "Áron", "Pál", "Márton", "Álmos", "Kornél", "Lőrinc", "Dániel", "Oszkár", "Márk", 
            "Koppány", "Ernő", "Lázár", "Mátyás", "Aladár", "Lajos", "Attila", "Benjámin", "Csaba", "Csanád", "Olivér", "Gyula", "Henrik", "Sámuel", "Tivadar", "Antal", "Vilmos",
            "Hugó", "Arnold", "Tibor", "Levente", "Géza", "Dezső", "Albert", "Csongor", "Iván", "Ottó", "Endre", "Dávid", "Zalán", "Nándor", "Imre", "Domonkos", "Zsombor",
            "Norbert", "Patrik", "Kevin", "Vince", "Kelemen", "Xavér", "Zebulon" }.AsReadOnly(); // férfi keresztnevek
        private readonly ReadOnlyCollection<String> femaleNames = new List<String> { "Petra", "Katalin", "Jázmin", "Melinda", "Vanda", "Zsófia", "Eszter", "Kamilla", "Sára",
            "Cecília", "Viktória", "Emese", "Erika", "Alexandra", "Barbara", "Zsuzsanna", "Linda", "Mária", "Emma", "Alíz", "Ibolya", "Erzsébet", "Tamara", "Virág", "Alma",
            "Réka", "Andrea", "Dóra", "Vivien", "Bernadett", "Karina", "Krisztina", "Lívia", "Anett", "Bella", "Edit", "Karolina", "Fruzsina", "Edina", "Beáta", "Boglárka",
            "Anna", "Éva", "Daniella", "Anita", "Veronika", "Csenge", "Adrienn", "Diána", "Júlia", "Katica", "Fanni", "Lilla", "Mónika", "Nóra", "Napsugár", "Márta", "Flóra",
            "Hanna", "Hajnalka", "Kincső", "Amanda", "Beatrix", "Dalma", "Dorina", "Johanna", "Laura", "Míra", "Nikoletta", "Orsolya", "Roxána", "Zsanett", "Viola", "Zita",
            "Tekla", "Olívia", "Mirtill", "Ilona", "Anikó", "Gabriella", "Tünde", "Szilvia", "Evelin", "Bianka", "Klaudia", "Kitti", "Léna", "Szonja", "Borbála", "Tímea", "Enikő",
            "Ramóna", "Dorottya", "Leila", "Hanga", "Adél", "Bettina", "Hortenzia", "Izabella" }.AsReadOnly(); // női keresztnevek

        #endregion

        #region Fields

        private Random rnd; // véletlenszám-generátor változója
        private String yourName; // a játékos neve
        private bool maleOrFemale; // férfi, vagy nő
        private bool smartUni; // kell-e fizetned az egyetemért
        private int universityCosts; // egyetem költségei
        private int timeToPayBack; // visszafizetési idő
        private Dictionary<Person, List<Person>> childParentPairs; // szülő-gyerek párosítások
        private IPersistence dataAccess; // adatelérés

        #endregion

        #region Properties

        /// <summary>
        /// Játékos karakter.
        /// </summary>
        public Player You { get; private set; }

        /// <summary>
        /// Játékos karakter + NPC-k listája.
        /// </summary>
        public List<Person> People { get; private set; }

        /// <summary>
        /// Potenciális partner.
        /// </summary>
        public Tuple<Person, int> PotentialPartner { get; private set; }

        /// <summary>
        /// Szülők listája.
        /// </summary>
        public List<Person> Parents { get; private set; }

        /// <summary>
        /// Munkák listája.
        /// </summary>
        public List<Job> Jobs { get; private set; }

        /// <summary>
        /// Egyetemek listája.
        /// </summary>
        public List<University> Universities { get; private set; }

        /// <summary>
        /// Lakások listája.
        /// </summary>
        public List<Home> Homes { get; private set; }

        /// <summary>
        /// Betegségek listája.
        /// </summary>
        public List<Sickness> Sicknesses { get; private set; }

        /// <summary>
        /// Autók listája.
        /// </summary>
        public List<Car> Vehicles { get; private set; }

        /// <summary>
        /// Alapértelmezett munka.
        /// </summary>
        public Job DefaultJob { get; private set; }

        /// <summary>
        /// Alapértelmezett egyetem.
        /// </summary>
        public University DefaultUniversity { get; private set; }

        /// <summary>
        /// Alapértelmezett otthon.
        /// </summary>
        public Home DefaultHome { get; private set; }

        /// <summary>
        /// Alapértelmezett jármű.
        /// </summary>
        public Car DefaultVehicle { get; private set; }

        /// <summary>
        /// Achievementek szótára.
        /// </summary>
        public Dictionary<String,String> Achievements { get; private set; }

        /// <summary>
        /// Teljesített achievementek listája.
        /// </summary>
        public List<int> CompletedAchievements { get; private set; }

        #endregion

        #region Events

        /// <summary>
        /// Személy halálának seseménye.
        /// </summary>
        public event EventHandler<LifeSimEventArgs> DeathEvent;

        /// <summary>
        /// Munka változásának seseménye (jelentkezés, kilépés).
        /// </summary>
        public event EventHandler<EventArgs> JobChangedEvent;

        /// <summary>
        /// Lakás változásának seseménye.
        /// </summary>
        public event EventHandler<EventArgs> HomeChangedEvent;

        /// <summary>
        /// Jármű változásának seseménye.
        /// </summary>
        public event EventHandler<EventArgs> VehicleChangedEvent;

        /// <summary>
        /// Egyetem változásának eseménye. (adott intelligencia felett)
        /// </summary>
        public event EventHandler<EventArgs> SmartUniChangedEvent;

        /// <summary>
        /// Egyetem változásának eseménye. (adott intelligencia alatt)
        /// </summary>
        public event EventHandler<LifeSimEventArgs> DumbUniChangedEvent;

        /// <summary>
        /// Egyetem sikeres elvégzésének eseménye. (adott intelligencia felett)
        /// </summary>
        public event EventHandler<EventArgs> SmartGraduateEvent;

        /// <summary>
        /// Egyetem sikeres elvégzésének eseménye. (adott intelligencia alatt)
        /// </summary>
        public event EventHandler<LifeSimEventArgs> DumbGraduateEvent;

        /// <summary>
        /// Egészség változásának eseménye.
        /// </summary>
        public event EventHandler<EventArgs> HealthRefreshEvent;

        /// <summary>
        /// Intelligencia változásának eseménye.
        /// </summary>
        public event EventHandler<EventArgs> IntelligenceRefreshEvent;

        /// <summary>
        /// Boldogság változásának eseménye.
        /// </summary>
        public event EventHandler<EventArgs> HappinessRefreshEvent;

        /// <summary>
        /// Kinézet változásának eseménye.
        /// </summary>
        public event EventHandler<EventArgs> AppearanceRefreshEvent;

        /// <summary>
        /// Pénz változásának eseménye.
        /// </summary>
        public event EventHandler<EventArgs> MoneyRefreshEvent;

        /// <summary>
        /// Kapcsolat sikertelenségének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> RelationshipFailEvent;

        /// <summary>
        /// Kapcsolat sikerességének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> RelationshipSuccessEvent;

        /// <summary>
        /// Szakítás eseménye.
        /// </summary>
        public event EventHandler<LifeSimEventArgs> BreakUpEvent;

        /// <summary>
        /// Gyermekvállalás sikertelenségének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> ChildFailEvent;

        /// <summary>
        /// Gyermekvállalás sikerességének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> ChildSuccessEvent;

        /// <summary>
        /// Gyermek születésének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> ChildBornEvent;

        /// <summary>
        /// Felmondás eseménye.
        /// </summary>
        public event EventHandler<EventArgs> QuitJobEvent;

        /// <summary>
        /// Előléptetés eseménye.
        /// </summary>
        public event EventHandler<EventArgs> PromotionEvent;

        /// <summary>
        /// Nyugdíjba vonulás eseménye.
        /// </summary>
        public event EventHandler<EventArgs> RetirementEvent;

        /// <summary>
        /// Vakáció sikertelenségének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> VacationFailedEvent;

        /// <summary>
        /// Gyermekvállalás sikerességének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> VacationSuccessEvent;

        /// <summary>
        /// Edzés sikertelenségének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> WorkOutFailedEvent;

        /// <summary>
        /// Edzés sikerességének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> WorkOutSuccessEvent;

        /// <summary>
        /// Olvasás sikertelenségének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> ReadFailedEvent;

        /// <summary>
        /// Olvasás sikerességének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> ReadSuccessEvent;

        /// <summary>
        /// Ismerőssel folytatott közös program eseménye.
        /// </summary>
        public event EventHandler<LifeSimEventArgs> ProgramWithAcquaintanceEvent;

        /// <summary>
        /// Ismerőssel való veszekedés eseménye.
        /// </summary>
        public event EventHandler<LifeSimEventArgs> QuarrelWithAcquaintanceEvent;

        /// <summary>
        /// Lottózás sikertelenségének eseménye. (pénz miatt)
        /// </summary>
        public event EventHandler<EventArgs> NoMoneyForLotteryEvent;

        /// <summary>
        /// Lottózás sikertelenségének eseménye. (randomgenerátor miatt)
        /// </summary>
        public event EventHandler<EventArgs> LotteryLoseEvent;

        /// <summary>
        /// Lottózás sikerességének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> LotteryWinEvent;

        /// <summary>
        /// Katonai küldetésre küldés eseménye.
        /// </summary>
        public event EventHandler<EventArgs> MilitaryMissionEvent;

        /// <summary>
        /// Barátkozás sikertelenségének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> MakeFriendFailedEvent;

        /// <summary>
        /// Barátkozás sikerességének eseménye.
        /// </summary>
        public event EventHandler<LifeSimEventArgs> MakeFriendSuccessEvent;

        /// <summary>
        /// Katonai küldetés teljesítésének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> MilitaryMissionCompleteEvent;

        /// <summary>
        /// Repülőgép-szerencsétlenség eseménye.
        /// </summary>
        public event EventHandler<EventArgs> PlaneCrashEvent;

        /// <summary>
        /// Karambol eseménye.
        /// </summary>
        public event EventHandler<EventArgs> CarCrashEvent;

        /// <summary>
        /// Betegség elkapásának eseménye.
        /// </summary>
        public event EventHandler<LifeSimEventArgs> CaughtSicknessEvent;

        /// <summary>
        /// Doktor látogatás eseménye.
        /// </summary>
        public event EventHandler<LifeSimEventArgs> DoctorsVisitEvent;

        /// <summary>
        /// Achievement megszerzésének eseménye.
        /// </summary>
        public event EventHandler<LifeSimEventArgs> AchievementUnlockedEvent;

        /// <summary>
        /// Jogosítvány vizsga befejezésének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> ExamCompleteEvent;

        #endregion

        #region Constructor

        /// <summary>
        /// LifeSim játék példányosítása véletlenszerű játékossal.
        /// </summary>
        /// <param name="dataAccess">Adatelérés.</param>
        public LifeSimModel(IPersistence dataAccess)
        {
            rnd = new Random();
            Universities = new List<University>() {
                new University("Informatikus", 3, 325000),
                new University("Orvosi", 6, 1045000),
                new University("Tisztképző", 4, 250000),
                new University("Mérnöki", 4, 325000),
                new University("Repülőmérnöki", 4, 375000)
            };
            Jobs = new List<Job>() { 
                new Job(new Dictionary<String, int> { { "Junior programozó", 3240000 }, { "Medior programozó", 6600000 }, { "Senior programozó", 9600000 } }, Universities[0], 2,
                Resources.programmer),
                new Job(new Dictionary<String, int> { { "Járőr", 2040000 }, { "Zászlós", 2811960 }, { "Rendőrtiszt", 4397520 } }, null, 2, Resources.police),
                new Job(new Dictionary<String, int> { { "Fogorvos", 3780000 } }, Universities[1], 0, Resources.dentist),
                new Job(new Dictionary<String, int> { { "Közlegény", 2040000 }, { "Tizedes", 2160000 },
                    { "Őrmester", 2580000 }, { "Zászlós", 3000000 } }, null, 3, Resources.soldier),
                new Job(new Dictionary<String, int> { { "Hadnagy", 2820000 },
                    { "Százados", 3360000 }, { "Őrnagy", 3660000 }, { "Ezredes", 4800000 }, { "Dandártábornok", 5880000 } }, Universities[2], 4, Resources.officer),
                new Job(new Dictionary<String, int> { { "Kezdő villamosmérnök", 2880000 }, { "Senior villamosmérnök", 5280000 }, { "Csoportvezető villamosmérnök", 10020000 },
                    { "Felsővezető villamosmérnök", 15960000 } }, Universities[3], 3, Resources.engineer),
                new Job(new Dictionary<String, int> { { "Pilóta gyakornok", 2820000 }, { "Másodpilóta", 6180000 }, { "Pilóta", 8640000 },
                    { "Vezető pilóta", 11640000 } }, Universities[4], 3, Resources.pilot) 
            };
            Homes = new List<Home>() {
                new Home("Albérlet", 165000, 865000, Resources.flat, 5),
                new Home("30 négyzetméteres, egyszerű lakás", 12450000, 3480000, Resources.middlehome, 10),
                new Home("50 négyzetméteres, szép lakás", 25500000, 6095000, Resources.nicehome, 15)
            };
            Sicknesses = new List<Sickness>() {
                new Sickness("Megfázás", 5),
                new Sickness("Rák", 18, 10),
                new Sickness("Magas vérnyomás", 6, 7),
                new Sickness("COVID-19", 20, 2) 
            };
            Vehicles = new List<Car>() {
                new Car("Lada Samara 1989", 150000, 60000, Resources.lada, 3),
                new Car("Renault Clio 1.4 16V Dynamique 2002", 600000, 130000, Resources.clio, 5),
                new Car("Opel Astra G 1.4 16V Classic II 2004", 1500000, 230000, Resources.opel, 7),
                new Car("Nissan 370 Z 3.7 V6 Nismo", 9000000, 400000, Resources.nissan, 13)
            };
            yourName = "";
            DefaultJob = new Job(new Dictionary<String, int> { { "Munkanélküli", 0 } }, null, 0, null);
            DefaultHome = new Home("Szülői lakás", 0, 0, null, 2);
            DefaultUniversity = new University("Jelenleg nem végzel egyetemi képzést", 0, 0);
            DefaultVehicle = new Car("Nem rendelkezel járművel", 0, 0, null, 1);
            this.dataAccess = dataAccess;
            Achievements = new Dictionary<string, string> {
                { "Genesis", "Kezdd el az első életedet!" },
                { "Gyenge immunrendszer", "Szenvedj egyszerre minimum két betegségben! (megfázáson kívül)" },
                { "Tiszavirág", "Élj maximum 10 évig egy karakterrel!" }, 
                { "Őskövület", "Élj minimum 90 évig egy karakterrel!" }, 
                { "Tango down!", "Sikeresen teljesíts egy katonai missziót!" },
                { "WIA", "Bukj el egy katonai missziót!" },
                { "KIA", "Halj meg egy katonai misszióban!" },
                { "Dolgos élet", "Vonulj nyugdíjba!" }, 
                { "Lesz mit mesélni az unokáknak!", "Vonulj nyugdíjba valamelyik katonai karrierből!" },
                { "Közkedvelt", "Legyen legalább 10 élő ismerősöd!" } };
            if (!File.Exists("achievements.ach")) // ha nem létezik az achievement fájl, akkor létrehozzuk és beleírunk egy 0-t (ez az első achievementet jelképezi)
            {
                saveAchievements(0);
                OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(0));
            }
            CompletedAchievements = new List<int>();
            loadAchievements(); // ezután betöltjük a már elért achievementeket
        }

        /// <summary>
        /// LifeSim játék példányosítása előre megadott adatokkal.
        /// </summary>
        /// <param name="yourName">A játékos által megadott név.</param>
        /// <param name="maleOrFemale">A játékos által megadott nem.</param>
        /// <param name="dataAccess">Adatelérés.</param>
        public LifeSimModel(String yourName, bool maleOrFemale, IPersistence dataAccess)
        {
            rnd = new Random();
            Universities = new List<University>() {
                new University("Informatikus", 3, 325000),
                new University("Orvosi", 6, 1045000),
                new University("Tisztképző", 4, 250000),
                new University("Mérnöki", 4, 325000),
                new University("Repülőmérnöki", 4, 375000)
            };
            Jobs = new List<Job>() {
                new Job(new Dictionary<String, int> { { "Junior programozó", 3240000 }, { "Medior programozó", 6600000 }, { "Senior programozó", 9600000 } }, Universities[0], 2,
                Resources.programmer),
                new Job(new Dictionary<String, int> { { "Járőr", 2040000 }, { "Zászlós", 2811960 }, { "Rendőrtiszt", 4397520 } }, null, 2, Resources.police),
                new Job(new Dictionary<String, int> { { "Fogorvos", 3780000 } }, Universities[1], 0, Resources.dentist),
                new Job(new Dictionary<String, int> { { "Közlegény", 2040000 }, { "Tizedes", 2160000 },
                    { "Őrmester", 2580000 }, { "Zászlós", 3000000 } }, null, 3, Resources.soldier),
                new Job(new Dictionary<String, int> { { "Hadnagy", 2820000 },
                    { "Százados", 3360000 }, { "Őrnagy", 3660000 }, { "Ezredes", 4800000 }, { "Dandártábornok", 5880000 } }, Universities[2], 4, Resources.officer),
                new Job(new Dictionary<String, int> { { "Kezdő villamosmérnök", 2880000 }, { "Senior villamosmérnök", 5280000 }, { "Csoportvezető villamosmérnök", 10020000 },
                    { "Felsővezető villamosmérnök", 15960000 } }, Universities[3], 3, Resources.engineer),
                new Job(new Dictionary<String, int> { { "Pilóta gyakornok", 2820000 }, { "Másodpilóta", 6180000 }, { "Pilóta", 8640000 },
                    { "Vezető pilóta", 11640000 } }, Universities[4], 3, Resources.pilot)
            };
            Homes = new List<Home>() {
                new Home("Albérlet", 165000, 1980000, Resources.flat, 5),
                new Home("30 négyzetméteres, egyszerű lakás", 12450000, 470000, Resources.middlehome, 10),
                new Home("50 négyzetméteres, szép lakás", 25500000, 580000, Resources.nicehome, 15)
            };
            Sicknesses = new List<Sickness>() {
                new Sickness("Megfázás", 5),
                new Sickness("Rák", 18, 10),
                new Sickness("Magas vérnyomás", 6, 7),
                new Sickness("COVID-19", 20, 2)
            };
            Vehicles = new List<Car>() {
                new Car("Lada Samara 1989", 150000, 60000, Resources.lada, 3),
                new Car("Renault Clio 1.4 16V Dynamique 2002", 600000, 130000, Resources.clio, 5),
            };
            this.yourName = yourName;
            this.maleOrFemale = maleOrFemale;
            DefaultJob = new Job(new Dictionary<String, int> { { "Munkanélküli", 0 } }, null, 0, null);
            DefaultHome = new Home("Szülői lakás", 0, 0, null, 2);
            DefaultUniversity = new University("Jelenleg nem végzel egyetemi képzést", 0, 0);
            DefaultVehicle = new Car("Nem rendelkezel járművel", 0, 0, null, 1);
            this.dataAccess = dataAccess;
            Achievements = new Dictionary<string, string> {
                { "Genesis", "Kezdd el az első életedet!" },
                { "Gyenge immunrendszer", "Szenvedj egyszerre minimum két betegségben! (megfázáson kívül)" },
                { "Tiszavirág", "Élj maximum 15 évig egy karakterrel!" },
                { "Őskövület", "Élj minimum 90 évig egy karakterrel!" },
                { "Tango down!", "Sikeresen teljesíts egy katonai missziót!" },
                { "WIA", "Bukj el egy katonai missziót!" },
                { "KIA", "Halj meg egy katonai misszióban!" },
                { "Dolgos élet", "Vonulj nyugdíjba!" },
                { "Lesz mit mesélni az unokáknak!", "Vonulj nyugdíjba valamelyik katonai karrierből!" },
                { "Közkedvelt", "Legyen legalább 10 élő ismerősöd!" } };
            if (!File.Exists("achievements.ach")) // ha nem létezik az achievement fájl, akkor létrehozzuk és beleírunk egy 0-t (ez az első achievementet jelképezi)
            {
                saveAchievements(0);
                OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(0));
            }
            CompletedAchievements = new List<int>();
            loadAchievements(); // ezután betöltjük a már elért achievementeket
        }

        #endregion

        #region Public game methods

        /// <summary>
        /// Új játék kezdése.
        /// </summary>
        public void newGame()
        {
            People = new List<Person>();
            childParentPairs = new Dictionary<Person, List<Person>>();
            String familyName;
            String name;
            Gender gender;
            if (yourName == "") // ha random karakterrel kezdünk, akkor a véletlenszám-generátor segítségével kiválaszt egy családnevet, nemet és ennek megfelelően egy keresztnevet
            {
                familyName = familyNames[rnd.Next(familyNames.Count)];
                gender = (Gender)rnd.Next(2);
                if (gender == 0)
                    name = femaleNames[rnd.Next(femaleNames.Count)];
                else
                    name = maleNames[rnd.Next(maleNames.Count)];
            }
            else // különben az előre megadott névvel és nemmel kezd új játékot
            {
                familyName = yourName.Split(' ')[0];
                name = yourName.Split(' ')[1];
                if (maleOrFemale)
                    gender = Gender.Male;
                else
                    gender = Gender.Female;
            }
            Parents = new List<Person>() { new Person(familyName, maleNames[rnd.Next(maleNames.Count)], rnd.Next(18,50), Gender.Male, rnd.Next(80,101), rnd.Next(101),
                                                        rnd.Next(101), rnd.Next(75,101), rnd.Next(75,101)),
                                            new Person(familyNames[rnd.Next(familyNames.Count)], femaleNames[rnd.Next(femaleNames.Count)], rnd.Next(18,50), Gender.Female,
                                                        rnd.Next(80,101), rnd.Next(101), rnd.Next(101), rnd.Next(75,101), rnd.Next(75,101))}; // szülők legenerálása

            int appearance = calculateStartingStat(Parents[0].Appearance, Parents[1].Appearance); // szülők kinézete alapján a játékos kinézetének kiszámolása
            int intelligence = calculateStartingStat(Parents[0].Intelligence, Parents[1].Intelligence); // szülők intelligenciája alapján a játékos intelligenciájának kiszámolása

            // ha az értékek 0 alattira, vagy 100 felettire jönnek ki, akkor átállnak 0-ra, vagy 100-ra
            if (appearance < 0)
                appearance = 0;
            if (intelligence < 0)
                intelligence = 0;

            if (appearance > 100)
                appearance = 100;
            if (intelligence > 100)
                intelligence = 100;

            You = new Player(familyName, name, 0, gender, 100, intelligence, appearance, 100, 0, 0, DefaultJob, DefaultHome, DefaultUniversity, DefaultVehicle);
            // játékos és szülők hozzáadása az emberek listájához
            People.Add(You);
            People.Add(Parents[0]);
            People.Add(Parents[1]);
            universityCosts = 0;
            timeToPayBack = 0;
        }

        /// <summary>
        /// Ez a függvény leszimulálja az 1 év alatt történő eseményeket.
        /// </summary>
        public void age()
        {
            foreach (Person p in People.ToList()) // minden listában szereplő emberen végigmegy
            {
                p.Age++; // növeli az életkort

                // változik az intelligencia, a kinézet, a boldogság és az egészség is (az utóbbiról később)
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

                p.Health += calculateHealth(p);

                if (p.Health > 100)
                    p.Health = 100;

                if (p != You && You.Age > 3) // ha az adott személy nem a játékos, és a játékos már elmúlt 3 éves, akkor a kapcsolatok romolhatnak, és akár veszekedés is történhet
                {
                    p.Relationship -= rnd.Next(1, 4);
                    if (rnd.Next(4) == 2)
                    {
                        quarrelWithAcquaintance(p);
                    }
                    if (p.Relationship < 0)
                        p.Relationship = 0;
                }

                if (p.Age == 110 || p.Health <= 0) // ha az adott személy egészsége elérte a 0-t, vagy a kora a 110-et, akkor meghal
                {
                    if (p == You) // ha a játékos karakter hal meg
                    {
                        if (p.Age <= 15 && !CompletedAchievements.Contains(2)) // ha a játékos legfeljebb 15 éves, és még nincs meg a 3. achievement, akkor megkapjuk
                        {
                            saveAchievements(2);
                            CompletedAchievements.Add(2);
                            OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(2));
                        }
                        else if (p.Age >= 90 && !CompletedAchievements.Contains(3)) // ha a játékos legalább 90 éves, és még nincs meg a 4. achievement, akkor megkapjuk
                        {
                            saveAchievements(3);
                            CompletedAchievements.Add(3);
                            OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(3));
                        }
                        People.Remove(You); // törlődik az emberek listájából
                        OnDeathEvent(You); // kiváltódik a halálhoz tartozó esemény
                        return;
                    }
                    else if (p == You.Partner) // ha a partnerünk hal meg, akkor már nem ő lesz a partnerünk
                    {
                        breakUp(true);
                    }
                    You.Happiness -= rnd.Next((int)(0.3 * p.Relationship));
                    p.Health = 0;
                    People.Remove(p); // törlődik az emberek listájából
                    OnDeathEvent(p); // kiváltódik a halálhoz tartozó esemény
                }

                p.Happiness += calculateHappiness(p);

                if (p.Happiness > 100)
                    p.Happiness = 100;
                else if (p.Happiness < 0)
                    p.Happiness = 0;
            }

            // Innentől csak a játékossal kapcsolatos változások szerepelnek

            You.Money += You.Job.JobLevels.Values.ElementAt(You.CurrentJobLevel) - You.Home.YearlyExpenses - You.Vehicle.YearlyExpenses - universityCosts; // a pénzünkhöz
                                                                                                                                //hozzáadódik a fizetésünk, és levonódik
                                                                                                                                // a lakás fenntartásának költsége, az
                                                                                                                                // egyetem költségei valamint a jármű fenntartása

            // ha vissza kell fizetnünk az egyetemi költségeket, a hátralévő évek folyamatosan csökkennek, és ha eléri a 0-t, akkor a költségek megszűnnek
            if (timeToPayBack > 0)
                timeToPayBack--;
            if (timeToPayBack == 0)
            {
                universityCosts = 0;
            }

            if (You.University != DefaultUniversity) // ha éppen egyetemre járunk (nem az alap egyetemre), akkor az ott töltött éveink növekednek
            {
                You.YearsInUni++;
                if (You.YearsInUni == You.University.YearsToFinish) // ha elérjük az elvégzéshez szükséges évszámot, akkor megkapjuk a diplomát
                {
                    if (!smartUni) // ha fizetősre kerültünk be, akkor el kell kezdenünk fizetni
                    {
                        do
                        {
                            timeToPayBack = rnd.Next(4, 25); // hány évig fogjuk visszafizetni
                            universityCosts = You.University.CostPerSemester * 2 * You.YearsInUni / timeToPayBack; // évente mennyit
                        } while (25000 * 12 > universityCosts || universityCosts > 60000 * 12);
                        OnDumbGraduateEvent(universityCosts, timeToPayBack);
                    }
                    else
                        OnSmartGraduateEvent();
                    You.YearsInUni = 0;
                    You.Degrees.Add(You.University);
                    You.University = DefaultUniversity;
                }
            }

            if (You.Job != DefaultJob && You.CurrentJobLevel != You.Job.MaxJobLevel) // ha van munkánk, és még nem értük el a végső szintjét
            {
                You.PromotionMeter += rnd.Next(6, 13); // növekszik az ún. Promotion Meter, ami az előléptetéshez való közelséget határozza meg
                if (You.PromotionMeter >= 100) // ha eléri a 100-at, akkor átlépünk a munka következő szintjére, kapunk egy kevés boldogságot, és visszaáll 0-ra a Promotion Meter
                {
                    You.CurrentJobLevel += 1;
                    You.PromotionMeter = 0;
                    You.Happiness += rnd.Next(2, 5);
                    OnPromotionEvent();
                    OnHappinessRefreshEvent();
                }
            }

            if (You.ChildOnWay) // ha éppen gyermeket vártunk, akkor hozzáadjuk a gyermeket a gyermekeink, és az emberek listájához
            {
                You.ChildOnWay = false;
                You.Children.Add(childParentPairs.Values.Last().Last());
                People.Add(You.Children[You.Children.Count - 1]);
                if (People.Count == 11 && !CompletedAchievements.Contains(9)) // ha ismerőseink száma (rajtunk kívül) eléri a 10-et, és nincs meg a 10. achievement, akkor megkapjuk
                {
                    saveAchievements(9);
                    CompletedAchievements.Add(9);
                    OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(9));
                }
                OnChildBornEvent();
            }

            if (You.Age == 65 && You.Job != DefaultJob) // ha elértük a 65 éves kort, és dolgozunk, akkor nyugdíjba vonulunk (a fizetésünk 2/3-át kapjuk meg a hátralévő években)
            {
                if (!CompletedAchievements.Contains(7)) // ha még nincs meg a 8. achievement, akkor megkapjuk
                {
                    saveAchievements(7);
                    CompletedAchievements.Add(7);
                    OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(7));
                }
                if ((You.Job == Jobs[3] || You.Job == Jobs[4]) && !CompletedAchievements.Contains(8)) // ha katonák voltunk, és még nincs meg a 9. achievement, akkor megkapjuk
                {
                    saveAchievements(8);
                    CompletedAchievements.Add(8);
                    OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(8));
                }
                int pension = Convert.ToInt32(Math.Round(You.Job.JobLevels.Values.ElementAt(You.CurrentJobLevel) * 0.67));
                You.Job = new Job(new Dictionary<String, int> { { "Nyugdíjas", pension } }, null, 0, Resources.retired);
                You.CurrentJobLevel = 0;
                OnRetirementEvent();
            }

            if (You.Job == Jobs[3] || You.Job == Jobs[4]) // ha katonai karrierben vagyunk, akkor 1/5 eséllyel behívhatnak misszióra
            {
                if (rnd.Next(5) == 3)
                {
                    OnMilitaryMissionEvent();
                }
            }

            if (You.Job == Jobs[6] && rnd.Next(150) == 50) //ha pilóta karrierben vagyunk, akkor 1/100 eséllyel meghalhatunk repülőgép-szerencsétlenségben
            {
                 You.Health -= 100;
                 OnPlaneCrashEvent();
                 OnDeathEvent(You);
            }

            if (You.Vehicle != DefaultVehicle && rnd.Next(200) == 50)
            {
                You.Health -= rnd.Next(10, 60);
                OnCarCrashEvent();
                if (You.Health == 0)
                {
                    OnDeathEvent(You);
                }
            }
            randomSickness();
        }

        /// <summary>
        /// Ez a függvény az edzés folyamatát foglalja magában.
        /// </summary>
        public void workOut()
        {
            // ha nem töltöttük be a 18-at, akkor ingyen edzünk, különben 120000 forintot kell fizetni
            if (You.Age < 18 || You.Money >= 120000)
            {
                int randomHealthGain = rnd.Next(6, 15); // kapunk egészséget 
                if (You.Health + randomHealthGain <= 100)
                    You.Health += randomHealthGain;
                else
                {
                    You.Health = 100;
                }

                int randomHappinessGain = rnd.Next(2, 5); // boldogságot
                if (You.Happiness + randomHappinessGain <= 100)
                    You.Happiness += randomHappinessGain;
                else
                {
                    You.Happiness = 100;
                }

                int randomAppearanceGain = rnd.Next(1, 5); // és kinézetet
                if (You.Appearance + randomAppearanceGain <= 100)
                    You.Appearance += randomAppearanceGain;
                else
                {
                    You.Appearance = 100;
                }
                OnWorkOutSuccessEvent();
                OnHealthRefreshEvent();
                OnHappinessRefreshEvent();
                OnAppearanceRefreshEvent();
                if (You.Age >= 18) // ha betöltöttük a 18-at, akkor levonja a pénzt
                {
                    You.Money -= 120000;
                    OnMoneyRefreshEvent();
                }
            }
            else // ha nem teljesülnek a feltételek, akkor nem tudunk edzeni
            {
                OnWorkOutFailedEvent();
            }
        }

        /// <summary>
        /// Ez a függvény az olvasás folyamatát foglalja magában.
        /// </summary>
        public void read()
        {
            // ha nem töltöttük be a 18-at, akkor ingyen olvasunk, különben 75000 forintot kell fizetni
            if (You.Age < 18 || You.Money >= 75000)
            {
                int randomIntelligenceGain = rnd.Next(3, 9); // kapunk intelligenciát
                if (You.Intelligence + randomIntelligenceGain <= 100)
                    You.Intelligence += randomIntelligenceGain;
                else
                {
                    You.Intelligence = 100;
                }

                int randomHappinessGain = rnd.Next(2, 5); // és boldogságot
                if (You.Happiness + randomHappinessGain <= 100)
                    You.Happiness += randomHappinessGain;
                else
                {
                    You.Happiness = 100;
                }
                OnReadSuccessEvent();
                OnIntelligenceRefreshEvent();
                OnHappinessRefreshEvent();
                if (You.Age >= 18) // ha betöltöttük a 18-at, akkor levonja a pénzt
                {
                    You.Money -= 75000;
                    OnMoneyRefreshEvent();
                }
            }
            else // ha nem teljesülnek a feltételek, akkor nem tudunk olvasnui
            {
                OnReadFailedEvent();
            }
        }

        /// <summary>
        /// A játékos munkáját frissítő függvény.
        /// </summary>
        /// <param name="job">A munka, amire a játékos jelentkezett.</param>
        public void jobRefresh(Job job)
        {
            You.Job = job;
            OnJobChangedEvent();
        }

        /// <summary>
        /// A játékos lakását frissítő függvény.
        /// </summary>
        /// <param name="home">A lakás, amit a játékos megvett.</param>
        public void homeRefresh(Home home)
        {
            You.Home = home;
            You.Money -= home.Price;
            OnHomeChangedEvent();
            OnMoneyRefreshEvent();
        }

        /// <summary>
        /// A lakás eladására szolgáló függvény.
        /// </summary>
        public void sellHome()
        {
            if (You.Home != Homes[0])
                You.Money += (int)(You.Home.Price * 0.75);
            You.Home = DefaultHome;
            OnHomeChangedEvent();
            OnMoneyRefreshEvent();
        }

        /// <summary>
        /// A játékos járművét frissítő függvény.
        /// </summary>
        /// <param name="vehicle">A Jármű, amit a játékos megvett.</param>
        public void vehicleRefresh(Car vehicle)
        {
            You.Vehicle = vehicle;
            You.Money -= vehicle.Price;
            OnVehicleChangedEvent();
            OnMoneyRefreshEvent();
        }

        /// <summary>
        /// A jármű eladására szolgáló függvény.
        /// </summary>
        public void sellVehicle()
        {
            You.Money += (int)(You.Vehicle.Price * 0.75);
            You.Vehicle = DefaultVehicle;
            OnVehicleChangedEvent();
            OnMoneyRefreshEvent();
        }

        /// <summary>
        /// A játékos egyetemi tanulmányait frissítő függvény.
        /// </summary>
        /// <param name="uni">Az egyetem, amire a játékos jelentkezett.</param>
        public void uniRefresh(University uni)
        {
            if (uni == DefaultUniversity)
            {
                return;
            }
            You.YearsInUni = 0;
            You.University = uni;
            if (You.Intelligence >= 70) // ha az intelligenciánk eléri a 70-et, akkor nem kell fizetnünk az egyetemért
            {
                smartUni = true;
                OnSmartUniChangedEvent();
            }
            else // különben igen
            {
                smartUni = false;
                OnDumbUniChangedEvent(uni.CostPerSemester);
            }
        }

        /// <summary>
        /// Függvény, amely a játékos lehetséges párját generálja le.
        /// </summary>
        /// <returns>A játékos lehetséges párja, és az esély a kapcsolatra.</returns>
        public Tuple<Person, int> newLove()
        {
            String randomName;
            Gender loveGender;
            if (You.Gender == Gender.Male) // ha férfi a játékos, akkor a visszatérített karakter nő lesz
            {
                randomName = femaleNames[rnd.Next(femaleNames.Count)];
                loveGender = Gender.Female;
            }
            else // különben férfi
            {
                randomName = maleNames[rnd.Next(maleNames.Count)];
                loveGender = Gender.Male;
            }
            int randomAge = rnd.Next(-2, 3);
            Person crush = new Person(familyNames[rnd.Next(familyNames.Count)], randomName, You.Age + randomAge, loveGender, rnd.Next(1, 101), rnd.Next(101), rnd.Next(101),
                rnd.Next(10, 101), 100);
            int chanceOfLove = chanceOfMutualLove(crush); // a játékos és a "crush" statisztikái alapján kiszámít egy esélyt a kapcsolatra
            PotentialPartner = new Tuple<Person, int>(crush, chanceOfLove);
            return PotentialPartner;
        }

        /// <summary>
        /// Kapcsolattal való megpróbálkozás függvénye.
        /// </summary>
        public void tryRelationship()
        {
            int randomNum = rnd.Next(5); // random szám generálása
            bool fail = false; // alapból az van beállítva, hogy sikeres legyen a kapcsolat
            switch (PotentialPartner.Item2) // megnézzük az esélyhez tartozó értéket
            {
                case 0: // ha 0, akkor semmiképpen nem tudunk összejönni a potenciális partnerrel
                    fail = true;
                    OnRelationshipFailEvent();
                    break;
                case 20: // ha 20, akkor 1/5 esélyünk van
                    if (randomNum > 0)
                    {
                        fail = true;
                        OnRelationshipFailEvent();
                    }
                    break;
                case 40: // ha 40, akkor 2/5 esélyünk van
                    if (randomNum > 1)
                    {
                        fail = true;
                        OnRelationshipFailEvent();
                    }
                    break;
                case 60: // ha 60, akkor 3/5 esélyünk van
                    if (randomNum > 2)
                    {
                        fail = true;
                        OnRelationshipFailEvent();
                    }
                    break;
                case 80: // ha 80, akkor 4/5 esélyünk van
                    if (randomNum > 3)
                    {
                        fail = true;
                        OnRelationshipFailEvent();
                    }
                    break;
            }
            if (!fail) // ha a randomszám-generátor jó számot generált, vagy 100% volt az esélyünk, akkor összejövünk a potenciális partnerrel
            {
                You.Partner = PotentialPartner.Item1;
                People.Add(PotentialPartner.Item1); // hozzáadjuk az emberek listájához
                if (People.Count == 10 && !CompletedAchievements.Contains(9)) // ha ismerőseink száma (rajtunk kívül) eléri a 10-et, és nincs meg a 10. achievement, akkor megkapjuk
                {
                    saveAchievements(9);
                    CompletedAchievements.Add(9);
                    OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(9));
                }
                PotentialPartner = null;
                childParentPairs.Add(You.Partner, new List<Person>());
                OnRelationshipSuccessEvent();
            }
        }

        /// <summary>
        /// Különválás partnerünkkel.
        /// </summary>
        /// <param name="death">A különválás oka a partner halála miatt volt-e.</param>
        public void breakUp(bool death)
        {
            You.Partner = null; // visszaállítjuk a partnerünket null-ra
            OnBreakUpEvent(death);
        }

        /// <summary>
        /// Munkából való kilépés.
        /// </summary>
        public void quitJob()
        {
            You.Job = DefaultJob; // visszaállítjuk a munkánkat az alap munkára
            You.CurrentJobLevel = 0; // visszaállítjuk az elért szintünket 0-ra
            OnQuitJobEvent();
        }

        /// <summary>
        /// Gyermekkel való próbálkozás függvénye.
        /// </summary>
        public void tryForChild()
        {
            int childSuccess = rnd.Next(2);
            switch (childSuccess) // 50% eséllyel lehet gyermekünk
            {
                case 0: // ha nem sikerül, akkor csak az ehhez tartozó esemény váltódik ki
                    OnChildFailEvent();
                    break;
                case 1: // ha sikerül, akkor a következők történnek:
                    Gender gender = (Gender)rnd.Next(2); // random nem generálása
                    String name;

                    if (gender == 0) // nemnek megfelelő névválasztás
                        name = femaleNames[rnd.Next(femaleNames.Count)];
                    else
                        name = maleNames[rnd.Next(maleNames.Count)];

                    String firstName;

                    if (You.Gender == Gender.Male) // ha férfi a játékos, akkor az ő vezetéknevét kapja meg, különben a partnerét
                        firstName = You.FirstName;
                    else
                        firstName = You.Partner.FirstName;

                    // kinézet és intelligencia statisztikákat a játékostól és a partnertől kapja meg a gyermek
                    int appearance = calculateStartingStat(You.Appearance, You.Partner.Appearance);
                    int intelligence = calculateStartingStat(You.Intelligence, You.Partner.Intelligence);

                    if (appearance < 0)
                        appearance = 0;
                    if (intelligence < 0)
                        intelligence = 0;

                    if (appearance > 100)
                        appearance = 100;
                    if (intelligence > 100)
                        intelligence = 100;
                    You.ChildOnWay = true;
                    childParentPairs[You.Partner].Add(new Person(firstName, name, 0, gender, 100, intelligence, appearance, 100, rnd.Next(75, 101)));
                    OnChildSuccessEvent();
                    break;
            }
        }

        /// <summary>
        /// Ez a függvény felel azért, hogy a halál után a legidősebb gyermek fölött vehessük át az irányítást.
        /// </summary>
        public void takeControlOfChild()
        {
            You = You.Children[0].changeToPlayer(DefaultJob, DefaultHome, DefaultUniversity, DefaultVehicle); // a játékos karakter szerepét átveszi a gyermek karakter
            You.Age += 1;
            Person otherParent = null;
            String otherParentFName;
            String otherParentLName;
            foreach (KeyValuePair<Person, List<Person>> p in childParentPairs) // megkeresi, hogy él-e még a gyermek másik szülője
            {
                if (p.Value.Count != 0)
                {
                    if (You.FirstName == p.Value[0].FirstName && You.LastName == p.Value[0].LastName)
                    {
                        otherParentFName = p.Key.FirstName;
                        otherParentLName = p.Key.LastName;
                        if (People.Exists(x => x.FirstName == otherParentFName && x.LastName == otherParentLName))
                            otherParent = People.Single(x => x.FirstName == otherParentFName && x.LastName == otherParentLName);
                    }
                }
            }
            People.Clear(); // kiürítjük az emberek listáját
            childParentPairs.Clear(); // ahogy a szülő-gyermek párokat is
            People.Add(You); // hozzáadjuk az új játékos karaktert az emberek listájához
            if (otherParent != null) // ha még él a másik szülő (azaz ha értéke nem null), akkor generálunk neki egy random kapcsolat értéket és hozzáadjuk az emberek listájához
            {
                otherParent.Relationship = rnd.Next(75, 101); 
                People.Add(otherParent);
            }
            breakUp(true); // meghívódik a szakítás függvény, hogy az új játékos karakterünknek ne legyen partnere
            jobRefresh(DefaultJob);
            homeRefresh(DefaultHome);
            uniRefresh(DefaultUniversity);
        }

        /// <summary>
        /// Ez a függvény a vakáció folyamatát foglalja magában.
        /// </summary>
        public void vacation()
        {
            int familyCount;
            if (You.Partner != null) // kiszámolja, hogy vannak-e gyermekeink és párunk, mert ettől fog függni a vakáció költsége
                familyCount = You.Children.Count + 2;
            else
                familyCount = You.Children.Count + 1;

            if (You.Money < 300000 * familyCount) // ha nincs 300000 * családtagokszáma pénzünk, akkor nem tudunk vakációra menni
                OnVacationFailedEvent();
            else // különben a következők történhetnek:
            {
                if (rnd.Next(100) == 50) // repülőgép-szerencsétlenséget szenvedhetünk 1/100 eséllyel
                {
                    You.Health -= 100;
                    OnPlaneCrashEvent();
                    OnDeathEvent(You);
                    return;
                }
                OnVacationSuccessEvent();
                You.Money -= 300000 * familyCount; // ha sikeres a vakáció, akkor levonódik a pénz
                OnMoneyRefreshEvent();
                int randomHappinessGain = rnd.Next(10, 21); // kapunk viszonylag sok boldogságot
                if (You.Happiness + randomHappinessGain <= 100)
                    You.Happiness += randomHappinessGain;
                else
                    You.Happiness = 100;
                OnHappinessRefreshEvent();
            }
        }

        /// <summary>
        /// Ismerőssel való közös program.
        /// </summary>
        /// <param name="index">Az ismerős sorszáma.</param>
        public void programWithAcquaintance(int index)
        {
            People[index].Relationship += rnd.Next(4, 10); // kapunk valamennyi kapcsolatpontot

            if (People[index].Relationship > 100)
            {
                People[index].Relationship = 100;
            }

            OnProgramWithAcquaintanceEvent(People[index], index - 1);
        }

        /// <summary>
        /// Ismerőssel való összeveszés.
        /// </summary>
        public void quarrelWithAcquaintance(Person p)
        {
            p.Relationship -= rnd.Next(6, 12);

            if (p.Relationship < 0)
            {
                p.Relationship = 0;
            }

            int index = People.IndexOf(p);

            OnQuarrelWithAcquaintanceEvent(p);
        }

        /// <summary>
        /// Lottózás függvénye.
        /// </summary>
        public void lottery()
        {
            if (You.Money < 5000) // a lottószelvény 5000 forintba kerül, ha ez nincs meg, akkor nem tudunk lottózni
            {
                OnNoMoneyForLotteryEvent();
                return;
            }
            You.Money -= 5000; // levonódik az 5000 forint a pénzünkből
            int chance = rnd.Next(100);
            if (chance == 42) // a nyerés esélye 1/100, ha sikerül, akkor nyerünk egy random, magas pénzösszeget
            {
                OnLotteryWinEvent();
                You.Money += rnd.Next(2000000, 250000001);
            }
            else // különben nem nyerünk semmit
            {
                OnLotteryLoseEvent();
            }
            OnMoneyRefreshEvent();
        }

        /// <summary>
        /// Katonai misszió végén történő eseményeket szimuláló függvény.
        /// </summary>
        /// <param name="success">Sikeres volt-e a misszió.</param>
        public void endOfMission(bool success)
        {
            if (success) // ha sikeres volt, akkor a következők történnek:
            {
                if (!CompletedAchievements.Contains(4)) // ha még nincs meg az 5. achievement, akkor megkapjuk
                {
                    saveAchievements(4);
                    CompletedAchievements.Add(4);
                    OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(4));
                }
                You.Money += rnd.Next(1000000, 4000001); // kapunk valamennyi pénzt
                You.PromotionMeter += 15; // közelebb kerülünk az előléptetéshez
                if (You.PromotionMeter >= 100) // ha a Promotion Meter eléri a 100-at, akkor megkapjuk az előléptetést
                {
                    You.CurrentJobLevel += 1;
                    You.PromotionMeter = 0;
                    You.Happiness += rnd.Next(2, 5);
                    OnPromotionEvent();
                    OnHappinessRefreshEvent();
                }
                OnMoneyRefreshEvent();
            }
            else // különben:
            {
                if (!CompletedAchievements.Contains(5)) // ha még nincs meg a 6. achievement, akkor megkapjuk
                {
                    saveAchievements(5);
                    CompletedAchievements.Add(5);
                    OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(5));
                }
                You.Health -= rnd.Next(25, 100); // egészségünk csökken
                if (You.Health <= 0) // ha eléri a 0-t, akkor meghalunk
                {
                    if (!CompletedAchievements.Contains(6)) // ha még nincs meg a 7.achievement, akkor megkapjuk
                    {
                        saveAchievements(6);
                        CompletedAchievements.Add(6);
                        OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(6));
                    }
                    People.Remove(You);
                    OnDeathEvent(You);
                    return;
                }
                OnHealthRefreshEvent();
            }
            OnMilitaryMissionCompleteEvent();
        }

        /// <summary>
        /// Barátkozást szimuláló függvény.
        /// </summary>
        public void makeFriend()
        {
            int chance = rnd.Next(2); // 50% esélyünk van összebarátkozni valakivel
            if (chance == 0) // ha nem sikerül, akkor itt visszatér a függvény
            {
                OnMakeFriendFailedEvent();
                return;
            }

            Gender gender = (Gender)rnd.Next(2); // generálunk új barátunknak egy random nemet
            String name;

            // ennek megfelelően kap egy keresztnevet is
            if (gender == 0)
                name = femaleNames[rnd.Next(femaleNames.Count)];
            else
                name = maleNames[rnd.Next(maleNames.Count)];

            Person p = new Person(familyNames[rnd.Next(familyNames.Count)], name, rnd.Next(You.Age - 1, You.Age + 3), gender, rnd.Next(85, 101), rnd.Next(101), rnd.Next(101),
                rnd.Next(25, 101), rnd.Next(85, 101));
            People.Add(p); //hozzáadódik az emberek listájához
            if (People.Count == 10 && !CompletedAchievements.Contains(9)) // ha ismerőseink száma (rajtunk kívül) eléri a 10-et, és nincs meg a 10. achievement, akkor megkapjuk
            {
                saveAchievements(9);
                CompletedAchievements.Add(9);
                OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(9));
            }
            OnMakeFriendSuccessEvent(p, People.Count - 1);
        }

        /// <summary>
        /// Orvos meglátogatását szimuláló függvény.
        /// </summary>
        public void visitDoctor()
        {
            if (You.YourSicknesses.Count == 0) // ha nincs egy betegség sem a betegségeink listájában, akkor az esemény üres stringeket kap paraméterül
            {
                OnDoctorsVisitEvent("", "");
                return;
            }
            String sicknessString = "";
            String sicknessesHealed = "";
            int randomVariable;
            foreach (Sickness s in You.YourSicknesses.ToList()) // végignézzük az összes betegséget a betegségeink listájában
            {
                sicknessString += s.Name + ", ";
                randomVariable = rnd.Next(s.ChanceToHeal);
                if (You.Age < 18 || You.Money >= 500000) // ha még nem töltöttük be a 18-at vagy van elég pénzünk:
                {
                    if (rnd.Next(s.ChanceToHeal) == randomVariable) // ha a két randomszám ugyanaz, akkor az orvos meg tudja gyógyítani a betegséget
                    {
                        sicknessesHealed += s.Name + ", ";
                        You.YourSicknesses.Remove(s); // kikerül a betegségek listájából
                    }
                    if (You.Age >= 18) // ha a játékos betöltötte már a 18-at, akkor a szükséges pénz levonódik tőle
                        You.Money -= 500000;
                }
            }

            // a diagnosztizált és a meggyógyított betegségeket összefűzzük stringekbe, hogy a nézetben könnyen ki lehessen őket írni
            sicknessString = sicknessString.Substring(0, sicknessString.Length - 2);

            if (sicknessesHealed.Length > 0)
                sicknessesHealed = sicknessesHealed.Substring(0, sicknessesHealed.Length - 2);

            OnDoctorsVisitEvent(sicknessString, sicknessesHealed);
            OnMoneyRefreshEvent();
        }


        /// <summary>
        /// Jogosítvány megszerzéséhez tartozó függvény.
        /// </summary>
        public void examTaken(bool success)
        {
            if (success)
            {
                You.HasLicense = true;
            }
            You.Money -= 250000;
            OnMoneyRefreshEvent();
            OnExamCompleteEvent();
        }

        /// <summary>
        /// Achievementek elmentésére szolgáló függvény.
        /// </summary>
        /// <param name="index">Az achievement sorszáma.</param>
        public async void saveAchievements(int index)
        {
            if (dataAccess == null)
                return;

            await dataAccess.AppendToFile("achievements.ach", index);
        }

        /// <summary>
        /// Achievementek betöltésére szolgáló függvény.
        /// </summary>
        /// <returns>Elért achievementek sorszámának listája.</returns>
        public async void loadAchievements()
        {
            if (dataAccess == null)
                return;

            CompletedAchievements = await dataAccess.LoadAchievements("achievements.ach");
        }

        /// <summary>
        /// Játék mentésére szolgáló függvény.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        public async Task saveGame(String path)
        {
            if (dataAccess == null)
                throw new InvalidOperationException("Nincs megadva adatelérés.");

            int count = 0;

            List<String> values = new List<String>();
            values.Add(People.Count.ToString()); // eltároljuk, hogy hány ember szerepel jelenlegi játékunkban
            values.Add(You.FirstName);
            values.Add(You.LastName);
            values.Add(You.Age.ToString());
            values.Add(You.genderToInt().ToString());
            values.Add(You.Health.ToString());
            values.Add(You.Intelligence.ToString());
            values.Add(You.Appearance.ToString());
            values.Add(You.Happiness.ToString());
            values.Add(You.Relationship.ToString());
            values.Add(You.Money.ToString());
            count += 11;
            if (You.Job.JobLevels.ElementAt(0).Key == "Nyugdíjas")
            {
                values.Add((-2).ToString());
                values.Add(You.Job.JobLevels.ElementAt(0).Value.ToString());
                count += 2;
            }
            else
            {
                values.Add(Jobs.IndexOf(You.Job).ToString());
                count++;
            }
            values.Add(Homes.IndexOf(You.Home).ToString());
            values.Add(Universities.IndexOf(You.University).ToString());
            values.Add(You.ChildOnWay.ToString());
            values.Add(You.HasLicense.ToString());
            values.Add(Vehicles.IndexOf(You.Vehicle).ToString());
            values.Add(You.Children.Count().ToString());
            count += 6;
            foreach (Person c in You.Children)
            {
                values.Add(c.FirstName);
                values.Add(c.LastName);
                values.Add(c.Age.ToString());
                values.Add(c.genderToInt().ToString());
                values.Add(c.Health.ToString());
                values.Add(c.Intelligence.ToString());
                values.Add(c.Appearance.ToString());
                values.Add(c.Happiness.ToString());
                values.Add(c.Relationship.ToString());
                count += 9;
            }
            if (You.Partner is null)
            {
                values.Add((0).ToString());
                count++;
            }
            else
            {
                values.Add((1).ToString());
                values.Add(You.Partner.FirstName);
                values.Add(You.Partner.LastName);
                values.Add(You.Partner.Age.ToString());
                values.Add(You.Partner.genderToInt().ToString());
                values.Add(You.Partner.Health.ToString());
                values.Add(You.Partner.Intelligence.ToString());
                values.Add(You.Partner.Appearance.ToString());
                values.Add(You.Partner.Happiness.ToString());
                values.Add(You.Partner.Relationship.ToString());
                count += 10;
            }
            values.Add(You.CurrentJobLevel.ToString());
            values.Add(You.YourSicknesses.Count().ToString());
            count += 2;
            foreach (Sickness s in You.YourSicknesses)
            {
                values.Add(Sicknesses.IndexOf(s).ToString());
                count++;
            }
            values.Add(You.Degrees.Count().ToString());
            count++;
            foreach (University u in You.Degrees)
            {
                values.Add(Universities.IndexOf(u).ToString());
                count++;
            }
            values.Add(You.PromotionMeter.ToString());
            values.Add(You.YearsInUni.ToString());
            count += 2;
            foreach (Person p in People) // eltároljuk minden tulajdonságukat
            {
                if (p != You)
                {
                    values.Add(p.FirstName);
                    values.Add(p.LastName);
                    values.Add(p.Age.ToString());
                    values.Add(p.genderToInt().ToString());
                    values.Add(p.Health.ToString());
                    values.Add(p.Intelligence.ToString());
                    values.Add(p.Appearance.ToString());
                    values.Add(p.Happiness.ToString());
                    values.Add(p.Relationship.ToString());
                    count += 9;
                }
            }
            values.Add(childParentPairs.Count().ToString());
            count++;
            foreach (KeyValuePair<Person, List<Person>> rel in childParentPairs) // végül pedig a gyermek-szülő párokat is tároljuk
            {
                values.Add(rel.Key.FirstName);
                values.Add(rel.Key.LastName);
                values.Add(rel.Key.Age.ToString());
                values.Add(rel.Key.genderToInt().ToString());
                values.Add(rel.Key.Health.ToString());
                values.Add(rel.Key.Intelligence.ToString());
                values.Add(rel.Key.Appearance.ToString());
                values.Add(rel.Key.Happiness.ToString());
                values.Add(rel.Key.Relationship.ToString());
                values.Add(rel.Value.Count().ToString());
                count += 10;
                foreach (Person c in rel.Value)
                {
                    values.Add(c.FirstName);
                    values.Add(c.LastName);
                    values.Add(c.Age.ToString());
                    values.Add(c.genderToInt().ToString());
                    values.Add(c.Health.ToString());
                    values.Add(c.Intelligence.ToString());
                    values.Add(c.Appearance.ToString());
                    values.Add(c.Happiness.ToString());
                    values.Add(c.Relationship.ToString());
                    count += 9;
                }
            }
            values.Insert(0, count.ToString());
            await dataAccess.SaveGame(path, values);
        }

        /// <summary>
        /// Játék betöltésére szolgáló függvény.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        public async Task loadGame(String path)
        {
            if (dataAccess == null)
                throw new InvalidOperationException("Nincs megadva adatelérés.");

            List<String> values = await dataAccess.LoadGame(path);
            People.Clear();
            You.Children.Clear();
            childParentPairs.Clear();
            int hasPension;
            Job job;
            Home home;
            University uni;
            Car vehicle;

            // ha a munka, az otthon, vagy az egyetem helyén -1 szerepel a fájlban, akkor az a Default értékeket jelzi
            if (Int32.Parse(values[11]) == -1)
            {
                job = DefaultJob;
                hasPension = 0;
            }
            else if (Int32.Parse(values[11]) == -2)
            {
                job = new Job(new Dictionary<String, int> { { "Nyugdíjas", Int32.Parse(values[12]) } }, null, 0, Resources.retired);
                hasPension = 1;
            }
            else
            {
                job = Jobs[Int32.Parse(values[11])];
                hasPension = 0;
            }

            if (Int32.Parse(values[12 + hasPension]) == -1)
                home = DefaultHome;
            else
                home = Homes[Int32.Parse(values[12 + hasPension])];

            if (Int32.Parse(values[13 + hasPension]) == -1)
                uni = DefaultUniversity;
            else
                uni = Universities[Int32.Parse(values[13 + hasPension])];

            if (Int32.Parse(values[16 + hasPension]) == -1)
                vehicle = DefaultVehicle;
            else
                vehicle = Vehicles[Int32.Parse(values[16 + hasPension])];

            int currIndex = 0;
            int tmpIndex = 0;

            for (int i = 0; i < Int32.Parse(values[0]); i++) // végigmegyünk a listán, és minden szükséges adattagot feltöltünk
            {
                if (i == 0)
                {
                    You = new Player(values[1], values[2], Int32.Parse(values[3]), (Gender)Int32.Parse(values[4]), Int32.Parse(values[5]), Int32.Parse(values[6]),
                        Int32.Parse(values[7]), Int32.Parse(values[8]), Int32.Parse(values[9]), Int32.Parse(values[10]), job, home, uni, Boolean.Parse(values[14 + hasPension]),
                        Boolean.Parse(values[15 + hasPension]), vehicle);
                    People.Add(You);
                    currIndex = 17 + hasPension;
                    tmpIndex = Int32.Parse(values[currIndex]);
                    for (int j = 0; j < tmpIndex ; j++)
                    {
                        Person pers = new Person(values[++currIndex], values[++currIndex], Int32.Parse(values[++currIndex]), (Gender)Int32.Parse(values[++currIndex]),
                            Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]),
                            Int32.Parse(values[++currIndex]));
                        You.Children.Add(pers);
                        People.Add(pers);
                    }
                    if (Int32.Parse(values[++currIndex]) == 0)
                    {
                        You.Partner = null;
                    }
                    else
                    {
                        You.Partner = new Person(values[++currIndex], values[++currIndex], Int32.Parse(values[++currIndex]), (Gender)Int32.Parse(values[++currIndex]),
                            Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]),
                            Int32.Parse(values[++currIndex]));
                        People.Add(You.Partner);
                    }
                    You.CurrentJobLevel = Int32.Parse(values[++currIndex]);
                    currIndex++;
                    tmpIndex = Int32.Parse(values[currIndex]);
                    for (int j = 0; j < tmpIndex; j++)
                    {
                        You.YourSicknesses.Add(Sicknesses[Int32.Parse(values[++currIndex])]);
                    }
                    currIndex++;
                    tmpIndex = Int32.Parse(values[currIndex]);
                    for (int j = 0; j < tmpIndex; j++)
                    {
                        You.Degrees.Add(Universities[Int32.Parse(values[++currIndex])]);
                    }
                    You.PromotionMeter = Int32.Parse(values[++currIndex]);
                    You.YearsInUni = Int32.Parse(values[++currIndex]);
                }
                else
                {
                    Person pers = new Person(values[++currIndex], values[++currIndex], Int32.Parse(values[++currIndex]), (Gender)Int32.Parse(values[++currIndex]),
                        Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]),
                        Int32.Parse(values[++currIndex]));

                    if (!You.Children.Exists(x => x.FirstName == pers.FirstName && x.LastName == pers.LastName))
                    {
                        if (You.Partner == null || !(You.Partner.FirstName == pers.FirstName && You.Partner.LastName == pers.LastName))
                            People.Add(pers);
                    }
                }
            }
            ++currIndex;
            tmpIndex = Int32.Parse(values[currIndex]);
            for (int i = 0; i < tmpIndex; i++)
            {
                if (You.Partner.FirstName == values[currIndex + 1] && You.Partner.LastName == values[currIndex + 2])
                {
                    childParentPairs.Add(You.Partner, new List<Person>());
                    currIndex += 10;
                }
                else
                {
                    childParentPairs.Add(new Person(values[++currIndex], values[++currIndex], Int32.Parse(values[++currIndex]), (Gender)Int32.Parse(values[++currIndex]),
                    Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]),
                    Int32.Parse(values[++currIndex])), new List<Person>());
                    ++currIndex;
                }
                int tmpIndexChild = Int32.Parse(values[currIndex]);
                for (int j = 0; j < tmpIndexChild; j++)
                {
                    childParentPairs.Last().Value.Add(new Person(values[++currIndex], values[++currIndex], Int32.Parse(values[++currIndex]),
                        (Gender)Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex]),
                        Int32.Parse(values[++currIndex]), Int32.Parse(values[++currIndex])));
                }
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Függvény, ami a kapcsolat esélyét számolja ki.
        /// </summary>
        /// <param name="crush">Potenciális párunk.</param>
        /// <returns>A kapcsolat esélye.</returns>
        private int chanceOfMutualLove(Person crush)
        {
            // a kinézet- és intelligenciabeli különbségeket veszi figyelembe, ez minél inkább a mi javunkra szól, annál nagyobb lesz az esély
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

        /// <summary>
        /// Kezdő statisztika kiszámolása.
        /// </summary>
        /// <param name="stat1">Első érték.</param>
        /// <param name="stat2">Második érték.</param>
        /// <returns>A paraméterekből kiszámolt statisztika.</returns>
        private int calculateStartingStat(int stat1, int stat2)
        {
            return (stat1 + stat2) / 2 + rnd.Next(-10, 11); //a két érték átlaga + egy random szám
        }

        /// <summary>
        /// Egészség kiszámolása.
        /// </summary>
        /// <param name="p">A személy, akinek az egészségét számoljuk.</param>
        /// <returns>Egészségbeli változás mértéke.</returns>
        private int calculateHealth(Person p)
        {
            int min;
            int max;
            
            // a személy boldogságától függően kapunk egy alap min és max értéket
            if (p.Happiness > 80 && p.Happiness <= 100)
            {
                min = -4;
                max = 6;
            }

            else if (p.Happiness > 60 && p.Happiness <= 80)
            {
                min = -6;
                max = 4;
            }

            else if (p.Happiness > 40 && p.Happiness <= 60)
            {
                min = -8;
                max = 2;
            }

            else if (p.Happiness > 20 && p.Happiness <= 40)
            {
                min = -10;
                max = 0;
            }

            else
            {
                min = -12;
                max = -2;
            }

            // ehhez még hozzájön a személy kora is, minél fiatalabb, annál előnyösebb ez az egészségére nézve
            if (p.Age < 18)
            {
                min += 5;
                max += 5;
            }

            else if (p.Age >= 18 && p.Age < 36)
            {
                min += 2;
                max += 2;
            }

            else if (p.Age >= 36 && p.Age < 55)
            {
                min -= 2;
                max -= 2;
            }

            else
            {
                min -= 4;
                max -= 4;
            }

            // végül pedig ha a játékos karaktert nézzük, ő az elkapott betegségei függvényében is veszíthet ezekből az értékekből
            if (p == You)
            {
                foreach (Sickness s in You.YourSicknesses)
                {
                    min -= s.ApproximateEffectOnHealth + rnd.Next(-3, 4);
                    max -= s.ApproximateEffectOnHealth + rnd.Next(-3, 4);
                }
            }

            // ha véletlenül a minimum nagyobb lenne, mint a maximum, akkor a minimumot a maximumnál 1-gyel kisebb értékre állítja
            if (min >= max)
            {
                min = max - 1;
            }

            return rnd.Next(min, max); // min és max közötti random számot térít vissza
        }

        /// <summary>
        /// Boldogság kiszámolása.
        /// </summary>
        /// <param name="p">A személy, akinek a boldogságát számoljuk.</param>
        /// <returns>Boldogságbeli változás mértéke.</returns>
        private int calculateHappiness(Person p)
        {
            int min = -4;
            int max = 6;

            // ha nem a játékos karaktert nézzük, akkor egyszerűen csak egy random generált szám lesz a változás mértéke
            if (p != You)
            {
                if (p.Age < 18)
                    return rnd.Next(min, max);
                else
                    return rnd.Next(-6, 3);
            }

            int averageRelationship = 0;
            int count = People.Count();

            // összeadja, hogy a játékos milyen kapcsolatot ápol ismerőseivel (ez alapból 0-ra van állítva, ha nincs ismerős, akkor marad is ennyi)
            foreach (Person other in People)
            {
                averageRelationship += other.Relationship;
            }

            // ha van legalább egy ismerőse a játékosnak, akkor az előbb kapott értéket elosztja az ismerősök számával
            if (count > 0)
                averageRelationship /= count;

            // ennek az értéknek a függvényében számolódik ki a boldogságbeli változás mértéke (minél nagyobb az átlag kapcsolat pont, annál több boldogságot kaphat a játékos)
            if (averageRelationship > 80 && averageRelationship <= 100)
            {
                min = 1;
                max = 10;
            }

            else if (averageRelationship > 60 && averageRelationship <= 80)
            {
                min = -2;
                max = 7;
            }

            else if (averageRelationship > 40 && averageRelationship <= 60)
            {
                min = -5;
                max = 4;
            }

            else if (averageRelationship > 20 && averageRelationship <= 40)
            {
                min = -8;
                max = 1;
            }

            else
            {
                min = -11;
                max = -2;
            }

            if (p.Age < 18)
            {
                min += 2;
                max += 2;
            }

            // a lakás és az autónk után is kapunk némi boldogságot
            max += rnd.Next(You.Home.HappinessGain) + rnd.Next(You.Vehicle.HappinessGain);

            if (min >= max)
            {
                min = max - 1;
            }

            return rnd.Next(min, max);
        }

        /// <summary>
        /// Véletlenszerű betegség elkapása.
        /// </summary>
        private void randomSickness()
        {
            // ha elkapunk egy betegséget, akkor csökken az egészségünk (a maradandóaknál egészen addig, amíg az orvos nem gyógyítja őket, ezért egy listában tároljuk őket)
            // ha a játékos karakter egészsége eléri a 0-t, akkor természetesen meghal
            if (rnd.Next(15) == 4) // megfázás (1/15 esély, nem maradandó)
            {
                You.Health -= Sicknesses[0].ApproximateEffectOnHealth + rnd.Next(-4, 5);
                OnCaughtSicknessEvent(Sicknesses[0]);
                OnHealthRefreshEvent();
                if (You.Health < 0)
                    OnDeathEvent(You);
                return;
            }

            if (rnd.Next(400) == 60 && !You.YourSicknesses.Contains(Sicknesses[1])) // rák (1/400 esély, maradandó)
            {
                You.Health -= Sicknesses[1].ApproximateEffectOnHealth + rnd.Next(-4, 5);
                OnCaughtSicknessEvent(Sicknesses[1]);
                OnHealthRefreshEvent();
                You.YourSicknesses.Add(Sicknesses[1]);
                if (You.YourSicknesses.Count >= 2 && !CompletedAchievements.Contains(1)) // ha ezzel együtt 2 betegségünk is van, és még nincs meg a 2. achievement, akkor megkapjuk
                {
                    CompletedAchievements.Add(1);
                    saveAchievements(1);
                    OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(1));
                }
                if (You.Health < 0)
                    OnDeathEvent(You);
                return;
            }

            if (rnd.Next(100) == 10 && !You.YourSicknesses.Contains(Sicknesses[2])) // magas vérnyomás (1/100 esély, maradandó)
            {
                You.Health -= Sicknesses[2].ApproximateEffectOnHealth + rnd.Next(-4, 5);
                OnCaughtSicknessEvent(Sicknesses[2]);
                OnHealthRefreshEvent();
                You.YourSicknesses.Add(Sicknesses[2]);
                if (You.YourSicknesses.Count >= 2 && !CompletedAchievements.Contains(1)) // ha ezzel együtt 2 betegségünk is van, és még nincs meg a 2. achievement, akkor megkapjuk
                {
                    CompletedAchievements.Add(1);
                    saveAchievements(1);
                    OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(1));
                }
                if (You.Health < 0)
                    OnDeathEvent(You);
                return;
            }

            if (rnd.Next(90) == 12 && !You.YourSicknesses.Contains(Sicknesses[3])) // COVID-19 (1/90 esély, maradandó)
            {
                You.Health -= Sicknesses[3].ApproximateEffectOnHealth + rnd.Next(-4, 5);
                OnCaughtSicknessEvent(Sicknesses[3]);
                OnHealthRefreshEvent();
                You.YourSicknesses.Add(Sicknesses[3]);
                if (You.YourSicknesses.Count >= 2 && !CompletedAchievements.Contains(1)) // ha ezzel együtt 2 betegségünk is van, és még nincs meg a 2. achievement, akkor megkapjuk
                {
                    CompletedAchievements.Add(1);
                    saveAchievements(1);
                    OnAchievementUnlockedEvent(Achievements.Keys.ElementAt(1));
                }
                if (You.Health < 0)
                    OnDeathEvent(You);
                return;
            }
        }

        #endregion

        #region Private event methods

        /// <summary>
        /// Halál eseményének kiváltása.
        /// </summary>
        /// <param name="p">A halott személy.</param>
        private void OnDeathEvent(Person p)
        {
            DeathEvent?.Invoke(this, new LifeSimEventArgs(p));
        }

        /// <summary>
        /// Munkaváltozás eseményének kiváltása.
        /// </summary>
        private void OnJobChangedEvent()
        {
            JobChangedEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Lakásváltozás eseményének kiváltása.
        /// </summary>
        private void OnHomeChangedEvent()
        {
            HomeChangedEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Járműváltozás eseményének kiváltása.
        /// </summary>
        private void OnVehicleChangedEvent()
        {
            VehicleChangedEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Egyetemváltozás eseményének kiváltása magas intelligenciával.
        /// </summary>
        private void OnSmartUniChangedEvent()
        {
            SmartUniChangedEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Egyetemváltozás eseményének kiváltása alacsony intelligenciával.
        /// </summary>
        /// <param name="CostOfUni">Az egyetem költsége.</param>
        private void OnDumbUniChangedEvent(int CostOfUni)
        {
            DumbUniChangedEvent?.Invoke(this, new LifeSimEventArgs(CostOfUni));
        }

        /// <summary>
        /// Egyetem elvégzés eseményének kiváltása magas intelligenciával.
        /// </summary>
        private void OnSmartGraduateEvent()
        {
            SmartGraduateEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Egyetem elvégzés eseményének kiváltása alacsony intelligenciával.
        /// </summary>
        /// <param name="CostPerYear">Évente visszafizetendő összeg.</param>
        /// <param name="YearsToPayBack">Hány évig tart visszafizetni.</param>
        private void OnDumbGraduateEvent(int CostPerYear, int YearsToPayBack)
        {
            DumbGraduateEvent?.Invoke(this, new LifeSimEventArgs(CostPerYear, YearsToPayBack));
        }

        /// <summary>
        /// Egészség változás eseményének kiváltása.
        /// </summary>
        private void OnHealthRefreshEvent()
        {
            HealthRefreshEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Intelligencia változás eseményének kiváltása.
        /// </summary>
        private void OnIntelligenceRefreshEvent()
        {
            IntelligenceRefreshEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Boldogság változás eseményének kiváltása.
        /// </summary>
        private void OnHappinessRefreshEvent()
        {
            HappinessRefreshEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Kinézet változás eseményének kiváltása.
        /// </summary>
        private void OnAppearanceRefreshEvent()
        {
            AppearanceRefreshEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Pénz változás eseményének kiváltása.
        /// </summary>
        private void OnMoneyRefreshEvent()
        {
            MoneyRefreshEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Kapcsolat sikertelenség eseményének kiváltása.
        /// </summary>
        private void OnRelationshipFailEvent()
        {
            RelationshipFailEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Kapcsolat sikeresség eseményének kiváltása.
        /// </summary>
        private void OnRelationshipSuccessEvent()
        {
            RelationshipSuccessEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Különválás eseményének kiváltása.
        /// </summary>
        /// <param name="death">Halál miatt történt-e a szétválás.</param>
        private void OnBreakUpEvent(bool death)
        {
            BreakUpEvent?.Invoke(this, new LifeSimEventArgs(death));
        }

        /// <summary>
        /// Gyermekkel való próbálkozás sikertelenségéhez tartozó esemény kiváltása.
        /// </summary>
        private void OnChildFailEvent()
        {
            ChildFailEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Gyermekkel való próbálkozás sikerességéhez tartozó esemény kiváltása.
        /// </summary>
        private void OnChildSuccessEvent()
        {
            ChildSuccessEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Gyermekkel megszületéséhez tartozó esemény kiváltása.
        /// </summary>
        private void OnChildBornEvent()
        {
            ChildBornEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Munkából való kilépés eseményének kiváltása.
        /// </summary>
        private void OnQuitJobEvent()
        {
            QuitJobEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Előléptetés eseményének kiváltása.
        /// </summary>
        private void OnPromotionEvent()
        {
            PromotionEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Nyugdíjba vonulás eseményének kiváltása.
        /// </summary>
        private void OnRetirementEvent()
        {
            RetirementEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Vakáció sikertelenségéhez tartozó esemény kiváltása.
        /// </summary>
        private void OnVacationFailedEvent()
        {
            VacationFailedEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Vakáció sikerességéhez tartozó esemény kiváltása.
        /// </summary>
        private void OnVacationSuccessEvent()
        {
            VacationSuccessEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Edzés sikerességéhez tartozó esemény kiváltása.
        /// </summary>
        private void OnWorkOutSuccessEvent()
        {
            WorkOutSuccessEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Edzés sikertelenségéhez tartozó esemény kiváltása.
        /// </summary>
        private void OnWorkOutFailedEvent()
        {
            WorkOutFailedEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Olvasás sikerességéhez tartozó esemény kiváltása.
        /// </summary>
        private void OnReadSuccessEvent()
        {
            ReadSuccessEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Olvasás sikertelenségéhez tartozó esemény kiváltása.
        /// </summary>
        private void OnReadFailedEvent()
        {
            ReadFailedEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Közös program eseményének kiváltása.
        /// </summary>
        /// <param name="p">A személy, akivel a közös programot folytattuk.</param>
        /// <param name="persind">A személy sorszáma a nézetben.</param>
        private void OnProgramWithAcquaintanceEvent(Person p, int persind)
        {
            ProgramWithAcquaintanceEvent?.Invoke(this, new LifeSimEventArgs(p, persind));
        }

        /// <summary>
        /// Összeveszés eseményének kiváltása.
        /// </summary>
        /// <param name="p">A személy, akivel összeveszünk.</param>
        /// <param name="persind">A személy sorszáma a nézetben.</param>
        private void OnQuarrelWithAcquaintanceEvent(Person p)
        {
            QuarrelWithAcquaintanceEvent?.Invoke(this, new LifeSimEventArgs(p));
        }

        /// <summary>
        /// Esemény, ami akkor váltódik ki, ha nincs pénz lottószelvényre.
        /// </summary>
        private void OnNoMoneyForLotteryEvent()
        {
            NoMoneyForLotteryEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Lottónyerés eseményének kiváltása.
        /// </summary>
        private void OnLotteryWinEvent()
        {
            LotteryWinEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Lottóvesztés eseményének kiváltása.
        /// </summary>
        private void OnLotteryLoseEvent()
        {
            LotteryLoseEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Katonai küldetés eseményének kiváltása.
        /// </summary>
        private void OnMilitaryMissionEvent()
        {
            MilitaryMissionEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Barátkozás sikertelenségéhez tartozó esemény kiváltása.
        /// </summary>
        private void OnMakeFriendFailedEvent()
        {
            MakeFriendFailedEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Barátkozás sikerességéhez tartozó esemény kiváltása.
        /// </summary>
        /// <param name="p">A személy, akivel összebarátkoztunk.</param>
        /// <param name="persind">A személy sorszáma a nézetben.</param>
        private void OnMakeFriendSuccessEvent(Person p, int persind)
        {
            MakeFriendSuccessEvent?.Invoke(this, new LifeSimEventArgs(p, persind));
        }

        /// <summary>
        /// Katonai küldetés teljesítéséhez tartozó esemény kiváltása.
        /// </summary>
        private void OnMilitaryMissionCompleteEvent()
        {
            MilitaryMissionCompleteEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Repülőgép-szerencsétlenség eseményének kiváltása.
        /// </summary>
        private void OnPlaneCrashEvent()
        {
            PlaneCrashEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Karambol eseményének kiváltása.
        /// </summary>
        private void OnCarCrashEvent()
        {
            CarCrashEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Betegség elkapásához tartozó esemény kiváltása.
        /// </summary>
        private void OnCaughtSicknessEvent(Sickness Sickness)
        {
            CaughtSicknessEvent?.Invoke(this, new LifeSimEventArgs(Sickness));
        }

        /// <summary>
        /// Orvos meglátogatásához tartozó esemény kiváltása.
        /// </summary>
        private void OnDoctorsVisitEvent(String Sicknesses, String SicknessesHealed)
        {
            DoctorsVisitEvent?.Invoke(this, new LifeSimEventArgs(Sicknesses, SicknessesHealed));
        }

        /// <summary>
        /// Achievement teljesítéséhez tartozó esemény kiváltása.
        /// </summary>
        private void OnAchievementUnlockedEvent(String achName)
        {
            AchievementUnlockedEvent?.Invoke(this, new LifeSimEventArgs(achName));
        }

        /// <summary>
        /// Jogosítvány vizsga befejezéséhez tartozó esemény kiváltása.
        /// </summary>
        private void OnExamCompleteEvent()
        {
            ExamCompleteEvent?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}
