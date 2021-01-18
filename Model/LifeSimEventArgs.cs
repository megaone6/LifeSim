using System;

namespace LifeSim.Model
{
    public class LifeSimEventArgs
    {
        public int Age { get; }

        public LifeSimEventArgs(int Age)
        {
            this.Age = Age;
        }
    }
}
