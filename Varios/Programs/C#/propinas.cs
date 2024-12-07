using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, double> mapaPropinas = new Dictionary<string, double>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nIntroduce la cantidad total de propina a repartir (0 para salir): ");
            double propinaTotal = double.Parse(Console.ReadLine());

            if (propinaTotal == 0)
            {
                Console.WriteLine("Finalizando el reparto de propinas...");
                break;
            }

            Console.WriteLine("Introduce el número de empleados: ");
            int numEmpleados = int.Parse(Console.ReadLine());

            if (numEmpleados <= 0)
            {
                Console.WriteLine("El número de empleados debe ser mayor que cero.");
                continue;
            }

            double propinaPorEmpleado = Math.Floor(propinaTotal / numEmpleados * 100) / 100.0;
            double resto = propinaTotal - (propinaPorEmpleado * numEmpleados);

            for (int i = 0; i < numEmpleados; i++)
            {
                Console.WriteLine($"Introduce el nombre del empleado {i + 1}: ");
                string nombre = Console.ReadLine();

                if (mapaPropinas.ContainsKey(nombre))
                {
                    mapaPropinas[nombre] += propinaPorEmpleado;
                }
                else
                {
                    mapaPropinas[nombre] = propinaPorEmpleado;
                }
            }

            foreach (var key in new List<string>(mapaPropinas.Keys))
            {
                if (resto <= 0) break;
                mapaPropinas[key] += 0.01;
                resto -= 0.01;
            }

            Console.WriteLine("\nDistribución actual de propinas:");
            foreach (var entry in mapaPropinas)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value:F2} euros");
            }

            Console.WriteLine("\n¿Quieres repartir más propinas? (s/n): ");
            string respuesta = Console.ReadLine().Trim().ToLower();
            if (respuesta != "s")
            {
                continuar = false;
            }
        }

        Console.WriteLine("\nDistribución final de propinas:");
        foreach (var entry in mapaPropinas)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value:F2} euros");
        }
    }
}

