using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Dtos;
using Xunit;

namespace TestProject.Tests
{
    public class ValidationTests
    {
        private bool ValidationModel(object model)
        {
            var validationResults = new List<ValidationResult>();

            var ctx = new ValidationContext(model, null, null);

            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }

        [Theory]
        [InlineData(null, null, 2.0, 1.0, false)]
        [InlineData(null, "Test@tester.com", 1.0,2.0, false)]
        [InlineData("TestName", "Test@tester.com", 3.0,4.0, true)]
        [InlineData("TestName", null, 3.0, 4.0, false)]
        public void TestModelValidation(string? name, string? email, decimal income, decimal expense, bool isValid)
        {
            var userDto = new UsersDto()
            {
                Name = name,
                Email = email,
                Income = income,
                Expenses = expense
            };

            Assert.Equal(isValid, ValidationModel(userDto));
        }
    }
}
