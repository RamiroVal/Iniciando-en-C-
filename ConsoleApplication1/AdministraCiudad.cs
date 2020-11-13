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

        // Devuelve los datos a un destino determinado por su clave.
        public string DatosCiudad(int clave)
        {
            return dicDestinos[clave].ToString();
        }

        // Cambia el precio de viaje a una ciudad determinada por su nombre.
        public bool CambiaPrecioPorNombre(string nombre, double precio)
        {
            for (int i = 0; i < dicDestinos.Count; i++)
            {
                KeyValuePair<int, CiudadDestino> kvp = dicDestinos.ElementAt(i);
                CiudadDestino ciudad = kvp.Value;
                if (ciudad.pNombreCiudad.Equals(nombre))
                {
                    ciudad.pCosto = precio;
                    return true;
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
            return false;
        }

        // Cambia el precio de viaje a una ciudad determinada por su clave.
        public bool CambiaPrecioPorClave(int clave, double precio)
        {
            if (dicDestinos.ContainsKey(clave))
            {
                dicDestinos[clave].pCosto = precio;
                return true;
            } else
            {
                return false;
            }

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
