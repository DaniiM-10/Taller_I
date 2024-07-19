using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace pelicula
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Pelicula> peliculas = new List<Pelicula>();
            leerYGuardarJsonEnLaLista(peliculas);
            cantPeliculasAlmacenadas(peliculas);
            peliculaMayorDuracion(peliculas);
            peliculaMenorDuracion(peliculas);
            promedioDeDuracion(peliculas);
            PeliculasConCalificU(peliculas);
        }
        public static void leerYGuardarJsonEnLaLista(List<Pelicula> _peliculas)
        {
            string peliculasJson = File.ReadAllText("movies.json"); //Leemos todo el string del .json
            var peliculasDeserialize = JsonSerializer.Deserialize<List<Pelicula>>(peliculasJson);
            foreach (var pelicula in peliculasDeserialize)
            {
                _peliculas.Add(pelicula);
            }
        }
        public static void cantPeliculasAlmacenadas(List<Pelicula> _peliculas)
        {
            Console.WriteLine("Cantidad de peliculas almacenadas: "+ _peliculas.Count);
        }
        public static void peliculaMayorDuracion(List<Pelicula> _peliculas)
        {
            string mayorDuracion = "0";
            Pelicula peliculaMayorDuracion = new Pelicula();
            foreach (var pelicula in _peliculas)
            {
                if(Convert.ToInt32(pelicula.Duracion) > Convert.ToInt32(mayorDuracion)){
                    mayorDuracion = pelicula.Duracion;
                    peliculaMayorDuracion = pelicula;
                }
            }
            Console.WriteLine("========== PELICULA CON MAYOR DURACION ==========");
            Console.WriteLine("Nombre: "+peliculaMayorDuracion.Nombre);
            Console.WriteLine("Duracion: "+ mayorDuracion +" min");
        }
        public static void peliculaMenorDuracion(List<Pelicula> _peliculas)
        {
            string menorDuracion = "10000"; //ponemos este valor para que cargue la primeraa pelicula
            Pelicula peliculaMenorDuracion = new Pelicula();
            foreach (var pelicula in _peliculas)
            {
                if(Convert.ToInt32(pelicula.Duracion) < Convert.ToInt32(menorDuracion)){
                    menorDuracion = pelicula.Duracion;
                    peliculaMenorDuracion = pelicula;
                }
            }
            Console.WriteLine("========== PELICULA CON MENOR DURACION ==========");
            Console.WriteLine("Nombre: "+peliculaMenorDuracion.Nombre);
            Console.WriteLine("Duracion: "+ menorDuracion +" min");
        }
        public static void promedioDeDuracion(List<Pelicula> _peliculas)
        {
            double promDuracion = 0;
            foreach (var pelicula in _peliculas)
            {
                promDuracion += Convert.ToInt32(pelicula.Duracion);
            }
            Console.WriteLine("========== PROMEDIO DE DURACION ==========");
            Console.WriteLine("Duracion promedio de la lista de peliculas: "+ promDuracion +" min");
        }

        //PARA LAS PELICULAS CON CALIFICACION "U"
        public static void PeliculasConCalificU(List<Pelicula> _peliculas)
        {
            int contPeliculasU = 0;
            int contPeliculas = 0;
            double puntuacionMayor = 0;
            double puntajePromedio = 0;
            Pelicula peliculaMejorPuntuada = new Pelicula();
            List<Pelicula> peliculasU = new List<Pelicula>();

            Console.WriteLine("========== PRIMERAS 3 PELICULAS CON CALIFICACION 'U' ==========");
            foreach (var pelicula in _peliculas)
            {
                if(pelicula.Calificacion == "U")
                {
                    if(contPeliculasU < 3){
                        Console.WriteLine($"Pelicula {contPeliculasU +1}");
                        Console.WriteLine("Nombre: "+ pelicula.Nombre +"\n");
                        contPeliculasU++;
                    }
                    if(puntuacionMayor < pelicula.IMDBRating){
                        puntuacionMayor = pelicula.IMDBRating;
                        peliculaMejorPuntuada = pelicula;
                    }
                    contPeliculas++;
                    puntajePromedio += pelicula.IMDBRating;
                    peliculasU.Add(pelicula);
                }
            }
            Console.WriteLine("========== CANTIDAD DE PELICULAS CON CALIFICACION 'U' ==========");
            Console.WriteLine("Cantidad: "+ contPeliculas);
            Console.WriteLine("========== PELICULA MEJOR PUNTUADA CON CALIFICACION 'U' ==========");
            Console.WriteLine("Nombre: "+ peliculaMejorPuntuada.Nombre);
            Console.WriteLine("Puntuacion: "+ puntuacionMayor+" ptos.");
            Console.WriteLine("========== PUNTAJE PROMEDIO CON CALIFICACION 'U' ==========");
            Console.WriteLine("Puntaje Promedio: "+ puntajePromedio + " ptos.");
            cargarJson("U", contPeliculas, peliculaMejorPuntuada.Nombre, puntuacionMayor, puntajePromedio);
        }       
        public static void cargarJson(string _calificU, int _contPelis, string _nomPelicula, double _puntMayor, double _puntProm)
        {
            peliculasCalificacionU pelis = new peliculasCalificacionU();
            pelis.calificacionFiltrada = _calificU;
            pelis.cantidadDePeliculas = _contPelis;
            pelis.nombreMejorPelicula = _nomPelicula;
            pelis.puntuacionMejorPelicula = _puntMayor;
            pelis.promedioGenero = _puntProm;

            string pathJson = "peliculasU.json";
            var options = new JsonSerializerOptions { WriteIndented = true }; //indentar el json
            string jugadoresJson = JsonSerializer.Serialize(pelis, options);
            File.WriteAllText(pathJson, jugadoresJson);             
        }
    }
}