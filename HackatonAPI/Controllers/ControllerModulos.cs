using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;
using HackatonAPI.models;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Collections;

namespace HackatonAPI.Controllers
{
    [ApiController]
    public class ControllerModulos : ControllerBase
    {
        [HttpGet]
        [Route("/ObtenerDatosCatModulo")]
        public dynamic obtenerDatosCatModulo() {
            Dictionary<string, ArrayList> resultadofinal = new Dictionary<string, ArrayList> {};

            Conexion cu = new Conexion();
            List<Categoria> listacats = new List<Categoria> { };
            List<CatModulo> listacatmod = new List<CatModulo> { };
            string query = "exec spc_obtener_categorias_modulos";
            SqlCommand cmd = new SqlCommand(query, cu.conectaruniversidad());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
 
                int idCategoria = dr.GetInt32(0);
                string descripcion = dr.GetString(1);
                Categoria l = new Categoria(idCategoria, descripcion);

                listacats.Add(l);
            }

            dr.NextResult();
            while (dr.Read())
            {
                string categoria = dr.GetString(0);
                string modulo = dr.GetString(1);
                CatModulo l = new CatModulo(categoria, modulo);

                listacatmod.Add(l);
            }
            
            foreach (Categoria c in listacats) {
                ArrayList arrayList = new ArrayList();
                foreach (CatModulo l in listacatmod)
                {
                    if (l.Categoria.Equals(c.NombreCategoria)) { 
                    
                    arrayList.Add(l.Modulo);
                    
                    }
                    

                }
                resultadofinal.Add(c.NombreCategoria, arrayList);
            }
            
           
            cu.CerrarConexion();
            return resultadofinal;
        }
    }
}

