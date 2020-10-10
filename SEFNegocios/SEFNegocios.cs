using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SegurosElFeliz.Entidades;
using SEF.Datos;

namespace SegurosElFeliz.Negocios
{
    public class SEFNegocios
    {
        ClienteDL _cli = new ClienteDL();
        public List<Clientes> ObtenerClientes(String pNombre)
        {
            List<Clientes> _clientes = _cli.ObtenerClientes();

            return _clientes.Where(p => p.Nombre.Contains(pNombre)).ToList();

        }

        public  String AgregarClientes(Clientes pCliente)
        {
            return _cli.AgregarCliente(pCliente);
        }
        public List<Catalogo> ObtenerCatalogo()
        {
            return _cli.ObtenerCatalogo();
        }

    }
}
