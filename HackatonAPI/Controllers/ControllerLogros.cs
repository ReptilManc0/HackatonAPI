using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using HackatonAPI.models;

namespace HackatonAPI.Controllers
{
    [ApiController]

    public class ControllerLogros
    {
        
        [HttpGet]
        [Route("/obtenerLogros")]
        public dynamic obtenerlogros() {
            Conexion cu = new Conexion();
            List<logros> listadoclientes = new List<logros> { };
            string query = "exec spc_obtener_logros";
            SqlCommand cmd = new SqlCommand(query, cu.conectaruniversidad());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                string nombre = dr.GetString(1);
                string descripcion = dr.GetString(2);
                i++;
                logros l = new logros(id, nombre, descripcion);

                listadoclientes.Add(l);
            }
            cu.CerrarConexion();
            return listadoclientes;
        }
    }
}
