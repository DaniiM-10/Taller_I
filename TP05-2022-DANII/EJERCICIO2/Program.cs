// See https://aka.ms/new-console-template for more information
using System;
Console.WriteLine("Hello, World!");


string otroCalculo = String.Empty;

do
{
    //elegimos la operacion a realizar
    Console.WriteLine("Que operacion desea realizar?\n1-Suma\n2-Resta\n3-Multiplicacion\n4-Division\nRespuesta: ");   
    int opcionAritmetica = Convert.ToInt32(Console.ReadLine());
    double resultado = 0;

    //pedimos los valores
    Console.WriteLine("Ingrese el primer valor: ");
    double n1 = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Ingrese el segundo valor: ");
    double n2 = Convert.ToDouble(Console.ReadLine());

    switch (opcionAritmetica)
    {
        case 1:
            resultado = suma(n1, n2);
            break;
        case 2:
            resultado = resta(n1, n2);
            break;
        case 3:
            resultado = multiplicacion(n1, n2);
            break;
        case 4:
            if(n2 == 0){
                Console.WriteLine("No puede tener 0 en el denominador!!!");
            }else{
                resultado = division(n1, n2);
            }
            break;
        default:
            Console.WriteLine("Ingreso un valor incorrecto!");
            break;
    }
    Console.WriteLine("Resultado = "+resultado);
    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine("Desea realizar otra operacion?\nSI/si o NO/no\nRespuesta: ");
    otroCalculo = Console.ReadLine();
} while (otroCalculo != "no" && otroCalculo != "NO");

//funciones calculadora V1
double suma(double n1, double n2){
    return n1+n2;   
}
double resta(double n1, double n2){
    return n1-n2;
}
double multiplicacion(double n1, double n2){
    return n1*n2;
}
double division(double n1, double n2){
    return n1/n2;
}
//version 2
Console.WriteLine("Ingrese un valor: ");
double n3 = Convert.ToDouble(Console.ReadLine());

//funciones calculadora V2
Console.WriteLine("El valor absoluto de "+n3+" = "+Math.Abs(n3));
Console.WriteLine("El cuadrado de "+n3+" = "+Math.Pow(n3, 2));
Console.WriteLine("La raiz cuadrada de "+n3+" = "+Math.Sqrt(n3));
Console.WriteLine("El Seno de "+n3+" = "+Math.Sin(n3));
Console.WriteLine("El Coseno de "+n3+" = "+Math.Cos(n3));
Console.WriteLine("Redondeo el numero flotante "+n3+" = "+Math.Round(n3));

Console.WriteLine("Ingrese un primer valor: ");
double valor1 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Ingrese un segundo valor: ");
double valor2 = Convert.ToDouble(Console.ReadLine());

if(valor1 > valor2){
    Console.WriteLine("El valor maximo (valor 1): "+ valor1);
    Console.WriteLine("El valor minimo (valor 2): "+ valor2);
}else{
    if(valor2 > valor1){
        Console.WriteLine("El valor maximo (valor 2): "+ valor2);
        Console.WriteLine("El valor minimo (valor 1): "+ valor1);
    }else{
        Console.WriteLine(valor1+"(valor 1) es igual a "+valor2+"(valor 2).");
    }
}