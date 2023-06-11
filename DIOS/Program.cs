using System;
using Papita.ConsoFacil;

namespace DIOS {
	internal class Program {
        static Promedio promedio;

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
			int[] valores = promedio.ValoresSuperiores();
			for(int i = 0; i < valores.Length; i++)
				ConsoFacil.MostrarPlacaDoble(String.Format("Valor {0,-3}", i + 1), Convert.ToString(valores[i]), ConsoleColor.DarkCyan);
			ConsoFacil.PausarPrograma();
		}

		static void AcomodarPantalla() {
			Console.Clear();
			Console.CursorTop = 1;
			Console.CursorLeft = 3;
		}
    }
}
