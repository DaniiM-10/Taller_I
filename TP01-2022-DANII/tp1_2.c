#include<stdio.h>
#include<stdlib.h>

//Inicializamos funcion que devuelve el cuadrado de un numero
int cuadradoNum(int num);

//Inicializamos funcion el cuadrado de un numero (tipo void)
void cuadradoNumVoid(int num);

//Inicializamos la funcion que nos mostrara la dir. de memoria y contenido de una variable
void infoVar(int num);

//Inicializamos la funcion para invertir dos valores
void invertirVal(int *a, int *b);

//Inicializamos la funcion para ordenar los valores de menor a mayor
void ordenarVal(int *n1, int *n2);

int main(){
    int num = 4;

    //Cuadrado de un numero
    int funcionCuadrado = cuadradoNum(num);
    printf("El cuadrado de %d es: %d\n", num, funcionCuadrado);

    //Cuadrado de un numero (tipo void)
    cuadradoNumVoid(num);

    //Dir. de memoria y contenido de una variable
    infoVar(num);

    //Invertir dos valores de entrada
    int a, b;
    printf("\n-------------------------Invertir dos valores -----------------------\n");
    printf("Ingrese el valor de a: ");
    scanf("%d", &a);
    printf("Ingrese el valor de b: ");
    scanf("%d", &b);

    invertirVal(&a, &b);
    printf("El valor de a es: %d\n", a);
    printf("El valor de b es: %d\n", b);

    //Ordenar valores
    int n1, n2;
    printf("\n-------------------------Ordenar dos valores -----------------------\n");
    printf("Ingrese el valor de a: ");
    scanf("%d", &n1);
    printf("Ingrese el valor de b: ");
    scanf("%d", &n2);

    ordenarVal(&n1, &n2);

    getchar();
    system("pause");
    return 0;
}

//Funcion que devuelve el cuadrado de un numero
int cuadradoNum(int num){
    int cuadrado = num * num;
    return cuadrado;
}

//Funcion (tipo void) del cuadrado de un numero
void cuadradoNumVoid(int num){
    int cuadrado = num * num;
    printf("El cuadrado de %d es: %d\n", num, cuadrado);
}

//Funcion que nos mostrara la dir. de memoria y contenido de una variable
void infoVar(int num){
    printf("La dir. de memoria de la variable es %p y su contenido es %d.\n", &num, num);
}

//Invertir dos valores
void invertirVal(int *a, int *b){
    int aux = *a; //Guardamos el valor de a en una variable aux para luego cambiarlo

    //Hacemos el intercambio de valores
    *a = *b;
    *b = aux;
}

//Ordenar valores de menor a mayor
void ordenarVal(int *n1, int *n2){
    if(*n1 <= *n2){
        printf("El orden en forma ascentende seria:\n- n1 = %d\n- n2 = %d\n", *n1, *n2);
    }else{
        printf("El orden en forma ascentende seria:\n- n2 = %d\n- n1 = %d\n", *n2, *n1);
    }
}