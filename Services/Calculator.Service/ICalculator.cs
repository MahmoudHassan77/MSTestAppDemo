namespace Calculator.Service
{
    public interface ICalculator
    {
         int Add(CalcInputs numbers);
         int Sub(CalcInputs numbers);
         int Mult(CalcInputs numbers);
         int Div(CalcInputs numbers);
    }
}
