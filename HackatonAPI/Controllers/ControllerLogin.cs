using HackatonAPI.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data.SqlClient;

namespace HackatonAPI.Controllers
{
    [ApiController]
    public class ControllerLogin: ControllerBase
    {
        [HttpPost]
        [Route("/comprobarLogin")]
        public dynamic obtenerImagen(Cuenta cuenta)
        {
            Conexion con = new Conexion();
            ArrayList list1 = new ArrayList();
            List<CuentaResponse> list = new List<CuentaResponse>();
            string query = "exec spc_verificar_cuenta_estudiante @cod_estudiante='" + cuenta.codEstudiante+"', @contrasena='"+cuenta.contrasenia+"'";
            SqlCommand cmd = new SqlCommand(query, con.conectaruniversidad());
            SqlDataReader dr = cmd.ExecuteReader();
            try {
                while (dr.Read())
                {
                    string resultado = dr.GetString(0);
                    int idEstudiante = dr.GetInt32(1);
                    string primerNombre = dr.GetString(2);
                    CuentaResponse c = new CuentaResponse(resultado, idEstudiante, primerNombre);
                    list.Add(c);
                    list1.Add(resultado);
                    list1.Add(((int)idEstudiante).ToString());
                    list1.Add(primerNombre);
                }
                
            } catch (Exception ){
                string resultado = dr.GetString(0);

                CuentaResponse c = new CuentaResponse(resultado, 0, "");
                list.Add(c);
                list1.Add(resultado);
                list1.Add("0");
                list1.Add("");
            }
            con.CerrarConexion();
            return list1;

        }
    }
}
