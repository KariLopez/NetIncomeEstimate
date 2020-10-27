using NetIncomeEstimate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIncomeEstimate.FilingStatuses
{
 
     class Single: FilingStatus
     {
        internal int deduction = 12400;
        public string name = "Single";

        public Single()
        {
            StandardDeduction = deduction;
            Alias = name;

            RateTable = new List<TaxRate>();
    
            RateTable.Add(new TaxRate(0, 9875, 1, .10));
            RateTable.Add(new TaxRate(9876, 40125, 987.5, .10));
            RateTable.Add(new TaxRate(40126, 85525, 4617.5, .22));
            RateTable.Add( new TaxRate(855526, 163300, 14605.5, .24));
            RateTable.Add(new TaxRate(163301, 207350, 33271.5, .32));
            RateTable.Add(new TaxRate(207351, 518400, 47367.5, .35));
            //edge case
           // RateTable.Add(new TaxRate(518401, null, 156235, .37));

          

        }
     

    }
}
