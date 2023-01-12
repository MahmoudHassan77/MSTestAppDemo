using Calculator.Service;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost]
        public IActionResult AddTwoNumbers(CalcInputs numbers)
        {
            if (ModelState.IsValid)
            {
                var result = _calculator.Add(numbers);
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult SubtractTwoNumbers(CalcInputs numbers)
        {
            if (ModelState.IsValid)
            {
                var result = _calculator.Sub(numbers);
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult MultiplyTwoNumbers(CalcInputs numbers)
        {
            if (ModelState.IsValid)
            {
                var result = _calculator.Mult(numbers);
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult DivideTwoNumbers(CalcInputs numbers)
        {
            if (ModelState.IsValid)
            {
                var result = _calculator.Div(numbers);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
