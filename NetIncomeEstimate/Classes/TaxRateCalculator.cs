using NetIncomeEstimate.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIncomeEstimate.Classes
{
    public class TaxRateCalculator
    {
        public TaxRate GetTaxRate(int taxableIncome, List<TaxRate> RateTable)
        {
            try
            {
                int selectedIndex = 0;
                bool foundRate = false;
                while (!foundRate)
                {
                    for (int i = 0; i < RateTable.Count; i++)
                    {
                        if (RateTable[i].RangeMax != null)
                        {
                            if (taxableIncome < RateTable[i].RangeMax && taxableIncome > RateTable[i].RangeMin)
                            {
                                selectedIndex = i;
                                foundRate = true;
                            }

                        }
                        else if (taxableIncome > RateTable[i].RangeMin && taxableIncome > RateTable[i].BaseTax)
                        {
                            selectedIndex = i;
                            foundRate = true;
                        }
                    }

                }
                return RateTable[selectedIndex];

            }
            catch (Exception e)
            {
                return null;
            }

        }
        public TaxRate GetLastTaxBracketMax(int rateIndex, List<TaxRate> RateTable)
        {
            if (rateIndex != 0)
            {
                return RateTable[rateIndex - 1];
            }
            else
            {
                return null;
            }
        }
        public double TaxOwedCalculation(int taxableIncome, TaxRate bracket, int surplus)
        {
                double taxesOwed;
                if (surplus != 0)
                {

                    taxesOwed = (taxableIncome - surplus) * bracket.Rate + bracket.BaseTax;
                    return taxesOwed;
                }
                else
                {
                    taxesOwed = taxableIncome * bracket.Rate;
                    return taxesOwed;
                }
        }
    }
}
