namespace HackatonAPI.models
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public int IdEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public int IdForo { get; set; }

        public string Contenido { get; set; }
        public string FechaCreacion { get; set; }

        public Respuesta(int idRespuesta, int idEstudiante, string nombreEstudiante, int idForo, string contenido, string fechaCreacion)
        {
            IdRespuesta = idRespuesta;
            IdEstudiante = idEstudiante;
            NombreEstudiante = nombreEstudiante;
            IdForo = idForo;
            Contenido = contenido;
            FechaCreacion = fechaCreacion;
        }
    }

}
