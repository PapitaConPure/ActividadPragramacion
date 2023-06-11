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

		public int CantidadValores {
			get {
				return cantidadValores;
			}
		}

		public int Valor(int i) {
			return this.valores[i];
		}

		public void AgregarValor(int num) {
			this.valores[this.cantidadValores] = num;
			this.cantidadValores++;
			this.EscalarArreglo();
		}

		//Como la clase se llama Promedio, es medio redundante que el método se llame "CalcularPromedio"
		//"Promedio.Calcular()"
		public double Calcular() {
			if(this.cantidadValores == 0)
				return 0;

			return Convert.ToDouble(this.Acumulado) / this.cantidadValores;
		}

		public int[] ValoresSuperiores() {
			double promedio = this.Calcular();
			int[] filtrado = new int[this.cantidadValores];
			int cantidadFiltrada = 0;

			#region Filtrar valores
			int i = 0;
			while(i < this.cantidadValores) {
				if(this.valores[i] > promedio) {
					filtrado[cantidadFiltrada] = this.valores[i];
					cantidadFiltrada++;
				}

				i++;
			}
			#endregion

			#region Copiar en arreglo con tamaño acorde a lo filtrado
			int[] reescalado = new int[cantidadFiltrada];

			for(i = 0; i < cantidadFiltrada; i++)
				reescalado[i] = filtrado[i];
			#endregion

			return reescalado;
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
