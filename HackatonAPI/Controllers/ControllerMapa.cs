using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using HackatonAPI.models;
using System.Data;
using System.Reflection.PortableExecutable;

namespace HackatonAPI.Controllers

{
    [ApiController]
    public class ControllerMapa : ControllerBase
    {
        [HttpPost]
        [Route("/ObtenerDatosMapa")]
        public dynamic pasarDatosMapa(SolicitudDatosMapa datos)
        {
            string prueba = "";
            Conexion cm = new Conexion();
            List<ObtenerDatosMapa> lista = new List<ObtenerDatosMapa> { };
            string query = "exec spc_obtener_informacion_mapa @nombre_piso='"+datos.piso+"',@nombre_sede='"+datos.sede+"'";
            SqlCommand cmd = new SqlCommand(query, cm.conectarmapa());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int idZona = dr.GetInt32(0);
                string filial = dr.GetString(1);
                string coordenadas = dr.GetString(2);
                string categoria = dr.GetString(3);

                ObtenerDatosMapa dm= new ObtenerDatosMapa(idZona, coordenadas, categoria,filial);

                lista.Add(dm);
            }
            cm.CerrarConexion();
            return lista;
        }
        [HttpPost]
        [Route("/ObtenerImagenPiso")]
        public dynamic obtenerImagen(SolicitudDatosMapa datos)
        {
            Conexion con = new Conexion();
            List<string> imagen = new List<string>();
            string query = "exec spc_obtener_imagen_piso '"+datos.piso+ "', '"+datos.sede+"';";
            SqlCommand cmd = new SqlCommand(query, con.conectarmapa());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                imagen.Add(dr.GetString(0));
            }
            return imagen;
        }
        [HttpGet]
        [Route("/ObtenerCatsLeyenda")]
        public dynamic obtenerCatsLeyenda() 
        {
            Conexion cu = new Conexion();
            List<Categoria> lista = new List<Categoria> { };
            string query = "exec spc_obtener_categorias_zona";
            SqlCommand cmd = new SqlCommand(query, cu.conectarmapa());

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int idCategoria = dr.GetInt32(0);
                string nombreCategoria = dr.GetString(1);


                Categoria datos = new Categoria(idCategoria, nombreCategoria);

                lista.Add(datos);
            }
            cu.CerrarConexion();
            return lista;

            //DataSet

        }
        /*
        [HttpGet]
        [Route("/pruebaselect")]
        public dynamic pruebaSelect()
        {
            Conexion cu = new Conexion();
            List<CatModulo> lista = new List<CatModulo> { };
            string query = "exec spc_prueba_dobleselect";
            SqlCommand cmd = new SqlCommand(query, cu.conectaruniversidad());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                string idCategoria = dr.GetString(0);
                string nombreCategoria = dr.GetString(1);

                CatModulo datos = new CatModulo(idCategoria, nombreCategoria);

                lista.Add(datos);
            }

            while (dr.NextResult()&&dr.Read())
            {
                
            }
            cu.CerrarConexion();
            return lista;

            //DataSet

        }
        */
        [HttpPost]
        [Route("/ObtenerDetallesZona")]
        public dynamic obtenerDetallesZona(int idZona)
        {
            Conexion con = new Conexion();
            List<DetallesZona> detZona = new List<DetallesZona>();
            string query = "exec sp_obtener_detalles_por_zona @idZona='"+idZona+"'";
            SqlCommand cmd = new SqlCommand(query, con.conectarmapa());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string descripcion;
                int mesa;
                int silla;
                int banquito;
                int expendedoraBebida;
                int expendedoraSnack;
                int expendedoraCafe;
                int puff;
                int pupitres;
                int computadora;

    }
            return detZona;
        }

    }
}
