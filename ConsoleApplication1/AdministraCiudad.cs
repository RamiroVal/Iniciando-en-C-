using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class AdministraCiudad
    {
        private Dictionary<int, CiudadDestino> dicDestinos = new Dictionary<int, CiudadDestino>();

        public bool EstaClave(int clave)
        {
            return dicDestinos.ContainsKey(clave);
        }

        public void AgregaCiudades(int clave, string ciudad, double tiempoTrayecto, double costo)
        {
            dicDestinos.Add(clave, new CiudadDestino(ciudad, tiempoTrayecto, costo));
        }

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
                ciudades[i, 3] = Convert.ToString(ciudad.pCosto);
                i++;
            }
            return ciudades;
        }

        public int pTotalCiudades
        {
            get
            {
                return dicDestinos.Count;
            }
        }

        public string DatosCiudad(int clave)
        {
            return dicDestinos[clave].ToString();
        }

        public bool CambiaPrecioPorNombre(string nombre, double precio)
        {
            foreach (KeyValuePair<int, CiudadDestino> item in dicDestinos)
            {
                if (item.Value.pNombreCiudad.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    item.Value.pCosto = precio;
                    return true;
                }
            }
            return false;
        }

        public bool CambiaPrecioPorClave(int clave, double precio)
        {
            if (dicDestinos.ContainsKey(clave))
            {
                dicDestinos[clave].pCosto = precio;
                return true;
            }else
            {
                return false;
            }
            
        }

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
    }
}