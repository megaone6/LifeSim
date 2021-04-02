using System;
using System.Collections.Generic;

namespace LifeSim.Model
{
    public class LifeSimEventArgs
    {
        public Person Person { get; }

        public bool Death { get; }

        public int UniversityCost { get; }

        public int YearsToPayBack { get; }

        public int PersonIndex { get; }

        public Sickness Sickness { get; }

        public String Sicknesses { get; }

        public String SicknessesHealed { get; }

        public LifeSimEventArgs(Person Person)
        {
            this.Person = Person;
        }

        public LifeSimEventArgs(Person Person, int PersonIndex)
        {
            this.Person = Person;
            this.PersonIndex = PersonIndex;
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

        public LifeSimEventArgs(Sickness Sickness)
        {
            this.Sickness = Sickness;
        }

        public LifeSimEventArgs(String Sicknesses, String SicknessesHealed)
        {
            this.Sicknesses = Sicknesses;
            this.SicknessesHealed = SicknessesHealed;
        }
    }
}
