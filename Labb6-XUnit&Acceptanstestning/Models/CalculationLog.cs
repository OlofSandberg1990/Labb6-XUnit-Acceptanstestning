using System;

namespace Labb6_XUnit_Acceptanstestning.Models
{
    public class CalculationLog
    {
        public double Num1 { get; }
        public double Num2 { get; }
        public double Result { get; }
        public string OperationSymbol { get; }

        public CalculationLog(double num1, double num2, double result, string operationSymbol)
        {
            Num1 = num1;
            Num2 = num2;
            Result = result;
            OperationSymbol = operationSymbol;
        }

        //Överskuggar den befintliga ToString-metoden för att skriva ut en egen beräkning av beräkningen.
        public override string ToString()
        {
            return $"{Num1} {OperationSymbol} {Num2} = {Result}";
        }
    }
}
