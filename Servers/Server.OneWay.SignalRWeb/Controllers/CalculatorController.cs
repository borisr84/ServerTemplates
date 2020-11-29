using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.OneWay.SignalRWeb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Server.OneWay.SignalRWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private ICalculator _calculator;
        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<double> PostAdd(double num1, double num2)
        {
            try
            {
                return _calculator.Add(num1, num2);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<double> GetResult()
        {
            try
            {
                return _calculator.Res;
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
