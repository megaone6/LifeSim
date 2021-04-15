using System;
using System.Drawing;

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
        /// A lakáshoz tartozó kép.
        /// </summary>
        public Bitmap Image { get; set; }

        /// <summary>
        /// Home osztály példányosítása.
        /// </summary>
        /// <param name="Type">Típus</param>
        /// <param name="Price">Ár</param>
        /// <param name="YearlyExpenses">Éves költségek</param>
        /// <param name="Image">Lakás képe</param>
        public Home(String Type, int Price, int YearlyExpenses, Bitmap Image)
        {
            this.Type = Type;
            this.Price = Price;
            this.YearlyExpenses = YearlyExpenses;
            this.Image = Image;
        }
    }
}
