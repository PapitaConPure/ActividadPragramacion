using System;
using Papita.ConsoFacil;

namespace DIOS {
	internal class Program {
        static Promedio promedio;
		static int filasMax = 10;

        static void Main(string[] args) {
            promedio = new Promedio();
            bool seguir = true;

            do {
                MostrarMenu();
                char op = ConsoFacil.LeerOpcion();

                switch (op) {
                case '1':
                    AgregarValores();
                    break;

                case '2':
                    MostrarPromedio();
                    break;

				case '3':
					MostrarSuperiores();
					break;

				case '4':
					MostrarOrdenados();
					break;

				default:
                    seguir = false;
                    break;
                }
            } while (seguir);

			ConsoFacil.FinalizarPrograma();
		}

		static void MostrarMenu() {
			AcomodarPantalla(48, 10);
			ConsoFacil.MostrarPlacaSimple("Seleccione una opción", ConsoleColor.White, ConsoleColor.Magenta);
			ConsoFacil.MostrarPlacaDoble("1", "Agregar valores   ", ConsoleColor.DarkGreen);
			ConsoFacil.MostrarPlacaDoble("2", "Mostrar promedio  ", ConsoleColor.Blue);
			ConsoFacil.MostrarPlacaDoble("3", "Mostrar superiores", ConsoleColor.DarkCyan);
			ConsoFacil.MostrarPlacaDoble("4", "Mostrar ordenados ", ConsoleColor.DarkYellow);
			ConsoFacil.MostrarPlacaDoble("X", "Salir             ", ConsoleColor.Red);

			Console.CursorTop = 1;
			Console.CursorLeft = 3 + " Seleccione una opción ".Length + 2;
			ConsoFacil.MostrarLineaColoreada("╒═══════════════╕", ConsoleColor.Yellow);
			ConsoFacil.MostrarLineaColoreada("│ Mini-parcial  │", ConsoleColor.Yellow);
			ConsoFacil.MostrarLineaColoreada("│      de       │", ConsoleColor.Yellow);
			ConsoFacil.MostrarLineaColoreada("│ Laboratorio I │", ConsoleColor.Yellow);
			ConsoFacil.MostrarLineaColoreada("│           UTN │", ConsoleColor.Yellow);
			ConsoFacil.MostrarLineaColoreada("╘═══════════════╛", ConsoleColor.Yellow);

			Console.CursorLeft = 3;
		}

		#region Opciones del Menú Principal
		static void AgregarValores() {
			AcomodarPantalla(31, 50);
			ConsoFacil.MostrarPlacaSimple("Ingreso de valores", ConsoleColor.White, ConsoleColor.DarkRed);
            ConsoFacil.MostrarLineaColoreada("Valorcito ó 0 para cortar", ConsoleColor.Cyan);
			Console.CursorTop++;

			int cantLocal = 1;
			int num = ConsoFacil.PedirYSeguirInt32(string.Format("Número {0}", cantLocal), ConsoleColor.DarkYellow);
            while(num != 0) {
				cantLocal++;
				promedio.AgregarValor(num);
                num = ConsoFacil.PedirYSeguirInt32(string.Format("Número {0}", cantLocal), ConsoleColor.DarkYellow);
			}
        }

        static void MostrarPromedio() {
			AcomodarPantalla(48, 6);
			double prom = promedio.Calcular();
			double cant = promedio.CantidadValores;
			ConsoFacil.MostrarPlacaDoble("Promedio", string.Format("{0,6:F2}", prom), ConsoleColor.DarkCyan);
			ConsoFacil.MostrarPlacaDoble("Valores ", string.Format("{0,6}", cant), ConsoleColor.DarkYellow);
			ConsoFacil.PausarPrograma();
		}

		static void MostrarSuperiores() {
			AcomodarPantalla(119, 50);
			ConsoFacil.MostrarPlacaSimple("Listado de valores superiores al promedio", ConsoleColor.White, ConsoleColor.DarkRed);
			Console.CursorTop++;

			if(promedio.CantidadValores == 0)
				ConsoFacil.MostrarLineaColoreada("No se ingresó ningún valor...", ConsoleColor.Red);
			else {
				int[] valores = promedio.ValoresSuperiores();

				if(valores.Length == 0)
					ConsoFacil.MostrarLineaColoreada("Ningún valor es mayor al promedio", ConsoleColor.Cyan);
				else
					MostrarConjuntoInt32(valores, false);
			}

			ConsoFacil.PausarPrograma();
		}

		static void MostrarOrdenados() {
			AcomodarPantalla(119, 50);
			ConsoFacil.MostrarPlacaSimple("Listado de valores ordenados", ConsoleColor.White, ConsoleColor.DarkRed);
			Console.CursorTop++;

			if(promedio.CantidadValores == 0)
				ConsoFacil.MostrarLineaColoreada("No se ingresó ningún valor...", ConsoleColor.Red);
			else {
				int[] valores = new int[promedio.CantidadValores];
				for(int i = 0; i < promedio.CantidadValores; i++)
					valores[i] = promedio.Valor(i);

				QuickSort(valores, 0, valores.Length - 1);
				MostrarConjuntoInt32(valores, true);
			}

			ConsoFacil.PausarPrograma();
		}
		#endregion

		#region Métodos de utilidad
		static void AcomodarPantalla(int ancho, int alto) {
			Console.Clear();
			Console.SetWindowSize(ancho, alto);
			Console.CursorTop = 1;
			Console.CursorLeft = 3;
		}

		static void MostrarConjuntoInt32(int[] valores, bool resaltarDesordenado) {
			int anteriorCursorLeft = Console.CursorLeft;
			int mayorFila = 0;

			for(int i = 0; i < valores.Length; i++) {
				ConsoleColor color = ConsoleColor.DarkCyan;

				if(resaltarDesordenado && i > 0 && valores[i - 1] > valores[i])
					color = ConsoleColor.DarkYellow;

				ConsoFacil.MostrarPlacaDoble(string.Format("Valor {0,-4}", i + 1), string.Format("{0,4}", valores[i]), color);

				if(Console.CursorTop > mayorFila)
					mayorFila = Console.CursorTop;

				if((i % filasMax) == (filasMax - 1)) {
					if(Console.CursorLeft < (Console.WindowWidth - 18 * 2)) {
						Console.CursorTop -= filasMax;
						Console.CursorLeft += 19;
					} else {
						Console.CursorTop++;
						Console.CursorLeft = anteriorCursorLeft;
					}
				}
			}

			Console.CursorTop = mayorFila;
			Console.CursorLeft = anteriorCursorLeft;
		}

		static void QuickSort(int[] vec, int inicio, int fin) {
			if(inicio >= fin)
				return;

			#region Partición
			int pivote = vec[inicio];
			int izq = inicio + 1;
			int der = fin;
			int aux;

			while(izq <= der) {
				while(izq <= fin && vec[izq] < pivote) izq++;
				while(inicio < der && pivote <= vec[der]) der--;

				if(izq < der) {
					aux = vec[izq];
					vec[izq] = vec[der];
					vec[der] = aux;
				}
			}

			vec[inicio] = vec[der];
			vec[der] = pivote;
			#endregion

			if(inicio < der - 1)
				QuickSort(vec, inicio, der - 1);
			if(der + 1 < fin)
				QuickSort(vec, der + 1, fin);
		}
		#endregion
	}
}
