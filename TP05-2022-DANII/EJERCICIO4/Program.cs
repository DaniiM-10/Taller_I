// See https://aka.ms/new-console-template for more information

using System;
using System.Text.RegularExpressions;

Console.WriteLine("Ingrese una cadena: ");
string cadenaTxt1 = Console.ReadLine();

//1- Obtener algunas letras que forman parte de una cadena
Console.WriteLine("Ingrese una letra para buscar: ");
char letraBuscar = Convert.ToChar(Console.ReadLine());
int contadorLetra = obtenerLetraDeUnaCadena(cadenaTxt1, letraBuscar);
Console.WriteLine("La cantidad de veces que aparece la letra '"+letraBuscar+"' es: "+contadorLetra);

//2- longitud de una cadena
int longCadena = cadenaTxt1.Length;

Console.WriteLine("La longitud de la cadena es: "+longCadena);

//3- Concatenar cadenas de texto
Console.WriteLine("\n---------------------------------------------------------\n");
Console.WriteLine("Ingrese la otra cadena: ");
string cadenaTxt2 = Console.ReadLine();

string cadenaConcatenada = cadenaTxt1+cadenaTxt2;

Console.WriteLine("La cadena concatenada es: "+cadenaConcatenada);

//4- Obtener una subcadena de la cadenaConcatenada
Console.WriteLine("\n---------------------------------------------------------\n");
string subCadena = cadenaConcatenada.Substring(longCadena);
Console.WriteLine("Una subCadena de la cadenaConcatenada: "+subCadena);


//Punto 5 y 11 de las calculadoras
Console.WriteLine("\n---------------------------------------------------------\n");
Console.WriteLine("Ingrese una operación aritmética que desea realizar: ");
string operacionTxt = Console.ReadLine();

    if(operacionTxt.Contains('+')){
        double resultado = Convert.ToDouble(operacionTxt.Split('+')[0]) + Convert.ToDouble(operacionTxt.Split('+')[1]);
        Console.WriteLine("El resultado de la suma es: "+resultado);
    }
    if(operacionTxt.Contains('-')){
        double resultado = Convert.ToDouble(operacionTxt.Split('-')[0]) - Convert.ToDouble(operacionTxt.Split('-')[1]);
        Console.WriteLine("El resultado de la resta es: "+resultado);
    }
    if(operacionTxt.Contains('*')){
        double resultado = Convert.ToDouble(operacionTxt.Split('*')[0]) * Convert.ToDouble(operacionTxt.Split('*')[1]);
        Console.WriteLine("El resultado del producto es: "+resultado);
    }
    if(operacionTxt.Contains('/')){
        if(Convert.ToDouble(operacionTxt.Split('/')[1]) == 0){
            Console.WriteLine("No está definida la división en cero");
        } else {
            double resultado = Convert.ToDouble(operacionTxt.Split('/')[0]) / Convert.ToDouble(operacionTxt.Split('/')[1]);
            Console.WriteLine("El resultado del cociente es: "+resultado);
        }
    }


//6- Recorrer la cadena de texto con un ciclo Foreach e ir mostrando elemento por elemento
Console.WriteLine("\n---------------------------------------------------------\n");
Console.WriteLine("Muestro caracter a caracter de la cadenaConcatenada con un Foreach:");

foreach (char letra in cadenaConcatenada)
{
    Console.Write(letra+"   ");
}

//7- Buscar la ocurrencia de una palabra determinada en la cadena ingresada
Console.WriteLine("\n---------------------------------------------------------\n");
Console.WriteLine("Ingrese una palabra: ");
string palabraBuscar = Console.ReadLine();
int total = Regex.Matches(cadenaConcatenada, palabraBuscar).Count; //cuenta la cantidad de veces que aparece una palbra en un string
Console.WriteLine("\nLa cantidad de veces que aparece la palabra '"+palabraBuscar+"' en la cadena concatenada es: "+total);


//8- Convierta la cadena a Mayúsculas y luego minúsculas
Console.WriteLine("\n---------------------------------------------------------\n");
Console.WriteLine("Cadena a minúsculas: "+cadenaConcatenada.ToLower());

Console.WriteLine("Cadena a mayúsculas: "+cadenaConcatenada.ToUpper());


//9- Ingrese una nueva cadena y luego compare los valores de ambas
Console.WriteLine("\n---------------------------------------------------------\n");
Console.WriteLine("Ingrese una cadena para comparar: ");
string nuevaCadena = Console.ReadLine();

Console.WriteLine("Comparando con el metodo Equals: "+String.Equals(cadenaConcatenada, nuevaCadena)); //metodo recomendado por microsoft para la comparacion de cadenas


//10- Ingrese una cadena separada por caracteres que usted determine y muestre por pantalla los resultados 
Console.WriteLine("\n---------------------------------------------------------\n");
Console.WriteLine("Ingrese una cadena separada por guiones: ");
string funcSplit = Console.ReadLine();

string cadenaSinEspacio = funcSplit.Replace(" ", String.Empty); //eliminamos todos los espacios de la cadena
string[] arrSplit = cadenaSinEspacio.Split("-"); //separa la cadena en el -

Console.WriteLine("Con la func Split: ");

foreach (string cadenaSplit in arrSplit)
{
    Console.WriteLine(cadenaSplit);
}


//Funciones
int obtenerLetraDeUnaCadena(string cadenaCompleta, char letraBuscar){
    int cont = 0;
    foreach (char letra in cadenaCompleta)
    {
        if(letra == letraBuscar){
            cont++;   
        }
    }
    return cont;
}

