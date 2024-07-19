#include<stdio.h>
#include<string.h>
#include<time.h>
#include<stdlib.h>
#include<stdbool.h>

char Servicio[3][10] = {"50Mg", "100Mb", "300Mb"};
typedef struct{
    int ServicioID;
    char *ServicioContratado;
    float Precio;
    bool Bonificacion;
    int Empresa;

}TVentas;

typedef struct Nodo{
    TVentas NVentas;
    struct Nodo* Siguiente;
}Nodo;

/************************Funciones***************************/
//punto1
Nodo * crearVenta(int);
Nodo * insertarVenta(Nodo * lista, Nodo * venta);

//punto2
int cantServiciosBonificacion(Nodo * lista);
int cantServiciosSinBonificacion(Nodo * lista);
float MontoTotalSinBonificacion(Nodo * lista);
float MontoTotalConBonificacion(Nodo * lista);
void mostrarServicios(Nodo * lista, int, int);

//punto3
void liberarMemoria(Nodo * lista);

int main(){
    srand(time(NULL)); //Instrucción que inicializa el generador de números aleatorios
    int N = (rand()%51)+50; //numero aleatorio entre 50 y 100

    Nodo * Ventas = NULL; //lista de las ventas

    //punto 1
    for(int i=0; i<N; i++){
        Nodo * nodoVenta = crearVenta(i);
        Ventas = insertarVenta(Ventas, nodoVenta);
    }

    //punto 2
    int cantConBonificacion = cantServiciosBonificacion(Ventas);
    printf("Cantidad de servicios con bonificacion y 50mb : %d\n", cantConBonificacion);

    int cantSinBonificacion = cantServiciosSinBonificacion(Ventas);
    printf("Cantidad de servicios con sin bonificacion y 100mb : %d\n", cantSinBonificacion);

    float totalSinBonificacion = MontoTotalSinBonificacion(Ventas);
    printf("Monto total sin bonificacion : %.2f\n", totalSinBonificacion);

    float totalConBonificacion = MontoTotalConBonificacion(Ventas);
    printf("Monto total con bonificacion: %.2f\n", totalConBonificacion);

    float promedioDeVentas = (totalConBonificacion + totalSinBonificacion) / N;
    printf("Promedio de ventas totales: %.2f\n", promedioDeVentas);

    int cantServicios, opcBonificacion;
    printf("Cuantos servicios quiere mostrar?: ");
    scanf("%d", &cantServicios);
    if(cantServicios != 0){
        printf("Elija una opcion:\n1- Con Bonificacion\n2- Sin Bonificacion\n- ");
        scanf("%d", &opcBonificacion);
    }else{
        opcBonificacion = 0;
    }
    printf("**************VENTAS************\n");
    mostrarServicios(Ventas, cantServicios, opcBonificacion);

    //punto3 
    liberarMemoria(Ventas);
    return 0;
}

//punto 1
Nodo * crearVenta(int id){
    Nodo * venta = (Nodo *) malloc(sizeof(Nodo));
    venta->NVentas.ServicioID = id;

    char *buff = (char *) malloc(sizeof(char) * 50);
    int j=rand()%3;
    strcpy(buff, Servicio[j]);
    venta->NVentas.ServicioContratado = (char *) malloc(sizeof(char) * (strlen(buff)+1));
    strcpy(venta->NVentas.ServicioContratado, buff);
    
    do{
        venta->NVentas.Precio = (rand()%5000)+1;
    }while(venta->NVentas.Precio<2000 || venta->NVentas.Precio>5000);
    if(rand()%2 == 0){
        venta->NVentas.Bonificacion = true;
    }else{
        venta->NVentas.Bonificacion = false;
    }
    venta->NVentas.Empresa = (rand()%3)+1; //random entre 1 y 3
    venta->Siguiente = NULL;
}

Nodo * insertarVenta(Nodo * lista, Nodo * venta){
    Nodo * listaAux = lista;

    if(listaAux != NULL){ //si la lista de tareas no esta vacia
        while(listaAux->Siguiente != NULL){ //recorre la lista hasta que encuentre un nodo cuyo nodo siguiente sea un NULL
            listaAux = listaAux->Siguiente; //se va moviendo de nodo
        }
        listaAux->Siguiente = (Nodo *) malloc(sizeof(Nodo));
        listaAux->Siguiente = venta; //agregamos el nodo creado al final de la lista

        return lista;
    }else{ //si la lista si esta vacia
        listaAux = venta; //inserto el primer nodo de la lista

        return listaAux;
    }
}

