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
    public partial class HistorialReservaHuesped : Form
    {
        private string nombreHuespedSeleccionado;
        private DatosReserva datosReserva;
        public HistorialReservaHuesped()
        {
            InitializeComponent();
            this.nombreHuespedSeleccionado = string.Empty;
            this.datosReserva = new DatosReserva();
        }

        private void HistorialReservaHuesped_Load(object sender, EventArgs e)
        {
            CargarHistorialDeReservas();
        }

        private void CargarHistorialDeReservas(string nombreHuesped = null)
        {
            List<Reserva> lista;

            if (string.IsNullOrEmpty(nombreHuesped))
            {
                lista = datosReserva.listarTodasLasReservas();
            }
            else
            {
                lista = datosReserva.buscarPorHuesped(nombreHuesped);
            }

            dgvHistorial.DataSource = lista;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToResizeRows = false;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void ActualizarHuespedSeleccionado(string nombreHuesped)
        {
            this.nombreHuespedSeleccionado = nombreHuesped;

            lblNombreHuesped.Text = nombreHuesped;

            CargarHistorialDeReservas(nombreHuesped);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarHuespued formBusqueda = new BuscarHuespued(this);
            formBusqueda.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
