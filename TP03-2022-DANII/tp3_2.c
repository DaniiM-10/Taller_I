#include<stdio.h>
#include<stdlib.h>
#include<string.h>

#define N 5

int main(){
	
	char *vector[N];
	char *Buff;
	
	Buff = (char *) malloc(100*sizeof(char)); //reservamos memoria en la var. aux.
	
	printf("Cargamos ----------------------------\n");

	for(int i=0; i<N; i++){
		printf("Ingrese un nombre: ");
		gets(Buff);
		*(vector+i) = (char *) malloc((strlen(Buff)+1)*sizeof(char)); //reservamos memoria en cierta posicion del array con la memoria justa
		strcpy(*(vector+i), Buff); //copiamos lo de la var. aux. al vector
	}
	
	printf("\nMostramos ----------------------------\n");
	for(int i=0; i<N; i++){
		puts(*(vector+i));
		free(*(vector+i));
	}
	free(Buff);
	
	return 0;
}
