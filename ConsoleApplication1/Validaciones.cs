using System;

namespace ConsoleApplication1
{
    class Validaciones
    {
        // Valida que no se dejen espacios en blanco
        public static string ValidaBlancos()
        {
            string t = Console.ReadLine().ToUpper();
            while (string.IsNullOrWhiteSpace(t))
            {
                Console.WriteLine("No se aceptan espacios en blanco.");
                Console.WriteLine("Ingrese un dato válido");
                t = Console.ReadLine();
            }
            return t;
        }

        // Valida claves
        public static int ValidaClave()
        {
            int a = -1;
            while (a < 0)
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a < 0)
                    {
                        Console.WriteLine("Ingrese clave válida");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Ingrese clave válida");
                }

            }
            return a;
        }

        // Valida entrada de hora y costo válidos
        public static double ValidaHoraCosto(string tipo)
        {
            double a = -1;
            while (a < 0)
            {
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                    if (a < 0)
                    {
                        Console.WriteLine($"Ingrese {tipo} válido");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Ingrese {tipo} válido");
                }

            }
            return a;
        }
    }
}
