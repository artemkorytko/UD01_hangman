using System;

namespace Calculator2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            Console.WriteLine("Калькулятор v2 \n");

            while (!quit)
            {
                Console.WriteLine("Введите выражение и нажмите Enter:");
                string expression = Console.ReadLine();

                Calculator p = new Calculator();
                if (double.IsNaN(p.Calculate(expression)))
                {
                    Console.WriteLine("Ошибка в вычислениях! \n");
                }
                else
                {
                    Console.WriteLine($"Результат: {p.Calculate(expression)}\n");
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
