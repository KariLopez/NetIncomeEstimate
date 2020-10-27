using NetIncomeEstimate.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetIncomeEstimate.Tests
{
    public class ValidationTests
    {
        [Fact]
        public void TestValidateRepeatInput()
        {
            string input = "no";
            bool expected = false;
            var validation = new UserValidation();
            bool actual = validation.ValidateRepeatInput(input);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestValidateGrossIncome()
        {
            string incomeInput = "60k";
            var expected = false;

            var validation = new UserValidation();
            bool actual = validation.ValidateGrossIncome(incomeInput);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestValidateFilingStatus()
        {
            string input = "Single";
            var expected = false;

            var validation = new UserValidation();
            bool actual = validation.ValidateFilingStatus(input);
            Assert.Equal(expected, actual);
        }
    }
}
