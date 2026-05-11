using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Laba6
{
    // ================= TASK 1 =================
    interface IPlace
    {
        string Name { get; }
        int Population { get; }
        void Show();
    }

    class Region : IPlace
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Districts { get; set; }

        public Region(string name, int population, int districts)
        {
            Name = name;
            Population = population;
            Districts = districts;
        }

        public void Show()
        {
            Console.WriteLine($"[Region] {Name}, pop={Population}, districts={Districts}");
        }
    }

    class City : IPlace
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Schools { get; set; }

        public City(string name, int population, int schools)
        {
            Name = name;
            Population = population;
            Schools = schools;
        }

        public void Show()
        {
            Console.WriteLine($"[City] {Name}, pop={Population}, schools={Schools}");
        }
    }

    class Megapolis : IPlace
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int MetroStations { get; set; }

        public Megapolis(string name, int population, int metro)
        {
            Name = name;
            Population = population;
            MetroStations = metro;
        }

        public void Show()
        {
            Console.WriteLine($"[Megapolis] {Name}, pop={Population}, metro={MetroStations}");
        }
    }

    // ================= TASK 3 =================
    interface IPhoneBook
    {
        void Show();
        bool Match(string surname);
    }

    class Person : IPhoneBook
    {
        string surname;
        string address;
        string phone;

        public Person(string s, string a, string p)
        {
            surname = s;
            address = a;
            phone = p;
        }

        public void Show()
        {
            Console.WriteLine($"Person: {surname}, {address}, {phone}");
        }

        public bool Match(string s) => surname == s;
    }

    class Friend : IPhoneBook
    {
        string surname;
        string phone;

        public Friend(string s, string p)
        {
            surname = s;
            phone = p;
        }

        public void Show()
        {
            Console.WriteLine($"Friend: {surname}, {phone}");
        }

        public bool Match(string s) => surname == s;
    }

    class Organization : IPhoneBook
    {
        string name;
        string phone;
        string contact;

        public Organization(string n, string p, string c)
        {
            name = n;
            phone = p;
            contact = c;
        }

        public void Show()
        {
            Console.WriteLine($"Org: {name}, {phone}, {contact}");
        }

        public bool Match(string s) => name == s;
    }

    // ================= TASK 4 =================
    sealed partial class MyClass : IEnumerable<int>
    {
        private int[] data;

        public MyClass(int size)
        {
            data = new int[size];
            for (int i = 0; i < size; i++)
                data[i] = i + 1;
        }

        public void Show()
        {
            Console.WriteLine("MyClass: " + string.Join(" ", data));
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var x in data)
                yield return x;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class Program
    {
        static void Task1()
        {
            IPlace[] places =
            {
                new Region("Odesa", 1500000, 5),
                new Region("Lviv", 2000000, 7),
                new City("Kyiv", 3000000, 500),
                new Megapolis("Tokyo", 14000000, 40)
            };

            var sorted = places.OrderBy(p => p.Population);

            foreach (var p in sorted)
                p.Show();
        }

        static void Task2()
        {
            MyClass a = new MyClass(3);
            a.Show();

            Console.WriteLine("foreach:");
            foreach (var x in a)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        static void Task3()
        {
            IPhoneBook[] book =
            {
                new Person("Ivanov", "Kyiv", "111"),
                new Friend("Petrenko", "222"),
                new Organization("Google", "333", "John")
            };

            foreach (var b in book)
                b.Show();

            Console.WriteLine("Search Petrenko:");
            foreach (var b in book)
                if (b.Match("Petrenko"))
                    b.Show();
        }

        static void Task4()
        {
            Console.WriteLine("Task 4 completed (sealed + partial + IEnumerable)");
        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n1-Task1 2-Task2 3-Task3 4-Task4 0-Exit");
                string input = Console.ReadLine();

                if (input == "0")
                    break;

                switch (input)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "4": Task4(); break;
                }
            }

            Console.WriteLine("Program finished");
        }
    }
}
