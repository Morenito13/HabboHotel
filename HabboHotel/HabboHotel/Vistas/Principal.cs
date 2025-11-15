using HabboHotel.Datos;
using HabboHotel.Vistas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabboHotel
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void conexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conBase = Conexion.GetConexion().crearConexion();
                if (conBase == null)
                {
                    MessageBox.Show("Ocurrio un error!!1! No se pudo establecer la conexion a la base de datos",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (conBase.State == ConnectionState.Closed)
                {
                    conBase.Open();
                }

                MessageBox.Show("Conexion exitosa con la base de datos.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar abrir la conexion: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funciones.AbrirFormInPanel(this, new AdministrarHabitaciones());
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funciones.CerrarFormInPanel(this);
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
        }

        private void verTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funciones.AbrirFormInPanel(this, new VisualizarTodasHabitaciones());
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funciones.AbrirFormInPanel(this, new RegistroReserva());
        }

        private void administrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Funciones.AbrirFormInPanel(this, new RegistroReserva());
        }

        private void reservasActivasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funciones.AbrirFormInPanel(this, new ReservasActivas());
        }

        private void adminsitrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funciones.AbrirFormInPanel(this, new HistorialReservaHuesped());
        }

        private void consultarReservasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funciones.AbrirFormInPanel(this, new ReservasPorFecha());
        }
    }
}
