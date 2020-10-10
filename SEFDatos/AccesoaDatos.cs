using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace SEF.Datos
{
    public class AccesoaDatos
    {
        // 3  Cosas:
        // a. Conexion a la base de Datos
        // b. Comandos a la base de Datos
        // c. Parametros de los Comandos

        public IDbConnection Conexion()
        {
            OdbcConnection _conn = new OdbcConnection();
            _conn.ConnectionString = "Driver={MySQL ODBC 3.51 Driver};Server=localhost;Database=SegurosElFeliz;User=root;Password=230680;Option=3;";

            return _conn;
        }
        public IDbCommand Comando()
        {
            OdbcCommand _comm = new OdbcCommand();
            return _comm;
        }
        public IDbCommand Comando(IDbConnection pConexion)
        {
            OdbcCommand _comm = new OdbcCommand();
            //Conversion Explicita entre IdbConnetion interface hacia OdbConnection
            
            _comm.Connection = (OdbcConnection)pConexion;
            return _comm;
        }

        public IDataParameter Parametro(String pNombre, DbType pTipo, Object pValor)
        {
            OdbcParameter _parameter = new OdbcParameter(pNombre, pValor);
            _parameter.DbType = pTipo;
            return _parameter;
        }

        public IDbConnection ConexionContabilidad()
        {
            SqlConnection _conn = new SqlConnection();
            _conn.ConnectionString = "Server=localhost;Database=contpre_coandes;Trusted_Connection=True;";

            return _conn;
        }
        public IDbCommand ComandoContabilidad()
        {
            SqlCommand _comm = new SqlCommand();
            return _comm;
        }
        public IDbCommand ComandoContabilidad(IDbConnection pConexion)
        {
            SqlCommand _comm = new SqlCommand();
            //Conversion Explicita entre IdbConnetion interface hacia OdbConnection

            _comm.Connection = (SqlConnection)pConexion;
            return _comm;
        }

        public IDataParameter ParametroContabilidad(String pNombre, DbType pTipo, Object pValor)
        {
            SqlParameter _parameter = new SqlParameter(pNombre, pValor);
            _parameter.DbType = pTipo;
            return _parameter;
        }


    }
}
