using System;

namespace ConsoleApplication1
{
    class Program
    {
        // Objetos
        private AdministraCiudad admCiudades;
        private PresentacionCiudad pcPresentacion;

        // Constructor que asigna el objeto admCiudades a pcPresentacion
        public Program()
        {
            admCiudades = new AdministraCiudad();
            pcPresentacion = new PresentacionCiudad(admCiudades);
        }

        // Main
        public static void Main(string[] args)
        {
            Program programa = new Program();
            int opcion = 0;

            do
            {
                Console.WriteLine("****************MENÚ****************");
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1.- Agregar Ciudad de Destino\n"
                    + "2.- Consultar Ciudades de Destino\n"
                    + "3.- Consulta Individual\n"
                    + "4.- Modificar Costo\n"
                    + "5.- Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (opcion)
                {
                    case 1:
                        programa.pcPresentacion.AltaDestinos();
                        Console.WriteLine();
                        break;
                    case 2:
                        programa.pcPresentacion.MuestraDestinos();
                        break;
                    case 3:
                        programa.pcPresentacion.ViajeClave();
                        break;
                    case 4:
                        programa.pcPresentacion.CambiarPrecio();
                        break;
                    case 5:
                        opcion = 5;
                        break;
                    default:
                        Console.WriteLine("****Opción no válida (1 - 5)****\n");
                        break;
                }
            } while (opcion != 5);
        }
    }
}
