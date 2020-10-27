using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIncomeEstimate.Main
{
    public class UserInput
    {
        public UserValidation validation = new UserValidation();
        public  string AskForFilingStatus()
        {
            bool validInput = false;
            string filingStatus = "";
            while (!validInput)
            {
                Console.WriteLine("Will you be filling your taxes as Single(s), Married(m), Head of HouseHold(h) or unknown(u)");
                filingStatus = Console.ReadLine();
                validInput = validation.ValidateFilingStatus(filingStatus);
            }
            return filingStatus;

        }
      
        public  int AskForGrossIncome()
        {
            bool validResponse = false;
            int grossIncome = 0;
            while (!validResponse)
            {
                Console.WriteLine("What is your annual gross income?");
                var incomeInput = Console.ReadLine();
                validResponse = validation.ValidateGrossIncome(incomeInput);
                if (validResponse)
                {
                    grossIncome = Int32.Parse(incomeInput);
                }

            }
            return grossIncome;
        }
      

        
        public  bool RepeatCalculatorInput()
        {
            bool repeatService = false;
            bool responseReceived = false;
            while (!responseReceived)
            {
                Console.WriteLine("Would you like run this again for different values? (Y/N)");
                var repeatInput = Console.ReadLine();
                repeatInput.ToLower();
                responseReceived = validation.ValidateRepeatInput(repeatInput);
                if (responseReceived)
                {
                    repeatService = validation.RepeatService(repeatInput);
                }

            }
            return repeatService;

        }
       
       
    }
}
