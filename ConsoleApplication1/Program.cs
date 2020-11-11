using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private AdministraCiudad admCiudades = new AdministraCiudad();
        static void Main(string[] args)
        {
            Program c = new Program();
            PresentacionCiudad presentacion;
            bool a = false;
            int b = 0;
            Console.WriteLine("*************MENÚ*************");
            do
            {
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("1.- Agregar Ciudad de Destino\n"
                    + "2.- Consultar Ciudades de Destino\n"
                    + "3.- Consulta Individual\n"
                    + "4.- Modificar Costo\n"
                    + "5.- Salir");
                b = Convert.ToInt32(Console.ReadLine());
                switch (b)
                {
                    case 1:
                        presentacion = new PresentacionCiudad(c.admCiudades);
                        presentacion.AltaDestinos();
                        break;
                    case 2:
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Ciudades:");
                        presentacion = new PresentacionCiudad(c.admCiudades);
                        presentacion.MuestraCiudades();
                        Console.WriteLine("---------------------------------------------------");
                        break;
                    case 4:
                        break;
                    case 5:
                        a = true;
                        break;
                }
            } while (a == false);
        }
    }
}
