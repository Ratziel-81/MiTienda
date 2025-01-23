using System.Collections.Generic;
using System;
using System.IO;

namespace AppTiendaV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Tienda tienda = new Tienda();
            string rutaArchivo = "clientes.txt";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Insertar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Guardar Clientes en Archivo");
                Console.WriteLine("4. Cargar Clientes desde Archivo");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        InsertarCliente(tienda);
                        break;
                    case "2":
                        tienda.ListarClientes();
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        tienda.GuardarClientesEnArchivo(rutaArchivo);
                        Console.WriteLine("Clientes guardados con éxito.");
                        Console.ReadKey();
                        break;
                    case "4":
                        tienda.CargarClientesDesdeArchivo(rutaArchivo);
                        Console.WriteLine("Clientes cargados con éxito.");
                        Console.ReadKey();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Método para insertar un cliente
        static void InsertarCliente(Tienda tienda)
        {
            Console.Clear();
            Console.WriteLine("Función: Insertar Cliente");
            Console.Write("Introduce el nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Introduce el teléfono del cliente: ");
            string telefono = Console.ReadLine();
            tienda.InsertarCliente(nombre, telefono);
        }
    }

    // Clase Cliente
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public override string ToString()
        {
            return $"{Nombre},{Telefono}";
        }

        public static Cliente FromString(string data)
        {
            var parts = data.Split(',');
            if (parts.Length == 2)
            {
                return new Cliente { Nombre = parts[0], Telefono = parts[1] };
            }
            throw new FormatException("Formato inválido en la cadena del cliente.");
        }
    }

    // Clase Tienda
    public class Tienda
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void InsertarCliente(string nombre, string telefono)
        {
            clientes.Add(new Cliente { Nombre = nombre, Telefono = telefono });
        }

        public void GuardarClientesEnArchivo(string rutaArchivo)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                foreach (var cliente in clientes)
                {
                    writer.WriteLine(cliente.ToString());
                }
            }
        }

        public void CargarClientesDesdeArchivo(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        clientes.Add(Cliente.FromString(linea));
                    }
                }
            }
            else
            {
                Console.WriteLine($"El archivo {rutaArchivo} no existe.");
            }
        }

        public void ListarClientes()
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre}, Teléfono: {cliente.Telefono}");
            }
        }
    }
}
