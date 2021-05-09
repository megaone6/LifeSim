using System;

namespace LifeSim.LSModel
{
    /// <summary>
    /// Egyetemet reprezentáló osztály.
    /// </summary>
    public class University
    {
        /// <summary>
        /// Egyetem típusa.
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// Hány évig tart elvégezni az egyetemet.
        /// </summary>
        public int YearsToFinish { get; set; }

        /// <summary>
        /// Mekkora a költsége egy félévre az egyetemnek.
        /// </summary>
        public int CostPerSemester { get; set; }

        /// <summary>
        /// University osztály példányosítása.
        /// </summary>
        /// <param name="Type">Típus.</param>
        /// <param name="YearsToFinish">Elvégzéshez szükséges évek.</param>
        /// <param name="CostPerSemester">Féléves költség.</param>
        public University(String Type, int YearsToFinish, int CostPerSemester)
        {
            this.Type = Type;
            this.YearsToFinish = YearsToFinish;
            this.CostPerSemester = CostPerSemester;
        }
    }
}
