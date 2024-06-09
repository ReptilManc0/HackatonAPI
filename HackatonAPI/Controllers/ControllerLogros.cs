using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using HackatonAPI.models;
using System.Collections;

namespace HackatonAPI.Controllers
{
    [ApiController]

    public class ControllerLogros:ControllerBase
    {
        
        [HttpGet]
        [Route("/obtenerLogros")]
        public dynamic obtenerlogros() {
            Conexion cu = new Conexion();
            List<Logros> logros = new List<Logros> { };
            string query = "exec sp_obtener_logros_y_progresos @id_estudiante=1";
            SqlCommand cmd = new SqlCommand(query, cu.conectaruniversidad());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                string nombre = dr.GetString(1);
                string descripcion = dr.GetString(3);
                Logros l = new Logros(id, nombre, descripcion);

                logros.Add(l);
            }
            cu.CerrarConexion();
            return logros;
           
            
        }

        [HttpPost]
        [Route("/obtenerLogrosdesbloqueados")]
        public dynamic obtenerlogrosdesbloqueados(IdZona IdEstudiante)
        {
            Conexion cu = new Conexion();
            ArrayList logrosdesbloqueados = new ArrayList();
            string query = "exec sp_obtener_logros_y_progresos @id_estudiante=" + IdEstudiante.id;
            SqlCommand cmd = new SqlCommand(query, cu.conectaruniversidad());
            SqlDataReader dr = cmd.ExecuteReader();    
            dr.NextResult();
            while (dr.Read())
            {
                logrosdesbloqueados.Add(dr.GetInt32(0));
            }
            cu.CerrarConexion();
            return logrosdesbloqueados;
        }

    }
}
