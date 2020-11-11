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

        public void MuestraCiudades()
        {
            foreach (var key in dicDestinos.Keys)
            {
                Console.WriteLine(dicDestinos[key].ToString());

            }
        }
    }
}
