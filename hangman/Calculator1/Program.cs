using System;

namespace Calculator1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            Console.WriteLine("Калькулятор v1 \n");

            while (!quit)
            {
                Console.WriteLine("Введите число и нажмите Enter:");
                string a = Console.ReadLine();

                double double_a;
                while (!double.TryParse(a, out double_a))
                {
                    Console.WriteLine("Не верно введено число");
                    a = Console.ReadLine();
                }

                Console.WriteLine("Введите операцию и нажмите Enter:");
                string operation = Console.ReadLine();

                Console.WriteLine("Введите второе число и нажмите Enter:");
                string b = Console.ReadLine();

                double double_b;
                while (!double.TryParse(b, out double_b))
                {
                    Console.WriteLine("Не верно введено число");
                    b = Console.ReadLine();
                }

                try
                {
                    double result = Calculator.Calculate(double_a, double_b, operation);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Ошибка в вычислениях! \n");
                    }
                    else
                    {
                        Console.WriteLine($"Результат: {result}\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Произошла ошибка: " + e.Message);
                }

                Console.Write("Нажмите q для выхода или любой символ для продолжения ");
                if (Console.ReadLine() == "q") 
                    quit = true;

                Console.WriteLine("\n"); 
            }
            return;
        }
    }
}
