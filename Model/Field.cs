using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Model
{
    public class Field
    {
        public bool Revealed { get; set; }

        public bool Mine { get; }

        public int MinesInProximity { get; }

        public Field(bool Revealed, bool Mine, int MinesInProximity)
        {
            this.Revealed = Revealed;
            this.Mine = Mine;
            this.MinesInProximity = MinesInProximity;
        }
    }
}
