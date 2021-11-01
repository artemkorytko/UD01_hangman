using System;
using System.IO;

namespace ConsoleApp1
{
   
    class Program
    {
        public static string path = @"C:\Users\USER\Documents\GitHub\hangman\word_rus.txt";
        private const int maxErrors = 30;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Let's play game!");

            handclass word = new handclass(path);

            //написали игровой движок
            while (true)
            {
                word.GenerateWord();
                int errors = maxErrors;

                Console.WriteLine($"Загадано слово из {word.WordLettersCount} букв. Отгадай его за {errors} попыток");

                //цикл партии
                while (errors > 0 && !word.IsSolved)

                {
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine().ToLower();

                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вводи только буквы");
                        Console.WriteLine("Вводи только прописные буквы");
                        continue;
                    }

                    if (inputString.Length > 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Вводи по одной букве за раз");
                        continue;

                    }

                    Console.Clear();
                    if(word.CheckLetter(inputString[0]))

                    {
                        Console.WriteLine("Угадал! Есть такая буква!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Такой буквы нет! Осталось попыток: {errors}");

                    }

                    Console.WriteLine(word.ViewWord);

                }

                if (word.IsSolved)

                {
                    Console.WriteLine("Молодец!!! Ты отгадал слово!");
                    Console.WriteLine("Жми\"ввод\" - продолжить");
                    Console.ReadKey();

                }

                else

                {
                    Console.WriteLine("Облом, ты проиграл! Попробуй еще");
                    Console.WriteLine("Жми\"ввод\" - продолжить");
                    Console.ReadKey();
                }
            }

            Console.Read();
            Console.Clear();

        }
    }
    
   
}
