using NetIncomeEstimate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIncomeEstimate.FilingStatuses
{
    class HeadOfHousehold: FilingStatus
    {
        internal int deduction = 18650;
        public string name = "Head of Household";
        
        public HeadOfHousehold()
        {
            StandardDeduction = deduction;
            Alias = name;

            RateTable.Add(new TaxRate(0, 14100, 1, .10));
            RateTable.Add(new TaxRate(14101, 53700, 1410, .10));
            RateTable.Add(new TaxRate(53701, 85500, 6162, .22));
            RateTable.Add(new TaxRate(85501, 163300, 13158, .24));
            RateTable.Add(new TaxRate(163301, 207350, 31830, .32));
            RateTable.Add(new TaxRate(207351, 518400, 45926, .35));

            //edge case 
            //RateTable.Add(new TaxRate(518401, null, 154793.5, .37));

        }
    }
}
