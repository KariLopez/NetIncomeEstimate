using NetIncomeEstimate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIncomeEstimate.FilingStatuses
{
    class Married: FilingStatus
    {
        internal int deduction = 24800;
        public string name = "Married";

        public Married()
        {
                StandardDeduction = deduction;
                Alias = name;

                RateTable = new List<TaxRate>();

                RateTable.Add(new TaxRate(0, 19750, 1, .10));
                RateTable.Add(new TaxRate(19751, 80250, 1975, .10));
                RateTable.Add(new TaxRate(80251, 171050, 9235, .22));
                RateTable.Add(new TaxRate(171051, 326600, 29211, .24));
                RateTable.Add(new TaxRate(326601, 414700, 66543, .32));
                RateTable.Add(new TaxRate(414701, 622050, 94735, .35));
                //edge case
                //RateTable.Add(new TaxRate(622051, null, 167307.5, .37));
            
          
            
        }
    }
    
}
