using System;

namespace Program
{
    class informacion
    {
        private int ID;
        private string Nombre;
        private string Extencion;

        public int id{get=>ID; set=>ID = value;}
        public string nombre{get=>Nombre; set=>Nombre = value;}
        public string extencion{get=>Extencion; set=>Extencion = value;}

        public informacion(int _id, string _nombre, string _extencion){
            this.ID = _id;
            this.Nombre = _nombre;
            this.Extencion = _extencion;
        }
    }
}