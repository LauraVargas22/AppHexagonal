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
        //
    }

    public void Crear(Producto productos)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO productos (nombre, stock) VALUES (@nombre, @stock)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", productos.Nombre);
        cmd.Parameters.AddWithValue("@stock", productos.Stock);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM productos WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public List<Producto> ObtenerTodos()
    {
        throw new NotImplementedException();
    }
}