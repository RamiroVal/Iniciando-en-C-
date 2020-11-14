using System;

namespace ConsoleApplication1
{
    class CiudadDestino
    {
        // Atributos de CiudadDestino.
        private string nombreCiudad;
        private double tiempoTrayecto;
        private double costo;

        //Constructor.
        public CiudadDestino(string nombreCiudad, double tiempoTrayecto, double costo)
        {
            this.nombreCiudad = nombreCiudad;
            this.tiempoTrayecto = tiempoTrayecto;
            this.costo = costo;
        }

        // Propiedad que obtiene y establece nombreCiudad.
        public string pNombreCiudad
        {
            get
            {
                return nombreCiudad;
            }
            set
            {
                nombreCiudad = value;
            }
        }

        // Propiedad que obtiene y establece tiempoTrayecto.
        public double pTiempoTrayecto
        {
            get
            {
                return tiempoTrayecto;
            }
            set
            {
                tiempoTrayecto = value;
            }
        }

        // Propiedad que obtiene y establece costo.
        public double pCosto
        {
            get
            {
                return costo;
            }
            set
            {
                costo = value;
            }
        }

        override
        public string ToString()
        {
            return $"Ciudad: {nombreCiudad}, Tiempo del trayecto: {tiempoTrayecto}, Costo: ${String.Format("{0:0.00}", costo)}";
        }
    }
}
