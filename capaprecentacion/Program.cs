using Microsoft.Data.SqlClient;
using SistemaHospitalario;
using capadatos.Database;

namespace capaprecentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Pre-calentar conexión SQL antes de mostrar el Login
            Task.Run(() =>
            {
                try
                {
                    using var conn = Conexion.ObtenerConexion();
                    conn.Open();
                }
                catch { }
            });

            Application.Run(new Login());
        }
    }
}