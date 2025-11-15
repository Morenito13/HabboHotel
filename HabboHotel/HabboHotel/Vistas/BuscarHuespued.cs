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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace HabboHotel.Vistas
{
    public partial class BuscarHuespued : Form
    {
        private HistorialReservaHuesped formularioPadre;
        private DatosReserva datosReserva;
        public BuscarHuespued(HistorialReservaHuesped papa)
        {
            InitializeComponent();
            this.formularioPadre = papa;
            this.datosReserva = new DatosReserva();
        }

        private void BuscarHuespued_Load(object sender, EventArgs e)
        {
            cargarDatagridConNombresUnicos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvListaNombres.SelectedRows.Count > 0)
            {

                string nombre = dgvListaNombres.SelectedRows[0].Cells["nombreHuesped"].Value.ToString();

                formularioPadre.ActualizarHuespedSeleccionado(nombre);
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un nombre.");
            }
        }

        private void cargarDatagridConNombresUnicos()
        {
            try
            {
                List<Reserva> todasLasReservas = datosReserva.listarTodasLasReservas();

                List<string> nombresUnicos = todasLasReservas
                    .Select(reserva => reserva.nombreHuesped)
                    .Distinct()
                    .OrderBy(nombre => nombre) // todo esto sirve pa ordenar alfafeticamente, pd stephanie no saca bien en voley :P
                    .ToList();

                var datosParaGrid = nombresUnicos
                    .Select(nombre => new { NombreHuesped = nombre })
                    .ToList();

                dgvListaNombres.DataSource = datosParaGrid;

                dgvListaNombres.Columns["nombreHuesped"].HeaderText = "Nombre del Huesped";
                dgvListaNombres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvListaNombres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListaNombres.ReadOnly = true;
                dgvListaNombres.AllowUserToResizeRows = false;
                dgvListaNombres.RowHeadersVisible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de huespedes: " + ex.Message);
            }
        }

        private void btnBuscarHuesped_Click(object sender, EventArgs e)
        {
        }

        private void dgvListaNombres_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombre = dgvListaNombres.Rows[e.RowIndex].Cells["nombreHuesped"].Value.ToString();

                formularioPadre.ActualizarHuespedSeleccionado(nombre);
                this.Close();
            }
        }
    }
}