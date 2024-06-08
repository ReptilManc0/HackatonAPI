using System.Data.SqlClient;

namespace HackatonAPI.Controllers
{
    public class ConexionMapa
    {
        SqlConnection conex = new SqlConnection();

        static string servidor = "localhost";
        static string bd = "mapa_db";
        static string user = "prueba1";
        static string pass = "123";
        static string port = "50399";

        string lineaconexion = "Data Source=" + servidor + "," + port + ";" + "user id=" + user + ";password=" + pass + ";" + "Initial Catalog=" + bd + ";" + "Persist Security Info=true";

        public SqlConnection conectar()
        {

            try
            {

                conex.ConnectionString = lineaconexion;
                conex.Open();
                Console.WriteLine("se establecio la conexión");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return conex;
        }
        public void CerrarConexion()
        {
            conex.Close();

        }
    }
}
