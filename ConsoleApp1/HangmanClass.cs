using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    public class HangmanClass
    {
        private string[] _words;
        private Random _random = new Random();
        private int _openedLetters;
        private List<char> _chars = new List<char>();    //список для хранения открытых букв
        
        public string word { get; private set; }
        public char[] charWord { get; private set; }
        public char[] viewWord { get; private set; }
        public int GetOpenedLetters => _openedLetters;
        public HangmanClass(string path)
        {
            _words = File.ReadAllLines(path);
        }

        public void GenerateWord()
        {
            _chars.Clear();
            _openedLetters = 0;
            word = _words[_random.Next(0, _words.Length)];
            charWord = word.ToCharArray();
            viewWord = new char[charWord.Length];
            for (int i = 0; i < word.Length; i++)
            {
                viewWord[i] = '_';
            }
        }

        public bool CheckLetter(char letter)
        {
            bool isLetterExist = false;
            
            if (Char.IsUpper(letter)) letter = Char.ToLower(letter);    //проверка на регистр и привод к нижнему

            for (int i = 0; i < charWord.Length; i++)
            {
                if (charWord[i] == letter && !_chars.Contains(viewWord[i]))
                {
                    _openedLetters++;
                    _chars.Add(letter);
                    viewWord[i] = letter;
                    isLetterExist = true;
                }
            }
            return isLetterExist;
        }
        
    }
}