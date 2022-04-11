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
            /*
            var millionareCustomers = customers
                .GroupBy(customer => customer.Bank)
                .Select(bank => new
                {
                    Bank = bank.Key,
                    Millonarios = bank.Where(customer => customer.Balance > 1000000)
                });
            */


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

        }
    }

    // Clase
    internal class Customer
    {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }

}
