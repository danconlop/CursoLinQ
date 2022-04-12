using System;
using System.Linq;

namespace LinQMethodSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] factoriales = { 2, 2, 3, 5, 5 };

            // DISTINCT > solo trae los elementos que no se repitan en la lista
            int FactorialesUnicos = factoriales.Distinct().Count();

            Console.WriteLine($"Hay {FactorialesUnicos} factoriales unicos");

            // SUMA > suma de elementos
            int[] number = { 5, 4, 1, 4, 6, 34 };
            double numSum = number.Sum();

            Console.WriteLine($"La suma de los elementos es: {numSum}");

            // NUMERO MINIMO > devuelve el valor minimo de un listado
            // NUMERO MAXIMO > devuelve el valor máximo del listado
            int[] numbers2 = { 5, 4, 1, 4, 6, 34 };
            int minNum = numbers2.Min();
            int maxNum = numbers2.Max();

            Console.WriteLine($"El número más chico es: {minNum}");
            Console.WriteLine($"El número más grande es: {maxNum}");

            // Proyecciones en min y max
            string[] words = { "cherry", "apple", "banana" };
            int shortestWord = words.Min(w => w.Length);
            int longestWord = words.Max(w => w.Length);

            Console.WriteLine($"La palabra más corta tiene {shortestWord} caracteres");
            Console.WriteLine($"La palabra más larga tiene {longestWord} caracteres");

            // AVERAGE > 
            int[] numbers3 = { 5, 4, 1, 4, 6, 34 };
            double averageNum = numbers3.Average();

            Console.WriteLine($"El promedio de la lista es {averageNum}");

            // Proyecciones en AVERAGE
            double averageLenght = words.Average(w => w.Length);
            Console.WriteLine($"El promedio de caracteres es {averageLenght}");

            // Conversión de listas
            double[] doubles = { 1.4, 5.3, 5.2, 6.4 };
            var sortedDoubles = doubles.OrderBy(d => d);
            var doublesArray = sortedDoubles.ToArray();
            for (int i = 0; i < doublesArray.Length; i++)
            {
                Console.WriteLine(doublesArray[i]);
            }

            var doublesList = sortedDoubles.ToList();
            foreach(var d in doublesList)
            {
                Console.WriteLine(d);
            }

            // Conversión a diccionario
            var scoreRecord = new[] {
                new {Name = "Alice", Score = 50 },
                new {Name = "Bob", Score = 40},
                new {Name = "Cathy", Score = 45}
            };

            // El diccionario es una colección de llave y valor (la llave no se puede repetir, sino manda una excepcion)
            var scoreRecordDict = scoreRecord.ToDictionary(sr => sr.Name);

            Console.WriteLine("Bob's score: {0}", scoreRecordDict["Bob"]);

            // extraer datos obtenidos (f convierte a flotante, d convierte a doble, m convierte a decimal
            object[] numbersObjects = {null, 1.0m, "two", 3, "four", 5,"six",7.0d };

            var doubleObjects = numbersObjects.OfType<double>();

            Console.WriteLine("Numeros guardados como dobles");
            foreach(var d in doubleObjects)
            {
                Console.WriteLine(d);
            }

            var stringObjects = numbersObjects.OfType<string>();
            Console.WriteLine("Numeros guardados como strings");
            foreach (var s in stringObjects)
            {
                Console.WriteLine(s);
            }

            // Un elemento del listado
            string[] strings = { "zero", "one", "two", "three", "four", "five" };

            var theOne = strings.First(e => e == "one");
            var theFirstOne = strings.First();
            Console.WriteLine($"El primer elemento de la lista es {theFirstOne}");
            Console.WriteLine($"El primer elemento que coincide con 'one' es {theOne}");

            // tal vez exista un elemento del listado
            string[] strings2 = { };
            var maybeTheFirst = strings2.FirstOrDefault();
            var maybeTheFirst2 = strings2.FirstOrDefault() ?? "Nulo"; // Investigar que es ?? no es parte de linQ
            // Si el listado no tiene valores
            var maybeTheFirst3 = strings2.DefaultIfEmpty("Nulo").First();

            Console.WriteLine($"Maybe exists {maybeTheFirst}");

            // Obtener un objeto de la posición en un listado
            int[] numbers4 = { 5, 4, 1, 4, 6, 34 };
            var InPosition = numbers4.ElementAt(2);
            Console.WriteLine($"El elemento en la posición 2 es: {InPosition}");

            // Ordenamiento de listados
            var sortedStringsAsc = strings.OrderBy(c => c);
            var sortedStringsDesc = strings.OrderByDescending(c => c);
            var sortedMultipleTimes = strings
                .OrderBy(c => c[0])
                .ThenBy(c => c.Length);

            Console.WriteLine($"La lista ordenada ascendente es {string.Join(", ", sortedStringsAsc)}");
            // Toma la lista y la ordena al revez
            var sortedReverse = strings.Reverse();

            // Particiones en una lista
            int[] numbers5 = { 5, 4, 1, 8, 6, 4, 9, 0 };
            var first3Numbers = numbers5.Take(3);
            Console.WriteLine($"Los primeros 3 números son: {string.Join(", ", first3Numbers)}");

            var takeWhile = numbers5.TakeWhile(c => c > 3);
            //Console.WriteLine($"Los números mayores a 3 son: {string.Join(", ", takeWhile)}");

            Console.WriteLine("Tomará mientras la condición de que el numero sea mayor a 3 se cumpla");
            foreach(var num in takeWhile)
            {
                Console.WriteLine(num);
            }

            var allButFirst4Numbers = numbers5.Skip(4);
            Console.WriteLine($"Menos los 4 primeros elementos los números son: {string.Join(", ", allButFirst4Numbers)}");

            var skipWhile = numbers5.SkipWhile(c => c > 2);
            Console.WriteLine($"Tomará mientras la condición de que el numero sea mayor a 2 se cumpla: {string.Join(", ", skipWhile)}");

            // Proyecciones
            // Listado a partir de una clase anonima
            var selectList = strings.Select(c => new
            {
                Lenght = c.Length,
                Word = c
            });
            // Listado a partir de una clase definida
            var selectListWithEntity = strings.Select(c => new MyWord
            {
                Lenght = c.Length,
                Word = c
            });

            foreach(var str in selectListWithEntity)
            {
                Console.WriteLine($"La palabra: {str.Word} tiene longitud de {str.Lenght} caracteres");
            }

            // CONTAINS (regresa booleano si la condicion se cumple)
            var existeZero = strings.Contains("zero");
            Console.WriteLine(existeZero);

            // EQUALS
            var esIgual = strings.Any(c => c.Equals("Three"));
            Console.WriteLine(esIgual);

            // CONCAT (Une dos listados del mismo tipo de dato)
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = { 4, 5, 6 };
            foreach(var n in nums1.Concat(nums2))
            {
                Console.WriteLine(n);
            }
        }

        public class MyWord
        {
            public int Lenght { get; set; }
            public string Word { get; set; }
        }
    }
}
