using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIncomeEstimate.BaseClasses
{
    public class TaxRate
    {
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }
        public double BaseTax { get; set; }
        public double Rate { get; set; }

     
        public TaxRate(int min,int max, double baseRate, double rate)
        {
            RangeMin = min;
            RangeMax = max;
            BaseTax = baseRate;
            Rate = rate;
        } 

    }
}
