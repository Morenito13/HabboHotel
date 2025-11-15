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
    public partial class VisualizarTodasHabitaciones : Form
    {
        public VisualizarTodasHabitaciones()
        {
            InitializeComponent();
        }

        private void VisualizarTodasHabitaciones_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }

        private void cargarDatagrid()
        {
            DatosHabitacion datos = new DatosHabitacion();
            List<Habitacion> habitaciones;

            string seleccion = "";

            if (comboBox1.SelectedItem != null)
            {
                seleccion = comboBox1.SelectedItem.ToString();
            }
            else
            {
                seleccion = "Mostrar Todas";
            }

            if (seleccion == "Disponible")
            {
                habitaciones = datos.listarDisponibles();
            }
            else if (seleccion == "Ocupada")
            {
                habitaciones = datos.listarOcupadas();
            }
            else
            {
                habitaciones = datos.listarHabitaciones();
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
    }
}
