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
            //Выбор вкладок меню
            do
            {
                switch (MenuChange)
                {
                    //Сам калькулятор
                    case 1:
                        string LeftString = "", RightString = "", Solve = "";
                        int z, answer;
                        Console.Clear();
                        Console.WriteLine("Введите пример со знаками без пробелов");
                        string primer = (Console.ReadLine());
                        int Dlina = primer.Length;
                    //Решение примера
                        for (int i = 1; i < Dlina; i++)
                        {
                            if (primer[i] == '*')
                                {                               
                                for (z = i; z != '*' || z != '/' || z != '-' || z != '+'; z--)
                                    {
                                    LeftString = primer[z] + LeftString;
                                    }
                                for (z = i; z != '*' || z != '/' || z != '-' || z != '+'; z++)
                                {
                                    RightString = RightString + primer[z];
                                }
                                Solve = Convert.ToString(int.Parse(LeftString) * int.Parse(RightString));
                                
                            }
                        }

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
            while (MenuChange != 1 || MenuChange != 2);
        }
    }
}

