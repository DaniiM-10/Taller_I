using System;

namespace Ejercicio1{
    public class Calculadora
    {
        private double resultado;

        public double Resultado {get => resultado; set => resultado = value;}
        public void sumar(double _resultado){
            resultado = resultado + _resultado;
        }
        public void restar(double _resultado){
            resultado = resultado - _resultado;
        }
        public void multiplicar(double _resultado){
            resultado = resultado * _resultado;
        }
        public void dividir(double _resultado){
            resultado = resultado / _resultado;
        }
        public void limpiar(){
            resultado = 0;
        }

    }
}