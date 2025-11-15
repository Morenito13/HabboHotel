using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabboHotel.Modelos
{
    internal class Habitacion
    {
        public int idHabitacion { get; set; }
        public int numero { get; set; }
        public string tipo { get; set; }
        public int capacidad { get; set; }
        public decimal precioNoche { get; set; }
        public bool disponible { get; set; } 

        public Habitacion() { }

        public Habitacion(int idHabitacion, int numero, string tipo, int capacidad, decimal precioNoche, bool disponible)
        {
            this.idHabitacion = idHabitacion;
            this.numero = numero;
            this.tipo = tipo;
            this.capacidad = capacidad;
            this.precioNoche = precioNoche;
            this.disponible = disponible;
        }

        public Habitacion(int numero, string tipo, int capacidad, decimal precioNoche, bool disponible)
        {
            this.numero = numero;
            this.tipo = tipo;
            this.capacidad = capacidad;
            this.precioNoche = precioNoche;
            this.disponible = disponible;
        }
    }
}
