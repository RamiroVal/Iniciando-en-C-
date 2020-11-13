﻿using System;

namespace ConsoleApplication1
{
    class CiudadDestino
    {
        private string nombreCiudad;
        private double tiempoTrayecto;
        private double costo;

        public CiudadDestino(string nombreCiudad, double tiempoTrayecto, double costo)
        {
            this.nombreCiudad = nombreCiudad;
            this.tiempoTrayecto = tiempoTrayecto;
            this.costo = costo;
        }

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

        public string ToString()
        {
            return $"Ciudad: {nombreCiudad}, Tiempo del trayecto: {tiempoTrayecto}, Costo: ${String.Format("{0:0.00}", costo)}";
        }
    }
}
