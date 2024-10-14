using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class CitaService
    {
        private string connection;
        public CitaService (IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public void ReservarCita(InsertCitaModel cita)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName = "id_cliente", SqlDbType = SqlDbType.Int, Value = cita.IdCliente});
            parametros.Add(new SqlParameter {ParameterName = "fecha", SqlDbType = SqlDbType.Date, Value = cita.Fecha});
            parametros.Add(new SqlParameter {ParameterName = "hora_inicio", SqlDbType = SqlDbType.Time, Value = cita.HoraInicio});
            parametros.Add(new SqlParameter {ParameterName = "hora_fin", SqlDbType = SqlDbType.Time, Value = cita.HoraFin});
            parametros.Add(new SqlParameter {ParameterName = "descripcion", SqlDbType = SqlDbType.NVarChar, Value = cita.Descripcion});

            try
            {
                dac.ExecuteNonQuery("ReservarCita", parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public List<CitaModel> ObtenerCitasPorCliente(int IdCliente)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            List<CitaModel> lista = new List<CitaModel>();

            parametros.Add(new SqlParameter {ParameterName = "id_cliente", SqlDbType = SqlDbType.Int, Value = IdCliente});


            try
            {
                DataSet ds = dac.Fill("ObtenerCitasPorCliente", parametros);
                
                if(ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CitaModel{
                            Id = int.Parse(dr["id_cita"].ToString()),
                            Fecha = dr["fecha"].ToString(),
                            HoraInicio = dr["hora_inicio"].ToString(),
                            HoraFin = dr["hora_fin"].ToString(),
                            Descripcion = dr["descripcion"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return lista;

        }

        public void ActualizarCita(CitaModel cita)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName = "id_cita", SqlDbType = SqlDbType.Int, Value = cita.Id});
            parametros.Add(new SqlParameter {ParameterName = "fecha", SqlDbType = SqlDbType.Date, Value = cita.Fecha});
            parametros.Add(new SqlParameter {ParameterName = "hora_inicio", SqlDbType = SqlDbType.Time, Value = cita.HoraInicio});
            parametros.Add(new SqlParameter {ParameterName = "hora_fin", SqlDbType = SqlDbType.Time, Value = cita.HoraFin});
            parametros.Add(new SqlParameter {ParameterName = "descripcion", SqlDbType = SqlDbType.NVarChar, Value = cita.Descripcion});

            try
            {
                dac.ExecuteNonQuery("ActualizarCita", parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public void EliminarCita(int Id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName = "id_cita", SqlDbType = SqlDbType.Int, Value = Id});


            try
            {
                dac.ExecuteNonQuery("EliminarCita", parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public List<IntervalosDisponiblesModel> ObtenerDisponibilidadCitas(string Fecha)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            List<IntervalosDisponiblesModel> lista = new List<IntervalosDisponiblesModel>();

            parametros.Add(new SqlParameter {ParameterName = "fecha", SqlDbType = SqlDbType.Date, Value = Fecha});

            try
            {
                DataSet ds = dac.Fill("ObtenerDisponibilidadCitas", parametros);
                
                if(ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new IntervalosDisponiblesModel{
                            HoraInicio = dr["hora_inicio"].ToString(),
                            HoraFin = dr["hora_fin"].ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return lista;
        }

        public List<string> ObtenerFechasConCitasOcupadas()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<string> lista = new List<string>();

            try
            {
                DataSet ds = dac.Fill("ObtenerFechasConCitasOcupadas");
                if(ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(dr["fecha"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return lista;
        }
    }
}