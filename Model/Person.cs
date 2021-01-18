using System;

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

        public bool IsDead { get; set; }

        public Person(String FirstName, String LastName, int Age, Gender Gender, int Health, int Intelligence, int Appearance)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Gender = Gender;
            this.Health = Health;
            this.Intelligence = Intelligence;
            this.Appearance = Appearance;
            IsDead = false;
        }
    }
}
