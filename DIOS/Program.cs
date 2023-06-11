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
			AcomodarPantalla();
			ConsoFacil.MostrarPlacaSimple("Seleccione una opción", ConsoleColor.White, ConsoleColor.Magenta);
			ConsoFacil.MostrarPlacaDoble("1", "Agregar valores   ", ConsoleColor.DarkGreen);
			ConsoFacil.MostrarPlacaDoble("2", "Mostrar promedio  ", ConsoleColor.Blue);
			ConsoFacil.MostrarPlacaDoble("3", "Mostrar superiores", ConsoleColor.DarkCyan);
			ConsoFacil.MostrarPlacaDoble("4", "Mostrar ordenados ", ConsoleColor.DarkYellow);
			ConsoFacil.MostrarPlacaDoble("X", "Salir             ", ConsoleColor.Red);
		}

		static void AgregarValores() {
			AcomodarPantalla();
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
			AcomodarPantalla();
			double prom = promedio.CalcularPromedio();
			ConsoFacil.MostrarPlacaDoble("Promedio", Convert.ToString(prom), ConsoleColor.DarkCyan);
			ConsoFacil.PausarPrograma();
		}

		static void MostrarSuperiores() {
			AcomodarPantalla();
			ConsoFacil.MostrarPlacaSimple("Listado de valores superiores al promedio", ConsoleColor.White, ConsoleColor.DarkRed);
			Console.CursorTop++;

			if(promedio.CantidadValores == 0)
				ConsoFacil.MostrarLineaColoreada("No se ingresó ningún valor...", ConsoleColor.Red);
			else {
				int[] valores = promedio.ValoresSuperiores();
				MostrarConjuntoInt32(valores);
			}

			ConsoFacil.PausarPrograma();
		}

		static void MostrarOrdenados() {
			AcomodarPantalla();
			ConsoFacil.MostrarPlacaSimple("Listado de valores ordenados", ConsoleColor.White, ConsoleColor.DarkRed);
			Console.CursorTop++;

			if(promedio.CantidadValores == 0)
				ConsoFacil.MostrarLineaColoreada("No se ingresó ningún valor...", ConsoleColor.Red);
			else {
				int[] valores = new int[promedio.CantidadValores];
				for(int i = 0; i < promedio.CantidadValores; i++)
					valores[i] = promedio.Valor(i);

				QuickSort(valores, 0, valores.Length - 1);
				MostrarConjuntoInt32(valores);
			}

			ConsoFacil.PausarPrograma();
		}

		static void AcomodarPantalla() {
			Console.Clear();
			Console.CursorTop = 1;
			Console.CursorLeft = 3;
		}

		static void MostrarConjuntoInt32(int[] valores) {
			for(int i = 0; i < valores.Length; i++) {
				ConsoFacil.MostrarPlacaDoble(string.Format("Valor {0,-3}", i + 1), Convert.ToString(valores[i]), ConsoleColor.DarkCyan);

				if((i % filasMax) == (filasMax - 1)) {
					Console.CursorLeft += 15;
					Console.CursorTop -= filasMax;
				}
			}
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
	}
}
