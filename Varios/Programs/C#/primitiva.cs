using System;
using System.Collections.Generic;
using System.Linq;

class NumerosPrimitiva
{
    static void Main(string[] args)
    {
        MostrarMenu();
    }

    static void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("\nMENÚ");
            Console.WriteLine("1 - Generar combinaciones de la Primitiva");
            Console.WriteLine("2 - Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    GenerarCombinaciones();
                    break;
                case 2:
                    Console.WriteLine("¡Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        } while (opcion != 2);
    }

    static void GenerarCombinaciones()
    {
        Console.Write("Número de participantes: ");
        int participantes = int.Parse(Console.ReadLine());

        for (int i = 1; i <= participantes; i++)
        {
            var combinacion = CalcularCombinacionGanadora();
            Console.WriteLine($"\nParticipante {i}");
            Console.WriteLine($"Combinación: {string.Join(", ", combinacion)}");
        }
    }

    static List<int> CalcularCombinacionGanadora()
    {
        Random random = new Random();
        HashSet<int> primitiva = new HashSet<int>();

        while (primitiva.Count < 6)
        {
            primitiva.Add(random.Next(1, 50));
        }

        var combinacion = primitiva.ToList();
        combinacion.Sort();
        return combinacion;
    }
}