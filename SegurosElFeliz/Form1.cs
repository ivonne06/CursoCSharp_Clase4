using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SegurosElFeliz.Entidades;
using SegurosElFeliz.Negocios;


namespace SegurosElFeliz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ActualizarClientes();
            cmbCuenta.DataSource = _bl.ObtenerCatalogo();
            cmbCuenta.ValueMember = "Cuenta" ;
            cmbCuenta.DisplayMember = "CuentaDesc";
        }
        SEFNegocios _bl = new SEFNegocios();
        private void button1_Click(object sender, EventArgs e)
        {
            Clientes _cli = new Clientes();

            _cli.DUI = txtDUI.Text;
            _cli.Nombre1 = txtNombre1.Text;
            _cli.Nombre2 = txtNombre2.Text;
            _cli.Nombre3 = txtNombre3.Text;
            _cli.Apellido1 = txtApellido1.Text;
            _cli.Apellido2 = txtApellido2.Text;
            _cli.Apellido3 = txtApellido3.Text;
            _cli.FechaNacimiento = dtpNacimiento.Value;
            _cli.Telefono =  txtTelefono.Text;
            String _resultado = _bl.AgregarClientes(_cli);
            if (_resultado == "Exito")
            {
                MessageBox.Show("El registro fue guardado Correctamente");
            }else
            {
                MessageBox.Show("Hubo un Error:" + _resultado);
            }

        }

        public void ActualizarClientes()
        {
            dataGridView1.DataSource = _bl.ObtenerClientes("");
        }
        public void ActualizarClientes(String pNombre)
        {
            dataGridView1.DataSource = _bl.ObtenerClientes(pNombre);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActualizarClientes(textBox1.Text);
        }
    }
}
