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

            var exampleTuple = CorrectArrays(numArr, opsArr);
            
            return Calculation(exampleTuple.Item1, exampleTuple.Item2);
        }

        private Tuple<double[], char[]> CorrectArrays(double[] numArr, char[] opsArr)
        {
            for (int i = 0; i < opsArr.Length; i++)
            {
                if (opsArr[i] == '-')
                {
                    numArr[i + 1] = -numArr[i + 1];
                    opsArr[i] = '+';
                }
            }
            return Tuple.Create<double[], char[]>(numArr, opsArr);
        }

        //ужас ужасный, но работает
        private double Calculation(double[] numArr, char[] opsArr)
        {
            char[] ops = new char[opsArr.Length];
            char[] greaterOps = {'*', '/'};

            //заполняем пустой массив #
            for (int j = 0; j < ops.Length; j++)
            {
                ops[j] = '#';
            }
            //отсеиваем высшие операторы
            for (int j = 0; j < ops.Length; j++)
            {
                foreach (var VARIABLE in greaterOps)
                {
                    if (opsArr[j] == VARIABLE)
                    {
                        ops[j] = opsArr[j];
                    }
                }
            }
            //сдвигаем высшие операторы вперед
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < ops.Length - 1; j++)
                {
                    if (ops[j] == '#')
                    {
                        ops[j] = ops[j + 1];
                        ops[j + 1] = '#';
                    }
                }
            }
            for (int j = 0; j < ops.Length; j++)
            {
                if (ops[j] == '#')
                {
                    ops[j] = '+';
                }
            }
            
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
                            }
                            numArr = numArr.RemoveAt(j + 1);
                            opsArr = opsArr.RemoveAt(j);
                        }
                    }
                }
                /*
                switch (opsArr[i])
                {
                    case '+' :
                        numArr[i] = Add(numArr[i], numArr[i + 1]);
                        break;
                    case '*' :
                        numArr[i] = Multiply(numArr[i], numArr[i + 1]);
                        break;
                    case '/' :
                        numArr[i] = Divide(numArr[i], numArr[i + 1]);
                        break;
                }
                */
                //numArr = numArr.RemoveAt(i + 1);
                //opsArr = opsArr.RemoveAt(i);
                
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

            /*
            if (errors > 0)
            {
                var consoleColorBuffer = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Enter only numbers & operators\nIncorrect input replace to \'0\' \nReplaced {errors} elements!");
                Console.ForegroundColor = consoleColorBuffer;
            }
            */
            
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
    }
}