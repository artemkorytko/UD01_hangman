using System;
using System.IO;

namespace ConsoleApp1
{
   
    class Program
    {
        public static string path = @"C:\Users\USER\Documents\GitHub\hangman\word_rus.txt";
        private const int maxErrors = 10;
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines(path);
            Random random = new Random();

            Console.WriteLine("Hello! Let's play game!");

            //написали игровой движок
            while (true)
            {
                //загадываем слово
                
                Console.WriteLine(stringWord);
                
                Console.WriteLine(charWord.Length);

                //создаем счетчик
                int errors = maxErrors;
                int opennedLetters = 0;

                //сформируем строку для отображения процесса
                
                for (int i = 0; i < viewWord.Length; i++)
                {
                    viewWord[i] = '*';
                }

                Console.WriteLine($"Загадано слово из {stringWord.Length} букв. Отгадай его за {errors} попыток");

                //цикл партии
                while (errors > 0 && opennedLetters != stringWord.Length)
                {
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вводи только буквы");
                        continue;
                    }

                    bool isLetterExist = false;
                    for (int i = 0; i < charWord.Length; i++)
                    {
                        if (charWord[i] == inputString[0])
                        {
                            opennedLetters = opennedLetters + 1;
                            viewWord[i] = inputString[0];
                            charWord[i] = ' ';
                            isLetterExist = true;
                           
                        }
                    }

                    Console.Clear();
                    if(isLetterExist)
                    {
                        Console.WriteLine("Угадал! Есть такая буква!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Такой буквы нет! Осталось попыток: {errors}");

                    }
                    Console.WriteLine("Чтобы продолжить нажми \"Ввод\"");
                    Console.Read();
                    Console.Clear();

                }
            }

        }
    }
    
   
}
