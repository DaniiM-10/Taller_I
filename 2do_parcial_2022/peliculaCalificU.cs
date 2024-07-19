using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace pelicula
{
    public class peliculasCalificacionU
    {
        private string CalificacionFiltrada="";
        private int CantidadDePeliculas;
        private string NombreMejorPelicula="";
        private double PuntuacionMejorPelicula;
        private double PromedioGenero;

        public string calificacionFiltrada{get=>CalificacionFiltrada; set=>CalificacionFiltrada=value;}
        public int cantidadDePeliculas{get=>CantidadDePeliculas; set=>CantidadDePeliculas=value;}
        public string nombreMejorPelicula{get=>NombreMejorPelicula; set=>NombreMejorPelicula=value;}
        public double puntuacionMejorPelicula{get=>PuntuacionMejorPelicula; set=>PuntuacionMejorPelicula=value;}
        public double promedioGenero{get=>PromedioGenero; set=>PromedioGenero=value;}
    }
}