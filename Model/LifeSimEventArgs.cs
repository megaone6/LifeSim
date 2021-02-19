using System;

namespace LifeSim.Model
{
    public class LifeSimEventArgs
    {
        public Person Person { get; }

        public bool Death { get; }

        public LifeSimEventArgs(Person Person)
        {
            this.Person = Person;
        }

        public LifeSimEventArgs(bool Death)
        {
            this.Death = Death;
        }
    }
}
