using System;

namespace OOP_Base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person _person = new Person(25, "Ron");
            Person _secondPerson = new Person(18);

            Console.WriteLine($"Name: {_person.GetName()}  Age: {_person.age}");
            Console.WriteLine($"Name: {_secondPerson.GetName()}  Age: {_secondPerson.age}");

        }
    }

    internal class Person
    {
        public int age { get; private set; }
        private string name;

        public Person(int age)
        {
            this.age = age;
            this.name = "NONAME";
        }
        
        public Person(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}