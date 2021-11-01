using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator1
{
    class Calculator
    {
        public static double Calculate(double a, double b, string operation)
        {
            double result = double.NaN;

            switch (operation)
            {
                //сложение
                case "+":
                    result = a + b;
                    break;
                //вычитание
                case "-":
                    result = a - b;
                    break;
                //умножение
                case "*":
                    result = a * b;
                    break;
                //деление
                case "/":
                    // проверка деления на 0
                    if (b != 0)
                    {
                        result = a / b;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
