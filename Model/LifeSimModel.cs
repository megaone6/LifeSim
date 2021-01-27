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
        private String yourName;
        private bool maleOrFemale;

        #endregion

        #region Properties

        public Person You { get; set; }

        public List<Person> Parents { get; private set; }

        public List<Job> Jobs { get; private set; }

        public Job Job { get; set; }

        #endregion

        #region Events

        public event EventHandler<LifeSimEventArgs> DeathEvent;

        public event EventHandler<EventArgs> JobChangedEvent;

        #endregion

        #region Constructor

        public LifeSimModel()
        {
            rnd = new Random();
            Jobs = new List<Job>() { new Job("Pályakezdő programozó", 3180000), new Job("Járőr", 2040000), new Job("Fogorvos", 3780000) };
            yourName = "";
        }

        public LifeSimModel(String yourName, bool maleOrFemale)
        {
            rnd = new Random();
            Jobs = new List<Job>() { new Job("Pályakezdő programozó", 3180000), new Job("Járőr", 2040000), new Job("Fogorvos", 3780000) };
            this.yourName = yourName;
            this.maleOrFemale = maleOrFemale;
        }

        #endregion

        #region Public game methods

        public void newGame()
        {
            String[] maleNames = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/NamesMale.name");
            String[] femaleNames = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/NamesFemale.name");
            String[] familyNames = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/FamilyNames.name");
            String familyName;
            String name;
            Gender gender;
            if (yourName == "")
            {
                familyName = familyNames[rnd.Next(familyNames.Length)];
                gender = (Gender)rnd.Next(2);
                if (gender == 0)
                    name = maleNames[rnd.Next(maleNames.Length)];
                else
                    name = femaleNames[rnd.Next(femaleNames.Length)];
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
            Parents = new List<Person>() { new Person(familyName, maleNames[rnd.Next(maleNames.Length)], rnd.Next(18,55), Gender.Male, rnd.Next(1,101), rnd.Next(101), rnd.Next(101)),
                                            new Person(familyNames[rnd.Next(familyNames.Length)], femaleNames[rnd.Next(femaleNames.Length)], rnd.Next(18,55), Gender.Female, rnd.Next(1,101), rnd.Next(101), rnd.Next(101))};
            int randomAppearance;
            int randomIntelligence;
            int parentIntAvg = (Parents[0].Intelligence + Parents[1].Intelligence) / 2;
            int parentAppAvg = (Parents[0].Appearance + Parents[1].Appearance) / 2;

            do
            {
                randomAppearance = rnd.Next(-10, 11);
                randomIntelligence = rnd.Next(-10, 11);
            } while (parentIntAvg + randomIntelligence < 0 && parentIntAvg + randomIntelligence > 100 && parentAppAvg + randomAppearance < 0 && parentAppAvg + randomAppearance > 100);



            You = new Person(familyName, name, 0, gender, 100, parentIntAvg + randomIntelligence, parentAppAvg + randomAppearance);
            Job = new Job("Munkanélküli", 0);
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
            You.Money += Job.Salary;
        }

        public void jobRefresh()
        {
            OnJobChangedEvent();
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

        #endregion
    }
}
