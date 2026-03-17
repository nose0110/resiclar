using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace conexion
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;
        private string connectionString;

        public DatabaseConnection()
        {
            connectionString = "server=localhost;port=3306;database=bdventas;user=root;password=;";
            connection = new MySqlConnection(connectionString);
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
            catch (MySqlException ex)
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
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo cerrar la conexión a la base de datos.", ex);
            }
        }

        public int ExecuteScalar(string query, object parameters = null)
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                if (parameters != null)
                {
                    // Asignar parámetros a la consulta
                    AssignParameters(cmd, parameters);
                }
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
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
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        AssignParameters(cmd, parameters);
                    }
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : (decimal?)null;
                }
            }
            catch (MySqlException ex)
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
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var prop in parameters.GetType().GetProperties())
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters, null));
                    }
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (MySqlException ex)
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
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var prop in parameters.GetType().GetProperties())
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters, null));
                    }
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (MySqlException ex)
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
                MySqlCommand cmd = new MySqlCommand(query, connection);
                if (parameters != null)
                {
                    // Asignar parámetros a la consulta
                    AssignParameters(cmd, parameters);
                }
                return cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
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
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (MySqlException ex)
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
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var prop in parameters.GetType().GetProperties())
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters, null));
                    }
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        private void AssignParameters(MySqlCommand cmd, object parameters)
        {
            // Asignar parámetros a la consulta
            var properties = parameters.GetType().GetProperties();
            foreach (var prop in properties)
            {
                cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
            }
        }
    }
}
