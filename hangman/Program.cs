using System;

namespace hangman
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            int _counter = 5;
            Print p = new Print();

            p.PrintFor(_counter);
            p.PrintWhile(_counter);
            p.PrintArray(_counter);
            
        }
    }

    internal class Print
    {
        public void PrintFor(int counter)
        {
            for(int i = 0; i < counter; i++)
            {
                Console.WriteLine("Printing FOR: {0}", i);
            }
            Console.WriteLine();
        }

        public void PrintWhile(int counter)
        {
            while(counter > 0)
            {
                Console.WriteLine("Printing WHILE: {0}", counter);
                counter--;
            }
            Console.WriteLine();
        }

        public void PrintArray(int counter)
        {
            int[] array = new int[counter];
            for(int i = 0;i < counter;i++)
            {
                array[i] = i;
            }
            Console.Write("Array: ");
            foreach(int i in array)
            {
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }
    }
}
