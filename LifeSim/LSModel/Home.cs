using System;
using System.Drawing;

namespace LifeSim.LSModel
{
    /// <summary>
    /// Lakásokat reprezentáló osztály.
    /// </summary>
    public class Home
    {
        /// <summary>
        /// Lakás típusa.
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// Lakás ára.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Lakás éves költségei.
        /// </summary>
        public int YearlyExpenses { get; set; }

        /// <summary>
        /// A lakáshoz tartozó kép.
        /// </summary>
        public Bitmap Image { get; set; }

        /// <summary>
        /// A lakáshoz tartozó boldogság érték.
        /// </summary>
        public int HappinessGain { get; set; }

        /// <summary>
        /// Home osztály példányosítása.
        /// </summary>
        /// <param name="Type">Típus</param>
        /// <param name="Price">Ár</param>
        /// <param name="YearlyExpenses">Éves költségek</param>
        /// <param name="Image">Lakás képe</param>
        /// <param name="HappinessGain">Lakás boldogság értéke</param>
        public Home(String Type, int Price, int YearlyExpenses, Bitmap Image, int HappinessGain)
        {
            this.Type = Type;
            this.Price = Price;
            this.YearlyExpenses = YearlyExpenses;
            this.Image = Image;
            this.HappinessGain = HappinessGain;
        }
    }
}
