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
                    + "3.- Consulta Individual Por Clave o Nombre\n"
                    + "4.- Modificar Costo\n" 
                    + "5.- Modificar Tiempo de Trayecto\n"
                    + "6.- Imprimir Viajes Con Costo Menor A:\n"
                    + "7.- Imprimir Viajes Con Duración Menor A:\n"
                    + "8.- Salir");
                opcion = Validaciones.ValidaClave("opción");
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
                        programa.pcPresentacion.ConsultaIndividual();
                        break;
                    case 4:
                        programa.pcPresentacion.CambiarPrecio();
                        break;
                    case 5:
                        programa.pcPresentacion.CambiarTiempo();
                        break;
                    case 6:
                        programa.pcPresentacion.ConsultaMenorA("costo", opcion);
                        break;
                    case 7:
                        programa.pcPresentacion.ConsultaMenorA("tiempo de trayecto", opcion);
                        break;
                    case 8:
                        opcion = 8;
                        break;
                    default:
                        Console.WriteLine("****Opción no válida (1 - 8)****\n");
                        break;
                }
            } while (opcion != 8);
        }
    }
}
