namespace HackatonAPI.models
{
    public class CuentaResponse
    {
        public string resultado { get; set; }
        public int idEstudiante { get; set; }
        public string primerNombre { get; set; }

        public CuentaResponse(string resultado, int idEstudiante, string primerNombre)
        {
            this.resultado = resultado;
            this.idEstudiante = idEstudiante;
            this.primerNombre = primerNombre;
        }
    }
}
