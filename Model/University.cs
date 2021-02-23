using System;

namespace LifeSim.Model
{
    public class University
    {
        public String Type { get; set; }

        public int YearsToFinish { get; set; }

        public int CostPerSemester { get; set; }

        public University(String Type, int YearsToFinish, int CostPerSemester)
        {
            this.Type = Type;
            this.YearsToFinish = YearsToFinish;
            this.CostPerSemester = CostPerSemester;
        }
    }
}
