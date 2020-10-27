using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIncomeEstimate.BaseClasses
{
    class FilingStatus
    {
        internal int StandardDeduction { get; set; }
        public  string Alias { get; set; }

        public List<TaxRate> RateTable { get; set; }

        
       

    }
}
