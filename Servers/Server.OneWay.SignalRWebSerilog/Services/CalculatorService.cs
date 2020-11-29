using Server.OneWay.SignalRWebSerilog.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.OneWay.SignalRWebSerilog.Services
{
    public class CalculatorService : ICalculator
    {
        #region Properties
        public double? Res { get; private set; } = null;
        #endregion

        #region Methods
        public double Add(double num1, double num2)
        {
            Res = num1 + num2;

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
