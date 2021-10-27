using System;

namespace hangman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int _counter = 0;
            int _counterMin = 0;
            int _counterMax = 5;

            Print p = new Print();

            Console.Write("Enter number from {0} to {1}: ", _counterMin, _counterMax);
            try
            {
                _counter = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Format exception, number set as {0}", _counter);
            }

            _counter = Constraint(_counter, _counterMin, _counterMax);

            Console.WriteLine();

            p.PrintFor(_counter);
            p.PrintWhile(_counter);
            p.PrintDoWhile(_counter);
            p.PrintArray(_counter);
            
        }

        private static int Constraint(int value, int from, int to)
        {
            if (value < from)
            {
                value = from;
                Console.WriteLine("Limited on {0}", from);
            }
            if (value > to)
            {
                value = to;
                Console.WriteLine("Limited on {0}", to);
            }
            return value;
        }
    }
}
