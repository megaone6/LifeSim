using System;
using System.Collections.Generic;

namespace LifeSim.Model
{
    public class Player : Person
    {
        public Job Job { get; set; }

        public University University { get; set; }

        public Home Home { get; set; }

        public List<Person> Children { get; set; }

        public Person Partner { get; set; }

        public int CurrentJobLevel { get; set; }

        public List<Sickness> YourSicknesses { get; set; }

        public int Money { get; set; }

        public List<University> Degrees { get; set; }

        public int PromotionMeter { get; set; }

        public int YearsInUni { get; set; }

        public Player(String FirstName, String LastName, int Age, Gender Gender, int Health, int Intelligence, int Appearance, int Happiness, int Relationship, int Money, Job Job, Home Home, University University): base(FirstName, LastName, Age, Gender, Health, Intelligence, Appearance, Happiness, Relationship)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Gender = Gender;
            this.Health = Health;
            this.Intelligence = Intelligence;
            this.Appearance = Appearance;
            this.Happiness = Happiness;
            this.Relationship = Relationship;
            this.Money = Money;
            this.Job = Job;
            this.Home = Home;
            this.University = University;
            Children = new List<Person>();
            Partner = null;
            CurrentJobLevel = 0;
            YourSicknesses = new List<Sickness>();
            Degrees = new List<University>();
            PromotionMeter = 0;
            YearsInUni = 0;
        }
    }
}
