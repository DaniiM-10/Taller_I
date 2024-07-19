using System;

namespace Tareas
{
    class tareas
    {
        public int TareaID;
        public string Descripcion;
        public int Duracion;

        public tareas(int _ID, string _descripcion, int _duracion){
            TareaID = _ID;
            Descripcion = _descripcion;
            Duracion = _duracion;
        }
    }
}