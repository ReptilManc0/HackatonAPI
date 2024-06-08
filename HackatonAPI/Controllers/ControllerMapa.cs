using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using HackatonAPI.models;

namespace HackatonAPI.Controllers

{
    [ApiController]
    public class ControllerMapa : ControllerBase
    {
        [HttpPost]
        [Route("/ObtenerDatosMapa")]
        public dynamic PasarDatosMapa(SolicitudDatosMapa datos)
        {
            string prueba = "";
            ConexionMapa cm = new ConexionMapa();
            List<ObtenerDatosMapa> lista = new List<ObtenerDatosMapa> { };
            string query = "exec spc_obtener_informacion_mapa @nombre_piso='"+datos.piso+"',@nombre_sede='"+datos.sede+"'";
            SqlCommand cmd = new SqlCommand(query, cm.conectar());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string nombrepiso = dr.GetString(0);
                string filial = dr.GetString(1);
                string coordenadas = dr.GetString(2);
                string categoria = dr.GetString(3);

                ObtenerDatosMapa dm= new ObtenerDatosMapa(nombrepiso, coordenadas, categoria,filial);

                lista.Add(dm);
            }
            cm.CerrarConexion();
            return lista;
        }
        [HttpPost]
        [Route("/ObtenerImagenPiso")]
        public dynamic ObtenerImagen(SolicitudDatosMapa datos)
        {
            ConexionMapa con = new ConexionMapa();
            List<string> imagen = new List<string>();
            string query = "exec spc_obtener_imagen_piso '"+datos.piso+ "', '"+datos.sede+"';";
            SqlCommand cmd = new SqlCommand(query, con.conectar());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                imagen.Add(dr.GetString(0));
            }
            return imagen;
        }
    }
}
