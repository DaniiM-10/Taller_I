#include<stdio.h>

int main(){
    //Punto a)
    printf("Hola Mundo!\n");

    //Punto e)
    int i = 10;
    int *punt = &i; //asignamos al puntero la dir. de memoria de la variable i.

    //Punto f)
    printf("Contenido del puntero: %p\n", punt); //el puntero almacena la dir. de memoria de la variable a la que apunta

    //Punto g)
    printf("Contenido de la dir. de memoria almacenada por el puntero: %d\n", *punt); //muestra el contenido que esta en la dir. de memoria almacenado en el puntero

    //Punto h)
    printf("Direccion de memoria almacenado en el puntero: %p\n", &i); //utilizamos el caracter & para acceder a la dir. de memoria de la variable i

    //Punto i)
    printf("Direccion de memoria del puntero: %p\n", &punt); //utilizamos el caracter & para acceder a la dir. de memoria del puntero *punt

    //Punto j)
    printf("Tamaño de memoria utilizado por la variable i: %d bytes", sizeof(i)); //mostramos los bytes que representa nuestra variable i

    getchar();
    return 0;
}