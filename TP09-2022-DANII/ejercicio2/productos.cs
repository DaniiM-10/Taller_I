using System;

namespace Ejercicio2
{
    class productos
    {
        private string Nombre;
        private DateTime FechaDeVencimiento;
        private float Precio;
        private string Tamanio;

        public string nombre{get=>Nombre; set=>Nombre = value;}
        public DateTime fechaDeVencimiento{get=>FechaDeVencimiento; set=>FechaDeVencimiento = value;}
        public float precio{get=>Precio; set=>Precio = value;}
        public string tamanio{get=>Tamanio; set=>Tamanio = value;}

        public productos(){
            string[] prod = new string[] {"Galletas", "Cigarros", "Alfajores", "Chicles", "Caramelos", "Chocolates", "Mantecoles"};
            Random nRand = new Random();
            this.Nombre = prod[nRand.Next(0, (prod.Length)-1)];
            this.FechaDeVencimiento = new DateTime(nRand.Next(2022, 2024), nRand.Next(7, 13), nRand.Next(1, 31), nRand.Next(1, 24), 0, 0);
            this.Tamanio = Convert.ToString(nRand.Next(1, 10)); //entre 1 y 10 cajas
            this.Precio = (float)(decimal.Round((decimal)(nRand.NextDouble() * (2000 - 500) + 500), 2)); //entre $500 y $2000 por unidad (caja)
        }
    }
}