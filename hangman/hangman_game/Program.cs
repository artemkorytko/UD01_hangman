using System;
using System.IO;

namespace hangman_game
{
    class Program
    {
        public static string path = @"C:\[UNITY]\hangman\word_rus.txt";
        private const int max_errors = 10; 
        static void Main(string[] args)
        {
                   
            Console.WriteLine("Hello! Let's play game!");

            HangmanClass word = new HangmanClass(path);

            while(true)
            {
                word.GenerateWord();                
                //создаем счетчик
                int errors = max_errors;

                Console.WriteLine($"Загадано слово из {word.WordLettersCount} букв. Отгадай его за {errors} попыток");

                //цикл партии
                while (errors > 0 && !word.IsSolved)
                {
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();
                    if(inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вводи только буквы");
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
                Console.WriteLine("Чтобы продожить нажми \"Ввод\"");
                Console.ReadLine();
                Console.Clear();

            }
        }
    }
}
