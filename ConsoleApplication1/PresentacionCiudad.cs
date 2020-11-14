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
            int clave = Validaciones.ValidaClave("clave");
            while (ciudades.EstaClave(clave))
            {
                Console.WriteLine("Clave existente, ingrese otra clave:");
                clave = Validaciones.ValidaClave("clave");
            }
            Console.WriteLine("Ingrese la ciudad de destino:");
            string nombreDestino = Validaciones.ValidaBlancos();
            while (ciudades.EstaCiudad(nombreDestino))
            {
                Console.WriteLine("Ciudad de destino existente, ingrese otro nombre:");
                nombreDestino = Validaciones.ValidaBlancos();
            }
            Console.WriteLine("Ingrese el tiempo del trayecto:");
            double tiempo = Validaciones.ValidaHoraCosto("tiempo de trayecto");
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
                Console.WriteLine("Ingrese el nombre o la clave de la ciudad:");
                string nombre = Validaciones.ValidaBlancos();
                try
                {
                    int clave = Convert.ToInt32(nombre);
                    if (ciudades.EstaClave(clave))
                    {
                        Console.WriteLine("Ingrese el nuevo precio");
                        double precio = Validaciones.ValidaHoraCosto("precio");
                        ciudades.CambiaPrecioPorClave(clave, precio);
                        Console.WriteLine("\n----------------------------------------------------------");
                        Console.WriteLine($"Se ha cambiado el costo de {ciudades.NombreDestino(clave)} a ${String.Format("{0:0.00}", precio)}");
                    }
                    else
                    {
                        Console.WriteLine("\n----------------------------------------------------------");
                        Console.WriteLine("****No se ha podido cambiar el costo ya que la clave del destino no ha sido agregado****");
                    }
                }catch(FormatException e)
                {
                    if (ciudades.EstaCiudad(nombre))
                    {
                        Console.WriteLine("Ingrese el nuevo precio");
                        double precio = Validaciones.ValidaHoraCosto("precio");
                        ciudades.CambiaPrecioPorNombre(nombre, precio);
                        Console.WriteLine("\n----------------------------------------------------------");
                        Console.WriteLine($"Se ha cambiado el costo de {nombre} a ${String.Format("{0:0.00}", precio)}");
                    }else
                    {
                        Console.WriteLine("\n----------------------------------------------------------");
                        Console.WriteLine("****No se ha podido cambiar el costo ya que el nombre del destino no ha sido agregado****");
                    }
                }
            }
            Console.WriteLine("----------------------------------------------------------\n");
        }

        // Muestra en consola una interfaz para cambiar el tiempo de trayecto de un destino.
        public void CambiarTiempo()
        {
            Console.WriteLine("----------------------CAMBIAR TIEMPO----------------------");
            if (ciudades.pVacia)
            {
                Console.WriteLine("****No se han añadido ciudades****");
            }
            else
            {
                Console.WriteLine("Ingrese el nombre o la clave de la ciudad:");
                string nombre = Validaciones.ValidaBlancos();
                try
                {
                    int clave = Convert.ToInt32(nombre);
                    if (ciudades.EstaClave(clave))
                    {
                        Console.WriteLine("Ingrese el nuevo tiempo de trayecto");
                        double tiempo = Validaciones.ValidaHoraCosto("tiempo de trayecto");
                        ciudades.CambiaTiempoPorClave(clave, tiempo);
                        Console.WriteLine("\n----------------------------------------------------------");
                        Console.WriteLine($"Se ha cambiado el tiempo de trayecto de {ciudades.NombreDestino(clave)} a {tiempo}");
                    }
                    else
                    {
                        Console.WriteLine("\n----------------------------------------------------------");
                        Console.WriteLine("****No se ha podido cambiar el tiempo del trayecto ya que la clave del destino no ha sido agregado****");
                    }
                }
                catch (FormatException e)
                {
                    if (ciudades.EstaCiudad(nombre))
                    {
                        Console.WriteLine("Ingrese el nuevo tiempo del trayecto");
                        double tiempo = Validaciones.ValidaHoraCosto("tiempo del trayecto");
                        ciudades.CambiaTiempoPorNombre(nombre, tiempo);
                        Console.WriteLine("\n----------------------------------------------------------");
                        Console.WriteLine($"Se ha cambiado el costo de {nombre} a {tiempo}");
                    }
                    else
                    {
                        Console.WriteLine("\n----------------------------------------------------------");
                        Console.WriteLine("****No se ha podido cambiar el tiempo del trayecto ya que el nombre del destino no ha sido agregado****");
                    }
                }
            }
            Console.WriteLine("----------------------------------------------------------\n");
        }

        // Muestra  en consola una interfaz que imprime los viajes con tiempo o costo menores a cierto dato.
        public void ConsultaMenorA(string tipo, int opcion)
        {
            if (tipo.Equals("tiempo de trayecto"))
            {
                Console.WriteLine("------------------------TIEMPO MENOR A------------------------");
            }
            else
            {
                Console.WriteLine("------------------------COSTO MENOR A------------------------");
            }
            if (ciudades.pVacia)
            {
                Console.WriteLine("****No se han añadido ciudades****");
                Console.WriteLine("----------------------------------------------------------\n\n");
            }else
            {
                Console.WriteLine($"Ingrese el límite del {tipo} a imprimir:");
                double costo = Validaciones.ValidaHoraCosto("precio");
                Console.WriteLine("----------------------------------------------------------");
                string[,] datosCiudades = ciudades.MenorA(costo, opcion);
                if (datosCiudades.GetLength(0) == 0)
                {
                    Console.WriteLine($"****No hay destinos con {tipo} menor o igual a {costo}****");
                    Console.WriteLine("----------------------------------------------------------");
                }
                else
                {
                    for(int i = 0; i < datosCiudades.GetLength(0); i++)
                    {
                        Console.WriteLine($"Clave: {datosCiudades[i, 0]}"
                            + $"\nCiudad: {datosCiudades[i, 1]}"
                            + $"\nTiempo de Trayecto: {datosCiudades[i, 2]}"
                            + $"\nCosto: {datosCiudades[i, 3]}");
                        Console.WriteLine("----------------------------------------------------------");
                    }
                }
                Console.WriteLine();
            }
        }

        // Muestra en consola una interfaz que pide el nombre o la clave del destino y muestra su información.
        public void ConsultaIndividual()
        {
            Console.WriteLine("---------------------CONSULTA INDIVIDUAL---------------------");
            if (ciudades.pVacia)
            {
                
            }else
            {
                Console.WriteLine("Ingrese la clave o el nombre de la ciudad que desea consultar");
                string dato = dato = Validaciones.ValidaBlancos();;
                try
                {
                    int clave = Convert.ToInt32(dato);
                    if (ciudades.EstaClave(clave))
                    {
                        Console.WriteLine(ciudades.DatosCiudad(clave));
                        Console.WriteLine("----------------------------------------------------------\n\n");
                    }else
                    {
                        Console.WriteLine("****Clave inexistente****");
                        Console.WriteLine("----------------------------------------------------------\n\n");
                    }
                }catch(FormatException e)
                {
                    if (ciudades.EstaCiudad(dato))
                    {
                        Console.WriteLine(ciudades.DatosCiudadNombre(dato));
                        Console.WriteLine("----------------------------------------------------------\n\n");
                    }
                    else
                    {
                        Console.WriteLine("****Ciudad inexistente****");
                        Console.WriteLine("----------------------------------------------------------\n\n");
                    }
                }
            }
        }
    }
}
