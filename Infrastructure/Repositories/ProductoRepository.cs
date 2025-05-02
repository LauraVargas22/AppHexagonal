using System;
using MiAppHexagonal.Domain.Entities;
using MiAppHexagonal.Domain.Ports;
using MiAppHexagonal.Infrastructure.Mysql;
using MySql.Data.MySqlClient;

namespace MiAppHexagonal.Infrastructure.Repositories;

public class ProductoRepository : IGenericRepository<Producto>, IProductoRepository
{
    private readonly ConexionSingleton _conexion;

    public ProductoRepository(string connectionString)
    {
        _conexion = ConexionSingleton.Instancia(connectionString);
    }

    public void Actualizar(Producto producto)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE productos SET nombre = @nombre WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
        cmd.Parameters.AddWithValue("@id", producto.Id);
        cmd.ExecuteNonQuery();
    }

    public void Crear(Producto producto)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO producto (nombre) VALUES (@nombre)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM clientes WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public List<Producto> ObtenerTodos()
    {
        throw new NotImplementedException();
    }
}