using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HangmanClass
    {
        string[] words;
        string stringWord;
        char[] charWord;
        char[] viewWord;
        int opennedLetters = 0;
        List<char> letterIsopen = new List<char>();
        Random random = new Random();

        public int WordLettersCount => stringWord.Length;

        public bool IsSolved => opennedLetters == stringWord.Length;

        public string ViewWord => new string(viewWord);

        public HangmanClass(string path)
        {
            words = File.ReadAllLines(path);
        }

        public void GenerateWord()
        {
            stringWord = words[random.Next(0, words.Length)];
            charWord = stringWord.ToCharArray();
            viewWord = new char[stringWord.Length];
            for (int i = 0; i < viewWord.Length; i++)
            {
                viewWord[i] = '*';
            }
        }
        public bool CheckLetterRepeat(char letterRepeat)
        {
            bool isLetterRepeat = false;
            for (int i = 0; i < charWord.Length; i++)
            {
                if (letterIsopen.Contains(letterRepeat))
                {
                    isLetterRepeat = true;
                    continue;
                }
            }
            return isLetterRepeat;
        }

        public bool CheckLetter(char letter)
        {
            bool isLetterExist = false;
            letterIsopen.Add(letter);
            for (int i = 0; i < charWord.Length; i++)
            {
                if (charWord[i] == letter)
                {
                    opennedLetters++;
                    viewWord[i] = letter;
                    charWord[i] = ' ';
                    isLetterExist = true;
                }
            }
            return isLetterExist;
        }
    }
}
