using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Model
{
    public class Player : Person
    {
        public Job Job { get; set; }

        public University University { get; set; }

        public Home Home { get; set; }

        public List<Person> Children { get; private set; }

        public Person Partner { get; set; }

        public int CurrentJobLevel { get; set; }

        public Player(String FirstName, String LastName, int Age, Gender Gender, int Health, int Intelligence, int Appearance, Job Job, Home Home, University University): base(FirstName, LastName, Age, Gender, Health, Intelligence, Appearance)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Gender = Gender;
            this.Health = Health;
            this.Intelligence = Intelligence;
            this.Appearance = Appearance;
            this.Money = 0;
            this.Job = Job;
            this.Home = Home;
            this.University = University;
            Children = new List<Person>();
            Partner = null;
            CurrentJobLevel = 0;
        }
    }
}
