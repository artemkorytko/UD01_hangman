using System;
using System.Collections.Generic;
using System.IO;

namespace hangmanGame
{
    class HangmanClass
    {
        string[] words;
        string randomWord;
        char[] charWord;
        char[] viewWord;
        int opennedLetters = 0;
        int errors = 10;
        List<char> cache = new List<char>();
        Random random = new Random();
        public string RandomWord => randomWord;
        public char[] ViewWord => viewWord;
        public int Errors => errors;

        public HangmanClass(string path, int errors)
        {
            words = File.ReadAllLines(path);
            this.errors = errors;
            GenerateWord();
        }

        public void GenerateWord()
        {
            randomWord = words[random.Next(0, words.Length)];
            charWord = randomWord.ToCharArray();
            viewWord = new char[randomWord.Length];

            for (int i = 0; i < viewWord.Length; i++)
            {
                viewWord[i] = '*';
            }
        }

        public void CheckLetter(char letter)
        {
            for (int i = 0; i < charWord.Length; i++)
            {
                if (new string(viewWord).Contains(letter))
                {
                    Console.WriteLine("Такая буква уже есть.");
                    return;
                }
                else if (charWord[i] == letter)
                {
                    opennedLetters++;
                    viewWord[i] = letter;
                    charWord[i] = ' ';
                    Console.WriteLine("Угадал! Такая буква есть!");
                    return;
                }
                else
                {
                    if (cache.Contains(letter))
                    {
                        Console.WriteLine("Такая буква уже использовалась.");
                        return;
                    }
                    errors--;
                    cache.Add(letter);
                    Console.WriteLine($"Такой буквы нет! Осталось {errors} попыток.");
                    return;
                }
            }
        }

        public bool isWin()
        {
            return opennedLetters == randomWord.Length;
        }
    }
}
