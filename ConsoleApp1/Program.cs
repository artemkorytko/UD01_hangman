using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    internal class Program
    {
        public static string path = @"D:\Unity\hangman\ConsoleApp1\word_rus.txt";

        private const int maxErrors = 10;

        static void Main(string[] args)
        {
            HangmanClass hWord = new HangmanClass(path);
            
            
            hWord.GenerateWord();

            while (true)
            {

                int errors = maxErrors;
                int openedLetters = 0;
                

                int viewWordPositionTop = Console.CursorTop;
                
                Console.Write(hWord.viewWord);
                Console.WriteLine();
                
                List<char> charList = new List<char>();
                
                charList.Clear();

                while (errors > 0 && openedLetters != hWord.word.Length)
                {
                    Console.Write("Введите букву: ");
                    
                    string inputString = Console.ReadLine();

                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.WriteLine("Неправильный ввод!");
                        continue;
                    }

                    bool isLetterExist = true;

                    for (int i = 0; i < hWord.charWord.Length; i++)
                    {
                        if (hWord.charWord[i] == inputString[0] && !charList.Contains(hWord.charWord[i]))
                        {
                            charList.Add(hWord.charWord[i]);
                            Console.SetCursorPosition(i, viewWordPositionTop);
                            Console.WriteLine(hWord.charWord[i]);
                            openedLetters++;
                            isLetterExist = false;
                        }
                    }

                    if (isLetterExist)
                    {
                        errors--;
                        Console.WriteLine($"Такой буквы нету! Осталось {errors} попыток!");
                        Console.SetCursorPosition(0, viewWordPositionTop + 1);
                    }
                }
                Console.SetCursorPosition(0, viewWordPositionTop + 3);

                if (errors == 0)
                {
                    Console.WriteLine("Проиграл!");
                }
                else
                {
                    Console.WriteLine("Пробедил!");
                }

                Console.WriteLine("\n\nНажми ESC что-бы выйти\nEnter для новой игры");
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.Key == ConsoleKey.Escape)
                    break;
                
                Console.Clear();
            }
        }
    }
}
