using System;
using Tareas;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args){
            //variables
            int cantTareas;
            double hrsTrabajadas;
            string buscarDescripcion="";

            //listas
            List<tareas> tareasPendientes = new List<tareas>();
            List<tareas> tareasRealizadas = new List<tareas>();

            do
            {
                Console.WriteLine("Cuantas tareas desea cargar?");
                cantTareas = Convert.ToInt32(Console.ReadLine());
            } while (cantTareas <= 0);

            Console.WriteLine("\n************************* Cargar Tareas Pendientes **************************");
            for (int i=0; i<cantTareas; i++)
            {
                tareasPendientes.Add(crearTarea(i));
            }

            Console.WriteLine("************************* Tareas Pendientes **************************");
            mostrarTarea(tareasPendientes);

            //1-
            Console.WriteLine("\n************************* Cargar Tareas Realizadas **************************");
            cargarTareasRealizadas(tareasRealizadas, tareasPendientes, cantTareas);
            Console.WriteLine("\n************************* Tareas Realizadas **************************");
            if(tareasRealizadas.Count == 0){
                Console.WriteLine("No posee tareas realizadas.\n");
            }else{
                mostrarTarea(tareasRealizadas);
            }

            //2-
            Console.WriteLine("\n************************* Buscar Tarea Pendiente **************************");
            Console.WriteLine("Buscar por descripcion: ");
            buscarDescripcion = Console.ReadLine();
            buscarTareaPendiente(tareasPendientes, buscarDescripcion);

            //3-
            Console.WriteLine("\n************************* Horas Trabajadas **************************");
            hrsTrabajadas = horasTrabajadas(tareasRealizadas);
            Console.WriteLine("Horas trabajadas: "+hrsTrabajadas+"hrs.");
        }

        public static tareas crearTarea(int id){
            int duracion;
            string descripcion="";

            //cargamos la tarea
            Console.WriteLine("\nTarea "+id+":");
            Console.WriteLine("Ingrese una descripcion: ");
            descripcion = Console.ReadLine();
            Console.WriteLine("Ingrese la duracion de la tarea: ");
            duracion = Convert.ToInt32(Console.ReadLine());
            return new tareas(id, descripcion, duracion);
        }

        public static void mostrarTarea(List<tareas> tareasPendientes){
            foreach (var tarea in tareasPendientes)
            {
                Console.WriteLine("\nTarea "+tarea.TareaID+":");
                Console.WriteLine("ID: "+tarea.TareaID);
                Console.WriteLine("Descripcion: "+tarea.Descripcion);
                Console.WriteLine("Duracion: "+tarea.Duracion);
            }
        }


        //1-
        public static void cargarTareasRealizadas(List<tareas> tareasRealizadas, List<tareas> tareasPendientes, int cantTareas){
            int respuesta, i=0, control=0;

            while(control != cantTareas)
            {
                Console.WriteLine("¿Realizo la Tarea "+tareasPendientes[i].TareaID+"?");
                Console.WriteLine("Descripcion: "+tareasPendientes[i].Descripcion);
                Console.WriteLine("Duracion: "+tareasPendientes[i].Duracion);
                Console.WriteLine("Respuesta (1=Si | 0=No):");
                respuesta = Convert.ToInt32(Console.ReadLine());
                
                if(respuesta == 1){
                    tareasRealizadas.Add(tareasPendientes[i]);
                    tareasPendientes.RemoveAt(i);
                }else{
                    i++;
                }
                control++;
            }
        }


        //2-
        public static void buscarTareaPendiente(List<tareas> tareasPendientes, string buscar){
            List<tareas> tareasBuscadas = new List<tareas>();
            foreach (var tarea in tareasPendientes)
            {
                if(tarea.Descripcion.Contains(buscar))
                {
                    tareasBuscadas.Add(tarea);
                }
            }
            mostrarTarea(tareasBuscadas);
        }


        //3-
        public static double horasTrabajadas(List<tareas> tareasRealizadas){
            double hrsTrabajadas=0;
            foreach (var tarea in tareasRealizadas)
            {
                hrsTrabajadas += tarea.Duracion;
            }
            return hrsTrabajadas;
        }
    }
}
