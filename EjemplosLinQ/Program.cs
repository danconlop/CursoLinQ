using System;
using System.Collections.Generic;
using System.Linq;

namespace EjemplosLinQ
{
    class Program
    {
        private static List<Student> students = new List<Student>
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
        static void Main(string[] args)
        {
            
            // PRIMER EJEMPLO DE LINQ
            
            // Primer ejemplo de LinQ (las estructuras se comportan como entidades (tablas)
            /*
            int[] scores = { 94, 76, 95, 67, 45 };

            // Resultado simple usando LinQ to objects en formato query expression
            //IEnumerable<int> scoreQuery = from score in scores
            //                              where score > 70
            //                              select score;

            // Manipulacion de resultados (en el SELECT)
            IEnumerable<int> scoreQuery = from score in scores
                                          where score > 70
                                          select score * score;

            // LinQ con expresión Lambda
            var scoreQueryLambda = scores
                .Where(score => score > 70)
                .Select(score => score * score);
            
            foreach (var i in scoreQueryLambda)
            {
                Console.Write($"{i} ");
            }
            */



            /* SELECT, ORDERBY 
             */
            /*
            var studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Scores[0] descending
                select student;

            foreach(var student in studentQuery)
            {
                Console.WriteLine($"{student.LastName} {student.FirstName} {student.Scores[0]}");
            }

            var studentQueryLambda = studentQuery
                .Where(student => student.Scores[0] > 90 && student.Scores[3] < 80)
                .OrderByDescending(student => student.Scores[0]);
            */


            // TODO: comparar cada calificacion que sea mayor a 50
            
            var studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Scores[0] descending
                select student;

            foreach (var student in studentQuery)
            {
                Console.WriteLine($"{student.LastName} {student.FirstName} {student.Scores[0]}");
            }
            
            
            var studentQueryLambdaX = studentQuery
                .Where(student => student.Scores.All(score => score > 80)) // Todas las calificaciones mayores a 80
                // .Where(student => student.Scores.Any(score => score > 80)) // Con que una de las calificaciones sea mayor a 80, se regresa el valor
                .OrderByDescending(student => student.Scores[0]);
            

            // GROUP BY
            
            var studentQuery2 =
                from student in students
                group student by student.LastName[0]
                into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            var studentQuery2Lambda = students
                .GroupBy(student => student.LastName[0])
                .OrderBy(group => group.Key);

            foreach(var studentGroup in studentQuery2)
            {
                Console.WriteLine($"{studentGroup.Key}");

                foreach(var student in studentGroup)
                {
                    Console.WriteLine($"Apellido: {student.LastName} Nombre: {student.FirstName}");
                }
            }
            

            /* se puede utilizar LinQ para realizar operaciones ddentro de la comparacion y ademas regresar el
             * valor deseado ya formateado*/
            IEnumerable<string> studentQuery3 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                where totalScore / 4 < student.Scores[0]
                                select $"{student.FirstName} {student.LastName} TotalScore: {totalScore/4} Score 0: {student.Scores[0]}";

            var studentQuery3Lambda = students
                .Where(student => (student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]) / 4 < student.Scores[0])
                .Select(student => $"{student.FirstName} {student.LastName}");

            foreach(var student in studentQuery3)
            {
                Console.WriteLine(student);
            }

            // SIN HACER ITERACION CON CADA ELEMENTO DEL LISTADO SCORES, SE USA LA FUNCION DE LINQ SUM()
            IEnumerable<string> studentQuery4 = from student in students
                                                let totalScore = student.Scores.Sum()
                                                where totalScore / 4 < student.Scores[0]
                                                select $"{student.FirstName} {student.LastName} TotalScore: {totalScore / 4} Score 0: {student.Scores[0]}";

            var studentQuery4Lambda = students
                .Where(student => student.Scores.Sum() / 4 < student.Scores[0])
                .Select(student => $"{student.FirstName} {student.LastName}");

            foreach (var student in studentQuery4)
            {
                Console.WriteLine(student);
            }


            // FUNCIONES DENTRO DE LINQ Y LAMBDA
            IEnumerable<string> studentQuery5 = from student in students
                                                let totalScore = student.Scores.Average()
                                                where totalScore < student.Scores[0]
                                                select $"{student.FirstName} {student.LastName} TotalScore: {totalScore} Score 0: {student.Scores[0]}";

            var studentQuery5Lambda = students
                .Where(student => student.Scores.Average() < student.Scores[0])
                .Select(student => $"{student.FirstName} {student.LastName}");

            foreach (var student in studentQuery5)
            {
                Console.WriteLine(student);
            }
            // Sacar el promedio de toda la clase
            var promedio = students.Average(student => student.Scores.Average());
            Console.WriteLine($"Promedio general: {promedio}");

            // Consultas LinQ con variables externas a ellas
            var lastname = "Garcia";
            var studentQuery6 = from student in students
                                where student.LastName.Equals(lastname)
                                select student.FirstName;

            Console.WriteLine("Todos los García de la lista son: ");
            Console.WriteLine(string.Join(", ", studentQuery6));

            var studentQuery6Lambda = students
                .Where(student => student.LastName.Equals(lastname))
                .Select(student => student.FirstName);


            // Podemos crear nuevos objetos a partir de la consulta
            var promedio = students.Average(student => student.Scores.Average());
            var studentQuery7 = from student in students
                                let totalScore = student.Scores.Sum()
                                where totalScore > promedio
                                select new { Id = student.ID, Score = totalScore };

            var studentQuery7Lambda = students
                .Where(student => student.Scores.Sum() > promedio)
                .Select(student => new
                {
                    Id = student.ID,
                    Score = student.Scores.Sum()
                });

            //var primerEstudianteFiltrado = studentQueryLambdaX.First();
            Student primEstudianteFiltrado = studentQueryLambdaX.Where(c => c.ID > 1000).FirstOrDefault(); // Para que no arroje excepcion si no hay elementos en la lista
            Console.WriteLine(primEstudianteFiltrado == null ? "es nulo" : primEstudianteFiltrado.FirstName);

            //var ultimoEstudianteFiltrado = studentQueryLambdaX.Last();
            //Student ultEstudianteFiltrado =

            //Student primEstudianteFiltradoSinResultadosReducido = studentQueryLambdaX.FirstOrDefault(c => c.ID > 1000);

            Student single = studentQueryLambdaX
                .Single(c => c.ID > 1000); //Tambien hay SingleOrDefault
            
            foreach (var item in studentQuery7)
            {
                Console.WriteLine($"Student ID: {item.Id} Score: {item.Score}");
            }
            



        }
    }
}

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public List<int> Scores { get; set; }
}
