using System;
using System.Collections.Generic;

namespace LifeSim.Model
{
    public class Job
    {

        public String Name { get; set; }

        public int Salary { get; set; }

        public Dictionary<String,int> JobLevels { get; set; }

        public University DegreeNeeded { get; set; }

        public int MaxJobLevel { get; set; }

        public Job(Dictionary<String,int> JobLevels, University DegreeNeeded, int MaxJobLevel)
        {
            this.JobLevels = JobLevels;
            this.DegreeNeeded = DegreeNeeded;
            this.MaxJobLevel = MaxJobLevel;
        }
    }
}
