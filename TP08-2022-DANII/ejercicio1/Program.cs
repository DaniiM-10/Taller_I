using System;
using System.Collections.Generic;
using System.IO;

namespace Program
{
    class Program
    {
        static void Main(string[] args){
            string path = "";
            Console.WriteLine("Ingrese el Path de una carpeta: ");
            path = $@"{Convert.ToString(Console.ReadLine())}";

            if(Directory.Exists(path)){
                DirectoryInfo directorio = new DirectoryInfo(path);
                List<string> directoriosInternos = Directory.GetDirectories(path).ToList();
                List<FileInfo> files = directorio.GetFiles().ToList();

                //Mostramos el contenido del directorio ingresado
                Console.WriteLine("\n============ Contenido del Directorio ===========");
                foreach (FileInfo dir in files)
                {
                    Console.WriteLine("Archivo: "+Convert.ToString(dir));
                }
                if(directoriosInternos != null){
                    foreach (string dir1 in directoriosInternos)
                    {
                        Console.WriteLine("Directorio: "+Convert.ToString(dir1));
                    }
                }
                Console.WriteLine("\n==============================================");
                guardarInfoDeLosFiles(files, directoriosInternos);
            }else{
                Console.WriteLine("No exite la carpeta.");
            }
        }

        public static void guardarInfoDeLosFiles(List<FileInfo> _files, List<string> _directoriosInternos){
            int nRegistro = 0;
            string guardarArchivo = @"C:\tp8-2022-Ejercicio1\tp08-2022-Danii5203\Ejercicio1\index.csv";
            StreamWriter writeStream = new StreamWriter(guardarArchivo);
            writeStream.WriteLine("ID, NOMBRE, EXTENSION");

            if(_files != null){ //controlamos que haya archivos
                foreach (FileInfo file in _files) //guardar archivos
                {
                    Console.WriteLine($"================= Archivo {nRegistro} ==================");
                    string[] nameFileExt = Path.GetFileName(Convert.ToString(file)).Split('.'); //separamos el nombre de archivo y extencion
                    string IdFileExt = $"{nRegistro}, {nameFileExt[0]}, .{nameFileExt[1]}"; //armamos lo que se guardara en el texto

                    Console.WriteLine("ID: "+nRegistro);
                    Console.WriteLine("Nombre: "+nameFileExt[0]);
                    Console.WriteLine("Extencion: "+nameFileExt[1]);
                    Console.WriteLine("Guardar: "+ IdFileExt);
                    Console.WriteLine("\n");
                    writeStream.WriteLine(IdFileExt);

                    nRegistro++;
                }
            }

            if(_directoriosInternos != null){ //controlamos que haya directorios
                foreach (string direct in _directoriosInternos){ //guardamos los directorios
                    Console.WriteLine($"================ Directorio {nRegistro} ================");
                    string[] nameDirect = direct.Split("\\"); //separamos el nombre de archivo y extencion
                    string IdDirectExt = $"{nRegistro}, {nameDirect[nameDirect.Length-1]}, 'Sin Extensión'"; //armamos lo que se guardara en el texto

                    Console.WriteLine("ID: "+nRegistro);
                    Console.WriteLine("Nombre: "+nameDirect[nameDirect.Length-1]);
                    Console.WriteLine("Guardar: "+ IdDirectExt);
                    Console.WriteLine("\n");
                    writeStream.WriteLine(IdDirectExt);

                    nRegistro++;
                }
            }
            writeStream.Close();
        }
    }
}