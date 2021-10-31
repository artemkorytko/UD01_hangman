using System;

namespace ConsoleCalc
{
    public class Calculate
    {
        public double Init(string example)
        {
            example = example.Replace('.', ',');
            example = example.Replace('=', ' ');
            
            double[] numArr = GetNumsArr(example);
            char[] opsArr = GetOperators(example);
            
            return Calculation(numArr, opsArr);
        }

        private double Calculation(double[] numArr, char[] opsArr)
        {
            int i = 0;
            while(opsArr.Length > 0)
            {
                switch (opsArr[i])
                {
                    case '+' :
                        numArr[i] = Add(numArr[i], numArr[i + 1]);
                        break;
                    case '-' :
                        numArr[i] = Take(numArr[i], numArr[i + 1]);
                        break;
                    case '*' :
                        numArr[i] = Multiply(numArr[i], numArr[i + 1]);
                        break;
                    case '/' :
                        numArr[i] = Divide(numArr[i], numArr[i + 1]);
                        break;
                }
                numArr = numArr.RemoveAt(i + 1);
                opsArr = opsArr.RemoveAt(i);
                
            }
            return numArr[0];
        }

        private char[] GetOperators(string example)
        {
            char[] ops;

            for (int i = 0; i < example.Length; i++)
            {
                if (!example[i].IsOperator())
                {
                    example = example.Replace(example[i].ToString(), " ");
                }
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


            while (example.Contains(' '))
            {
                example = example.Remove(example.IndexOf(' '), 1);
            }
            
            exampleArr = example.Split(operators);
            
            double[] numsArr = new double[exampleArr.Length];
            int errors = 0;

            for (int i = 0; i < numsArr.Length; i++)
            {
                
                try
                {
                    numsArr[i] = Convert.ToDouble(exampleArr[i]);
                }
                catch (FormatException)
                {
                    errors++;
                }
                
            }

            if (errors > 0)
            {
                var consoleColorBuffer = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Enter only numbers & operators\nIncorrect input replace to \'0\' \nReplaced {errors} elements!");
                Console.ForegroundColor = consoleColorBuffer;
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
            return first * second;
        }
        private double Divide(double first, double second)
        {
            return first / second;
        }
    }
}