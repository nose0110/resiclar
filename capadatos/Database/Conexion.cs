using Microsoft.Data.SqlClient;
namespace capadatos.Database
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection(
                "Server=localhost\\SQLEXPRESS;Database=HospitalDB;Integrated Security=True;TrustServerCertificate=True;"
            );

            return conn;
        }
    }
}