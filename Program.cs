using MiAppHexagonal.Application.Services;
using MiAppHexagonal.Domain.Factory;
using MiAppHexagonal.Infrastructure.Mysql;

internal class Program
{
    private static void Main(string[] args)
    {
        string connStr = "server=localhost;database=prueba;user=campus2023;password=campus2023;";
        IDbFactory factory = new MySqlDbFactory(connStr);
        var servicio = new ClienteService(factory.CrearClienteRepository());
                while (true)
        {
            Console.WriteLine("\n--- MENÚ CLIENTES ---");
            Console.WriteLine("1. Mostrar todos");
            Console.WriteLine("2. Crear nuevo");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    servicio.MostrarTodos();
                    break;
                case "2":
                    Console.Write("Nombre: ");
                    servicio.CrearCliente(Console.ReadLine()!);
                    break;
                case "3":
                    Console.Write("ID a actualizar: ");
                    int idA = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo nombre: ");
                    servicio.ActualizarCliente(idA, Console.ReadLine()!);
                    break;
                case "4":
                    Console.Write("ID a eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    servicio.EliminarCliente(idE);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("❌ Opción inválida.");
                    break;
            }
        }
    }
}