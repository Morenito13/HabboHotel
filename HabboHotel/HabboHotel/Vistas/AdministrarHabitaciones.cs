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
    public partial class AdministrarHabitaciones : Form
    {
        private string ultimoValorBuenoPrecio = "";
        private string ultimoValorBuenoCapacidad = "";
        private string ultimoValorBuenoNumero = "";
        private Habitacion habitacionSeleccionada = null;

        public AdministrarHabitaciones()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNum.Text) || string.IsNullOrEmpty(txtTipo.Text) || 
                string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtCapacidad.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int numero;
            int capacidad;
            decimal precio;

            try
            {
                numero = Convert.ToInt32(txtNum.Text);
                capacidad = Convert.ToInt32(txtCapacidad.Text);
                precio = Convert.ToDecimal(txtPrecio.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("El Numero, Capacidad o Precio tienen un formato incorrecto.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatosHabitacion datos = new DatosHabitacion();

            Habitacion habitacionExistente = datos.buscarPorNumero(numero);

            if (habitacionExistente != null)
            {
                MessageBox.Show("Una habitacion con ese numero ya existe.", "Error", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                txtNum.Focus();
                return;
            }

            Habitacion nuevaHabitacion = new Habitacion()
            {
                numero = numero,         
                tipo = txtTipo.Text,
                capacidad = capacidad,    
                precioNoche = precio,     
                disponible = Disponible.Checked
            };

            if (datos.agregarHabitacion(nuevaHabitacion) == "OK") 
            {
                MessageBox.Show("Habitacion agregada", "Informacion", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                dgvHabitaciones.DataSource = datos.listarHabitaciones();
            }
            else
            {
                Funciones.Logs("btnAgregar_Click", "Error: Habitacion NO agregada.");
                MessageBox.Show("Habitacion NO agregada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrecio.Text, out _) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                ultimoValorBuenoPrecio = txtPrecio.Text;
            }
            else
            {
                txtPrecio.Text = ultimoValorBuenoPrecio;

                txtPrecio.SelectionStart = txtPrecio.Text.Length;
            }
        }

        private void txtCapacidad_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtCapacidad.Text, out _) || string.IsNullOrEmpty(txtCapacidad.Text))
            {
                ultimoValorBuenoCapacidad = txtCapacidad.Text;
            }
            else
            {
                txtCapacidad.Text = ultimoValorBuenoCapacidad;

                txtCapacidad.SelectionStart = txtCapacidad.Text.Length;
            }
        }

        private void AdministrarHabitaciones_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            btnGuardar.Enabled = false;
        }

        private void cargarDatagrid()
        {
            DatosHabitacion datos = new DatosHabitacion();
            List<Habitacion> habitaciones = datos.listarHabitaciones();

            dgvHabitaciones.DataSource = habitaciones;
            dgvHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHabitaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            foreach (DataGridViewColumn column in dgvHabitaciones.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            dgvHabitaciones.ReadOnly = true;
            dgvHabitaciones.AllowUserToResizeRows = false;
            dgvHabitaciones.RowHeadersVisible = false;
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtNum.Text, out _) || string.IsNullOrEmpty(txtNum.Text))
            {
                ultimoValorBuenoNumero = txtNum.Text;
            }
            else
            {
                txtNum.Text = ultimoValorBuenoNumero;

                txtNum.SelectionStart = txtNum.Text.Length;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargarDatagrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!chbEliminar.Checked) 
            {
                MessageBox.Show("Debe seleccionar el checkbox 'Eliminar' para confirmar.", "Advertencia",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (dgvHabitaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una habitacion de la lista.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatosHabitacion datos = new DatosHabitacion();
            bool errorOcurrido = false;

            foreach (DataGridViewRow row in dgvHabitaciones.SelectedRows)
            {
                int idHabitacion = Convert.ToInt32(row.Cells["idHabitacion"].Value);

                string resultado = datos.eliminarHabitacion(idHabitacion);

                if (resultado != "Habitacion eliminada") 
                {
                    MessageBox.Show(resultado, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorOcurrido = true;
                    break;
                }
            }

            if (!errorOcurrido)
            {
                MessageBox.Show("Habitacion(es) eliminada(s).", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            chbEliminar.Checked = false;

            dgvHabitaciones.DataSource = datos.listarHabitaciones();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (habitacionSeleccionada != null)
            {
                txtNum.Text = habitacionSeleccionada.numero.ToString();
                txtTipo.Text = habitacionSeleccionada.tipo;
                txtCapacidad.Text = habitacionSeleccionada.capacidad.ToString();
                txtPrecio.Text = habitacionSeleccionada.precioNoche.ToString();
                Disponible.Checked = habitacionSeleccionada.disponible;

                btnAgregar.Enabled = false;        
                btnGuardar.Enabled = true; 
                                                  
            }
            else
            {
                MessageBox.Show("No hay una habitacion seleccionada.", "Advertencia", MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }
        }

        private void dgvHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHabitaciones.Rows[e.RowIndex].DataBoundItem != null)
            {
                habitacionSeleccionada = (Habitacion)dgvHabitaciones.Rows[e.RowIndex].DataBoundItem;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNum.Text) || string.IsNullOrEmpty(txtTipo.Text) ||
        string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtCapacidad.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int numero;
            int capacidad;
            decimal precio;

            try
            {
                numero = Convert.ToInt32(txtNum.Text);
                capacidad = Convert.ToInt32(txtCapacidad.Text);
                precio = Convert.ToDecimal(txtPrecio.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("El Numero, Capacidad o Precio tienen un formato incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatosHabitacion datos = new DatosHabitacion();

            Habitacion habitacionExistente = datos.buscarPorNumero(numero);
            if (habitacionExistente != null &&
                habitacionExistente.idHabitacion != habitacionSeleccionada.idHabitacion)
            {
                MessageBox.Show("Otra habitacion con ese numero ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNum.Focus();
                return;
            }

            Habitacion habitacionActualizada = new Habitacion()
            {
                idHabitacion = habitacionSeleccionada.idHabitacion,

                numero = numero,
                tipo = txtTipo.Text,
                capacidad = capacidad,
                precioNoche = precio,
                disponible = Disponible.Checked 
            };

            if (datos.actualizarHabitacion(habitacionActualizada) == "OK")
            {
                MessageBox.Show("Habitacion actualizada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cargarDatagrid();

                btnAgregar.Enabled = true;
                btnGuardar.Enabled = false;
                habitacionSeleccionada = null;
            }
            else
            {
                Funciones.Logs("btnGuardarCambios_Click", "Error: Habitacion NO actualizada.");
                MessageBox.Show("Habitacion NO actualizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
