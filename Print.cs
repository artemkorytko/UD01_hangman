using System;

namespace hangman
{
    public class Print
    {

        public void PrintFor(int counter)
        {
            Console.WriteLine("FOR prev");
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Printing FOR: {0}", i);
            }
            Console.WriteLine();
        }

        public void PrintWhile(int counter)
        {
            Console.WriteLine("WHILE prev");
            while (counter > 0)
            {
                Console.WriteLine("Printing WHILE: {0}", counter);
                counter--;
            }
            Console.WriteLine();
        }

        public void PrintDoWhile(int counter)
        {
            Console.WriteLine("DO|WHILE prev");
            do
            {
                Console.WriteLine("Printing DO|WHILE: {0}", counter);
                counter--;
            } while (counter > 0);
            Console.WriteLine();
        }

        public void PrintSwitch(int counter)
        {
            Console.WriteLine("Switch prev");
            switch (counter)
            {
                case 0:
                    Console.WriteLine("Switched on {0} \n  Case name Dave", counter);
                    break;
                case 1:
                    Console.WriteLine("Switched on {0} \n  Case name Todd", counter);
                    break;
                case 2:
                    Console.WriteLine("Switched on {0} \n  Case name Ron", counter);
                    break;
                case 3:
                    Console.WriteLine("Switched on {0} \n  Case name Alex", counter);
                    break;
                case 4:
                    Console.WriteLine("Switched on {0} \n  Case name Jane", counter);
                    break;
                case 5:
                    Console.WriteLine("Switched on {0} \n  Case name NULL", counter);
                    break;
            }
            Console.WriteLine();
        }

        public void PrintArray(int counter)
        {
            Console.WriteLine("ARRAY prev");
            int[] array = new int[counter];
            for (int i = 0; i < counter; i++)
            {
                array[i] = i;
            }
            Console.Write("Array: ");
            foreach (int i in array)
            {
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }
    }
}