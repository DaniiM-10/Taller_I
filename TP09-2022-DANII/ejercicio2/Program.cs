using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Ejercicio2
{
    class Program
    {
        public static void Main(string[] args){
            //VARIABLES
            int cantDeProductos;

            //LISTA DE LOS PRODUCTOS
            List<productos> listaDeProductos = new List<productos>();

            //PEDIMOS LA CANTIDAD DE PRODUCTOS QUE VAMOS A CARGAR DE MANERA ALEATORIA
            Console.WriteLine("Ingrese la cantidad de productos: ");
            cantDeProductos = Convert.ToInt32(Console.ReadLine());
            
            //CARGAMOS LOS PRODUCTOS
            for (int i=0; i<cantDeProductos; i++)
            {
                productos Producto = new productos(); //se crea un producto aleatorio
                listaDeProductos.Add(Producto); //cargamos la lista con los productos
            }

            //PATH DEL ARCHIVO JSON
            string pathJson = @"C:\tp92022\tp09-2022-Danii5203\Ejercicio2\productos.json";
            
            //CARGAMOS EL ARCHIVO JSON
            var options = new JsonSerializerOptions { WriteIndented = true }; //indentar el json
            string productosJson = JsonSerializer.Serialize(listaDeProductos, options);
            File.WriteAllText(pathJson, productosJson); //Escibimos todo el string en el .json

            //MOSTRAMOS EL ARCHIVO JSON
            productosJson = File.ReadAllText("productos.json"); //Leemos todo el string del .json
            List<productos>? productosDeserialize = JsonSerializer.Deserialize<List<productos>>(productosJson);
            Console.WriteLine("====================== PRODUCTOS ======================");
            if(productosDeserialize != null){
                foreach (var prod in productosDeserialize)
                {
                    Console.WriteLine($"_Nombre = {prod.nombre}");
                    Console.WriteLine($"_Fecha de vencimiento = {prod.fechaDeVencimiento}");
                    Console.WriteLine($"_Precio por unidad(caja) = ${prod.precio}"); //precio por caja
                    Console.WriteLine($"_Cantidad de unidades(caja/s) = {prod.tamanio}");
                    Console.WriteLine($"_Precio total = ${Math.Round(prod.precio * Convert.ToInt32(prod.tamanio), 2)}");

                    Console.WriteLine("\n");
                }
            }
        }
    }
}