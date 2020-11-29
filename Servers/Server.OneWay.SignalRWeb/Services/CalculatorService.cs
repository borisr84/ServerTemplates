using Microsoft.Extensions.Logging;
using Server.OneWay.SignalRWeb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.OneWay.SignalRWeb.Services
{
    public class CalculatorService : ICalculator
    {
        private readonly ILogger<CalculatorService> _logger;
        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
        }

        #region Properties
        public double? Res { get; private set; } = null;
        #endregion

        #region Methods
        public double Add(double num1, double num2)
        {
            Res = num1 + num2;
            _logger.LogInformation(@"Add numbers: ({num1} + {num2}) = {res}", num1, num2, Res);

            return Res.Value;
        }

        //public double Div(double num1, double num2)
        //{
        //    if (num2 == 0.0)
        //        throw new DivideByZeroException();

        //    Res = num1 / num2;

        //    return Res.Value;
        //}

        //public double Mult(double num1, double num2)
        //{
        //    Res = num1 * num2;

        //    return Res.Value;
        //}

        //public double Subtract(double num1, double num2)
        //{
        //    Res = num1 - num2;

        //    return Res.Value;
        //}
        #endregion
    }
}
