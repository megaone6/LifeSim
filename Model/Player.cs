using System;
using System.Collections.Generic;

namespace LifeSim.Model
{
    /// <summary>
    /// Játékost reprezentáló osztály. A Person leszármazottja.
    /// </summary>
    public class Player : Person
    {
        /// <summary>
        /// Játékos munkája.
        /// </summary>
        public Job Job { get; set; }

        /// <summary>
        /// Játékos jelenlegi egyeteme.
        /// </summary>
        public University University { get; set; }

        /// <summary>
        /// Játékos lakása.
        /// </summary>
        public Home Home { get; set; }

        /// <summary>
        /// Játékos gyermekeinek listája.
        /// </summary>
        public List<Person> Children { get; set; }

        /// <summary>
        /// Játékos párja.
        /// </summary>
        public Person Partner { get; set; }

        /// <summary>
        /// Játékos jelenlegi szintje a munkába.
        /// </summary>
        public int CurrentJobLevel { get; set; }

        /// <summary>
        /// Játékos betegségeinek listája.
        /// </summary>
        public List<Sickness> YourSicknesses { get; set; }

        /// <summary>
        /// Játékos pénze.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// Játékos elvégzett egyetemeinek listája.
        /// </summary>
        public List<University> Degrees { get; set; }

        /// <summary>
        /// Játékos előléptetési szintje.
        /// </summary>
        public int PromotionMeter { get; set; }

        /// <summary>
        /// Játékos jelenlegi egyetemen eltöltött évei.
        /// </summary>
        public int YearsInUni { get; set; }

        /// <summary>
        /// Player osztály példányosítása.
        /// </summary>
        /// <param name="FirstName">Vezetéknév.</param>
        /// <param name="LastName">Keresztnév.</param>
        /// <param name="Age">Kor.</param>
        /// <param name="Gender">Nem.</param>
        /// <param name="Health">Egészség.</param>
        /// <param name="Intelligence">Intelligencia.</param>
        /// <param name="Appearance">Kinézet.</param>
        /// <param name="Happiness">Boldogság.</param>
        /// <param name="Relationship">Kapcsolat.</param>
        /// <param name="Money">Pénz.</param>
        /// <param name="Job">Munka.</param>
        /// <param name="Home">Lakás.</param>
        /// <param name="University">Egyetem.</param>
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
