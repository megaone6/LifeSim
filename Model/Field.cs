namespace LifeSim.Model
{
    public class Field
    {
        public bool Revealed { get; set; }

        public bool Mine { get; }

        public int MinesInProximity { get; }

        public bool Marked { get; set; }

        public Field(bool Revealed, bool Mine, int MinesInProximity, bool Marked)
        {
            this.Revealed = Revealed;
            this.Mine = Mine;
            this.MinesInProximity = MinesInProximity;
            this.Marked = Marked;
        }
    }
}
