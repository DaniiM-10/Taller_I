using System;

//1=true / 0=false

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args){
            int operacion;
            double num;

            Calculadora calculadoraV1 = new Calculadora();

            Console.WriteLine("Ingrese un valor de incio: ");
            calculadoraV1.Resultado = Convert.ToDouble(Console.ReadLine());

            do
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Seleccione una operacion: \n1- Suma\n2- Resta\n3- Multiplicacion\n4- Division\n5- Limpiar\n0- Salir\nRespuesta: ");
                operacion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------------");
              switch (operacion)
              {
                case 0:
                    calculadoraV1.limpiar();
                    break;
                case 1:
                    Console.WriteLine("Ingrese un valor: ");
                    num = Convert.ToDouble(Console.ReadLine());
                    calculadoraV1.sumar(num);
                    break;
                case 2:
                    Console.WriteLine("Ingrese un valor: ");
                    num = Convert.ToDouble(Console.ReadLine());
                    calculadoraV1.restar(num);
                    break;
                case 3:
                    Console.WriteLine("Ingrese un valor: ");
                    num = Convert.ToDouble(Console.ReadLine());
                    calculadoraV1.multiplicar(num);
                    break;
                case 4:
                    Console.WriteLine("Ingrese un valor: ");
                    num = Convert.ToDouble(Console.ReadLine());
                    if(num!=0){
                        calculadoraV1.dividir(num);
                    }else{
                        Console.WriteLine("EL DENOMINADOR NO PUEDE SER 0.");
                    }
                    break;
                case 5:
                    calculadoraV1.limpiar();
                    Console.WriteLine("**************\nResultado: "+calculadoraV1.Resultado+"\n**************");
                    Console.WriteLine("Ingrese un valor de incio: ");
                    calculadoraV1.Resultado = Convert.ToDouble(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Ingreso un valor invalido.");
                    break;
              }  
              Console.WriteLine("**************\nResultado: "+calculadoraV1.Resultado+"\n**************");
            } while (operacion != 0);
        }
    }
}
