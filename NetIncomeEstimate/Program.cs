using NetIncomeEstimate.BaseClasses;
using NetIncomeEstimate.Classes;
using NetIncomeEstimate.FilingStatuses;
using NetIncomeEstimate.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIncomeEstimate
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInput input = new UserInput();
            Console.WriteLine("Welcome to Karina's Net Income Estimator. First I'll need a litte bit of information");
            bool run = true;
            while (run)
            {
                string filing = input.AskForFilingStatus();

                int income= input.AskForGrossIncome();

                var netIncome =GetNetIncome(filing, income);
                DisplayIncomeBreakOut(netIncome);

                run = input.RepeatCalculatorInput();

            }


        }
        public static double GetNetIncome(string filingStatus, int grossIncome)
        {

            Married marriedFilier = new Married();
            FilingStatuses.Single singleFilier = new FilingStatuses.Single();
            HeadOfHousehold HoHFilier = new HeadOfHousehold();

            TaxRateCalculator calculator = new TaxRateCalculator();

            List<TaxRate> RateTable;
            int standardDeduction;
            string filingStatusName;
            switch (filingStatus)
            {
                case "m":
                    RateTable = marriedFilier.RateTable;
                    standardDeduction = marriedFilier.StandardDeduction;
                    filingStatusName = marriedFilier.name;

                    break;
                case "h":
                    RateTable = HoHFilier.RateTable;
                    standardDeduction = HoHFilier.StandardDeduction;
                    filingStatusName = HoHFilier.name;
                    break;
                default:

                    RateTable = singleFilier.RateTable;
                    standardDeduction = singleFilier.StandardDeduction;
                    filingStatusName = singleFilier.name;
                    break;

            }
            var taxableIncome = grossIncome - standardDeduction;
            var userRate = calculator.GetTaxRate(taxableIncome, RateTable);
            int index = RateTable.IndexOf(userRate);
            var LowerTaxBracket = calculator.GetLastTaxBracketMax(index, RateTable);
            var taxesOwed = calculator.TaxOwedCalculation(taxableIncome, userRate, LowerTaxBracket.RangeMax);

            double NetIncome = taxableIncome - taxesOwed;
            Console.WriteLine("You will receive {0} after taxes if you file your taxes as : {1}", NetIncome, filingStatusName);
            return NetIncome;
        }
        public static void DisplayIncomeBreakOut(double NetIncome)
        {
            var weekly = NetIncome / 52;
            var monthly = NetIncome / 12;
            var biweekly = NetIncome / 26;

            Console.WriteLine("This is your Net Income by pay period");
            Console.WriteLine("Monthly: $" + monthly);
            Console.WriteLine("Bi-Weekly: $"+ biweekly);
            Console.WriteLine("Weekly: $" + weekly);

        }



    }
}
