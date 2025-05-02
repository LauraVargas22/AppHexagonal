using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MiAppHexagonal.Application.Services;
using MiAppHexagonal.Domain.Factory;

namespace MiAppHexagonal.Application.UI.Clientes
{
    public class UICliente
    {
        
      
        string connStr = "server=localhost;database=prueba;user=root;password=campus2023;";
       
        private readonly IDbFactory _factory;
        //var servicio = new ClienteService(factory.CrearClienteRepository());

        public UICliente(IDbFactory factory)
        {
            _factory = factory;


        }
    }

}