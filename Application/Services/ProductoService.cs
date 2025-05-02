using System;
using MiAppHexagonal.Domain.Entities;
using MiAppHexagonal.Domain.Ports;

namespace MiAppHexagonal.Application.Services;

public class ProductoService
{
    private readonly IProductoRepository _repo;

    public ProductoService(IProductoRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}");
        }
    }

    public void CrearProducto(string nombre)
    {
        _repo.Crear(new Producto { Nombre = nombre });
    }

    public void ActualizarProducto(int id, string nuevoNombre)
    {
        _repo.Actualizar(new Producto { Id = id, Nombre = nuevoNombre });
    }

    public void EliminarCliente(int id)
    {
        _repo.Eliminar(id);
    }
}