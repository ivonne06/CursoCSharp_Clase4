using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosElFeliz.Entidades
{
    public class Catalogo
    {
        public String Cuenta { get; set; }
        public String Descripcion { get; set; }
        private String m_CuentaDesc;
        public String CuentaDesc
        {
            set
            {
                m_CuentaDesc = value;
            }
            get
            {
                return Cuenta + "." + Descripcion;

            }
        }
        public Catalogo() { }
        public String Tipo { get; set; }
        public Catalogo(String pCuenta, String pDescripcion, String pTipo)
        {
            Cuenta = pCuenta;
            Descripcion = pDescripcion;
            Tipo = pTipo;
        }
    }
    public class Clientes
    {
        public String DUI { get; set; }
        public String Nombre1 { get; set; }
        public String Nombre2 { get; set; }
        public String Nombre3 { get; set; }
        public String Apellido1 { get; set; }
        public String Apellido2 { get; set; }
        public String Apellido3 { get; set; }
        public String Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        private String m_nombre;
        public String Nombre
        {
            set
            {
                m_nombre = value;
            }
            get
            {
                return String.Format("{0} {1} {3} {4} {5}",
                    Nombre1, Nombre2, Nombre3, Apellido1, Apellido2, Apellido3);
            }
        }

        public Clientes()
        {

        }

    }

    public class Polizas
    {
        public String DUI { get; set; }
        public DateTime FechaContratacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public Decimal SumaAsegurada { get; set; }
        public Decimal Prima { get; set; }
        public Polizas() { }

    }
}
