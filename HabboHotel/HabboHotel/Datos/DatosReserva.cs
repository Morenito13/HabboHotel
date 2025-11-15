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
    internal class DatosReserva : IReserva
    {
        public string actualizarReserva(Reserva _reserva)
        {
            throw new NotImplementedException();
        }

        public string agregarReserva(Reserva _reserva)
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

                MySqlCommand comando = new MySqlCommand("psa_guardar_reserva", SQLdatos, tras)
                {
                    CommandType = CommandType.StoredProcedure
                };

                comando.Parameters.Add("_idHabitacion", MySqlDbType.Int32).Value = _reserva.idHabitacion;
                comando.Parameters.Add("_nombreHuesped", MySqlDbType.VarChar).Value = _reserva.nombreHuesped;
                comando.Parameters.Add("_fechaIngreso", MySqlDbType.Date).Value = _reserva.fechaIngreso;
                comando.Parameters.Add("_fechaSalida", MySqlDbType.Date).Value = _reserva.fechaSalida;
                comando.Parameters.Add("_observacion", MySqlDbType.VarChar).Value = _reserva.observacion;

                int result = comando.ExecuteNonQuery();
                if (result == 1)
                {
                    tras.Commit();
                    respuesta = "OK";
                }
                else
                {
                    tras.Rollback();
                    Funciones.Logs("DatosReserva_Agregar", "Error: Ninguna fila fue afectada.");
                }
            }
            catch (Exception ex)
            {
                tras?.Rollback();
                Funciones.Logs("DatosReserva_Agregar", ex.ToString());
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

        public List<Reserva> buscarPorFechaIngreso(DateTime _fecha)
        {
            MySqlConnection SQLdatos = Conexion.GetConexion().crearConexion();
            MySqlDataReader resultado;
            List<Reserva> listaReservas = new List<Reserva>();

            try
            {
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_buscarReservasPorFecha", SQLdatos)
                {
                    CommandType = CommandType.StoredProcedure
                };

                comando.Parameters.AddWithValue("p_fecha", _fecha);

                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Reserva res = new Reserva()
                    {
                        idReserva = resultado.GetInt32(resultado.GetOrdinal("idReserva")),
                        idHabitacion = resultado.GetInt32(resultado.GetOrdinal("id_habitacion")),
                        nombreHuesped = resultado.GetString(resultado.GetOrdinal("nombreHuesped")),
                        fechaIngreso = resultado.GetDateTime(resultado.GetOrdinal("fechaIngreso")),
                        fechaSalida = resultado.GetDateTime(resultado.GetOrdinal("fechaSalida")),
                        observacion = resultado.IsDBNull(resultado.GetOrdinal("observacion"))
                                        ? string.Empty
                                        : resultado.GetString(resultado.GetOrdinal("observacion"))
                    };
                    listaReservas.Add(res);
                }
                resultado.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Datos_buscarPorFechaIngreso: " + ex.Message);
            }
            finally
            {
                if (SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }

            return listaReservas;
        }

        public List<Reserva> buscarPorHuesped(string _nombreHuesped)
        {
            MySqlConnection SQLdatos = Conexion.GetConexion().crearConexion();
            MySqlDataReader resultado;
            List<Reserva> listaReservas = new List<Reserva>();

            try
            {
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_buscarReservasPorHuesped", SQLdatos)
                {
                    CommandType = CommandType.StoredProcedure
                };

                comando.Parameters.AddWithValue("p_nombreHuesped", _nombreHuesped);

                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Reserva res = new Reserva()
                    {
                        idReserva = resultado.GetInt32(resultado.GetOrdinal("idReserva")),
                        idHabitacion = resultado.GetInt32(resultado.GetOrdinal("id_habitacion")),
                        nombreHuesped = resultado.GetString(resultado.GetOrdinal("nombreHuesped")),
                        fechaIngreso = resultado.GetDateTime(resultado.GetOrdinal("fechaIngreso")),
                        fechaSalida = resultado.GetDateTime(resultado.GetOrdinal("fechaSalida")),
                        observacion = resultado.IsDBNull(resultado.GetOrdinal("observacion"))
                                    ? string.Empty : resultado.GetString(resultado.GetOrdinal("observacion"))
                    };
                    listaReservas.Add(res);
                }
                resultado.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Datos_buscarPorHuesped: " + ex.Message);
            }
            finally
            {
                if (SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }

            return listaReservas;
        }

        public Reserva buscarPorId(int _idReserva)
        {
            throw new NotImplementedException();
        }

        public string eliminarReserva(int _idReserva)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> listarReservasActivas()
        {
            List<Reserva> lista = new List<Reserva>();
            MySqlConnection SQLdatos = null;
            MySqlDataReader reader = null; 

            try
            {
                SQLdatos = Conexion.GetConexion().crearConexion();

                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_listar_reservas_activas", SQLdatos)
                {
                    CommandType = CommandType.StoredProcedure
                };

                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Reserva reserva = new Reserva();

                    reserva.idReserva = Convert.ToInt32(reader["idReserva"]);

                    reserva.idHabitacion = Convert.ToInt32(reader["id_habitacion"]);

                    reserva.nombreHuesped = reader["nombreHuesped"].ToString();
                    reserva.fechaIngreso = Convert.ToDateTime(reader["fechaIngreso"]);
                    reserva.fechaSalida = Convert.ToDateTime(reader["fechaSalida"]);
                    reserva.observacion = reader["observacion"].ToString();

                    lista.Add(reserva);
                }
            }
            catch (Exception ex)
            {
                Funciones.Logs("DatosReserva_ListarActivas", ex.ToString());
            }
            finally
            {
                reader?.Close();
                if (SQLdatos != null && SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }

            return lista;
        }

        public List<Reserva> listarReservasFuturas()
        {
            throw new NotImplementedException();
        }

        public List<Reserva> listarReservasPasadas()
        {
            throw new NotImplementedException();
        }

        public List<Reserva> listarTodasLasReservas()
        {
            MySqlConnection SQLdatos = Conexion.GetConexion().crearConexion();
            MySqlDataReader resultado;
            List<Reserva> listaReservas = new List<Reserva>();

            try
            {
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_listarTodasLasReservas", SQLdatos)
                {
                    CommandType = CommandType.StoredProcedure
                };

                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Reserva res = new Reserva()
                    {
                        idReserva = resultado.GetInt32(resultado.GetOrdinal("idReserva")),
                        idHabitacion = resultado.GetInt32(resultado.GetOrdinal("id_habitacion")),
                        nombreHuesped = resultado.GetString(resultado.GetOrdinal("nombreHuesped")),
                        fechaIngreso = resultado.GetDateTime(resultado.GetOrdinal("fechaIngreso")),
                        fechaSalida = resultado.GetDateTime(resultado.GetOrdinal("fechaSalida")),

                        observacion = resultado.IsDBNull(resultado.GetOrdinal("observacion"))
                                        ? string.Empty 
                                        : resultado.GetString(resultado.GetOrdinal("observacion"))
                    };
                    listaReservas.Add(res);
                }
                resultado.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Datos_metodoListarTodasReservas: " + ex.Message);
            }
            finally
            {
                if (SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }

            return listaReservas;
        }

        public bool verificarDisponibilidadHabitacion(int _idHabitacion, DateTime _fechaIngreso, DateTime _fechaSalida)
        {
            MySqlConnection SQLdatos = null;
            bool estaDisponible = false;

            try
            {
                SQLdatos = Conexion.GetConexion().crearConexion();
                if (SQLdatos.State == ConnectionState.Closed)
                {
                    SQLdatos.Open();
                }

                MySqlCommand comando = new MySqlCommand("psa_verificar_disponibilidad", SQLdatos)
                {
                    CommandType = CommandType.StoredProcedure
                };

                comando.Parameters.Add("_idHabitacion", MySqlDbType.Int32).Value = _idHabitacion;
                comando.Parameters.Add("_fechaIngreso", MySqlDbType.DateTime).Value = _fechaIngreso;
                comando.Parameters.Add("_fechaSalida", MySqlDbType.DateTime).Value = _fechaSalida;

                int conteoReservas = Convert.ToInt32(comando.ExecuteScalar());

                if (conteoReservas == 0)
                {
                    estaDisponible = true;
                }
            }
            catch (Exception ex)
            {
                Funciones.Logs("DatosReserva_Verificar", ex.ToString());
                estaDisponible = false;
            }
            finally
            {
                if (SQLdatos != null && SQLdatos.State == ConnectionState.Open)
                {
                    SQLdatos.Close();
                }
            }
            return estaDisponible;
        }
    }
}
