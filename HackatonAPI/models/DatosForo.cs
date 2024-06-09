using System.Data.SqlTypes;

namespace HackatonAPI.models
{
    public class DatosForo
    {
        public int IdForo { get; set; }
        public int  IdEstudiante { get; set; }

        public string NombreEstudiante { get; set; }

        public string Titulo { get; set; }
        public string Contenido{ get; set; }
        public int NumeroLikes{ get; set; }
        public string FechaPublicacion{ get;set; }
        public string FechaEdicion { get; set; }
        
        public DatosForo(int idForo, int idEstudiante, string nombreEstudiante, string titulo, string contenido, int numeroLikes, string fechaPublicacion, string fechaEdicion)
        {
            IdForo = idForo;
            IdEstudiante = idEstudiante;
            NombreEstudiante = nombreEstudiante;
            Titulo = titulo;
            Contenido = contenido;
            NumeroLikes = numeroLikes;
            FechaPublicacion = fechaPublicacion;
            FechaEdicion = fechaEdicion;
        }
        

    }
}
