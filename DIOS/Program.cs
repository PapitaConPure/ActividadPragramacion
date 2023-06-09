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

                default:
                    seguir = false;
                    break;
                }
            } while (seguir);

			ConsoFacil.FinalizarPrograma();
        }

        static void AgregarValores() {
			Console.Clear();
			Console.CursorTop = 1;
			Console.CursorLeft = 3;
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
			Console.Clear();
			double prom = promedio.CalcularPromedio();
			ConsoFacil.MostrarPlacaDoble("Promedio", Convert.ToString(prom), ConsoleColor.DarkCyan);
			ConsoFacil.PausarPrograma();
        }

        static void MostrarMenu() {
			Console.Clear();
			Console.CursorTop = 1;
			Console.CursorLeft = 3;
			ConsoFacil.MostrarPlacaSimple("Seleccione una opción", ConsoleColor.White, ConsoleColor.Magenta);
			ConsoFacil.MostrarPlacaDoble("1", "Agregar valores   ", ConsoleColor.DarkGreen);
			ConsoFacil.MostrarPlacaDoble("2", "Mostrar promedio  ", ConsoleColor.Blue);
			ConsoFacil.MostrarPlacaDoble("X", "Salir             ", ConsoleColor.Red);
        }
    }
}
