using System;
using System.IO;

namespace HangMan
{
    class Program
    {
        public static string path = @"D:\Repositories\hangman\word_rus.txt";
        private const int maxErrors = 10;
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines(path);
            Random random = new Random();

            Console.WriteLine("Да начнётся игра не на жизнь, а на смерть!!!");

            while (true)
            {
                //Загадывается слово
                string stringWord = words[random.Next(0, words.Length)];
                char[] charWord = stringWord.ToCharArray();

                //счётчики
                int errors = maxErrors;
                int opennedLetters = 0;

                //строка для отображения процесса
                char[] viewWord = new char[stringWord.Length];
                for (int i = 0; i < viewWord.Length; i++)
                {
                    viewWord[i] = '*';
                }
                Console.WriteLine($"Слово было загадано, и оно состоит из {charWord.Length} букв!!! Отгадай его за {errors} попыток!!!");

                //игра
                while (errors > 0 && opennedLetters != stringWord.Length)
                {
                    Console.WriteLine("Введи русскую букву нижнего регистра");
                    string inputString = Console.ReadLine();

                    //Никаких проверок, просто всегда меняем регистр на нижний

                    inputString = inputString.ToLower();

                    if (inputString.Length > 1 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Ясно было сказано, что нужно ввести РУССКУЮ БУКВУ!! Глупость проицается и ты лишаешься одной жизни");
                        --errors;
                        Console.WriteLine($"И у тебя осталось {errors} попыток.");
                        continue;
                    }

                    bool isLetterExist = false;
                    for (int i = 0; i < charWord.Length; i++)
                    {
                        if (charWord[i] == inputString[0])
                        {
                            ++opennedLetters;
                            viewWord[i] = inputString[0];
                            charWord[i] = ' ';
                            isLetterExist = true;
                        }
                    }
                    Console.Clear();
                    if (isLetterExist == true)
                    {
                        Console.WriteLine("Ты угадал букву, не останавливайся");
                    }
                    else
                    {
                        --errors;
                        Console.WriteLine($"Буква неверная, у тебя осталось {errors} попыток") ;                       
                    }
                    Console.WriteLine(new string(viewWord));
                }
                Console.Clear();
            }
        }

    }
}
