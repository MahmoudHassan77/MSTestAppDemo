using SqlEntity.Data;
using System.Diagnostics;
namespace Calculator.Service
{
    public class Calculator : ICalculator
    {
        private readonly ApplicationDbContext _dbContext;
        public Calculator()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            _dbContext = dbContext;
        }
         // [ExcludeFromCodeCoverage]  ==> to exclude this function from code coverage
        public int Add(CalcInputs numbers)
        {
            var result = numbers.Number1 + numbers.Number2;
            SaveOperation(numbers,result);
            return result;
        }
        public int Sub(CalcInputs numbers)
        {
            var result = numbers.Number1 - numbers.Number2;
            SaveOperation(numbers, result);
            return result;
        }
        public int Mult(CalcInputs numbers)
        {
            var result = numbers.Number1 * numbers.Number2;
            SaveOperation(numbers, result);
            return result;
        }
        public int Div(CalcInputs numbers)
        {
            if (numbers.Number2 == 0) throw new DivideByZeroException("Divide By Zero Exception");
            var result = numbers.Number1 / numbers.Number2;
            SaveOperation(numbers, result);
            return result;
        }

        private double CosAngel(double angel)
        {
            return Math.Cos(angel);
        }

        private int SaveOperation(CalcInputs inputs, int result)
        {
            Operation operation = new Operation
            {
                OperationName =  (new StackTrace()).GetFrame(1)?.GetMethod()?.Name,
                Number1 = inputs.Number1,
                Number2 = inputs.Number2,
                Result = result,
                DateTime = DateTime.Now
            };
            _dbContext.Operations.Add(operation);
            return _dbContext.SaveChanges();
        } 
    }
}