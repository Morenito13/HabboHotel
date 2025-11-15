using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HabboHotel.Datos;
using HabboHotel.Modelos;

namespace HabboHotel.Vistas
{
    public partial class ReservasPorFecha : Form
    {
        private DatosReserva datos;

        public ReservasPorFecha()
        {
            InitializeComponent();
            this.datos = new DatosReserva();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReservasPorFecha_Load(object sender, EventArgs e)
        {
            CargarReservas();
        }


        private void CargarReservas(List<Reserva> lista = null)
        {
            try
            {
                if (lista == null)
                {
                    lista = datos.listarTodasLasReservas();
                }

                dgvReservasFecha.DataSource = lista;
                dgvReservasFecha.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvReservasFecha.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvReservasFecha.ReadOnly = true;
                dgvReservasFecha.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las reservas: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fechaBuscada = dtpFechaSalida.Value.Date; 
            DatosReserva datos = new DatosReserva();
            List<Reserva> reservasEncontradas = datos.buscarPorFechaIngreso(fechaBuscada);
            dgvReservasFecha.DataSource = reservasEncontradas;
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            CargarReservas();
            dtpFechaSalida.Value = DateTime.Now;
        }
    }
}