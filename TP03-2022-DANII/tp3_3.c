#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<time.h>

//Creamos las estructuras
typedef struct{
	int productoID;
	int Cantidad;
	char *TipoProducto;
	float PrecioUnitario;
}Producto;

typedef struct{
	int ClienteID; // Numerado en el ciclo iterativo
	char *NombreCliente; // Ingresado por usuario
	int CantidadProductosAPedir; // (aleatorio entre 1 y 5)
	Producto *Productos; //El tamaño de este arreglo depende de la variable
}Cliente;

//Declaramos las funciones
void cargarClientes(Cliente *clientes, int cantCalientes);
void mostrarClientesYProductos(Cliente *clientes, int cantClientes);
float costoTotalDeUnProducto(int cantidad, float precio);

int main(){
	srand(time(NULL)); //Instrucción que inicializa el generador de números aleatorios
	
	int cantClientes;
	
	//i- Desarrollar una interfaz por consola donde se solicite al usuario la cantidad de clientes.
	printf("Ingrese la cantidad de clientes: ");
	scanf("%d", &cantClientes);
	
	Cliente *clientes;
	clientes = (Cliente *) malloc(sizeof(Cliente) * cantClientes); //creamos un arreglo de puntero con la cantidad de clientes que se van a cargar
	
	//ii- Solicitar al usuario la carga de los clientes creados dinámicamente en el paso anterior.
	cargarClientes(clientes, cantClientes);
	
	//v- Mostrar por pantalla todo lo cargado. Incluyendo un total a pagar por cliente
	mostrarClientesYProductos(clientes, cantClientes);
	
	return 0;
}

void cargarClientes(Cliente *clientes, int cantClientes){

	char *tipoProductos[] = {"Galletas","Snack","Cigarrillos","Caramelos","Bebidas"};
	char *nombreCliente = (char *) malloc(50*sizeof(char)); //reservamo memoria en el puntero aux para cargar el nombre

	for(int i=0; i<cantClientes; i++){
		clientes[i].ClienteID = i; //id del cliente
		
		printf("Ingrese el nombre del cliente %d: ", i);
		fflush(stdin);
		gets(nombreCliente);
		clientes[i].NombreCliente = (char *) malloc(sizeof(char) * (strlen(nombreCliente) + 1)); //reservamos el memoria para cargar el nombre
		strcpy(clientes[i].NombreCliente, nombreCliente); //copiamos el nombre que cargamos en la var. aux. a la estructura
		
		clientes[i].CantidadProductosAPedir = (rand()%5)+1; //numero random entre 1 y 5

		clientes[i].Productos = (Producto *) malloc(sizeof(Producto) * (clientes[i].CantidadProductosAPedir)+1); //reservamos memoria para cargar cierta cantidad de productos

		for(int j=0; j<clientes[i].CantidadProductosAPedir; j++){
			clientes[i].Productos[j].productoID = j; //id del producto
			clientes[i].Productos[j].Cantidad = (rand()%10)+1; //numero random entre 1 y 10
			
			int posProducto = (rand()%5); //posicion del producto que se va a cargar

			clientes[i].Productos[j].TipoProducto = (char *) malloc(sizeof(char) * (strlen(tipoProductos[posProducto]) + 1)); //reservamos memoria para cargar el producto
			strcpy(clientes[i].Productos[j].TipoProducto, tipoProductos[posProducto]); //compiamos el producto del arreglo a la estructura

			clientes[i].Productos[j].PrecioUnitario = (rand()%91)+10; //precio de cada producto
		}
	}
	
	free(nombreCliente); //liberamos memoria de la variable aux.
}

void mostrarClientesYProductos(Cliente *clientes, int cantClientes){
	for(int i=0; i<cantClientes; i++){
		float totalPagarPorProducto = 0, totalPagar = 0; //variables para guardar los costos

		//mostramos al cliente
		printf("\n-------------------- Cliente %d --------------------\n", i+1);
		printf("ID del cliente: %d\n", clientes[i].ClienteID);
		printf("Nombre del cliente: ");
		puts(clientes[i].NombreCliente);
		printf("Cantidad de productos: %d\n", clientes[i].CantidadProductosAPedir);

		for(int j=0; j<clientes[i].CantidadProductosAPedir; j++){
			//mostramos cada producto del cliente
			printf("--- Producto %d ---\n", j+1);
			printf("ID del producto: %d\n", clientes[i].Productos[j].productoID);
			printf("Tipo de producto: ");
			puts(clientes[i].Productos[j].TipoProducto);
			printf("Cantidad del producto: %d\n", clientes[i].Productos[j].Cantidad);
			printf("Precio unitario: $%.2f\n", clientes[i].Productos[j].PrecioUnitario);
			totalPagarPorProducto = costoTotalDeUnProducto(clientes[i].Productos[j].Cantidad, clientes[i].Productos[j].PrecioUnitario); //funcion que calcula el precio total de cada producto
			printf("Total a pagar del producto: $%.2f\n", totalPagarPorProducto);
			totalPagar += totalPagarPorProducto; //vamos acumulando los costos de todos los productos del cliente para mostrarlo al final
		}

		printf("\n-- Total a pagar por cliente: $%.2f --\n", totalPagar);
	}
	
	//liberamos memoria
	for(int i=0; i<cantClientes; i++){
		for(int j=0; j<clientes[i].CantidadProductosAPedir; j++){
			free(clientes[i].Productos[j].TipoProducto);
		}
		free(clientes[i].Productos);
	}
	free(clientes);
}

float costoTotalDeUnProducto(int cantidad, float precio){
	return cantidad * precio;
}