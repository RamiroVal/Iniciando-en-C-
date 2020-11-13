using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        AdministraCiudad admCiudades = new AdministraCiudad();
        static void Main(string[] args)
        {
            Program programa = new Program();
            PresentacionCiudad presentacion = new PresentacionCiudad(programa.admCiudades);
            bool a = false;

            do
            {
                Console.WriteLine("****************MENÚ****************");
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1.- Agregar Ciudad de Destino\n"
                    + "2.- Consultar Ciudades de Destino\n"
                    + "3.- Consulta Individual\n"
                    + "4.- Modificar Costo\n"
                    + "5.- Salir");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (opcion)
                {
                    case 1:
                        presentacion.AltaDestinos();
                        Console.WriteLine();
                        break;
                    case 2:
                        presentacion.MuestraCiudades();
                        break;
                    case 3:
                        presentacion.CiudadClave();
                        break;
                    case 4:
                        presentacion.CambiarPrecio();
                        break;
                    case 5:
                        a = true;
                        break;
                }
            } while (a == false);
        }
    }
}
