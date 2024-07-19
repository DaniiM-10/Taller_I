using System.Text.Json.Serialization;

public class Pelicula
    {
        
        [JsonPropertyName("Series_Title")]
        public string Nombre { get; set; }

        [JsonPropertyName("Released_Year")]
        public int AnioLazamiento { get; set; }

        [JsonPropertyName("Certificate")]
        public string Calificacion { get; set; }

        [JsonPropertyName("Runtime")]
        public string Duracion { get; set; }

        [JsonPropertyName("Genre")]
        public string Genero { get; set; }

        [JsonPropertyName("IMDB_Rating")]
        public double IMDBRating { get; set; }

        [JsonPropertyName("Overview")]
        public string Overview { get; set; }

        [JsonPropertyName("Meta_score")]
        public int MetaScore { get; set; }

        [JsonPropertyName("Director")]
        public string Director { get; set; }

        [JsonPropertyName("Star1")]
        public string Star1 { get; set; }

        [JsonPropertyName("Star2")]
        public string Star2 { get; set; }

        [JsonPropertyName("Star3")]
        public string Star3 { get; set; }

        [JsonPropertyName("Star4")]
        public string Star4 { get; set; }

        [JsonPropertyName("No_of_Votes")]
        public int CantidadDeVotos { get; set; }

        [JsonPropertyName("Gross")]
        public string Ganancia { get; set; }
    }