#include<stdio.h>
#include<stdlib.h>
#include<string.h>

int main(){
	int filas;
	char **nombres;
	char *Buff;
	
	printf("Indique la cantidad de nombres que quiere ingresar: ");
	scanf("%d", &filas);

	Buff = (char *) malloc(50*sizeof(char)); //reservamos memoria en la var. aux.
	
	nombres = (char **) malloc(sizeof(char *) * filas); //reservamos memoria para el puntero doble
	
	printf("Cargamos ----------------------------\n");

	for(int i=0; i<filas; i++){
		printf("Ingrese un nombre: ");
		fflush(stdin);
		gets(Buff);
		nombres[i] = (char *) malloc(sizeof(char) * (strlen(Buff)+1)); //reservamos memoria en cierta posicion
		strcpy(nombres[i], Buff); //copiamos lo de la var. aux. al vector
	}
	
	printf("\nMostramos ----------------------------\n");
	for(int i=0; i<filas; i++){ //mostramos y liberamos memoria
		puts(nombres[i]);
		free(nombres[i]);
	}

	free(nombres);
	free(Buff);
	
	return 0;
}