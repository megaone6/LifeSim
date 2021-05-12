using System;
using System.Collections.Generic;

namespace LifeSim.LSModel
{
    /// <summary>
    /// Személyt reprezentáló osztály.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Vezetéknév.
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// Keresztnév.
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// Kor.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Nem.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Egészség.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Intelligencia.
        /// </summary>
        public int Intelligence { get; set; }

        /// <summary>
        /// Kinézet.
        /// </summary>
        public int Appearance { get; set; }

        /// <summary>
        /// Boldogság.
        /// </summary>
        public int Happiness { get; set; }

        /// <summary>
        /// Kapcsolat.
        /// </summary>
        public int Relationship { get; set; }

        /// <summary>
        /// Person osztály példányosítása.
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
        public Person(String FirstName, String LastName, int Age, Gender Gender, int Health, int Intelligence, int Appearance, int Happiness, int Relationship)
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
        }

        /// <summary>
        /// Függvény, amely egy Person-t alakít át Player-ré. (irányítás átvétele funkcióhoz)
        /// </summary>
        /// <param name="Job">Munka.</param>
        /// <param name="Home">Lakás.</param>
        /// <param name="University">Egyetem.</param>
        public Player changeToPlayer(Job Job, Home Home, University University, Car Vehicle)
        {
            Player player = new Player(FirstName, LastName, Age, Gender, Health, Intelligence, Appearance, Happiness, Relationship, 0, Job, Home, University, Vehicle);
            player.Children = new List<Person>();
            player.Partner = null;
            player.CurrentJobLevel = 0;
            player.YourSicknesses = new List<Sickness>();
            player.Degrees = new List<University>();
            player.PromotionMeter = 0;
            return player;
        }

        /// <summary>
        /// Átkonvertálja a Gender-t int-té.
        /// </summary>
        /// <returns>A Gender értéke int-ben.</returns>
        public int genderToInt()
        {
            return (int)Gender;
        }
    }
}
