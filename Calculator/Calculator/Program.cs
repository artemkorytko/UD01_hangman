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
            int MenuChange = Convert.ToInt32(Console.ReadLine());
            //Выбор вкладок меню
            do
            {
                switch (MenuChange)
                {                  
                    //Сам калькулятор
                    case 1:
                        string LeftString = "", RightString = "", Solve = "";
                        int z;
                        Console.Clear();
                        Console.WriteLine("Введите пример со знаком без пробелов");
                        string primer = (Console.ReadLine());
                        int Dlina = primer.Length;
                    //Решение примера
                        for (int i = 1; i < Dlina; i++)
                        {
                            if (primer[i] == '*')
                                {                               
                                for (z = i-1; z != -1; z--)
                                    {
                                    LeftString = primer[z] + LeftString;
                                    }
                                for (z = i + 1; z != primer.Length; z++)
                                {   
                                    RightString = RightString + primer[z];
                                }
                                Solve = Convert.ToString(int.Parse(LeftString) * int.Parse(RightString));               
                            }
                            if (primer[i] == '-')
                            {
                                for (z = i - 1; z != -1; z--)
                                {
                                    LeftString = primer[z] + LeftString;
                                }
                                for (z = i + 1; z != primer.Length; z++)
                                {
                                    RightString = RightString + primer[z];
                                }
                                Solve = Convert.ToString(int.Parse(LeftString) - int.Parse(RightString));
                            }
                            if (primer[i] == '+')
                            {
                                for (z = i - 1; z != -1; z--)
                                {
                                    LeftString = primer[z] + LeftString;
                                }
                                for (z = i + 1; z != primer.Length; z++)
                                {
                                    RightString = RightString + primer[z];
                                }
                                Solve = Convert.ToString(int.Parse(LeftString) + int.Parse(RightString));
                            }
                            if (primer[i] == '/')
                            {
                                for (z = i - 1; z != -1; z--)
                                {
                                    LeftString = primer[z] + LeftString;
                                }
                                for (z = i + 1; z != primer.Length; z++)
                                {
                                    RightString = RightString + primer[z];
                                }
                                Solve = Convert.ToString(int.Parse(LeftString) / int.Parse(RightString));
                            } 
                        }
                        Console.WriteLine(Solve);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    //Если введена не та цифра
                    default:
                        Console.Clear();
                        Console.WriteLine("Главное меню, выберите вкладку");
                        System.Console.WriteLine();
                        Console.WriteLine("1.Калькулятор");
                        MenuChange = Console.Read();
                    break;
                }
            }
            while (MenuChange != 1 || MenuChange != 2);
        }
    }
}

