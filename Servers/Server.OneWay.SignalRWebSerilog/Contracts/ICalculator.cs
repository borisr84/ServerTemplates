using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.OneWay.SignalRWebSerilog.Contracts
{
    public interface ICalculator
    {
        #region Properties
        double? Res { get; }
        #endregion

        #region Methods
        double Add(double num1, double num2); //num1 + num2
        //double Subtract(double num1, double num2); //num1 - num2
        //double Mult(double num1, double num2); //num1 * num2
        //double Div(double num1, double num2); //num1 / num2
        #endregion
    }
}
