using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LifeSim.LSModel
{
    /// <summary>
    /// Járműveket reprezentáló osztály.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Jármű típusa.
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// Jármű ára.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Jármű éves költségei.
        /// </summary>
        public int YearlyExpenses { get; set; }

        /// <summary>
        /// A járműhöz tartozó kép.
        /// </summary>
        public Bitmap Image { get; set; }

        /// <summary>
        /// A lakáshoz tartozó boldogság érték.
        /// </summary>
        public int HappinessGain { get; set; }

        /// <summary>
        /// Car osztály példányosítása.
        /// </summary>
        /// <param name="Type">Típus</param>
        /// <param name="Price">Ár</param>
        /// <param name="YearlyExpenses">Éves költségek</param>
        /// <param name="Image">Lakás képe</param>
        /// <param name="HappinessGain">Lakás boldogság értéke</param>
        public Car(String Type, int Price, int YearlyExpenses, Bitmap Image, int HappinessGain)
        {
            this.Type = Type;
            this.Price = Price;
            this.YearlyExpenses = YearlyExpenses;
            this.Image = Image;
            this.HappinessGain = HappinessGain;
        }
    }
}
