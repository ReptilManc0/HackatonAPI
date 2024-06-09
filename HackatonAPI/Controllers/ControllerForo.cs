using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using HackatonAPI.models;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlTypes;
namespace HackatonAPI.Controllers
{
    [ApiController]
    public class ControllerForo : ControllerBase
    {
        [HttpGet]
        [Route("/ObtenerForos")]

        public dynamic obtenerForos()
        {


            Conexion cu = new Conexion();
            List<DatosForo> lista = new List<DatosForo> { };
            string query = "exec spc_obtener_temas_foro";
            SqlCommand cmd = new SqlCommand(query, cu.conectaruniversidad());
            SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int IDForo = dr.GetInt32(0);
                    int IDEstudiante = dr.GetInt32(1);
                    string NombreEstudiante = dr.GetString(2);
                    string Titulo = dr.GetString(3);
                    string Contenido = dr.GetString(4);
                    int NumeroLikes = dr.GetInt32(5);
                    string FechaPublicacion = dr.GetString(6);



                    DatosForo datos = new DatosForo(IDForo, IDEstudiante, NombreEstudiante, Titulo, Contenido, NumeroLikes, FechaPublicacion);

                    lista.Add(datos);
                }
                cu.CerrarConexion();
                return lista;
            

           
        }










        
        [HttpPost]
        [Route("/ObtenerRespuestas")]
        public dynamic obtenerRespuestas(string foroID){
            Conexion cu = new Conexion();
            List<Respuesta> ListaRespuestas = new List<Respuesta> { };
            string query = "exec spc_obtener_respuestas_foro '"+foroID+"'";
            SqlCommand cmd = new SqlCommand(query, cu.conectaruniversidad());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                int idRespuesta= dr.GetInt32(0);
                int idForo = dr.GetInt32(1);
                int idEstudiante = dr.GetInt32(2);
                string nombreEstudiante = dr.GetString(3);
                string contenido = dr.GetString(4);
               string fechaCreacion = dr.GetString(5);

                Respuesta datos = new Respuesta(idRespuesta,idEstudiante,nombreEstudiante,idForo,contenido, fechaCreacion);

                ListaRespuestas.Add(datos);
            }
            cu.CerrarConexion();
            return ListaRespuestas;

        }
        [HttpPost]
        [Route("/GuardarRespuestas")]
        public dynamic guardarRespuestas(Respuesta r)
        {
           
            try
            {
                Conexion cu = new Conexion();
                string query = "EXEC spc_guardar_respuesta @id_foro = " + r.IdForo + ", @id_estudiante = " + r.IdEstudiante + ", @contenido = '" + r.Contenido + "';";
                SqlCommand cmd = new SqlCommand(query, cu.conectaruniversidad());
                SqlDataReader dr = cmd.ExecuteReader();

                cu.CerrarConexion();
                return new
                {
                    success = true,
                    message = "registro completado",
                    result = r,

                };

            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "error" + ex.Message,
                };
            }
            
           

        }

    }
}
    