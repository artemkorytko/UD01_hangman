using System;

public class Program
{
    static void Main (string[] args)
    {
        Console.WriteLine("Hello, World");
        string aFriend = "Bill";
        Console.WriteLine(aFriend);
        aFriend = "Loura";
        Console.WriteLine(aFriend);
        Console.WriteLine("Hello" + aFriend);
        Console.WriteLine($"Hello {aFriend}");
        string firstFriend = "Maria";
        string secondFriend = "Anna";
        Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");
        Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters.");
        Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters.");
        int a = 5;
        int b = 15;
        int c = a * b;
        Console.WriteLine(c);
        int v = 4;
        int d = 15;
        int s = 21;
        int p = (v * d) - s;
        Console.WriteLine(p);
        int a = 3;
        int b = 4;
        if (a + b > 10)
            Console.WriteLine("The answer is greater that 10");
        else
            Console.WriteLine("The answer is not greater that 10");
        int counter = 0;
        while (counter < 10)
        {
            Console.WriteLine($"Hello World! The counter is {counter}");
            counter++;
        }
        int counter = 0;
        do
        {
            Console.WriteLine($"Hello World! The counter is {counter}");
            counter++;
        } while (counter < 10);
        for (int counter = 0; counter < 10; counter++)
        {
            Console.WriteLine($"Hello World! The counter is {counter}");

        }
        var names = new List<string> { "<name>", "Ana", "Felipe" };
        foreach (var name is names) 
        {
            Console.WriteLine($"Hello {name.ToUpper()}!");
        }
    }

}
