using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Главное меню, выберите вкладку");
            System.Console.WriteLine();
            Console.WriteLine("1.Калькулятор");
            Console.WriteLine("2.Достижения");
            int MenuChange = int.Parse(Console.ReadLine());

                switch (MenuChange)
                {
                    //Сам калькулятор
                    case 1:

                        Console.Clear();

                        break;
                    //Меню с достижениями
                    case 2:

                        break;
                    //Если введена не та цифра
                    default:
                        Console.Clear();
                        Console.WriteLine("Главное меню, выберите вкладку");
                        System.Console.WriteLine();
                        Console.WriteLine("1.Калькулятор");
                        Console.WriteLine("2.Достижения");
                        MenuChange = int.Parse(Console.ReadLine());
                    break;
                }
            }

            //Выбор вкладок меню
            
        }
    }
}

