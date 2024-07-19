#include<stdio.h>
#include<stdlib.h>
#include<time.h>
#include<string.h>

#define X 6
#define Y 10
#define PCS 5

//Declaramos la estructura
typedef struct {
	int velocidad;
	int anio;
	int cantidad;
	char *tipo_compu;
}pc;

//Declaramos a las funciones
void cargarPc(pc *compu, char tipos[X][Y]); //carga una struct con datos random

void mostrarPc(pc *compu); //muestra una struct

void cincoPcs(pc *compu, char tipos[X][Y]); //carga y muestra las 5 pc

void pcMasVieja(pc *compu); //obtiene y muestra la pc mas vieja de las 5 cargadas

void pcMasVeloz(pc *compu); //obtiene y muestra la pc mas veloz de las 5 cargadas

int main(){
	
	srand(time(NULL)); //Instrucción que inicializa el generador de números aleatorios
	
	//Arreglo con los procesadores
	char tipos[X][Y]={"Intel", "AMD", "Celeron", "Athlo", "Core", "Pentium"};
	
	//Declaramos el arreglo de estructuras
	pc arrayPcs[PCS];
	
	//Llamamos a las funciones
	cincoPcs(arrayPcs, tipos);
	pcMasVieja(arrayPcs);
	pcMasVeloz(arrayPcs);
	
	return 0;
}

//carga una struct con datos random
void cargarPc(pc *compu, char tipos[X][Y]){
	compu->velocidad = (rand()%3)+1; //valor aleatorio del 1 al 3
	compu->anio = 2000 + (rand()%18); //valor aleatorio del 2000 al 2017
	compu->cantidad = (rand()%8)+1; //valor aleatorio del 1 al 8
	compu->tipo_compu = &tipos[rand()%X][0]; //guarda un elemento aleatorio del arreglo tipos de procesadores
}

//muestra una struct
void mostrarPc(pc *compu){
	
	//mostramos los valores de una struct con el operador flecha
	printf("Velocidad: %d\n", compu->velocidad);
	printf("Anio: %d\n", compu->anio);
	printf("Cantidad: %d\n", compu->cantidad);
	printf("tipo: %s\n", compu->tipo_compu);
}

//carga y muestra las 5 pc
void cincoPcs(pc *compu, char tipos[X][Y]){
	int i;
	
	//for para cargar el arreglo de tipo struct con datos
	for(i=0; i<PCS; i++){
		cargarPc(compu+i, tipos);
	}
	
	//for para mostrar el arreglo de tipo struct
	for(i=0; i<PCS; i++){
		printf("\n------------Compu %d--------\n", i+1);
		mostrarPc(compu+i);
	}
}

//obtiene y muestra la pc mas vieja de las 5 cargadas
void pcMasVieja(pc *compu){
	int i;
	
	printf("\n------------PC mas vieja--------\n");
	
	pc pcVieja = compu[0]; //guardamos en una variable auxiliar la primera pc que cargamos para poder compararla con las otras del arreglo
	
	//recorremos todo el arreglo e iremos comparando el anio de cada pc
	for(i=0; i<PCS; i++){
		
		//cuando detecte una mas vieja que la que esta en la variable auxiliar actualizara los datos
		if(compu[i].anio < pcVieja.anio){
			pcVieja = compu[i];
		}
	}
	
	mostrarPc(&pcVieja); //mostramos la pc mas vieja que encontramos
}

//obtiene y muestra la pc mas veloz de las 5 cargadas
void pcMasVeloz(pc *compu){
	int i;
	
	printf("\n------------PC mas veloz--------\n");
	
	pc pcVeloz = compu[0]; //guardamos en una variable auxiliar la primera pc que cargamos para poder compararla con las otras del arreglo
	
	//recorremos todo el arreglo e iremos comparando la velocidad de cada pc
	for(i=0; i<PCS; i++){
		
		//cuando detecte una mas veloz que la que esta en la variable auxiliar actualizara los datos
		if(compu[i].velocidad > pcVeloz.velocidad){
			pcVeloz = compu[i];
		}
	}
	
	mostrarPc(&pcVeloz); //mostramos la pc mas veloz que encontramos
}
