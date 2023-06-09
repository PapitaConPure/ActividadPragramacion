using System;

namespace Papita.ConsoFacil {
	class ConsoFacil {
		private static int tempCursorLeft = 0;

		#region Métodos híbridos de entrada-salida
		public static int PedirYSeguirInt32(string texto, ConsoleColor colorEnfasis) {
			int indentado = Console.CursorLeft;

			PedirEntradaPlaca(texto, colorEnfasis);
			int entrada = LeerInt32();
			SeguirEntradaPlaca(entrada, colorEnfasis);

			Console.CursorLeft = indentado;
			return entrada;
		}
		public static double PedirYSeguirDouble(string texto, ConsoleColor colorEnfasis) {
			int indentado = Console.CursorLeft;

			PedirEntradaPlaca(texto, colorEnfasis);
			double entrada = LeerDouble();
			SeguirEntradaPlaca(entrada, colorEnfasis);

			Console.CursorLeft = indentado;
			return entrada;
		}
		public static string PedirYSeguirString(string texto, ConsoleColor colorEnfasis) {
			int indentado = Console.CursorLeft;

			PedirEntradaPlaca(texto, colorEnfasis);
			string entrada = Console.ReadLine();
			SeguirEntradaPlaca(entrada, colorEnfasis);

			Console.CursorLeft = indentado;
			return entrada;
		}
		#endregion

		#region Pausa elegante
		public static void PausarPrograma(bool centrado = false) {
			string mensajePausa = "Presiona cualquier tecla para continuar... ";
			if(centrado)
				Console.CursorLeft = CalcularCentradoHorizontal(mensajePausa);
			Console.CursorTop += 1;
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write(mensajePausa);
			Console.ReadKey();
		}

		public static void FinalizarPrograma(bool centrado = false) {
			string mensajeFinal = "Presiona cualquier tecla para salir... ";
			Console.CursorTop += 1;
			if(centrado)
				Console.CursorLeft = CalcularCentradoHorizontal(mensajeFinal);
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write(mensajeFinal);
			Console.ReadKey();
		}
		#endregion

		#region Coloreo básico
		public static void MostrarColoreado(string texto, ConsoleColor color) {
			ConsoleColor anteriorFg = Console.ForegroundColor;
			ConsoleColor anteriorBg = Console.BackgroundColor;

			Console.ForegroundColor = color;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write(texto);

			Console.ForegroundColor = anteriorFg;
			Console.BackgroundColor = anteriorBg;
		}

		public static void MostrarLineaColoreada(string texto, ConsoleColor color) {
			ConsoleColor anteriorFg = Console.ForegroundColor;
			ConsoleColor anteriorBg = Console.BackgroundColor;
			int anteriorCursorLeft = Console.CursorLeft;

			Console.ForegroundColor = color;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.WriteLine(texto);

			Console.ForegroundColor = anteriorFg;
			Console.BackgroundColor = anteriorBg;
			Console.CursorLeft = anteriorCursorLeft;
		}
		#endregion

		#region Placas
		public static void MostrarPlacaSimple(string cartel, ConsoleColor foreground, ConsoleColor background) {
			ConsoleColor anteriorFg = Console.ForegroundColor;
			ConsoleColor anteriorBg = Console.BackgroundColor;
			tempCursorLeft = Console.CursorLeft;

			Console.ForegroundColor = foreground;
			Console.BackgroundColor = background;
			Console.WriteLine(" {0} ", cartel);

			Console.ForegroundColor = anteriorFg;
			Console.BackgroundColor = anteriorBg;
			Console.CursorLeft = tempCursorLeft;
		}

		public static void MostrarPlacaDoble(string cartel, string dato, ConsoleColor colorEnfasis) {
			ConsoleColor anteriorFg = Console.ForegroundColor;
			ConsoleColor anteriorBg = Console.BackgroundColor;
			tempCursorLeft = Console.CursorLeft;

			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = colorEnfasis;
			Console.Write(" {0} ", cartel);

			Console.ForegroundColor = colorEnfasis;
			Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine(" {0} ", dato);
			Console.ResetColor();

			Console.ForegroundColor = anteriorFg;
			Console.BackgroundColor = anteriorBg;
			Console.CursorLeft = tempCursorLeft;
		}

