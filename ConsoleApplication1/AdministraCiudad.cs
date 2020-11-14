using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class AdministraCiudad
    {
        // Dictionary para guardar los objetos CiudadDestino.
        private Dictionary<int, CiudadDestino> dicDestinos = new Dictionary<int, CiudadDestino>();

        // Determina si una clave ya fue añadida en dicDestinos.
        public bool EstaClave(int clave)
        {
            return dicDestinos.ContainsKey(clave);
        }

        // Valida si una ciudad de destino ya fue agregada
        public bool EstaCiudad(string ciudad)
        {
            foreach(KeyValuePair<int, CiudadDestino> item in dicDestinos)
            {
                if (item.Value.pNombreCiudad.Equals(ciudad))
                {
                    return true;
                }
            }
            return false;
        }

        // Agrega objetos CiudadDestino a dicDestino.
        public void AgregaCiudades(int clave, string ciudad, double tiempoTrayecto, double costo)
        {
            dicDestinos.Add(clave, new CiudadDestino(ciudad, tiempoTrayecto, costo));
        }

        // Devuelve una matriz de string donde se encuentran guardados todos los viajes con sus atributos que se han agregado.
        public string[,] Ciudades()
        {
            string[,] ciudades = new string[dicDestinos.Count, 4];
            int i = 0;
            foreach (KeyValuePair<int, CiudadDestino> item in dicDestinos)
            {
                int llave = item.Key;
                CiudadDestino ciudad = item.Value;
                ciudades[i, 0] = Convert.ToString(llave);
                ciudades[i, 1] = ciudad.pNombreCiudad;
                ciudades[i, 2] = Convert.ToString(ciudad.pTiempoTrayecto);
                ciudades[i, 3] = String.Format("{0:0.00}", ciudad.pCosto);
                i++;
            }
            return ciudades;
        }

        // Método para obtener los datos de los viajes con el costo menor o igual dado.
        public string[,] MenorA(double valor, int opcion)
        {
            string[,] ciudades = new string[CountMenoresA(valor, opcion), 4];
            int i = 0;
            foreach(KeyValuePair<int, CiudadDestino> item in dicDestinos)
            {
                if (item.Value.pCosto <= valor && opcion == 6)
                {
                    ciudades[i, 0] = Convert.ToString(item.Key);
                    ciudades[i, 1] = item.Value.pNombreCiudad;
                    ciudades[i, 2] = Convert.ToString(item.Value.pTiempoTrayecto);
                    ciudades[i, 3] = String.Format("{0:0.00}", item.Value.pCosto);
                    i++;
                }
                if (item.Value.pTiempoTrayecto <= valor && opcion == 7)
                {
                    ciudades[i, 0] = Convert.ToString(item.Key);
                    ciudades[i, 1] = item.Value.pNombreCiudad;
                    ciudades[i, 2] = Convert.ToString(item.Value.pTiempoTrayecto);
                    ciudades[i, 3] = String.Format("{0:0.00}", item.Value.pCosto);
                    i++;
                }
            }
            return ciudades;
        }

        // Método para obtener el número de viajes con el costo menor o igual dado.
        private int CountMenoresA(double valor, int opcion)
        {
            int i = 0;
            foreach (KeyValuePair<int, CiudadDestino> item in dicDestinos)
            {
                if(opcion == 6 && item.Value.pCosto <= valor)
                {
                    i++;
                }
                if (opcion == 7 && item.Value.pTiempoTrayecto <= valor)
                {
                    i++;
                }
            }
            return i;
        }

        // Devuelve los datos de un destino determinado por su clave.
        public string DatosCiudad(int clave)
        {
            return $"Clave: {clave}, {dicDestinos[clave].ToString()}";
        }

        // Devuelve los datos de un destino determinado por su nombre.
        public string DatosCiudadNombre(string nombreCiudad)
        {
            string datos = "";
            foreach(KeyValuePair<int, CiudadDestino> item in dicDestinos)
            {
                if (item.Value.pNombreCiudad.Equals(nombreCiudad))
                {
                    datos = $"Clave: {item.Key}, {item.Value.ToString()}";
                    break;
                }
            }
            return datos;
        }

        // Cambia el precio de viaje a una ciudad determinada por su nombre.
        public void CambiaPrecioPorNombre(string nombre, double precio)
        {
            for (int i = 0; i < dicDestinos.Count; i++)
            {
                KeyValuePair<int, CiudadDestino> kvp = dicDestinos.ElementAt(i);
                CiudadDestino ciudad = kvp.Value;
                if (ciudad.pNombreCiudad.Equals(nombre))
                {
                    ciudad.pCosto = precio;
                }
            }
            /*foreach (KeyValuePair<int, CiudadDestino> item in dicDestinos)
            {
                if (item.Value.pNombreCiudad.Equals(nombre))
                {
                    item.Value.pCosto = precio;
                    return true;
                }
            }*/
        }

        // Cambia el precio de viaje a una ciudad determinada por su clave.
        public void CambiaPrecioPorClave(int clave, double precio)
        {
            dicDestinos[clave].pCosto = precio;
        }

        // Da el nombre de la ciudad de destino por su clave.
        public string NombreDestino(int clave)
        {
            return dicDestinos[clave].pNombreCiudad;
        }
        
        // Cambia el tiempo del trayecto a un viaje determinado por su nombre.
        public void CambiaTiempoPorNombre(string nombre, double tiempo)
        {
            for (int i = 0; i < dicDestinos.Count; i++)
            {
                KeyValuePair<int, CiudadDestino> kvp = dicDestinos.ElementAt(i);
                CiudadDestino ciudad = kvp.Value;
                if (ciudad.pNombreCiudad.Equals(nombre))
                {
                    ciudad.pTiempoTrayecto = tiempo;
                }
            }
        }

        // Cambia el tiempo del trayecto a un viaje determinado por su clave.
        public void CambiaTiempoPorClave(int clave, double tiempo)
        {
            dicDestinos[clave].pTiempoTrayecto = tiempo;
        }

        // Propiedad para determinar si dicDestinos esta vacía o no.
        public bool pVacia
        {
            get
            {
                if (dicDestinos.Count == 0)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
        }
        
        // Propiedad que devuelve el número total de destinos que han sido añadidas.
        public int pTotalCiudades
        {
            get
            {
                return dicDestinos.Count;
            }
        } 
    }
}
