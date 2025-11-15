using HabboHotel.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabboHotel.Interfaz
{
    internal interface IHabitacion
    {
        string agregarHabitacion(Habitacion _habitacion);
        string actualizarHabitacion(Habitacion _habitacion);
        string eliminarHabitacion(int _idHabitacion);
        Habitacion buscarPorId(int _idHabitacion);
        Habitacion buscarPorNumero(int numero); 

        List<Habitacion> listarHabitaciones();

        List<Habitacion> listarDisponibles();
        List<Habitacion> listarOcupadas();

        // Opcional ver si la uso capa, no se ahora
        // List<Habitacion> buscarPorTipo(string tipo);
        // List<Habitacion> buscarPorCapacidad(int capacidad);
    }
}
