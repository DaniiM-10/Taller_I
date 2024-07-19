// See https://aka.ms/new-console-template for more information
using System;
Console.WriteLine("Ingrese un numero: ");
string numero = Console.ReadLine();

if(Convert.ToInt32(numero)>0){
    string numInvertido = invertirNumero(numero);
    Console.WriteLine("El numero invertido es: " + numInvertido);
}else{
    Console.WriteLine("El numero menor o igual a 0: "+numero);
}

string invertirNumero(string n){
    string numInverso = String.Empty; //inicializamos el string vacio
    for (int i=n.Length-1; i>=0; i--) //recorremos el numero de atras hacia adelante
    {
        numInverso += n[i];
    }
    return numInverso;
}