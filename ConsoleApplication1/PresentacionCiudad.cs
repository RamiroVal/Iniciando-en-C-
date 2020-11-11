using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PresentacionCiudad
    {
        private AdministraCiudad ciudades;

        public PresentacionCiudad(AdministraCiudad c)
        {
            ciudades = c;
        }

        public void AltaDestinos()
        {
            Console.WriteLine("Alta de Destinos");
            Console.WriteLine("Clave del Destino:");
            int clave = Convert.ToInt32(Console.ReadLine());
            if (!ciudades.EstaClave(clave))
            {
                Console.WriteLine("Ingrese el nombre del destino:");
                string nombreDestino = Console.ReadLine();
                Console.WriteLine("Ingrese el tiempo del trayecto:");
                double tiempo = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ingrese el costo del viaje:");
                double costo = Convert.ToDouble(Console.ReadLine());
                ciudades.AgregaCiudades(clave, nombreDestino, tiempo, costo);
            }else
            {
                Console.WriteLine("Clave existente.");
            }
        }

        public void MuestraCiudades()
        {
            ciudades.MuestraCiudades();
        }
    }
}
