using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class ClienteService
    {
        private string connection;

        public ClienteService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public int CrearCliente(ClienteModel cliente)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            int IdCliente = 0;

            parametros.Add(new SqlParameter {ParameterName = "nombre", SqlDbType = SqlDbType.NVarChar, Value = cliente.Nombre});
            parametros.Add(new SqlParameter {ParameterName = "telefono", SqlDbType = SqlDbType.NVarChar, Value = cliente.Telefono});
            parametros.Add(new SqlParameter {ParameterName = "email", SqlDbType = SqlDbType.NVarChar, Value = cliente.Email});

            try
            {
                DataSet ds = dac.Fill("CrearCliente", parametros);

                IdCliente = int.Parse(ds.Tables[0].Rows[0]["id_cliente"].ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return IdCliente;
        }
    }
}