using System.Diagnostics;
using System.Reflection;

namespace Calculator.Service.Tests
{
    [TestClass] // decorator for test class
    public class CalculatorTests
    {
        public TestContext TestContext { get; set; }  // ==> to get information about test case
        private static readonly Calculator Service = new();
        [TestMethod] // decorator for test method
        [TestCategory("CorrectionCat")] // category trait ==> to group test cases by category
        [TestProperty("Test Group","Security")] // property trait ==> to group test cases by property
        [Owner("Mahmoud Hassan")] // owner trait ==> to group test cases by owner
        [Priority(1)] // priority trait ==> to group test cases by priority
        public void Add_PositiveNumbers_ReturnPositive() // Naming Conventions [UnitOfWork(Method being tested)_StateUnderTest_ExpectedBehavior]
        {
             // AAA
             // Arrange => to prepare your data and initialize the expected result
             // Act => to perform the testable action and get the actual result
             // Assert => to compare the expected and the actual results 

             // Arrange
             int expectedResult = 20; 
             CalcInputs numbers = new CalcInputs
             {
                 Number1 = 15,
                 Number2 = 5
             };

             // Act
             int actualResult = Service.Add(numbers);

             // Assert
             Assert.AreEqual(expectedResult, actualResult); // check equality
                                                            // Assert. [AreEqual, AreNotEqual, AreSame, AreNotSame, Fail, Inconclusive, IsTrue, IsFalse, IsNull, IsNotNull, IsInstanceOfType, IsNotInstanceOfType]
                                                            // Equal ==> compare values
                                                            // Same ==> compare references
                                                            // Fail ==> to force test case to fail
                                                            // IsTrue ==> to check true boolean values
                                                            // IsFalse ==> to check false boolean values
                                                            // IsNull ==> to check Nullability
                                                            // IsInstanceOfType ==> to check the type of object

            // CollectionAssert. [AreEqual, AreNotEqual, AreEquivalent, AreEquivalent, Contains, DoesNotContain, IsSubsetOf, IsNotSubsetOf, AllItemsAreUnique, AllItemsAreNotNull, AllItemsAreInstancesOfType]
            // StringAssert. [StartWith, EndsWith, Contains, Matches, DoesNotMatch]
            // TestContext.WriteLine();  to write output message for test case
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName); // to write output message with class name
             TestContext.WriteLine(TestContext.TestName); // to write output message with method name
             TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString()); // to write output message with test case status
        }
        [TestMethod]
        public void Add_NegativeNumbers_ReturnNegative() 
        {
            // Arrange
            int expectedResult = -20;
            CalcInputs numbers = new CalcInputs
            {
                Number1 = -15,
                Number2 = -5
            };

            // Act
            int actualResult = Service.Add(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Add_PositiveAndNegativeNumbers_ReturnNegative()
        {
            // Arrange
            int expectedResult = -10;
            CalcInputs numbers = new CalcInputs
            {
                Number1 = -15,
                Number2 = 5
            };

            // Act
            int actualResult = Service.Add(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Add_PositiveAndNegativeNumbers_ReturnPositive()
        {
            // Arrange
            int expectedResult = 10;
            CalcInputs numbers = new CalcInputs
            {
                Number1 = 15,
                Number2 = -5
            };

            // Act
            int actualResult = Service.Add(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))] // to test method returns exception
        public void Div_DivideByZero_ThrowDivideByZeroError()
        {
            //Arrange
            CalcInputs inputs = new CalcInputs
            {
                Number1 = 25,
                Number2 = 0
            };
            //Act
            try
            {
                 Service.Div(inputs);
            }
            catch (DivideByZeroException ex)
            {
                //Assert
                Assert.AreEqual("Divide By Zero Exception", ex.Message);
                throw;
            }

        }

        // test private method by Reflection
        [TestMethod]
        public void CosAngel_DoubleAngel_ReturnCosineOfAngel()
        {
                double angel = 0;
                double expected = 1;
                Calculator calc = new Calculator(); 

                
                // Act
                MethodInfo method = typeof(Calculator)
                    .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(x => x is { Name: "CosAngel", IsPrivate: true });
                var actual = method.Invoke(calc, new object[] { angel });

                //Assert
                Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SaveOperation_TwoPositiveNumbersAndSubResult_ReturnDbRowId()
        {
           // Arrange
            Calculator calc = new Calculator();
            CalcInputs inputs = new CalcInputs
            {
                Number1 = 100,
                Number2 = 50,
            };
            int result = 50;


            // Act
            MethodInfo method = typeof(Calculator)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(x => x is { Name: "SaveOperation", IsPrivate: true });
            var actual = method.Invoke(calc, new object[] { inputs, result });

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestCleanup] // you can't write another method with this type, it runs after test case to get specific output message 
        public void CleanUp()
        {
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }

        [TestInitialize] // it will run before all test cases
        public void Initialize()
        {

        }


        [TestMethod]
        [Timeout(2000)] // to give method time to test If it is late, it will fail
        [Ignore]  // to ignore this test method  
        public void TestMethod()
        {
        }
    }
}