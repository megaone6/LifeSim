namespace LifeSim.Model
{
    /// <summary>
    /// Az aknamező elemeit reprezentáló osztály.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Az adott mező fel van-e fedve.
        /// </summary>
        public bool Revealed { get; set; }

        /// <summary>
        /// Az adott mező tartalmaz-e aknát.
        /// </summary>
        public bool Mine { get; }

        /// <summary>
        /// Hány akna található az adott mező mellett.
        /// </summary>
        public int MinesInProximity { get; }

        /// <summary>
        /// Megjelöltük-e az adott mezőt.
        /// </summary>
        public bool Marked { get; set; }

        /// <summary>
        /// Field osztály példányosítása.
        /// </summary>
        /// /// <param name="Revealed">Fel van-e fedve a mező.</param>
        /// <param name="Mine">Akna-e az adott mező.</param>
        /// <param name="MinesInProximity">Adott mező melletti aknák száma.</param>
        /// <param name="Marked">Meg van-e jelölve a mező.</param>
        public Field(bool Revealed, bool Mine, int MinesInProximity, bool Marked)
        {
            this.Revealed = Revealed;
            this.Mine = Mine;
            this.MinesInProximity = MinesInProximity;
            this.Marked = Marked;
        }
    }
}
