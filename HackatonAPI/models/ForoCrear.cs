namespace HackatonAPI.models
{
    public class ForoCrear
    {
        public int idEstudiante { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public ForoCrear(int idEstudiante, string titulo, string contenido)
        {
            this.idEstudiante = idEstudiante;
            this.titulo = titulo;
            this.contenido = contenido;
        }
    }
}
