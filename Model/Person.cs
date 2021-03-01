using System;
using System.Collections.Generic;

namespace LifeSim.Model
{
    public class Person
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int Health { get; set; }

        public int Intelligence { get; set; }

        public int Appearance { get; set; }

        public int Happiness { get; set; }

        public int Money { get; set; }

        public Person(String FirstName, String LastName, int Age, Gender Gender, int Health, int Intelligence, int Appearance, int Happiness)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Gender = Gender;
            this.Health = Health;
            this.Intelligence = Intelligence;
            this.Appearance = Appearance;
            this.Happiness = Happiness;
            Money = 0;
        }

        public Player changeToPlayer(Job Job, Home Home, University University)
        {
            Player player = new Player(FirstName, LastName, Age, Gender, Health, Intelligence, Appearance, Happiness, Job, Home, University);
            player.Children = new List<Person>();
            player.Partner = null;
            player.CurrentJobLevel = 0;
            return player;
        }
    }
}
