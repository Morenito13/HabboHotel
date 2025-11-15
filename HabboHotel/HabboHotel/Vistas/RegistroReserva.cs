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
    public partial class RegistroReserva : Form
    {
        private int idHabitacionSeleccionada;
        public RegistroReserva()
        {
            InitializeComponent();
            idHabitacionSeleccionada = 0;

            lblCaracteresR.Text = "0/255";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarHabitacion formHijo = new BuscarHabitacion(this);
            formHijo.ShowDialog();
        }

        private void RegistroReserva_Load(object sender, EventArgs e)
        {
        }

        public void ActualizarHabitacionSeleccionada(int id, string numero)
        {
            this.idHabitacionSeleccionada = id;

            MessageBox.Show($"ID seleccionado: {idHabitacionSeleccionada}");
            txtid.Text = idHabitacionSeleccionada.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.idHabitacionSeleccionada == 0)
            {
                MessageBox.Show("Debes seleccionar una habitacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtNombreHuesped.Text))
            {
                MessageBox.Show("El nombre del huesped es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime ingreso = dtpFechaIngreso.Value;
            DateTime salida = dtpFechaSalida.Value;
            string nombreHuesped = txtNombreHuesped.Text;
            string observacion = txtObservacion2.Text;

            if (salida.Date <= ingreso.Date)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la fecha de ingreso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatosReserva datosCheck = new DatosReserva();
            bool estaDisponible = datosCheck.verificarDisponibilidadHabitacion(
                                        this.idHabitacionSeleccionada,
                                        ingreso,
                                        salida);

            if (!estaDisponible)
            {
                MessageBox.Show(
                    "La habitacion seleccionada ya esta reservada en esas fechas.\n" +
                    "Por favor, seleccione otras fechas o una habitacion diferente.",
                    "Eror en la reserva",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return; 
            }

            Reserva nuevaReserva = new Reserva()
            {
                idHabitacion = this.idHabitacionSeleccionada,
                nombreHuesped = nombreHuesped,
                fechaIngreso = ingreso,
                fechaSalida = salida,
                observacion = observacion
            };


            try
            {
                DatosReserva datos = new DatosReserva();
                string resultado = datos.agregarReserva(nuevaReserva);

                if (resultado == "OK")
                {
                    MessageBox.Show("Reserva guardada exitosamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar la reserva: " + resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Funciones.Logs("btnGuardarReserva_Click", ex.Message);
            }
        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            //este no me ando nunca no se pq tuve que hacer otro
        }

        private void txtObservacion2_TextChanged(object sender, EventArgs e)
        {
            int caracteresMaximos = 255;
            int caracteresUsados = txtObservacion2.Text.Length;
            lblCaracteresR.Text = $"{caracteresUsados}/{caracteresMaximos}";

            if (caracteresUsados > caracteresMaximos)
            {
                txtObservacion2.Text = txtObservacion2.Text.Substring(0, caracteresMaximos);
                txtObservacion2.SelectionStart = caracteresMaximos;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
