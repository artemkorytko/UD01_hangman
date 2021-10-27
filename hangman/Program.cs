using System;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("====================================");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Even numbers in array is:");
            foreach (int number in numbers)
            {
                if (number % 2 == 0) 
                    Console.Write($"{number} ");
            }

            Console.WriteLine("\n====================================");
            int[] arrList = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine($"Array: {PrintArray(arrList)}");
            Console.WriteLine("Replace even numbers in array on '0' number...");
            int arrCount = arrList.Length - 1;
            while (arrCount >= 0)
            {
                if (arrList[arrCount] % 2 == 0)
                {
                    arrList[arrCount] = 0;
                }
                arrCount--;
            }
            Console.WriteLine($"Array afeter replacing: {PrintArray(arrList)}");

            Console.WriteLine("====================================");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("#");
                }

                Console.WriteLine();
            }

            Console.WriteLine("====================================");
            string[] actions = { "PLAY", "STOP", "RESTART", "EXIT" };

            switch (actions[2])
            {
                case "PLAY": Console.WriteLine("Player put on 'PLAY' button"); break;
                case "STOP": Console.WriteLine("Player put on 'STOP' button"); break;
                case "RESTART": Console.WriteLine("Player put on 'RESTART' button"); break;
                case "EXIT": Console.WriteLine("Player put on 'EXIT' button"); break;
                default: break;
            }
        }

        static object PrintArray<T>(T[] enumerator) where T: struct
        {
            string str = "";
            foreach (T key in enumerator)
            {
                str += $"{key} ";
            }
            return str;
        }
    }
}
