using System;

namespace DIOS {
    class Promedio {
        int acumulado;
        int cantidadValores;

        public Promedio() { 
            acumulado = 0;
            cantidadValores = 0;
        }

        public void AgregarValor(int num) {
            acumulado += num;
            cantidadValores++;
        }

        public double CalcularPromedio() { 
            if(cantidadValores == 0)
                return 0;
            else
                return Convert.ToDouble(acumulado) / cantidadValores;
        }
    }
}
