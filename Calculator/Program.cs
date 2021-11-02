using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Калькулятор v1.0.0");
                Console.WriteLine("Введите выржание из двух операндов (прим. 10+15):");
                string expression = Console.ReadLine();
                try
                {
                    expression = Calculator.Calculate(expression);
                    Console.WriteLine($"Ответ: {expression}");
                    Restart();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Restart();
                }
            }
        }

        private static void Restart()
        {
            Console.WriteLine("Нажмите любую кнопку для продолжения.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