		public static void PedirEntradaPlaca(string texto, ConsoleColor colorEnfasis) {
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = colorEnfasis;
			Console.Write(" {0} ", texto);

			tempCursorLeft = Console.CursorLeft;

			Console.ResetColor();
			Console.Write(" >");
		}

		public static void SeguirEntradaPlaca(double variable, ConsoleColor colorEnfasis) {
			Console.ResetColor();

			Console.CursorTop -= 1;
			Console.CursorLeft = tempCursorLeft;

			int cantidadEspacios = Console.WindowWidth - Console.CursorLeft - 1;
			Console.Write("{0," + cantidadEspacios + "}", " ");
			Console.CursorLeft -= cantidadEspacios;

			Console.ForegroundColor = colorEnfasis;
			Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine(" {0:0.##} ", variable);

			Console.ResetColor();
		}
		public static void SeguirEntradaPlaca(string variable, ConsoleColor colorEnfasis) {
			Console.ResetColor();

			Console.CursorTop -= 1;
			Console.CursorLeft = tempCursorLeft;

			int cantidadEspacios = Console.WindowWidth - Console.CursorLeft - 1;
			Console.Write("{0," + cantidadEspacios + "}", " ");
			Console.CursorLeft -= cantidadEspacios;

			Console.ForegroundColor = colorEnfasis;
			Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine(" {0} ", variable);

			Console.ResetColor();
		}
		#endregion

		#region Cálculos de utilidad
		static int CalcularCentradoHorizontal(string muestra) {
			return Console.WindowWidth / 2 - muestra.Length / 2;
		}
		static int CalcularCentradoVertical(int lineas) {
			return Console.WindowHeight / 2 - (int)Math.Ceiling(lineas / 2d);
		}
		#endregion

		#region Atajos de lectura
		public static int LeerInt32() {
			int num;
			bool valido;
			string entrada;
			int mayorLargo;
			int anteriorCursorLeft = Console.CursorLeft;
			string mensajeError = "Número inválido";

			entrada = Console.ReadLine();
			valido = int.TryParse(entrada, out num);

			while(!valido) {
				Console.CursorTop--;
				Console.CursorLeft = anteriorCursorLeft;
				mayorLargo = Math.Max(entrada.Length, mensajeError.Length);
				Console.WriteLine("{0,-" + Convert.ToString(mayorLargo) + "}", num);
				Console.CursorTop--;
				Console.CursorLeft = anteriorCursorLeft;

				MostrarColoreado(mensajeError, ConsoleColor.Red);
				Console.CursorLeft = anteriorCursorLeft;

				entrada = Console.ReadLine();
				valido = int.TryParse(entrada, out num);
			}

			Console.CursorTop--;
			Console.CursorLeft = anteriorCursorLeft;
			mayorLargo = Math.Max(entrada.Length, mensajeError.Length);
			Console.WriteLine("{0,-" + Convert.ToString(mayorLargo) + "}", num);
			Console.CursorLeft = anteriorCursorLeft;

			return num;
		}
		public static double LeerDouble() {
			double num;
			bool valido;
			string entrada;
			int mayorLargo;
			int anteriorCursorLeft = Console.CursorLeft;
			string mensajeError = "Número inválido";

			entrada = Console.ReadLine();
			valido = double.TryParse(entrada, out num);

			while(!valido) {
				Console.CursorTop--;
				Console.CursorLeft = anteriorCursorLeft;
				mayorLargo = Math.Max(entrada.Length, mensajeError.Length);
				Console.WriteLine("{0,-" + Convert.ToString(mayorLargo) + "}", num);
				Console.CursorTop--;
				Console.CursorLeft = anteriorCursorLeft;

				MostrarColoreado(mensajeError, ConsoleColor.Red);
				Console.CursorLeft = anteriorCursorLeft;

				entrada = Console.ReadLine();
				valido = double.TryParse(entrada, out num);
			}

			Console.CursorTop--;
			Console.CursorLeft = anteriorCursorLeft;
			mayorLargo = Math.Max(entrada.Length, mensajeError.Length);
			Console.WriteLine("{0,-" + Convert.ToString(mayorLargo) + "}", num);
			Console.CursorLeft = anteriorCursorLeft;

			return num;
		}
		public static char LeerOpcion() {
			return char.ToLower(Console.ReadKey(true).KeyChar);
		}
		#endregion
	}
}
