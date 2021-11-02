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
                    inputString = inputString.ToLower();

                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Только буквы!");
                        continue;
                    }
                    else if(inputString.Length > 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Вводите не более одной буквы за раз!");
                        continue;
                    }
                    Console.Clear();

                    if(word.CheckLetterRepeat(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вы уже вводили эту букву");
                        continue;
                    }

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
                
                if (errors > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Победа!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Поражение :_(");
                }
                word.ClearList();
                Console.WriteLine("\"д\" - продолжить, \"н\" - выход");
                string endgame = Console.ReadLine();
                switch (endgame)
                {
                    case "д":
                        continue;
                    case "н":
                        Console.WriteLine("Досвидания");
                        break;
                }
                Console.Clear();
            }
        }
    }
}
