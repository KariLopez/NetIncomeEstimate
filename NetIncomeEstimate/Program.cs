using NetIncomeEstimate.BaseClasses;
using NetIncomeEstimate.Classes;
using NetIncomeEstimate.FilingStatuses;
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
            Console.WriteLine("Welcome to Karina's Net Income Estimator. First I'll need a litte bit of information");
            bool run = true;
            while (run)
            {
                string filing = AskForFilingStatus();

                int income= AskForGrossIncome();

                GetNetIncome(filing, income);

            }


        }
        public static string AskForFilingStatus()
        {
            bool validInput = false;
            string filingStatus = "";
            while (!validInput)
            {
                Console.WriteLine("Will you be filling your taxes as Single(s), Married(m), Head of HouseHold(h) or unknown(u)");
                filingStatus = Console.ReadLine();
                validInput = ValidateFilingStatus(filingStatus);
            }
            return filingStatus;
            
        }
        public static bool ValidateFilingStatus(string userInput)
        {
            bool validInput = true;
            userInput= userInput.ToLower();
            switch (userInput)
            {
                case "m":
                    break;
                case "u":
                    break;
                case "h":
                    break;
                case "s":
                    break;
                default:
                    Console.WriteLine("Please enter a valid text input");
                    validInput = false;
                    break;
            }
         
            return validInput;
        }
        public static int AskForGrossIncome()
        {
            bool validResponse = false;
            int grossIncome = 0;
            while (!validResponse)
            {
                Console.WriteLine("What is your annual gross income?");
                var incomeInput = Console.ReadLine();
                validResponse = ValidateGrossIncome(incomeInput);
                if (validResponse)
                {
                    grossIncome = Int32.Parse(incomeInput);
                }

            }
            return grossIncome;
        }
        public static bool ValidateGrossIncome(string incomeInput)
        {
            bool validResponse;
            validResponse = Int32.TryParse(incomeInput, out int grossIncome);
            if (!validResponse)
            {
                Console.WriteLine("Please enter a valid number input for income (without decimals, $ signs or other)"); 
            }
            return validResponse;
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
            var taxesOwed = calculator.TaxOwedCalculation(taxableIncome, userRate,LowerTaxBracket.RangeMax);

            double NetIncome = taxableIncome - taxesOwed;
            Console.WriteLine("You will receive {0} after taxes if you file your taxes as : {1}", NetIncome, filingStatusName);
            return NetIncome;
            
            

        }

    }
}
