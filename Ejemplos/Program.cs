using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Func recibe
            Func<int, int> square = x => x * x;
            // Action solo recibe valores (no devuelve)
            Action<string> action = x => Console.WriteLine(x);

            // Ejemplo
            int[] numbers = { 1, 3, 6, 8 };
            var squaredNumbers = numbers.Select(square);
            Console.WriteLine(String.Join(",", squaredNumbers));

            // Los actions pueden tambien declararse sin variables de entrada
            Action line = () => Console.WriteLine("Hola");

            Func<int, int, string> IsTooLong = (x, y) => x > y ? "Es mayor" : "Es menor";
            Console.WriteLine(IsTooLong(5,3));

            // A partir de C#7
            var tuplas = MisTuplas();
            Console.WriteLine($"{tuplas.EsCorrecto} Mensaje: {tuplas.Mensaje}");

            // Regresar multiples valores con tuplas en funciones lambda
            Func<int, int, (bool, string)> MiFunc = (x, y) => (x > y, "Mi mensaje");
            Func<int, int, (bool EsCorrecto, string Mensaje)> MiFunc2 = (x, y) => (x > y, "Mi mensaje");
            var x = MiFunc2(1, 2);
            Console.WriteLine($"{x.EsCorrecto} {x.Mensaje}");

            // Se pueden usar delegados con parametros descartados (C# 9)
            Func<int, int, int> constant = (_, _) => 42;
            Action<int, int> constant2 = (_, _) => Console.WriteLine(43);


            // Esto es un action con serie de declaraciones (statements)
            Action<int> miAccionAsincrona = miParametro => {
                Task.Delay(2000);
                Console.WriteLine("Me esperé 2000 milisegundos");
            };

            // Usando el metodo con cuerpo de expresion
            Console.WriteLine($"{IsTooLong(20, 15)}");
            Console.WriteLine(IsTooLong2(20, 15));

            // Un Action con método asincrono
            Action<int> miOtraAccionAsincrona = async parametro => await DelayConImpresion(parametro);


        }

        static (bool EsCorrecto, string Mensaje) MisTuplas()
        {
            return (true, "mensaje de prueba");
        }

        // Método con cuerpo de expresión
        static string IsTooLong2(int x, int y) => x > y ? "es mayor" : "es menor";

        // Método asincrono que es utilizado por el action con metodo asincrono
        static async Task DelayConImpresion(int x)
        {
            await Task.Delay(2000);
            Console.WriteLine("Me esperé 2000 milisegundos e imprimir " + x);
        }
    }
}
