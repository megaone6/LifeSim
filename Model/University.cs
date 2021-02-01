using System;

namespace LifeSim.Model
{
    public class University
    {
        public String Type { get; set; }

        public int YearsToFinish { get; set; }

        public University(String Type, int YearsToFinish)
        {
            this.Type = Type;
            this.YearsToFinish = YearsToFinish;
        }
    }
}
