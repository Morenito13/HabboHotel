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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HabboHotel.Vistas
{
    public partial class BuscarHabitacion : Form
    {
        private RegistroReserva formularioPadre;
        public BuscarHabitacion(RegistroReserva parent)
        {
            InitializeComponent();
            this.formularioPadre = parent;
        }

        private void BuscarHabitacion_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }

        private void cargarDatagrid()
        {
            DatosHabitacion datos = new DatosHabitacion();
            List<Habitacion> habitaciones;

            habitaciones = datos.listarDisponibles();

            dgvHabitaciones2.DataSource = habitaciones;
            dgvHabitaciones2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHabitaciones2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvHabitaciones2.Columns["idHabitacion"].Visible = false;

            foreach (DataGridViewColumn column in dgvHabitaciones2.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            dgvHabitaciones2.ReadOnly = true;
            dgvHabitaciones2.AllowUserToResizeRows = false;
            dgvHabitaciones2.RowHeadersVisible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvHabitaciones2.SelectedRows.Count > 0)
            {
                int id = (int)dgvHabitaciones2.SelectedRows[0].Cells["idHabitacion"].Value;
                string numero = dgvHabitaciones2.SelectedRows[0].Cells["numero"].Value.ToString();

                formularioPadre.ActualizarHabitacionSeleccionada(id, numero);

                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una habitacion.");
            }
        }

        private void dgvHabitaciones2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)dgvHabitaciones2.Rows[e.RowIndex].Cells["idHabitacion"].Value;
                string numero = dgvHabitaciones2.Rows[e.RowIndex].Cells["numero"].Value.ToString();

                formularioPadre.ActualizarHabitacionSeleccionada(id, numero);
                this.Close();
            }
        }
    }
}
