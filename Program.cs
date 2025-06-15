using System;
using System.Collections.Generic;
using System.Globalization;

namespace Primer_ejercicio_Moran_Leandro
{
    class Program
    {
        public static void PrintBox(string text)
        {
            int width = text.Length + 4;
            string border = "+" + new string('-', width - 2) + "+";
            Console.WriteLine(border);
            Console.WriteLine("| " + text.PadRight(width - 4) + " |");
            Console.WriteLine(border);
        }

        public static void PrintLine(char ch, int length)
        {
            Console.WriteLine(new string(ch, length));
        }

        class Factura
        {
            public string Fch1;
            public string Fch2;
            public int Cant;
            public string Nom;
            public string Des;
            public double VDC;
            public double VDV;
            public double GO;
            public double GP;
            public int CP;
            public int CC;

            public void IngresarDatos()
            {
                Program.PrintBox("Bienvenido a LEGG Company");
                Console.ReadLine();

                Console.Write("Ingrese la fecha de ingreso: ");
                Fch1 = Console.ReadLine();

                Console.Write("Ingrese la fecha de salida: ");
                Fch2 = Console.ReadLine();

                Console.Write("Ingrese la cantidad: ");
                Cant = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nombre del producto: ");
                Nom = Console.ReadLine();

                Console.Write("Ingrese la descripción: ");
                Des = Console.ReadLine();

                Console.Write("Ingrese el valor de compra: ");
                VDC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Ingrese el valor de venta: ");
                VDV = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                GO = (VDV - VDC) * Cant;
                GP = VDC != 0 ? ((VDV - VDC) / VDC) * 100 : 0;

                Console.Write("Ingrese la cantidad en bodega al finalizar: ");
                CP = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el ciclo contable: ");
                CC = int.Parse(Console.ReadLine());
            }

            public void Mostrar(int numeroFactura)
            {
                Program.PrintBox("FACTURA DE INVENTARIO N° " + numeroFactura);

                Console.WriteLine("Fecha de ingreso: " + Fch1);
                Console.WriteLine("Fecha de salida: " + Fch2);
                Console.WriteLine("Cantidad ingresada: " + Cant);
                Console.WriteLine("Nombre del producto: " + Nom);
                Console.WriteLine("Descripción: " + Des);
                Console.WriteLine("Valor de compra: " + VDC.ToString("0.00", CultureInfo.InvariantCulture));
                Console.WriteLine("Valor de venta: " + VDV.ToString("0.00", CultureInfo.InvariantCulture));
                Console.WriteLine("Ganancia obtenida: " + GO.ToString("0.00", CultureInfo.InvariantCulture));
                Console.WriteLine("Ganancia en porcentaje: " + GP.ToString("0.00", CultureInfo.InvariantCulture) + " %");
                Console.WriteLine("Cantidad en bodega: " + CP);
                Console.WriteLine("Ciclo contable: " + CC);

                Program.PrintLine('-', 50);
            }
        }

        static void MostrarFacturasComoTabla(List<Factura> facturas)
        {
            string[] headers = { "Factura", "Fecha Ingreso", "Fecha Salida", "Nombre", "Cantidad", "Descripción", "V. Compra", "V. Venta", "Ganancia", "Ganancia %", "Bodega", "Ciclo" };
            int[] widths = { 10, 15, 15, 10, 10, 20, 12, 12, 12, 12, 10, 10 };

            string line = "+";
            for (int i = 0; i < widths.Length; i++)
            {
                line += new string('-', widths[i]) + "+";
            }

            Console.WriteLine(line);
            for (int i = 0; i < headers.Length; i++)
            {
                Console.Write("|" + headers[i].PadRight(widths[i]));
            }
            Console.WriteLine("|");
            Console.WriteLine(line);

            for (int i = 0; i < facturas.Count; i++)
            {
                Factura f = facturas[i];
                string[] values = {
                    "Factura " + (i + 1),
                    f.Fch1,
                    f.Fch2,
                    f.Nom,
                    f.Cant.ToString(),
                    f.Des,
                    f.VDC.ToString("0.00", CultureInfo.InvariantCulture),
                    f.VDV.ToString("0.00", CultureInfo.InvariantCulture),
                    f.GO.ToString("0.00", CultureInfo.InvariantCulture),
                    f.GP.ToString("0.00", CultureInfo.InvariantCulture),
                    f.CP.ToString(),
                    f.CC.ToString()
                };

                for (int j = 0; j < values.Length; j++)
                {
                    Console.Write("|" + values[j].PadRight(widths[j]));
                }
                Console.WriteLine("|");
                Console.WriteLine(line);
            }

            Console.WriteLine("Hecho por Morán, Gonzalez, Guilcapi y Cedeño 3ro N.");
        }

        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            List<Factura> listaFacturas = new List<Factura>();

            Console.Write("¿Cuántas facturas desea ingresar?: ");
            int repeticiones = int.Parse(Console.ReadLine());

            for (int i = 0; i < repeticiones; i++)
            {
                Console.WriteLine();
                Program.PrintBox("Factura número " + (i + 1));

                Factura f = new Factura();
                f.IngresarDatos();
                listaFacturas.Add(f);
                f.Mostrar(i + 1);
            }

            Console.WriteLine("\n¿Qué desea hacer ahora?");
            Console.WriteLine("1. Sí, deseo ver todas las facturas");
            Console.WriteLine("2. No, borrar los procesos y volver a repetir el ejercicio");
            Console.WriteLine("3. No, terminar el ejercicio");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine();
                    Program.PrintBox("LISTA COMPLETA DE FACTURAS EN TABLA");
                    MostrarFacturasComoTabla(listaFacturas);
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Main();
                    break;

                case "3":
                    Program.PrintBox("Hecho por Morán, Gonzalez, Guilcapi y Cedeño 3ro N.");
                    Console.ReadLine();
                    break;

                default:
                    Program.PrintBox("Opción no válida. Finalizando el programa");
                    Console.ReadLine();
                    break;
            }
        }
    }
}

