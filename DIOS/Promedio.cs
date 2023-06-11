using System;

namespace DIOS {
    class Promedio {
        int[] valores;
		int cantidadValores;

        public Promedio() { 
            this.valores = new int[2];
			this.cantidadValores = 0;
		}

		private int Acumulado {
			get {
				int acumulado = 0;

				int i = 0;
				while(i < cantidadValores)
					acumulado += valores[i++];

				return acumulado;
			}
		}

		public void AgregarValor(int num) {
			this.valores[this.cantidadValores] = num;
			this.cantidadValores++;
			this.EscalarArreglo();
		}

		public double CalcularPromedio() {
            if(this.cantidadValores == 0)
                return 0;

			return Convert.ToDouble(this.Acumulado) / this.cantidadValores;
        }

		private void EscalarArreglo() {
			int nuevoLargo = this.valores.Length;

			if(this.cantidadValores < this.valores.Length / 2)
				nuevoLargo /= 2;
			else if(this.cantidadValores >= this.valores.Length)
				nuevoLargo *= 2;
			else
				return;

			int[] nuevoArr = new int[nuevoLargo];

			for(int i = 0; i < this.valores.Length; i++)
				nuevoArr[i] = this.valores[i];

			this.valores = nuevoArr;
		}
    }
}
