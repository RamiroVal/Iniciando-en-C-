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
            Console.WriteLine("-----------------------AÑADIR CIUDAD----------------------");
            Console.WriteLine("Alta de Destinos");
            Console.WriteLine("Clave del Destino:");
            int clave = Convert.ToInt32(Console.ReadLine());
            while (ciudades.EstaClave(clave))
            {
                Console.WriteLine("Clave existente, ingrese otra clave:");
                clave = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Ingrese el nombre del destino:");
            string nombreDestino = Console.ReadLine().ToUpper();
            Console.WriteLine("Ingrese el tiempo del trayecto:");
            double tiempo = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese el costo del viaje:");
            double costo = Convert.ToDouble(Console.ReadLine());
            ciudades.AgregaCiudades(clave, nombreDestino, tiempo, costo);
            Console.WriteLine("----------------------------------------------------------\n\n");
        }

        public void MuestraCiudades()
        {
            Console.WriteLine("-------------------------CIUDADES-------------------------");
            if (ciudades.pVacia)
            {
                Console.WriteLine("****No se han añadido ciudades****");
                Console.WriteLine("----------------------------------------------------------\n\n");
            }
            else
            {
                string[,] datos = ciudades.Ciudades();
                for (int i = 0; i < ciudades.pTotalCiudades; i++)
                {
                    Console.WriteLine("Clave: " + datos[i, 0]
                        + "\nCiudad Destino: " + datos[i,1]
                        + "\nTiempo de Viaje: " + datos[i,2]
                        + "\nCosto: $" + datos[i,3]);
                    Console.WriteLine("----------------------------------------------------------");
                }
                Console.WriteLine("\n");
            }
           
        }

        public void CambiarPrecio()
        {
            Console.WriteLine("----------------------CAMBIAR PRECIO----------------------");
            if (ciudades.pVacia)
            {
                Console.WriteLine("****No se han añadido ciudades****");
            }
            else
            {
                Console.WriteLine("Ingrese el nombre de la ciudad:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo precio");
                double precio = Convert.ToDouble(Console.ReadLine());
                if (ciudades.CambiaPrecioPorNombre(nombre, precio))
                {
                    Console.WriteLine("\n----------------------------------------------------------");
                    Console.WriteLine("Se ha cambiado el costo de {0}", nombre);
                }
                else
                {
                    Console.WriteLine("\n----------------------------------------------------------");
                    Console.WriteLine("****No se ha podido cambiar el costo****");
                }
            }
            Console.WriteLine("----------------------------------------------------------\n");
        }


        public void CiudadClave()
        {
            Console.WriteLine("----------------------CIUDAD POR CLAVE--------------------");
            if (ciudades.pVacia)
            {
                Console.WriteLine("****No se han añadido ciudades****");
                Console.WriteLine("----------------------------------------------------------\n\n");
            }
            else
            {
                Console.WriteLine("Ingrese la clave de la ciudad que desea consultar");
                int clave = Convert.ToInt32(Console.ReadLine());
                if (ciudades.EstaClave(clave))
                {
                    Console.WriteLine(ciudades.DatosCiudad(clave));
                    Console.WriteLine("----------------------------------------------------------\n\n");
                }else
                {
                    Console.WriteLine("****Clave inexistente****");
                    Console.WriteLine("----------------------------------------------------------\n\n");
                }
            }
        }



    }
}
