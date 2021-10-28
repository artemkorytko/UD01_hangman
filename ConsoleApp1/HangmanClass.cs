using System;
using System.IO;

namespace ConsoleApp
{
    public class HangmanClass
    {
        private string[] _words;
        private Random _random = new Random();

        public string word { get; private set; }
        public char[] charWord { get; private set; }
        public char[] viewWord { get; private set; }
        
        public HangmanClass(string path)
        {
            _words = File.ReadAllLines(path);
        }

        public void GenerateWord()
        {
            word = _words[_random.Next(0, _words.Length)];
            charWord = word.ToCharArray();
            viewWord = new char[charWord.Length];
            for (int i = 0; i < word.Length; i++)
            {
                viewWord[i] = '_';
            }
        }
        
    }
}