using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace CompanyManager.Data
{
    public class BdConnection
    {

        private List<SqlParameter> _parameters = new List<SqlParameter>();

        private string GerarConnectionString()
        {
            var conn = ConfigurationManager.ConnectionStrings["AuthenticationDbContextConnection"].ToString();

            return conn;
        }
        public void AddParameter(string name, object value)
        {
            _parameters.Add(new SqlParameter(name, value));
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(GerarConnectionString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    _parameters.ForEach(x => sqlCommand.Parameters.Add(x));
                    try
                    {
                        connection.Open();
                        return sqlCommand.ExecuteNonQuery();
                    }
                    finally
                    {

                        connection.Close();
                    }
                }
            }
        }

        public DataTable ExecuteReader(string query)
        {
            using (SqlConnection connection = new SqlConnection(GerarConnectionString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    _parameters.ForEach(x => sqlCommand.Parameters.Add(x));
                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            var dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            dataReader.Close();
                            return dataTable;
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
