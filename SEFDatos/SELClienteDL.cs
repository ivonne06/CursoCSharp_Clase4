using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SegurosElFeliz.Entidades;
using System.Data;

namespace SEF.Datos
{
    //CRUD
    //Create: Crear Agregar o Insertar Datos <<
    //Read: Leer, Obtener, Seleccionar Datos
    //Update: Actualizar Datos.
    //Delete: Eliminar Datos

    public class ClienteDL
    {
        AccesoaDatos _mibd = new AccesoaDatos();

        public String FechaSQL(DateTime pFecha)
        {
            return pFecha.Year.ToString() + "-" +
                pFecha.Month.ToString() + "-" +
                pFecha.Day.ToString();
        }

        public List<Catalogo> ObtenerCatalogo()
        {
            List<Catalogo> _lista = new List<Catalogo>();
            IDbConnection _conn = _mibd.ConexionContabilidad();
            IDbCommand _comm = _mibd.ComandoContabilidad(_conn);
            _conn.Open();
            _comm.CommandText = "select cuenta, descrip, tipo from glcat order by cuenta";

            IDataReader _reader = _comm.ExecuteReader();
            while (_reader.Read())
            {
                Catalogo _c = new Catalogo();
                _c.Cuenta = _reader.GetString(0);
                _c.Descripcion = _reader.GetString(1);
                _c.Tipo= _reader.GetString(2);
                _lista.Add(_c);
            }
            _conn.Close();
            return _lista;
        }
        

        public String AgregarCliente(Clientes pCliente)
        {
            String _resultado = "Exito";
            IDbConnection _conn = _mibd.Conexion();
            IDbCommand _comm = _mibd.Comando(_conn);

            _conn.Open();
            /*
             * Ejemplo con PARAMETRO
            _comm.CommandText = "insert into cliente "+
                " (DUI, Nombre1, Nombre2, Nombre3, Apellido1, Apellido2, Apellido3, FechaNacimiento, Telefono) "+
                " values " +
                "(@DUI, @NOMBRE1, @NOMBRE2, @NOMBRE3, @APELLIDO1, @APELLIDO2, @APELLIDO3, @FECHANACIM, @TELEFONO) ";
            
            _comm.Parameters.Add(_mibd.Parametro("@DUI", DbType.String, pCliente.DUI));
            _comm.Parameters.Add(_mibd.Parametro("@NOMBRE1", DbType.String, pCliente.Nombre1));
            _comm.Parameters.Add(_mibd.Parametro("@NOMBRE2", DbType.String, pCliente.Nombre2));
            _comm.Parameters.Add(_mibd.Parametro("@NOMBRE3", DbType.String, pCliente.Nombre3));
            _comm.Parameters.Add(_mibd.Parametro("@APELLIDO1", DbType.String, pCliente.Apellido1));
            _comm.Parameters.Add(_mibd.Parametro("@APELLIDO2", DbType.String, pCliente.Apellido2));
            _comm.Parameters.Add(_mibd.Parametro("@APELLIDO3", DbType.String, pCliente.Apellido3));
            _comm.Parameters.Add(_mibd.Parametro("@FECHANACIM", DbType.Date, pCliente.FechaNacimiento));
            _comm.Parameters.Add(_mibd.Parametro("@TELEFONO", DbType.String, pCliente.Telefono));
            */

            _comm.CommandText = String.Format("insert into cliente " +
                " (DUI, Nombre1, Nombre2, Nombre3, Apellido1, Apellido2, Apellido3, FechaNacimiento, Telefono) " +
                " values " +
                "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}') ", 
                pCliente.DUI, pCliente.Nombre1, pCliente.Nombre2, pCliente.Nombre3,
                pCliente.Apellido1, pCliente.Apellido2, pCliente.Apellido3, 
                FechaSQL( pCliente.FechaNacimiento), pCliente.Telefono);


            try
            {
                _comm.ExecuteNonQuery();
                _resultado = "Exito";
            }catch (Exception ex)
            {
                _resultado = ex.Message;
            }
            
            _conn.Close();
            return _resultado;
        }

        public List<Clientes> ObtenerClientes()
        {
            List<Clientes> _listadoclientes = new List<Clientes>();
            IDbConnection _conn = _mibd.Conexion();
            IDbCommand _comm = _mibd.Comando(_conn);

            _conn.Open();
            _comm.CommandText = "SELECT DUI, Nombre1, Nombre2, Nombre3, "+
                " Apellido1, Apellido2, Apellido3, FechaNacimiento, Telefono FROM cliente order by Apellido1; ";

            IDataReader _reader = _comm.ExecuteReader();
            while (_reader.Read())
            {
                Clientes _cli = new Clientes();
                _cli.DUI = _reader.GetString(0);
                _cli.Nombre1 = _reader.GetString(1);
                _cli.Nombre2 = _reader.GetString(2);
                _cli.Nombre3 = _reader.GetString(3);
                _cli.Apellido1 = _reader.GetString(4);
                _cli.Apellido2 = _reader.GetString(5);
                _cli.Apellido3 = _reader.GetString(6);
                _cli.FechaNacimiento = _reader.GetDateTime(7);
                _cli.Telefono = _reader.GetString(8);
                _listadoclientes.Add(_cli);
            }
            
            _conn.Close();
            return _listadoclientes;
        }


    }
}
