using HabboHotel.Datos;
using HabboHotel.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabboHotel.Vistas
{
    public partial class ReservasActivas : Form
    {
        public ReservasActivas()
        {
            InitializeComponent();
        }

        private void ReservasActivas_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        private void cargarDatagrid()
        {
            DatosReserva datos = new DatosReserva();

            List<Reserva> reservas = datos.listarReservasActivas();

            dgvReservas.DataSource = reservas;

            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn column in dgvReservas.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            dgvReservas.ReadOnly = true;
            dgvReservas.AllowUserToResizeRows = false;
            dgvReservas.RowHeadersVisible = false;

            if (dgvReservas.Columns.Contains("fechaIngreso"))
            {
                dgvReservas.Columns["fechaIngreso"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvReservas.Columns.Contains("fechaSalida"))
            {
                dgvReservas.Columns["fechaSalida"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
    }
}
