using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class IntervalosDisponiblesService
    {
        private string connection;

        public IntervalosDisponiblesService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public void GenerarIntervalosDisponibles(string fecha)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            parametros.Add(new SqlParameter {ParameterName = "fecha", SqlDbType = SqlDbType.Date, Value = fecha});

            try
            {
                dac.ExecuteNonQuery("GenerarIntervalosDisponibles", parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}