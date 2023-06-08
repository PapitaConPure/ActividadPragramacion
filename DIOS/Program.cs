using System;

namespace DIOS {
    internal class Program {
        static Promedio promedio;

        static void Main(string[] args) {
            promedio = new Promedio();
            bool seguir = true;

            do {
                Console.Clear();
                MostrarMenu();
                char op = char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();

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

            Console.WriteLine("Chau, papá");
            Console.ReadKey();
        }

        static void AgregarValores() {
            Console.WriteLine("Valorcito ó 0 para cortar");
            int num = Convert.ToInt32(Console.ReadLine());
            while(num != 0) {
                promedio.AgregarValor(num);
                num = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void MostrarPromedio() {
            double prom = promedio.CalcularPromedio();
            Console.WriteLine("Promedio: {0}", prom);
            Console.ReadKey();
        }

        static void MostrarMenu() {
            Console.WriteLine("Cómase un nabo porfa");
            Console.WriteLine("1. Agregar valores");
            Console.WriteLine("2. Mostrar promedio");
            Console.WriteLine("X. Salir");
        }
    }
}
