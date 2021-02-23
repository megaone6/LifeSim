using System;

namespace LifeSim.Model
{
    public class LifeSimEventArgs
    {
        public Person Person { get; }

        public bool Death { get; }

        public int UniversityCost { get; }

        public int YearsToPayBack { get; }

        public LifeSimEventArgs(Person Person)
        {
            this.Person = Person;
        }

        public LifeSimEventArgs(bool Death)
        {
            this.Death = Death;
        }

        public LifeSimEventArgs(int UniversityCost)
        {
            this.UniversityCost = UniversityCost;
        }

        public LifeSimEventArgs(int UniversityCost, int YearsToPayBack)
        {
            this.UniversityCost = UniversityCost;
            this.YearsToPayBack = YearsToPayBack;
        }
    }
}
