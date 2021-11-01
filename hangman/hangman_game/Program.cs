using System;
using System.Collections.Generic;
using System.IO;

namespace hangman_game
{
    class Program
    {
        public static string path = @"C:\[UNITY]\hangman\word_rus.txt";
        private const int max_errors = 10;
        
       
        static void Main(string[] args)
        {
           
            Console.WriteLine("Привет! Давай поиграем :)");
           
            HangmanClass word = new HangmanClass(path);
           
            while (true)
            {
                word.GenerateWord();
               
                //создаем счетчик
                int errors = max_errors;
                List<char> enteredWords = new List<char>();

                Console.WriteLine($"Загадано слово {word.stringWord} из {word.WordLettersCount} букв. Отгадай его за {errors} попыток");

                //цикл партии
                while (errors > 0 && !word.IsSolved)
                {
                    bool isDuplicateWord = false;

                    Console.WriteLine(word.ViewWord);

                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();
                    if(inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вводи только буквы");
                        Console.ResetColor();
                        continue;
                    }
                    //проверка на кол-во введенных букв
                    if(inputString.Length > 1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вводи по одной букве");
                        Console.ResetColor();
                        continue;
                    }

                    //проверяем на повторный ввод буквы
                    for (int j = 0; j < enteredWords.Count; j++)
                    {
                        if (Char.ToLower(inputString[0]) == enteredWords[j])
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы уже вводили такую букву!");
                            Console.ResetColor();
                            isDuplicateWord = true;
                        }
                    }

                    if (isDuplicateWord)
                    continue;

                    //записываем введенную букву
                    enteredWords.Add(Char.ToLower(inputString[0]));

                    Console.Clear();
                    //проверка есть ли такая буква в слове
                    if (word.CheckLetter(inputString[0]))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Угадал! Есть такая буква!");
                        Console.ResetColor();
                    }
                    else
                    {
                        errors--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Такой буквы нет! Осталось попыток: {errors}");
                        Console.ResetColor();
                    }
                   
                }

                //подводим итоги
                Console.Clear();
                if(errors == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Проигрыш :( Загаданое слово: {word.stringWord}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ура! Победа :)");
                    Console.ResetColor();
                }

                Console.WriteLine("Чтобы продожить нажми \"Ввод\"");
                Console.ReadLine();
                Console.Clear();

            }
        }
    }
}
