using Calculator.API.Controllers;
using Calculator.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.APITests.Controllers
{
    [TestClass]
    public class CalculatorControllerTests
    {
        private static readonly Service.Calculator Repository = new Service.Calculator();
        private static readonly CalculatorController Controller = new CalculatorController(Repository);

     

        [TestMethod]
        public void AddTwoNumbers_TwoPositiveNumbers_RetuenNotNull()
        {
            // Arrange
            var expected = 50;
            CalcInputs inputs = new CalcInputs
            {
                Number1 = 10,
                Number2 = 40
            };

            // Act
            var actionResult = Controller.AddTwoNumbers(inputs);
            var okResult = actionResult as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
        }
        [TestMethod]
        public void AddTwoNumbers_TwoPositiveNumbers_StatusCode200()
        {
            // Arrange
            var expected = 200;
            CalcInputs inputs = new CalcInputs
            {
                Number1 = 10,
                Number2 = 40
            };

            // Act
            var actionResult = Controller.AddTwoNumbers(inputs);
            var okResult = actionResult as OkObjectResult;
            var actual = okResult.StatusCode;
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddTwoNumbers_TwoPositiveNumbers_returnSumOfTwoNumbers()
        {
            // Arrange
            var expected = 50;
            CalcInputs inputs = new CalcInputs
            {
                Number1 = 10,
                Number2 = 40
            };

            // Act
            var actionResult = Controller.AddTwoNumbers(inputs);
            var okResult = actionResult as OkObjectResult;
            var actual = okResult.Value;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        // you can add more test cases up on you method logic
    }
}