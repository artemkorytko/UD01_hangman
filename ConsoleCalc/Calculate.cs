using System;

namespace ConsoleCalc
{
    public class Calculate
    {
        public string Init(string example)
        {
            example = example.Replace('.', ',');
            if(example.Contains('='))                                                    //при наличии знака "=" в примере
                example = example.Substring(0, example.IndexOf('='));     //удаляем его и все что правее

            example = ParenthesisRecalculate(example);
            
            return Calculation(example);
        }

        //пересчет выражений в скобках если они есть
        private string ParenthesisRecalculate(string example)
        {
            //проверка наличия оператора перед скобкой, добавление "*" при его отсутствии
            for (int i = 0; i < example.Length; i++)
            {
                if(i > 0)
                    if (example[i] == '(' && !example[i - 1].IsOperator() && example[i - 1] != '(')
                        example = example.Insert(i, "*");
            }
            //проверка наличия оператора после скобки, добавление "*" при его отсутствии
            for (int i = 0; i < example.Length; i++)
            {
                if(i < example.Length - 1)
                    if (example[i] == ')' && !example[i + 1].IsOperator() && example[i + 1] != ')')
                        example = example.Insert(i, "*");
            }
            //пересчет выражение в скобках с права на лево, пока есть скобки
            while (example.Contains('('))
            {
                int firstIndex = 0;
                int secondIndex = 0;
                
                //поиск первой скобки (справа на лево)
                for (int i = example.Length - 1; i > 0 ; i--)
                {
                    if (example[i] == '(')
                    {
                        firstIndex = i;
                        break;
                    }
                }
                //поиск второй (закрывающей скобки), добавлениее ее в конец при ее отсутствии
                for (int i = firstIndex; i <= example.Length - 1; i++)
                {
                    if (example[i] == ')')
                    {
                        secondIndex = i;
                        break;
                    }
                    else if (i == example.Length - 1)
                    {
                        example += ")";
                        secondIndex = example.Length;
                    }
                }
                //пересчет выражения в скобках и его замена в основном примере
                string enternalExample = example.Substring(firstIndex + 1, secondIndex - firstIndex - 1);
                string enternalExampleBuffer = enternalExample;
                enternalExample = Calculation(enternalExample);
                example = example.Replace($"({enternalExampleBuffer})", enternalExample);
            }
            return example;
        }

        //ужас ужасный, но работает
        private string Calculation(string example)
        {
            double[] numArr = GetNumsArr(example);
            char[] opsArr = GetOperators(example);
            
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
                for (int j = 0; j < opsArr.Length; j++)
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
            
            //перебор примера и его вычисление в соответствии с отсортированным списком операторов
            while(opsArr.Length > 0) //выполняем пока колличество операторов в исходном порядке не станет равно нулю
            {
                foreach (var VARIABLE in sortedOps)             //перебор отсортированного массива операторов
                {                                                    //и для каждого элемента отсортированного массива(строки)
                    for (int j = 0; j < opsArr.Length; j++)          //перебор исходного массива операторов
                    {                                                //и сравнение его с заданным в порядке сортировки
                        if (opsArr[j] == VARIABLE)                   //и выполнение пересчета
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
                                    if (numArr[j + 1] != 0)
                                        numArr[j] = Divide(numArr[j], numArr[j + 1]);
                                    else
                                        return "Divide by zero exception!";
                                    break;
                                case '^' :
                                    if (numArr[j + 1] == 0)
                                        numArr[j] = 1;
                                    else
                                        numArr[j] = Involution(numArr[j], numArr[j + 1]);
                                    break;
                            }
                            numArr = numArr.RemoveAt(j + 1);    //удаление второго числа операции
                            opsArr = opsArr.RemoveAt(j);              //удаление расчитанного оператора
                        }
                    }
                }
                
            }
            return numArr[0].ToString();
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