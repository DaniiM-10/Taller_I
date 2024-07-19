using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using unidadUnica;

namespace civilizaciones
{
    class Program
    {
        public static void Main(string[] args)
        {
            getCivilizaciones();
        }

        //GET CIVILIZACIONES
        public static void getCivilizaciones()
        {
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if(strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string strCivilizaciones = objReader.ReadToEnd();
                            civilizaciones? civilizacionesAOF = JsonSerializer.Deserialize<civilizaciones>(strCivilizaciones);

                            Console.WriteLine("===============================================");
                            Console.WriteLine("===== CIVILIZACIONES DISPONIBLES");
                            Console.WriteLine("===============================================");
                            foreach (var infoCiv in civilizacionesAOF.Civilizations)
                            {
                                Console.WriteLine($"ID: {infoCiv.Id} | NOMBRE: {infoCiv.Name}");
                            }

                            Console.WriteLine("\n- Elija una civilizacion para mostrar sus caracteristicas mediante su ID:");
                            int respuestaId = Convert.ToInt32(Console.ReadLine());

                            
                            foreach (var infoCiv in civilizacionesAOF.Civilizations)
                            {
                                if (infoCiv.Id == respuestaId)
                                {
                                    Console.WriteLine("\n===============================================");
                                    Console.WriteLine("===== INFORMACION DE LA CIVILIZACION");
                                    Console.WriteLine("===============================================");
                                    Console.WriteLine($"ID: {infoCiv.Id}");
                                    Console.WriteLine($"NOMBRE: {infoCiv.Name}");
                                    Console.WriteLine($"EXPANCION: {infoCiv.Expansion}");
                                    Console.WriteLine($"TIPO DE EJERCITO: {infoCiv.ArmyType}");

                                    Console.WriteLine($"\nUNIDAD UNICA:"); //api de la informacion sobre la unidad unica
                                    foreach (var unidadUnica in infoCiv.UniqueUnit)
                                    {
                                        getUnidadUnica(unidadUnica);
                                    }

                                    Console.WriteLine($"\nTECNOLOGIA UNICA:"); //api de la informacion sobre la unidad unica
                                    foreach (var tecUnica in infoCiv.UniqueTech)
                                    {
                                        getTecUnica(tecUnica);
                                    }

                                    Console.WriteLine($"BONUS DE EQUIPO: {infoCiv.TeamBonus}");
                                    Console.WriteLine($"BONUS DE CIVILIZACION:"); 
                                    foreach (var civBonus in infoCiv.CivilizationBonus)
                                    {
                                        Console.WriteLine($"- {civBonus}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                
                throw;
            }
        }

        //GET UNIDAD UNICA
        public static void getUnidadUnica(string _pathUnidadUnica)
        {
            var url = $"{_pathUnidadUnica}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if(strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string strUnidadUnica = objReader.ReadToEnd();
                            unidadUnica.unidadUnica? unidadUnicaAOF = JsonSerializer.Deserialize<unidadUnica.unidadUnica>(strUnidadUnica); //namespace.class
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine($"ID: {unidadUnicaAOF.Id}");
                            Console.WriteLine($"NOMBRE: {unidadUnicaAOF.Name}");
                            Console.WriteLine($"DESCRIPCION: {unidadUnicaAOF.Description}");
                            Console.WriteLine($"EXPANCION: {unidadUnicaAOF.Expansion}");
                            Console.WriteLine($"LA ERA: {unidadUnicaAOF.Age}");
                            Console.WriteLine($"COSTO: ");
                                Console.WriteLine($"- Alimento: {unidadUnicaAOF.Cost.Food}");
                                Console.WriteLine($"- Oro: {unidadUnicaAOF.Cost.Gold}");
                            Console.WriteLine($"TIEMPO DE CONSTR.: {unidadUnicaAOF.BuildTime}");
                            Console.WriteLine($"TIEMPO DE RECARGA: {unidadUnicaAOF.ReloadTime}");
                            Console.WriteLine($"RETRASO DE ATAQUE: {unidadUnicaAOF.AttackDelay}");
                            Console.WriteLine($"TASA DE MOVIMIENTO: {unidadUnicaAOF.MovementRate}");
                            Console.WriteLine($"LINEA DE VISION: {unidadUnicaAOF.LineOfSight}");
                            Console.WriteLine($"PUNTOS DE GOLPE: {unidadUnicaAOF.HitPoints}");
                            Console.WriteLine($"RANGO: {unidadUnicaAOF.Range}");
                            Console.WriteLine($"ATAQUE: {unidadUnicaAOF.Attack}");
                            Console.WriteLine($"ARMADURA: {unidadUnicaAOF.Armor}");
                            Console.WriteLine($"BONUS DE ATAQUE: ");
                            foreach (var bonusAtk in unidadUnicaAOF.AttackBonus)
                            {
                                Console.WriteLine($"- {bonusAtk}");
                            }
                            Console.WriteLine("-----------------------------------------------------------------");
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                
                throw;
            }
        }    

        //GET TECNOLOGIA UNICA
        public static void getTecUnica(string _pathTecUnica)
        {
            var url = $"{_pathTecUnica}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if(strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string strTecUnica = objReader.ReadToEnd();
                            unidadUnica.unidadUnica? tecUnicaAOF = JsonSerializer.Deserialize<unidadUnica.unidadUnica>(strTecUnica); //namespace.class
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine($"ID: {tecUnicaAOF.Id}");
                            Console.WriteLine($"NOMBRE: {tecUnicaAOF.Name}");
                            Console.WriteLine($"DESCRIPCION: {tecUnicaAOF.Description}");
                            Console.WriteLine($"EXPANCION: {tecUnicaAOF.Expansion}");
                            Console.WriteLine($"LA ERA: {tecUnicaAOF.Age}");
                            Console.WriteLine($"COSTO: ");
                                Console.WriteLine($"- Alimento: {tecUnicaAOF.Cost.Food}");
                                Console.WriteLine($"- Oro: {tecUnicaAOF.Cost.Gold}");
                            Console.WriteLine($"TIEMPO DE CONSTR.: {tecUnicaAOF.BuildTime}");
                            Console.WriteLine("-----------------------------------------------------------------");
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                
                throw;
            }
        }    
    }
}