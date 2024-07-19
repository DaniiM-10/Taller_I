using System;

namespace sistemaAdministrativo{
    public class Empleado
    {   
        //Propiedades
        private string nombre="";
        private string apellido="";
        private DateTime fechaDeNacimiento;
        private char estadoCivil;
        private char genero;
        private DateTime fechaDeIngresoEmpresa;
        private double sueldoBasico;
        public cargo Cargo;
        public enum cargo{
            Auxiliar,
            Administrativo,
            Ingeniero,
            Especialista,
            Investigador
        }

        public string Nombre {get => nombre; set => nombre = value;}
        public string Apellido {get => apellido; set => apellido = value;}
        public DateTime FechaDeNacimiento {get => fechaDeNacimiento; set => fechaDeNacimiento = value;}
        public char EstadoCivil {get => estadoCivil; set => estadoCivil = value;}
        public char Genero {get => genero; set => genero = value;}
        public DateTime FechaDeIngresoEmpresa {get => fechaDeIngresoEmpresa; set => fechaDeIngresoEmpresa = value;}
        public double SueldoBasico {get => sueldoBasico; set => sueldoBasico = value;}


        //Metodos
        public int antiguedad(DateTime fechaDeIngresoEmpresa){
            int antiguedad = (DateTime.Now.Month - fechaDeIngresoEmpresa.Month)+12 * (DateTime.Now.Year - fechaDeIngresoEmpresa.Year);

            if(antiguedad >= 12){
                antiguedad = antiguedad / 12; //en el caso de que lleve 1 año o mas de antiguedad
            }else{
                antiguedad = 0; //en el caso de que no lleve 1 año de antiguedad
            }

            return antiguedad;
        }

        public int edad(DateTime fechaDeNacimiento){
            int edad = DateTime.Now.Year - fechaDeNacimiento.Year;
            if(fechaDeNacimiento.Month > DateTime.Now.Month){ //En caso de que el mes de nacimiento sea mayor que el que estamos 
                edad -= 1; //restaremos 1 año de la edad
            }
            if(fechaDeNacimiento.Month == DateTime.Now.Month){ //En el caso de que el mes sea el mismo
                if(fechaDeNacimiento.Day > DateTime.Now.Day){ //En el caso de que su cumpleaños todavia no llega
                    edad -= 1;
                }
            }
            return edad;
        }

        public int jubilacion(int edadEmpleado){
            int aniosParaJubilarse = 0;
            if(genero == 'm' || genero == 'M'){
                aniosParaJubilarse = 60 - edadEmpleado;
                if(aniosParaJubilarse <= 0){
                    aniosParaJubilarse = 0;
                }
            }else{
                if(genero == 'h' || genero == 'H'){
                    aniosParaJubilarse = 65 - edadEmpleado;
                    if(aniosParaJubilarse <= 0){
                        aniosParaJubilarse = 0;
                    }
                }
            }

            return aniosParaJubilarse;
        }

        //b
        public double salario(double _sueldoBasico, cargo _Cargo, char _estadoCivil, int _antiguedad){
            double adicional;
            
            //i)-
            if(_antiguedad <= 20){
                if(_antiguedad == 0){
                    adicional = 0;
                }else{
                    adicional = (1*_antiguedad/100)*_sueldoBasico;
                }
            }else{
                adicional = 0.25*_sueldoBasico;
            }
            
            if(_Cargo == cargo.Ingeniero || _Cargo == cargo.Especialista){
                adicional += 0.50*adicional;
            }

            if(char.ToUpper(_estadoCivil) == 'C'){
                adicional += 15000;
            }

            double salarioTotal = sueldoBasico + adicional;

            return salarioTotal;
        }
    }
}