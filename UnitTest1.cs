using Xunit;
using FirstResponsiveWebAppPulyala.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace ResponsiveWebAppXUnit
{
    public class UnitTest1
    {
        // Correct Test
        [Fact]
        public void TestCorrectCalc()
        {
            // Set Age
            var calculator = new PersonInfoModel { BirthYear = 1999 };
            // Expected Age
            int expected = 27;

            // Calculated Result from PersonInfoModel Code
            int? actual = calculator.AgeThisYear();

            // Assertion for calculation
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNewbornCalc()
        {
            // Set Age
            var calculator = new PersonInfoModel { BirthYear = 2026 };
            // Expected Age
            int expected = 0;

            // Calculated Result from PersonInfoModel Code
            int? actual = calculator.AgeThisYear();

            // Assertion for calculation
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNullBirthCalc() 
        {
            // Set Age
            var calculator = new PersonInfoModel { BirthYear = null };

            // Validation container for calculator.
            var context = new ValidationContext(calculator);

            // Stores errors or successes for data annotation validation
            var results = new List<ValidationResult>();


            // Manually validates an object based on data annotations, mainly [Range]
            bool isValid = Validator.TryValidateObject(calculator, context, results, true);

            //Assertion that it is not valid.
            Assert.False(isValid);

            // Contains Error Message
            var errMsg = results.FirstOrDefault(r => r.MemberNames.Contains("BirthYear"))?.ErrorMessage;

            // Assertion for result
            Assert.Equal("Please enter your birth year.", errMsg);
        }

        [Fact]
        public void TestAncientCalc()
        {
            // Set Name and Age
            var calculator = new PersonInfoModel { Name = "Cornelius", BirthYear = 1850 };

            // Validation container for calculator.
            var context = new ValidationContext(calculator);

            // Stores errors or successes for data annotation validation
            var results = new List<ValidationResult>();

            // Manually validates an object based on data annotations, mainly [Range]
            bool isValid = Validator.TryValidateObject(calculator, context, results, true);

            //Assertion that it is not valid.
            Assert.False(isValid);

            // Contains error message.
            var errMsg = results.FirstOrDefault(r => r.MemberNames.Contains("BirthYear"))?.ErrorMessage;

            // Assertion for result
            Assert.Equal("Year must be between 1900 and 2026.", errMsg);
        }

        [Fact]
        public void TestNamelessCalc() 
        {
            // Set Name and Age
            var calculator = new PersonInfoModel { Name = null, BirthYear = 1967 };

            // Validation container for calculator.
            var context = new ValidationContext(calculator);

            // Stores errors or successes for data annotation validation
            var results = new List<ValidationResult>();

            // Manually validates an object based on data annotations, mainly [Required]
            bool isValid = Validator.TryValidateObject(calculator, context, results, true);

            //Assertion that it is not valid.
            Assert.False(isValid);

            // Contains error message.
            var errMsg = results.FirstOrDefault(r => r.MemberNames.Contains("Name"))?.ErrorMessage;

            // Assertion for result
            Assert.Equal("Please enter your name.", errMsg);
        }
    }
}