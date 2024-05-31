using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6_XUnit_Acceptanstestning.Models
{
    public class Calculator
    {
        public double Addition(double num1, double num2)
        {
            var result = num1 + num2;
            return Math.Round(result, 2);
        }

        public double Subtraction(double num1, double num2)
        {
            var result = num1 - num2;
            return Math.Round(result, 2);
        }

        public double Division(double num1, double num2)
        {
            //Kastar ett undantag om andra talet är 0 för att förhindra division med noll.
            if (num2 == 0)
            {
                throw new DivideByZeroException("Division med 0 är ej tillåtet.");
            }
            var result = num1 / num2;
            return Math.Round(result, 2);
        }

        public double Multiplication(double num1, double num2)
        {
            var result = num1 * num2;
            return Math.Round(result, 2);
        }
    }
}
