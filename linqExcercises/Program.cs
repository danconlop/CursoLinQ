using System;
using System.Collections.Generic;
using System.Linq;

namespace linqExcercises
{
    class Program
    {
        /*
        // EJERCICIOS 01
        // Find the words in the collection that start with the letter 'L'
        static List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

        // Which of the following numbers are multiples of 4 or 6
        static List<int> mixedNumbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        // Output how many numbers are in this list
        static List<int> numbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };
        */

        static void Main(string[] args)
        {
            /*
            // EJERCICIOS 01
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            // Which of the following numbers are multiples of 4 or 6
            List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            // Output how many numbers are in this list
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            // Find the words in the collection that start with the letter 'L'
            var fruitQueryStartWith = fruits
                .Where(fruit => fruit.StartsWith("L"));

            Console.WriteLine($"Fruits starting with L: {string.Join(", ", fruitQueryStartWith)}");

            // Which of the following numbers are multiples of 4 or 6
            var numberMultipleof4and6 = mixedNumbers
                .Where(mixedNumber => mixedNumber % 4 == 0 || mixedNumber % 6 == 0);

            Console.WriteLine($"\nNumbers multiple by 4 or 6: {string.Join(", ", numberMultipleof4and6)}");

            // Output how many numbers are in this list
            var numberInList = numbers.Count;

            Console.WriteLine($"\nNumbers in List: {numberInList}");
            */

            // EJERCICIOS 02
            /*
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            // Despliega cuantos millonarios hay por banco (group by!!)
            var millionaresPerBank = customers
                .Where(customer => customer.Balance > 1000000)
                .GroupBy(customer => customer.Bank)
                .OrderBy(group => group.Key);

            foreach(var bank in millionaresPerBank)
            {
                Console.WriteLine($"{bank.Key}");
                foreach(var customer in bank)
                {
                    Console.WriteLine($"Customer: {customer.Name} Balance: {customer.Balance}");
                }
            }

            // SOLUCION TUTOR
            
            //var millionareCustomers = customers
            //    .GroupBy(customer => customer.Bank)
            //    .Select(bank => new
            //    {
            //        Bank = bank.Key,
            //        Millonarios = bank.Where(customer => customer.Balance > 1000000)
            //    });
           


            // Despliega a los clientes que su balance es mayor a 100,000
            Console.WriteLine($"\nCUSTOMERS BALANCE BIGGER THAN 100,000");
            var balanceHundreds = customers
                .Where(customer => customer.Balance > 100000);

            foreach(var customer in balanceHundreds)
            {
                Console.WriteLine($"Customer: {customer.Name} Balance: {customer.Balance}");
            }

            // Ordenar clientes por su balance
            Console.WriteLine($"\nCUSTOMERS ORDERED BY BALANCE");
            var orderedByBalance = customers
                .OrderBy(customer => customer.Balance);

            foreach(var customer in orderedByBalance)
            {
                Console.WriteLine($"Customer: {customer.Name} Balance: {customer.Balance}");
            }


            // Hacer una sumatoria por riqueza por cada banco (group by)
            Console.WriteLine($"\nSUM BY BANK");
            var sumByBank = customers
                .GroupBy(customer => customer.Bank)
                .Select(group => new
                {
                    Bank = group.Key,
                    Total = group.Sum(customer => customer.Balance)
                });

            foreach (var bank in sumByBank)
            {
                Console.WriteLine($"Bank: {bank.Bank} Total: {bank.Total}");
            }

            // Obtener el nombre de los clientes que su balance sea menor a 100,000 y su banco tenga solo 3 caracteres
            Console.WriteLine($"\nBALANCE LOWER THAN 100,000 AND BANK NAME LESS THAN 3 CHARS");
            var balanceLower = customers
                .Where(customer => customer.Balance < 100000 && customer.Bank.Length == 3)
                .OrderBy(customer => customer.Bank);

            foreach(var customer in balanceLower)
            {
                Console.WriteLine($"Customer: {customer.Name} Balance: {customer.Balance} Bank: {customer.Bank}");
            }
            */

            // EJERCICIOS 03
            /*
            string[] cities =
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

            // B.1 Find the string which starts and ends with a specific character : AM
            Console.WriteLine("B.1 Find the string which starts and ends with a specific character : AM");
            var result1 = cities
                .Where(city => city.StartsWith("AM") && city.EndsWith("AM"));

            foreach(var city in result1)
            {
                Console.WriteLine(city);
            }

            // B.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.
            // TODO: ascending order!!!
            Console.WriteLine($"\nB.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.");
            var result2 = cities
                .OrderBy(city => city.Length)
                .ThenBy(city => city.Substring(0, 1));

            foreach(var city in result2)
            {
                Console.WriteLine($"City Name: {city}");
            }

            // B.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.
            // TODO: finish it!
            Console.WriteLine($"\nB.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.");
            var result3 = cities
                .GroupBy(group => group.Take(cities.Length / 3));

            foreach(var group in result3)
            {
                Console.WriteLine("GRUPO");
                foreach(var city in group)
                {
                    Console.WriteLine(city);
                }
            }
            */

            /*
            // EJERCICIOS 4
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            // C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
            Console.WriteLine("Number and frequency");
            var result1 = arr1
                .OrderBy(c => c)
                .GroupBy(c => c)
                .Select(group => new
                {
                    Number = group.Key,
                    Frequency = group.Count()
                });

            foreach(var number in result1)
            {
                Console.WriteLine($"Number: {number.Number} Frequency: {number.Frequency}");
            }


            // C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
            var result2 = arr1
                //.OrderBy(c => c)
                .GroupBy(c => c)
                .Where(group => group.Count()==1)
                .Select(group => new
                {
                    Number = group.Key,
                });

            Console.WriteLine("\nList of unrepeated numbers: ");
            foreach(var number in result2)
            {
                Console.WriteLine(number.Number);
            }

            // C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
            Console.WriteLine($"\nNumbers, Multiplication and Frequency");
            var result3 = arr1
                .GroupBy(c => c)
                .Select(group => new
                {
                    Number = group.Key,
                    Frequency = group.Count(),
                    Multiplication = group.Key * group.Count()
                });

            foreach (var number in result3)
            {
                Console.WriteLine($"Number: {number.Number} Frequency: {number.Frequency} Multiplication: {number.Multiplication}");
            }
            */

            // EJERCICIOS 5
            List<Student> students = new List<Student>
            {
                new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
            };

            // D.1 Get the top student of the list making an average of their scores.
            var result1 = students
                .OrderBy(student => student.Scores.Average())
                .Last();

            Console.WriteLine($"Best student\nName: {result1.FirstName} Score: {result1.Scores.Average()}");

            // D.2 Get the student with the lowest average score.
            var result2 = students
                .OrderBy(student => student.Scores.Average())
                .First();

            Console.WriteLine($"\nLowest score student\nName: {result2.FirstName} Score: {result2.Scores.Average()}");

            // D.3 Get the last name of the student that has the ID 117
            var result3 = students.FirstOrDefault(student => student.ID.Equals(117));
            Console.WriteLine($"\nID 117 Lastname: {result3.LastName}");

            // D.4 Get the first name of the students that have any score more than 90
            var result4 = students
                .Where(student => student.Scores.Max() > 90)
                .OrderBy(student => student.Scores.Max());

            Console.WriteLine($"\nStudents with at least a score more than 90");
            foreach(var student in result4)
            {
                Console.WriteLine($"First name {student.FirstName} Score {student.Scores.Max()}");
            }

        }
    }

    // Clase
    /*
    internal class Customer
    {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }
    */

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }

}
