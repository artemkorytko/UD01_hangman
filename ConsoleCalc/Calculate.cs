using System;
using System.Linq;

namespace ConsoleCalc
{
    public class Calculate
    {
        public void Init()
        {
            Console.WriteLine("Enter your example: ");

            string example = Console.ReadLine();
            
            double[] numArr = GetNumsArr(example);
            char[] opsArr = GetOperators(example, numArr);

            
            //debug
            foreach (var VARIABLE in numArr)
            {
                Console.Write($"{VARIABLE} ");
            }
            Console.WriteLine();
            foreach (var VARIABLE in opsArr)
            {
                Console.Write($"{VARIABLE} ");
            }
        }

        private char[] GetOperators(string example, double[] numArr)
        {
            char[] ops;
            double[] arr = numArr;

            foreach (var VARIABLE in arr)
            {
                example = example.Replace(VARIABLE.ToString(), " ");
            }
            
            while (example.Contains(' '))
            {
                example = example.Remove(example.IndexOf(' '), 1);
            }
            ops = example.ToCharArray();
            
            return ops;
        }

        private double[] GetNumsArr(string example)
        {
            char[] operators = {'+', '-', '*', '/',};
            string[] exampleArr;

            example = example.Replace('.', ',');

            while (example.Contains(' '))
            {
                example = example.Remove(example.IndexOf(' '), 1);
            }
            
            exampleArr = example.Split(operators);
            
            double[] numsArr = new double[exampleArr.Length];

            for (int i = 0; i < exampleArr.Length; i++)
            {
                try
                {
                    numsArr[i] = Convert.ToDouble(exampleArr[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter only numbers & operators\nIncorrect input replace to 0!");
                }
            }
            
            return numsArr;
        }

        private double Add(double first, double second)
        {
            return first + second;
        }
        private double Take(double first, double second)
        {
            return first - second;
        }
        private double Multiply(double first, double second)
        {
            return first + second;
        }
        private double Divide(double first, double second)
        {
            return first / second;
        }
        
    }
}