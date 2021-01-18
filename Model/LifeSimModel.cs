using System;
using System.Collections.Generic;
using System.IO;

namespace LifeSim.Model
{
    public enum Gender { Male, Female }
    class LifeSimModel
    {
        #region Fields

        private Random rnd;

        #endregion

        #region Properties

        public Person You { get; set; }

        public List<Person> Parents { get; private set; }

        #endregion

        #region Events

        public event EventHandler<LifeSimEventArgs> DeathEvent;

        #endregion

        #region Constructor

        public LifeSimModel()
        {
            rnd = new Random();
        }

        #endregion

        #region Public game methods

        public void newGame()
        {
            String[] familyNames = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/FamilyNames.name");
            String[] maleNames = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/NamesMale.name");
            String[] femaleNames = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/NamesFemale.name");
            String familyName = familyNames[rnd.Next(familyNames.Length)];
            String name;
            Gender gender = (Gender)rnd.Next(2);
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

            if (gender == 0)
                name = maleNames[rnd.Next(maleNames.Length)];
            else
                name = femaleNames[rnd.Next(femaleNames.Length)];

            You = new Person(familyName, name, 0, gender, 100, parentIntAvg + randomIntelligence, parentAppAvg + randomAppearance);
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

        }
        #endregion

        #region Private event methods

        private void OnDeathEvent()
        {
            DeathEvent?.Invoke(this, new LifeSimEventArgs(You.Age));
        }

        #endregion
    }
}
