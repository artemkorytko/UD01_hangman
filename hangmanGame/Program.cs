using System;

namespace hangmanGame
{
    class Program
    {
        public static string path = @"C:\Users\vladt\Desktop\UnityProjects\hangman\word_rus.txt";
        public const int maxErrors = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Let's play game!");

            while (true)
            {
                HangmanClass hangman = new HangmanClass(path, maxErrors);

                Console.WriteLine($"Загадано слово из {hangman.RandomWord.Length} букв. Отгадай его за {hangman.Errors} попыток.");

                while (hangman.Errors > 0 && !hangman.isWin())
                {
                    Console.WriteLine("Введите букву:");
                    string inputChar = Console.ReadLine();

                    if (inputChar.Length == 0 || !char.IsLetter(inputChar[0]) || inputChar.Length > 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Введена не буква!");
                        continue;
                    }

                    Console.Clear();
                    inputChar = inputChar.ToLower();
                    hangman.CheckLetter(inputChar[0]);

                    Console.WriteLine(new string(hangman.ViewWord));
                }

                Console.Clear();
                if (hangman.isWin()) {
                    Console.WriteLine("Ты выиграл!");
                }
                else
                {
                    Console.WriteLine("Ты проиграл!");
                }
                Console.WriteLine("Нажми \"Enter\" для продолжения.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
