using HabboHotel.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabboHotel.Interfaz
{
    internal interface IReserva
    {
        string agregarReserva(Reserva _reserva);
        string actualizarReserva(Reserva _reserva);
        string eliminarReserva(int _idReserva);
        Reserva buscarPorId(int _idReserva);
        List<Reserva> listarTodasLasReservas();
        List<Reserva> listarReservasActivas();
        List<Reserva> buscarPorHuesped(string _nombreHuesped);
        List<Reserva> buscarPorFechaIngreso(DateTime _fecha);
        List<Reserva> listarReservasFuturas();
        List<Reserva> listarReservasPasadas();
        bool verificarDisponibilidadHabitacion(int _idHabitacion, DateTime _fechaIngreso, DateTime _fechaSalida);
    }
}