//punto 2
int cantServiciosBonificacion(Nodo * lista){
    Nodo * listaAux = lista;
    int i=0;
    while(listaAux!=NULL){
        if(listaAux->NVentas.Empresa == 3){
            if(listaAux->NVentas.Bonificacion == true){
                if(strcmp(listaAux->NVentas.ServicioContratado, "50Mb") == 0){
                    i++;
                }
            }
        }
        listaAux = listaAux->Siguiente;
    }
    return i;
}

int cantServiciosSinBonificacion(Nodo * lista){
    Nodo * listaAux = lista;
    int i=0;
    while(listaAux!=NULL){
        if(listaAux->NVentas.Empresa == 3){
            if(listaAux->NVentas.Bonificacion == false){
                if(strcmp(listaAux->NVentas.ServicioContratado, "100Mb") == 0){
                    i++;
                }
            }
        }
        listaAux = listaAux->Siguiente;
    }
    return i;
}

float MontoTotalSinBonificacion(Nodo * lista){
    Nodo * listaAux = lista;
    float montoTotal=0;
    while(listaAux!=NULL){
        if(listaAux->NVentas.Empresa == 3){
            if(listaAux->NVentas.Bonificacion == false){
                montoTotal = montoTotal + listaAux->NVentas.Precio;
            }
        }
        listaAux = listaAux->Siguiente;
    }
    return montoTotal;
}

float MontoTotalConBonificacion(Nodo * lista){
    Nodo * listaAux = lista;
    float montoTotal=0;
    while(listaAux!=NULL){
        if(listaAux->NVentas.Empresa == 3){
            if(listaAux->NVentas.Bonificacion == true){
                montoTotal = montoTotal + listaAux->NVentas.Precio;
            }
        }
        listaAux = listaAux->Siguiente;
    }
    return montoTotal;
}
void mostrarServicios(Nodo * lista, int cant, int opcBonificacion){
    Nodo * listaAux = lista;

    if(cant == 0){
        while(listaAux != NULL){
            printf("\nID: %d\n", listaAux->NVentas.ServicioID);
            printf("Servicio contratado: %s\n", listaAux->NVentas.ServicioContratado);
            printf("Precio: %.2f/n", listaAux->NVentas.Precio);
            printf("Bonificacion: %d/n", listaAux->NVentas.Bonificacion);
            switch (listaAux->NVentas.Empresa)
            {
            case 1:
                printf("Empresa: Telecom\n");
                break;
            case 2:
                printf("Empresa: Claro\n");
                break;
            default:
                printf("Empresa: Movistar\n");
                break;
            }
            listaAux = listaAux->Siguiente;
        }
    }else{
        int i=0;

        while(listaAux != NULL || i<cant){
            if(opcBonificacion == 1){
                if(listaAux->NVentas.Bonificacion == true){
                    printf("\nID: %d\n", listaAux->NVentas.ServicioID);
                    printf("Servicio contratado: %s \n", listaAux->NVentas.ServicioContratado);
                    printf("Precio: %.2f\n", listaAux->NVentas.Precio);
                    printf("Bonificacion: %d\n", listaAux->NVentas.Bonificacion);
                    switch (listaAux->NVentas.Empresa)
                    {
                    case 1:
                        printf("Empresa: Telecom\n");
                        break;
                    case 2:
                        printf("Empresa: Claro\n");
                        break;
                    default:
                        printf("Empresa: Movistar\n");
                        break;
                    }
                }
                i++;
            }else if(opcBonificacion == 2){
                if(listaAux->NVentas.Bonificacion == false){
                    printf("\nID: %d\n", listaAux->NVentas.ServicioID);
                    printf("Servicio contratado: %s\n", listaAux->NVentas.ServicioContratado);
                    printf("Precio: %.2f/n", listaAux->NVentas.Precio);
                    printf("Bonificacion: %d/n", listaAux->NVentas.Bonificacion);
                    switch (listaAux->NVentas.Empresa)
                    {
                    case 1:
                        printf("Empresa: Telecom\n");
                        break;
                    case 2:
                        printf("Empresa: Claro\n");
                        break;
                    default:
                        printf("Empresa: Movistar\n");
                        break;
                    }
                }
                i++;
            }else{
                printf("Error!\n");
                i=cant;
            }   
            listaAux = listaAux->Siguiente;
        }
    }
}

//punto 3
void liberarMemoria(Nodo * lista){
    Nodo * Aux; //Aux. que servira para apuntar a la lista para no perder la referencia
    while(lista!=NULL){
        Aux=lista; //asignamos la lista en el nodo que lo dejamos
        lista=lista->Siguiente; //pasamos al siguiente nodo
        free(Aux->NVentas.ServicioContratado); //Liberamos el espacio que pedimos para guardar la descripcion
        free(Aux); //liberamos el nodo  
    } 
}