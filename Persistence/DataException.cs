using System;

namespace LifeSim.Persistence
{
    public class DataException : Exception
    {
        public DataException(String message) : base(message) { }
    }
}
