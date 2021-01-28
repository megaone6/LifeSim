using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Model
{
    public class Home
    {
        public String Type { get; set; }

        public int Price { get; set; }

        public int YearlyExpenses { get; set; }

        public Home(String Type, int Price, int YearlyExpenses)
        {
            this.Type = Type;
            this.Price = Price;
            this.YearlyExpenses = YearlyExpenses;
        }
    }
}
