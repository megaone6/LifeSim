using System;

namespace LifeSim.Model
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
        /// Home osztály példányosítása.
        /// </summary>
        /// <param name="isWon">Típus</param>
        /// <param name="gameStepCount">Ár</param>
        /// <param name="gameTime">Éves költségek</param>
        public Home(String Type, int Price, int YearlyExpenses)
        {
            this.Type = Type;
            this.Price = Price;
            this.YearlyExpenses = YearlyExpenses;
        }
    }
}
