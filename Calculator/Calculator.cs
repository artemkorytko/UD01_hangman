using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Calculator
    {
        public static string Calculate(string exp)
        {
            string[] arr = ParseExpression(exp);

            if (arr != null)
            {
                double result = arr[1] switch
                {
                    "+" => Sum(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[2])),
                    "-" => Subtraction(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[2])),
                    "*" => Multiplication(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[2])),
                    "/" => Division(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[2]))
                };

                return $"{result}";
            }
            else
            {
                throw new Exception("Что-то пошло не так..");
            }
        }

        private static int Sum(int a, int b) => a + b;

        private static int Subtraction(int a, int b) => a - b;

        private static int Multiplication(int a, int b) => a * b;

        private static double Division(int a, int b)
        {
            if (b == 0)
            {
                throw new Exception("На ноль делить нельзя.");
            }
            return (double)a / (double)b;
        }

        private static string[] ParseExpression(string exp)
        {
            Regex template = new Regex(@"^\d+[+\-*\/]\d+$");
            string[] expression = new string[3];
            if (template.Matches(exp).Count > 0)
            {
                MatchCollection matches = new Regex(@"\d+|[+\-*\/]").Matches(exp);
                for (int i = 0; i < matches.Count; i++)
                {
                    expression[i] = matches[i].Value;
                }

                return expression;
            }
            else
            {
                throw new Exception("Некорректное выражение.");
            }
        }
    }
}
