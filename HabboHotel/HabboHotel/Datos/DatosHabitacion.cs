using HabboHotel.Interfaz;
using HabboHotel.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabboHotel.Datos
{
    internal class DatosHabitacion : IHabitacion
    {

        public List<Habitacion> listarHabitaciones()
        {
            MySqlConnection SQLdatos = Conexion.GetConexion().crearConexion();
            MySqlDataReader resultado;
            List<Habitacion> listaHabitaciones = new List<Habitacion>();

            try
            {
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_listadoHabitaciones", SQLdatos)
                {
                    CommandType = CommandType.StoredProcedure
                };

                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Habitacion hab = new Habitacion()
                    {
                        idHabitacion = resultado.GetInt32(resultado.GetOrdinal("idHabitacion")),
                        numero = resultado.GetInt32(resultado.GetOrdinal("numero")),
                        tipo = resultado.GetString(resultado.GetOrdinal("tipo")),
                        capacidad = resultado.GetInt32(resultado.GetOrdinal("capacidad")),
                        precioNoche = resultado.GetDecimal(resultado.GetOrdinal("precioNoche")),
                        disponible = resultado.GetBoolean(resultado.GetOrdinal("disponible"))
                    };
                    listaHabitaciones.Add(hab);
                }
                resultado.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Datos_metodoListarHabitaciones: " + ex.Message);
            }
            finally
            {
                if (SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }

            return listaHabitaciones;
        }

        public string agregarHabitacion(Habitacion _habitacion)
        {
            MySqlConnection SQLdatos = null;
            string respuesta = "Error al guardar";
            MySqlTransaction tras = null;
            try
            {
                SQLdatos = Conexion.GetConexion().crearConexion();

                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                tras = SQLdatos.BeginTransaction();
                MySqlCommand comando = new MySqlCommand("psa_guardar_habitacion", SQLdatos, tras)
                {
                    CommandType = CommandType.StoredProcedure
                };

                comando.Parameters.Add("_numero", MySqlDbType.Int32).Value = _habitacion.numero;
                comando.Parameters.Add("_tipo", MySqlDbType.VarChar).Value = _habitacion.tipo;
                comando.Parameters.Add("_capacidad", MySqlDbType.Int32).Value = _habitacion.capacidad;
                comando.Parameters.Add("_precioNoche", MySqlDbType.Decimal).Value = _habitacion.precioNoche;
                comando.Parameters.Add("_disponible", MySqlDbType.Byte).Value = _habitacion.disponible; 

                int result = comando.ExecuteNonQuery();
                if (result == 1)
                {
                    tras.Commit();
                    respuesta = "OK";
                }
                else
                {
                    tras.Rollback();
                    Funciones.Logs("DatosHabitacion_Agregar", "Error: Ninguna fila fue afectada.");
                }
            }
            catch (Exception ex)
            {
                tras?.Rollback();
                Funciones.Logs("DatosHabitacion_Agregar", respuesta + ">>" + ex.ToString());
            }
            finally
            {
                if (SQLdatos != null && SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }
            return respuesta;
        }

        public string actualizarHabitacion(Habitacion _habitacion)
        {
            MySqlConnection SQLdatos = null;
            string respuesta = "Error al actualizar";
            MySqlTransaction tras = null;

            try
            {
                SQLdatos = Conexion.GetConexion().crearConexion();
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }
                tras = SQLdatos.BeginTransaction();

                MySqlCommand comando = new MySqlCommand("psa_actualizar_habitacion", SQLdatos, tras)
                {
                    CommandType = CommandType.StoredProcedure
                };

                comando.Parameters.Add("_idHabitacion", MySqlDbType.Int32).Value = _habitacion.idHabitacion;
                comando.Parameters.Add("_numero", MySqlDbType.Int32).Value = _habitacion.numero;
                comando.Parameters.Add("_tipo", MySqlDbType.VarChar).Value = _habitacion.tipo;
                comando.Parameters.Add("_capacidad", MySqlDbType.Int32).Value = _habitacion.capacidad;
                comando.Parameters.Add("_precioNoche", MySqlDbType.Decimal).Value = _habitacion.precioNoche;
                comando.Parameters.Add("_disponible", MySqlDbType.Byte).Value = _habitacion.disponible;

                int result = comando.ExecuteNonQuery();
                if (result == 1)
                {
                    tras.Commit();
                    respuesta = "OK";
                }
                else
                {
                    tras.Rollback(); 
                    Funciones.Logs("DatosHabitacion_Actualizar", "Error: Ninguna fila fue afectada.");
                }
            }
            catch (Exception ex)
            {
                tras?.Rollback();
                Funciones.Logs("DatosHabitacion_Actualizar", respuesta + ">>" + ex.ToString());
            }
            finally
            {
                if (SQLdatos != null && SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }
            return respuesta;
        }

        public string eliminarHabitacion(int _idHabitacion)
        {
            MySqlConnection SQLdatos = Conexion.GetConexion().crearConexion();
            string resultado = "";

            try
            {
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_eliminar_habitacion", SQLdatos);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("_idHabitacion", _idHabitacion);

                comando.ExecuteNonQuery();

                resultado = "Habitacion eliminada";
            }
            catch (Exception ex)
            {
                resultado = "Error al eliminar habitacion: Probablemente tenga una reserva activa.";
                Funciones.Logs("DatosHabitacion_Eliminar", $"Error: {ex.Message} - Detalle: {ex.ToString()}");
            }
            finally
            {
                if (SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }
            return resultado;
        }

        public Habitacion buscarPorId(int idHabitacion)
        {
            throw new NotImplementedException();
        }

        public Habitacion buscarPorNumero(int _numero)
        {
            MySqlConnection SQLdatos = Conexion.GetConexion().crearConexion();
            MySqlDataReader resultado;
            Habitacion habitacion = null; 

            try
            {
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_buscarHabitacionPorNumero", SQLdatos);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("_numero", _numero);

                resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    habitacion = new Habitacion()
                    {
                        idHabitacion = resultado.GetInt32(resultado.GetOrdinal("idHabitacion")),
                        numero = resultado.GetInt32(resultado.GetOrdinal("numero")),
                        tipo = resultado.GetString(resultado.GetOrdinal("tipo")),
                        capacidad = resultado.GetInt32(resultado.GetOrdinal("capacidad")),
                        precioNoche = resultado.GetDecimal(resultado.GetOrdinal("precioNoche")),
                        disponible = resultado.GetBoolean(resultado.GetOrdinal("disponible"))
                    };
                }

                resultado.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                Funciones.Logs("DatosHabitacion_buscarPorNumero", ex.ToString());
            }
            finally
            {
                if (SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }

            return habitacion;
        }

        public List<Habitacion> listarDisponibles()
        {
            MySqlConnection SQLdatos = Conexion.GetConexion().crearConexion();
            MySqlDataReader resultado;
            List<Habitacion> habitaciones = new List<Habitacion>();

            try
            {
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_listarHabitacionesDisponibles", SQLdatos);
                comando.CommandType = CommandType.StoredProcedure;

                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Habitacion habitacion = new Habitacion()
                    {
                        idHabitacion = resultado.GetInt32(0),
                        numero = resultado.GetInt32(1),
                        tipo = resultado.GetString(2),
                        capacidad = resultado.GetInt32(3),
                        precioNoche = resultado.GetDecimal(4),
                        disponible = resultado.GetBoolean(5)
                    };
                    habitaciones.Add(habitacion);
                }
                resultado.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                Funciones.Logs("DatosHabitacion_listarDisponibles", ex.ToString());
            }
            finally
            {
                if (SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }

            return habitaciones;
        }

        public List<Habitacion> listarOcupadas()
        {
            MySqlConnection SQLdatos = Conexion.GetConexion().crearConexion();
            MySqlDataReader resultado;
            List<Habitacion> habitaciones = new List<Habitacion>();

            try
            {
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_listarHabitacionesOcupadas", SQLdatos);
                comando.CommandType = CommandType.StoredProcedure;

                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Habitacion habitacion = new Habitacion()
                    {
                        idHabitacion = resultado.GetInt32(0),
                        numero = resultado.GetInt32(1),
                        tipo = resultado.GetString(2),
                        capacidad = resultado.GetInt32(3),
                        precioNoche = resultado.GetDecimal(4),
                        disponible = resultado.GetBoolean(5)
                    };
                    habitaciones.Add(habitacion);
                }
                resultado.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                Funciones.Logs("DatosHabitacion_listarOcupadas", ex.ToString());
            }
            finally
            {
                if (SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }

            return habitaciones;
        }
    }
}