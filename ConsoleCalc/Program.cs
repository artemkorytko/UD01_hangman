using System;

namespace ConsoleCalc
{
    internal class Program
    {
        internal static void Main()
        {
            Calculate _calculate = new Calculate();

            string description = "This calculator works in two modes:\n" +
                                 "1. Here is an example in one line\n" +
                                 "2. Input via ENTER (an equal sign \'=\' is expected in end)\n" +
                                 "The following operators are supported: +, -, *, /, ^ (involution), '(' ')'\n" +
                                 "The transition between modes is semi-automatic\n\n" +
                                 "Features:\n" +
                                 "All words/letters will be equal to zero\n" +
                                 "\'.. + + ..\' is equal to \'.. + 0 + ..\'\n\n" +
                                 "Press any key to start\nESC to exit";
            var consoleColorBuffer = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(description);
            Console.ForegroundColor = consoleColorBuffer;
            
            if(Console.ReadKey().Key != ConsoleKey.Escape)
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Enter your example: ");
                    string example = Console.ReadLine();
                    
                    if (!example.ConatainOperators())
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Input via ENTER mode!");
                        Console.ForegroundColor = consoleColorBuffer;
                        Console.WriteLine(example);
                        example = Functions.WaitForEqualsSign(example);
                        Console.Clear();
                        Console.WriteLine($"You\'r example: \n{example}");
                        Console.WriteLine("Answer: " + _calculate.Init(example));
                    }
                    else
                        Console.WriteLine("Answer: " + _calculate.Init(example));
                        
                    //program exit
                    Console.WriteLine("\nESC to exit\nAny key to repeat");
                    if(Console.ReadKey().Key == ConsoleKey.Escape)
                        break;
                }
        }
    }
}