using System;

namespace LifeSim.Model
{
    public class Job
    {

        public String Name { get; set; }

        public int Salary { get; set; }

        public University DegreeNeeded { get; set; }

        public Job(String Name, int Salary, University DegreeNeeded)
        {
            this.Name = Name;
            this.Salary = Salary;
            this.DegreeNeeded = DegreeNeeded;
        }
    }
}
