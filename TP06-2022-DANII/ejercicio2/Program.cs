using System;
using sistemaAdministrativo;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args){
            Empleado empleado1 = new Empleado();
            Empleado empleado2 = new Empleado();
            Empleado empleado3 = new Empleado();

            //cargamos los empleados
            Console.WriteLine("\n*******************Empleado 1********************\n");
            empleado1 = cargarEmpleado(empleado1);            
            Console.WriteLine("\n*******************Empleado 2********************\n");
            empleado2 = cargarEmpleado(empleado2);            
            Console.WriteLine("\n*******************Empleado 3********************\n");
            empleado3 = cargarEmpleado(empleado3);            
        
        //a)----------------------------------------------------------------------------------------
            //i)-
                int antiguedadEmpleado1 = empleado1.antiguedad(empleado1.FechaDeIngresoEmpresa);
                int antiguedadEmpleado2 = empleado2.antiguedad(empleado2.FechaDeIngresoEmpresa);
                int antiguedadEmpleado3 = empleado2.antiguedad(empleado3.FechaDeIngresoEmpresa);

            //ii)-
                int edadEmpleado1 = empleado1.edad(empleado1.FechaDeNacimiento);
                int edadEmpleado2 = empleado1.edad(empleado2.FechaDeNacimiento);
                int edadEmpleado3 = empleado1.edad(empleado3.FechaDeNacimiento);

        //d)-----------------------------------------------------------------------------------------
            double salarioEmpleado1 = empleado1.salario(empleado1.SueldoBasico, empleado1.Cargo, empleado1.EstadoCivil, antiguedadEmpleado1);
            double salarioEmpleado2 = empleado2.salario(empleado2.SueldoBasico, empleado2.Cargo, empleado2.EstadoCivil, antiguedadEmpleado2);
            double salarioEmpleado3 = empleado3.salario(empleado3.SueldoBasico, empleado3.Cargo, empleado3.EstadoCivil, antiguedadEmpleado3);

            double salarioTotal = salarioEmpleado1 + salarioEmpleado2 + salarioEmpleado3;
            Console.WriteLine("\n********************************\nEl monto total de salarios a pagar es: $"+salarioTotal);

        //e)-----------------------------------------------------------------------------------------
            int jubilacionEmpleado1 = empleado1.jubilacion(edadEmpleado1);
            int jubilacionEmpleado2 = empleado1.jubilacion(edadEmpleado2);
            int jubilacionEmpleado3 = empleado1.jubilacion(edadEmpleado3);
            Console.WriteLine("\nEmpleado mas proximo a jubilarse-----------------------\n");
            if(jubilacionEmpleado1 < jubilacionEmpleado2 && jubilacionEmpleado1 < jubilacionEmpleado3){
                Console.WriteLine("------ Empleado 1 ------");
                jubilacionMasProxima(empleado1, antiguedadEmpleado1, edadEmpleado1, salarioEmpleado1);
            }else{
                if(jubilacionEmpleado2 < jubilacionEmpleado1 && jubilacionEmpleado2 < jubilacionEmpleado3){
                    Console.WriteLine("------ Empleado 2 ------");
                    jubilacionMasProxima(empleado2, antiguedadEmpleado2, edadEmpleado2, salarioEmpleado2);
                }else{
                    Console.WriteLine("------ Empleado 3 ------");
                    jubilacionMasProxima(empleado3, antiguedadEmpleado3, edadEmpleado3, salarioEmpleado3);
                }
            }

        }

        static Empleado cargarEmpleado(Empleado empleadoCargar){
            //ingresar los datos
            string cargoDeEmpleado = "";
            Console.WriteLine("Ingrese su nombre: ");
            empleadoCargar.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido: ");
            empleadoCargar.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese su fecha de nacimiento(dd-mm-aaaa): ");
            empleadoCargar.FechaDeNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese su estado civil (S/P/C): ");
            empleadoCargar.EstadoCivil = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Genero (m/M | h/H): ");
            empleadoCargar.Genero = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Fecha de ingreso a la empresa (dd-mm-aaaa): ");
            empleadoCargar.FechaDeIngresoEmpresa = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Sueldo Basico: ");
            empleadoCargar.SueldoBasico = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Su Cargo(Auxiliar, Administrativo, Ingeniero, Especialista, Investigador): ");
            cargoDeEmpleado = Console.ReadLine();
            empleadoCargar.Cargo = (Empleado.cargo)Enum.Parse(typeof(Empleado.cargo), cargoDeEmpleado);

            return empleadoCargar;
        }

        static void jubilacionMasProxima(Empleado empleadoConJubilacionMasProxima, int antiguedad, int edad, double salario){
            Console.WriteLine("Antiguedad: "+antiguedad+" año/s");
            Console.WriteLine("Edad: "+edad+" años");
            Console.WriteLine("Años faltantes para su jubilacion: "+empleadoConJubilacionMasProxima.jubilacion(edad)+" año/s");
            Console.WriteLine("Salario: $"+salario);
        }
    }
}
