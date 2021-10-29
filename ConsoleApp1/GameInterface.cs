using System;
using System.Diagnostics;

namespace ConsoleApp
{
    public class GameInterface
    {
        private string _viewWordCache = "";
        public void Print(int errorsQuantity,int errorCode, GameEvent gameEvent)
        {
            Print(_viewWordCache, errorsQuantity, errorCode, gameEvent);
        }
        public void Print(string viewWord, int errorsQuantity)
        {
            Print(viewWord, errorsQuantity, 0, GameEvent.Empty);
        }

        public void Print(string viewWord, int errorsQuantity, int errorCode, GameEvent gameEvent)
        {
            _viewWordCache = viewWord;
            Console.Clear();
            
            Console.WriteLine($"Я загадал слово из {viewWord.Length} букв");
            Console.WriteLine(viewWord);
            Console.Write("Введите букву: ");
            int[] cursorPosToEnter = new int[] {Console.CursorLeft, Console.CursorTop};
            
            Console.WriteLine();
            Console.WriteLine($"Осталось попыток: {errorsQuantity}");
            Console.WriteLine();

            bool gameEnded = false;
            
            switch (gameEvent)
            {
                case GameEvent.Error:
                    Console.Write("Ошибка ввода! ");
                    switch(errorCode)
                    {
                        case 1:
                            Console.WriteLine("Такая буква уже есть");
                            break;
                        default:
                            Console.WriteLine();
                            break;
                    }
                    break;
                case GameEvent.Win:
                    Console.WriteLine("Победа!");
                    gameEnded = true;
                    break;
                case GameEvent.Fail:
                    Console.WriteLine("Проиграл, попробуй снова!");
                    gameEnded = true;
                    break;
                case GameEvent.Empty:
                    break;
            }
            if (!gameEnded)
                Console.SetCursorPosition(cursorPosToEnter[0], cursorPosToEnter[1]);
            else
                Console.WriteLine("\nESC что бы выйти\nENTER для новой игры");
        }
        
        public enum GameEvent
        {
            Empty,
            Error,
            Win,
            Fail
        }
    }
}