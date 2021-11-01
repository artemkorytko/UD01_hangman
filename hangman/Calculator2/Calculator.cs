using System;


namespace Calculator2
{
    class Calculator
    {
        public double Calculate(string expression)
        {
            double result = double.NaN;
            int operatorIndex = 0;
            // проходим по выражению
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                //проверяем оперции
                if (c == '+' || c == '-')
                {
                    //записываем индекс
                    operatorIndex = i;
                    break;
                }
                else if ((c == '*' || c == '/') && operatorIndex == 0)
                {
                    operatorIndex = i;
                }
            }

            if (operatorIndex == 0)
            {
                expression = expression.Trim();
                //возвращаем число
                result = double.Parse(expression);    
            }
            else
            {
                double first_val = Calculate(expression.Substring(0, operatorIndex));
                double second_val = Calculate(expression.Substring(operatorIndex + 1));
                switch (expression[operatorIndex])
                {
                    //вычисляем
                    case '+':
                        result = first_val + second_val;
                        break;
                    case '-':
                        result = first_val - second_val;
                        break;
                    case '*':
                        result = first_val * second_val;
                        break;
                    case '/':
                        if(second_val != 0)
                        {
                            result = first_val / second_val;
                        }
                        break;
                }
            }
            return result;
        }
    }
}
