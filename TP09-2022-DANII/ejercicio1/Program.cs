using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Program
{
    class Program
    {
        public static void Main(string[] args){
            List<informacion> info = new List<informacion>();

            string pathJson = @"C:\tp92022\tp09-2022-Danii5203\Ejercicio1\index.json";
            string? path;
            Console.WriteLine("Ingrese el Path de una carpeta: ");
            path = $@"{Convert.ToString(Console.ReadLine())}";

            if(Directory.Exists(path)){
                DirectoryInfo directorio = new DirectoryInfo(path);
                List<FileInfo> files = directorio.GetFiles().ToList();

                //Mostramos el contenido del directorio ingresado
                if(files != null){
                    Console.WriteLine("\n============ Contenido del Directorio ===========");
                    Console.WriteLine("ID, Ruta del archivo");
                    int id=0;
                    foreach (FileInfo file in files)
                    {
                        string[] nameFileExt = Path.GetFileName(Convert.ToString(file)).Split('.'); //separamos el nombre de archivo y extencion
                        informacion infoDelArchivo = new informacion(id, nameFileExt[0], nameFileExt[1]);
                        info.Add(infoDelArchivo);
                        Console.WriteLine($"{infoDelArchivo.id}, {file}");
                        id++;
                    }
                }
                var options = new JsonSerializerOptions { WriteIndented = true }; //indentar el json
                string infoJson = JsonSerializer.Serialize(info, options);
                File.WriteAllText(pathJson, infoJson);
                Console.WriteLine("\n==============================================");
            }else{
                Console.WriteLine("No exite la carpeta.");
            }
        }
    }
}