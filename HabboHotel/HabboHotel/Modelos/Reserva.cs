using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabboHotel.Modelos
{
    internal class Reserva
    {
        public int idReserva { get; set; }
        public int idHabitacion { get; set; }
        public string nombreHuesped { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaSalida { get; set; }
        public string observacion { get; set; }

        public Reserva() { }

        public Reserva(int idReserva, int idHabitacion, string nombreHuesped, DateTime fechaIngreso, DateTime fechaSalida, string observacion)
        {
            this.idReserva = idReserva;
            this.idHabitacion = idHabitacion;
            this.nombreHuesped = nombreHuesped;
            this.fechaIngreso = fechaIngreso;
            this.fechaSalida = fechaSalida;
            this.observacion = observacion;
        }

        public Reserva(int idHabitacion, string nombreHuesped, DateTime fechaIngreso, DateTime fechaSalida, string observacion)
        {
            this.idHabitacion = idHabitacion;
            this.nombreHuesped = nombreHuesped;
            this.fechaIngreso = fechaIngreso;
            this.fechaSalida = fechaSalida;
            this.observacion = observacion;
        }
    }
}
