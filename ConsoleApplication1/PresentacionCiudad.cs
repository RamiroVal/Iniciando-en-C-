using System;

namespace ConsoleApplication1
{
    class PresentacionCiudad
    {
        // Objeto de AdministraCiudad guardar los datos
        private AdministraCiudad ciudades;

        // Constructor
        public PresentacionCiudad(AdministraCiudad c)
        {
            ciudades = c;
        }

        // Muestra en consola una interfaz para dar de alta ciudades.
        public void AltaDestinos()
        {
            Console.WriteLine("-----------------------AÑADIR CIUDAD----------------------");
            Console.WriteLine("Alta de Destinos");
            Console.WriteLine("Clave del Destino:");
            int clave = Validaciones.ValidaClave();
            while (ciudades.EstaClave(clave))
            {
                Console.WriteLine("Clave existente, ingrese otra clave:");
                clave = Validaciones.ValidaClave();
            }
            Console.WriteLine("Ingrese la ciudad de destino:");
            string nombreDestino = Validaciones.ValidaBlancos();
            while (ciudades.EstaCiudad(nombreDestino))
            {
                Console.WriteLine("Ciudad de destino existente, ingrese otro nombre:");
                nombreDestino = Validaciones.ValidaBlancos();
            }
            Console.WriteLine("Ingrese el tiempo del trayecto:");
            double tiempo = Validaciones.ValidaHoraCosto("hora");
            Console.WriteLine("Ingrese el costo del viaje:");
            double costo = Validaciones.ValidaHoraCosto("costo");
            ciudades.AgregaCiudades(clave, nombreDestino, tiempo, costo);
            Console.WriteLine("----------------------------------------------------------\n\n");
        }

        // Muestra en consola los destinos agregadas hasta el momento.
        public void MuestraDestinos()
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
                    Console.WriteLine($"Clave: {datos[i, 0]}" 
                        + $"\nCiudad Destino: {datos[i, 1]}" 
                        + $"\nTiempo de Viaje: {datos[i, 2]}" 
                        + $"\nCosto: ${datos[i, 3]}");
                    Console.WriteLine("----------------------------------------------------------");
                }
                Console.WriteLine("\n");
            }
           
        }

        // Muestra en consola una interfaz para cambiar el precio de un destino.
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
                string nombre = Console.ReadLine().ToUpper();
                Console.WriteLine("Ingrese el nuevo precio");
                double precio = Convert.ToDouble(Console.ReadLine());
                if (ciudades.CambiaPrecioPorNombre(nombre, precio))
                {
                    Console.WriteLine("\n----------------------------------------------------------");
                    Console.WriteLine($"Se ha cambiado el costo de {nombre} a ${String.Format("{0:0.00}", precio)}");
                }
                else
                {
                    Console.WriteLine("\n----------------------------------------------------------");
                    Console.WriteLine("****No se ha podido cambiar el costo****");
                }
            }
            Console.WriteLine("----------------------------------------------------------\n");
        }

        // Muestra en consola una interfaz para pedir una clave de viaje y mostrar su información
        public void ViajeClave()
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
