using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIncomeEstimate.Main
{
    public class UserValidation
    {
        public bool ValidateRepeatInput(string userInput)
        {
            bool validResponse;
            if (userInput == "y" || userInput == "n")
            {
               
                validResponse = true;
            }
       
            else
            {
                Console.WriteLine("Please enter a valid response (Y/N)");
                validResponse = false;
            }
            return validResponse;

        }
        public bool ValidateGrossIncome(string incomeInput)
        {
            bool validResponse;
            validResponse = Int32.TryParse(incomeInput, out int grossIncome);
            if (!validResponse)
            {
                Console.WriteLine("Please enter a valid number input for income (without decimals, $ signs or other)");
            }
            return validResponse;
        }
        public bool ValidateFilingStatus(string userInput)
        {
            bool validInput = true;
            userInput = userInput.ToLower();
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
        public  bool RepeatService(string userInput)
        {
            bool repeatAll;
            if (userInput == "y")
            {
                repeatAll = true;
            }
            else
            {
                repeatAll = false;
            }
            return repeatAll;
        }
    }
}
