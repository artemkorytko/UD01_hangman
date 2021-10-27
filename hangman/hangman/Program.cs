using System;

namespace hangman
{
    class Program
    {
        // массив с марками авто
        static string[] cars = new string[] { "Audi", "BMW", "Cadillac", "Citroen", "Peugeot", "Ford", "Mazda", "Lada", "Toyota", "Gaz" };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int a = 5, b = 4;
            float x = 0.03f, y = 1.15f;
            int i = 0;
            string country;

            // пример int
            Console.WriteLine("\n----------Example int----------");
            comparse(a, b);

            // пример float
            Console.WriteLine("\n----------Example float----------");
            Console.WriteLine(float_sum(x, y));


            // пример while
            Console.WriteLine("\n----------Example while----------");
            while (i < cars.Length)
            {
                Console.WriteLine("Current car is: "+ cars[i]);
                i++;
            }

            // пример do while
            i = 0;
            Console.WriteLine("\n----------Example do while----------");
            do
            {
                Console.WriteLine("Current car is: " + cars[i]);
                i++;
            }
            while (i < cars.Length);

            // пример for
            Console.WriteLine("\n----------Example for----------");
            for(i=0;i<cars.Length;i++)
            {
                Console.WriteLine("Current car is: ");
                // разбиваем на char
                for (int j = 0;j<cars[i].Length;j++)
                {
                    Console.WriteLine(cars[i][j]);
                }
                
            }

            // пример foreach
            Console.WriteLine("\n----------Example foreach----------");
            foreach(string car in cars)
            {
                Console.WriteLine("Current car is: " + car);
            }

            // пример if else
            Console.WriteLine("\n----------Example if else----------");
            foreach (string car in cars)
            {
                if(car == "Audi" || car == "BMW")
                {
                    country = "Germany";
                }
                else if(car == "Cadillac" || car == "Ford")
                {
                    country = "USA";
                }
                else if (car == "Citroen" || car == "Peugeot" )
                {
                    country = "France";
                }
                else if (car == "Mazda" || car == "Toyota")
                {
                    country = "Japan";
                }
                else if (car == "Lada" || car == "Gaz")
                {
                    country = "Russia";
                }
                else
                {
                    country = "unknown";
                }
                Console.WriteLine(car+" made in " + country);
            }

            // пример switch
            Console.WriteLine("\n----------Example switch----------");
            foreach (string car in cars)
            {
                switch (car)
                {
                    case "Audi":
                        Console.WriteLine(car + " made in Germany");
                        break;
                    case "BMW":
                        Console.WriteLine(car + " made in Germany");
                        break;
                    case "Cadillac":
                        Console.WriteLine(car + " made in USA");
                        break;
                    case "Citroen":
                        Console.WriteLine(car + " made in France");
                        break;
                    case "Peugeot":
                        Console.WriteLine(car + " made in France");
                        break;
                    case "Ford":
                        Console.WriteLine(car + " made in USA");
                        break;
                    case "Mazda":
                        Console.WriteLine(car + " made in Japan");
                        break;
                    case "Lada":
                        Console.WriteLine(car + " made in Russia");
                        break;
                    case "Toyota":
                        Console.WriteLine(car + " made in Japan");
                        break;
                    case "Gaz":
                        Console.WriteLine(car + " made in Russia");
                        break;
                }
            }

            //пример bool
            Console.WriteLine("\n----------Example bool----------");
            if (hasCar("Audi"))
            {
                Console.WriteLine("There is an audi");
            }
            else
            {
                Console.WriteLine("No audi");
            }

        }
        // Метод проверяет есть ли такая машина
        static bool hasCar(string name)
        {
            bool isCar = false;
            foreach (string car in cars)
            {
                if(name == car)
                {
                    isCar = true;
                }
            }
            return isCar;
        }
        // Метод сравнивает целые числа между собой
        static void comparse(int a, int b)
        {
            if (a < b)
            {
                Console.WriteLine("b is bigger");
            }
            else if (a == b)
            {
                Console.WriteLine("a and b are equal");
            }
            else
            {
                Console.WriteLine("a is bigger");
            }
           
        }
        // Метод суммирует float числа
        static float float_sum(float a, float b)
        {
            return a + b;
        }
    }
}
