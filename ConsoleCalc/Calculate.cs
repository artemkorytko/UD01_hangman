using System;

namespace ConsoleCalc
{
    public class Calculate
    {
        public double Init(string example)
        {
            example = example.Replace('.', ',');
            example = example.Substring(0, example.IndexOf('='));
            
            double[] numArr = GetNumsArr(example);
            char[] opsArr = GetOperators(example);
            
            return Calculation(numArr, opsArr);
        }

        //ужас ужасный, но работает
        private double Calculation(double[] numArr, char[] opsArr)
        {
            char[] ops = new char[opsArr.Length];
            
            string[] opsByPriority = Functions.opsList.Split(' ');

            string sortedOps = "";
            
            //замена всех минусов на плюсы
            for (int i = 0; i < opsArr.Length; i++)
            {
                if (opsArr[i] == '-')
                {
                    numArr[i + 1] = -numArr[i + 1];
                    opsArr[i] = '+';
                }
            }
            
            //перебор списка операторов и их сортировка
            for (int i = 0; i < opsByPriority.Length; i++)
            {
                for (int j = 0; j < ops.Length; j++)
                {
                    foreach (var op in opsByPriority[i])
                    {
                        if (opsArr[j] == op)
                        {
                            sortedOps += opsArr[j].ToString();
                        }
                    }
                }
            }

            ops = sortedOps.ToCharArray();
            
            
            //перебор примера в соответствии с отсортированным списком операторов
            while(opsArr.Length > 0)
            {
                foreach (var VARIABLE in ops)
                {
                    for (int j = 0; j < opsArr.Length; j++)
                    {
                        if (opsArr[j] == VARIABLE)
                        {
                            switch (opsArr[j])
                            {
                                case '+' :
                                    numArr[j] = Add(numArr[j], numArr[j + 1]);
                                    break;
                                case '*' :
                                    numArr[j] = Multiply(numArr[j], numArr[j + 1]);
                                    break;
                                case '/' :
                                    numArr[j] = Divide(numArr[j], numArr[j + 1]);
                                    break;
                                case '^' :
                                    numArr[j] = Involution(numArr[j], numArr[j + 1]);
                                    break;
                            }
                            numArr = numArr.RemoveAt(j + 1);
                            opsArr = opsArr.RemoveAt(j);
                        }
                    }
                }
                
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
            string ops = Functions.opsList;
            
            while (ops.Contains(' '))
            {
                ops = ops.Remove(ops.IndexOf(' '), 1);
            }
            
            char[] operators = ops.ToCharArray();
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
                Console.WriteLine($"Replaced to \'0\': {errors} elements!");
                Console.ForegroundColor = consoleColorBuffer;
            }
            
            return numsArr;
        }
        private double Add(double first, double second)
        {
            return first + second;
        }
        private double Multiply(double first, double second)
        {
            return first * second;
        }
        private double Divide(double first, double second)
        {
            return first / second;
        }
        private double Involution(double figure, double rate)
        {
            double figureCache = figure;
            for (int i = 1; i < rate; i++)
            {
                figure = figure * figureCache;
            }
            return figure;
        }
    }
}