using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace conexion
{
    public class DatabaseConnection
    {
        private SqlConnection connection;
        private string connectionString;

        public DatabaseConnection()
        {
            connectionString = "Server=localhost\\SQLEXPRESS;Database=HospitalDB;Integrated Security=True;TrustServerCertificate=True;";
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo abrir la conexión a la base de datos.", ex);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo cerrar la conexión a la base de datos.", ex);
            }
        }

        public int ExecuteScalar(string query, object parameters = null)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    AssignParameters(cmd, parameters);
                }
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar consulta: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public decimal? ExecuteScalar2(string query, object parameters = null)
        {
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        AssignParameters(cmd, parameters);
                    }
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : (decimal?)null;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar consulta: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable ExecuteQuerybujia(string query, object parameters = null)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var prop in parameters.GetType().GetProperties())
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters, null));
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable ExecuteQuery2(string query, object parameters = null)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var prop in parameters.GetType().GetProperties())
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters, null));
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int ExecuteNonQuery(string query, object parameters = null)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    AssignParameters(cmd, parameters);
                }
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar consulta: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable ExecuteQuery(string query, object parameters = null)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var prop in parameters.GetType().GetProperties())
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters, null));
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        private void AssignParameters(SqlCommand cmd, object parameters)
        {
            var properties = parameters.GetType().GetProperties();
            foreach (var prop in properties)
            {
                cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
            }
        }
    }
}