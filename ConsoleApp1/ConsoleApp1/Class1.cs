using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static string path = @"F:\Other\Unity\Projects\School\Hang_Man\word_rus.txt";
        private const int maxErrors = 10;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Lets play game");

            HangmanClass word = new HangmanClass(path);

            while(true)
            {
                word.GenerateWord();
                int errors = maxErrors;

                Console.WriteLine($"Загадано слово из {word.WordLettersCount} букв. Отгадай его за {errors} попыток");

                //цикл партии
                while (errors > 0 && !word.IsSolved)
                {
                    Console.WriteLine("Введи букву");
                    string inputString = Console.ReadLine();

                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Только буквы!");
                        continue;
                    }
                    

                    Console.Clear();
                    if(word.CheckLetter(inputString[0]))
                    {
                        Console.WriteLine("Угадал!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Мимо! Осталось {errors} попыток");
                    }

                    Console.WriteLine(word.ViewWord);
                }
            }
            Console.WriteLine("Конец");
            Console.WriteLine("Жми \"ввод\" - продолжить");
            Console.Read();
            Console.Clear();
        }
    }
}
