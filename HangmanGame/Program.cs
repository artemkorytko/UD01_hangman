using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    internal class Program
    {
        public static string path = @"D:\Unity\hangman\word_rus.txt";

        private const int maxErrors = 10;

        static void Main(string[] args)
        {
            HangmanClass word = new HangmanClass(path);
            GameInterface gameInterface = new GameInterface();
            
            while (true)
            {
                int errors = maxErrors;
                
                word.GenerateWord();
                
                gameInterface.Print(new string(word.viewWord), errors);
                
                //подсказка в начале
                //Console.WriteLine(word.word);

                while (errors > 0 && word.GetOpenedLetters != word.word.Length)
                {
                    string inputString = Console.ReadLine();

                    if (inputString.Length == 0 || inputString.Length > 1 || !Char.IsLetter(inputString[0]))
                    {
                        gameInterface.Print(errors, 0, GameInterface.GameEvent.Error);
                        continue;
                    }

                    if (!word.CheckLetter(inputString[0]))
                    {
                        errors--;
                        gameInterface.Print(errors, 1, GameInterface.GameEvent.Error);
                    }
                    else
                    {
                        gameInterface.Print(new string(word.viewWord), errors);
                    }
                }
                if (errors > 0)
                    gameInterface.Print(new string(word.viewWord), errors, 0, GameInterface.GameEvent.Win);
                else
                    gameInterface.Print(new string(word.viewWord), errors, 0, GameInterface.GameEvent.Fail);

                //выход из игры
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.Key == ConsoleKey.Escape)
                    break;
                
                Console.Clear();
            }
        }
    }
}
