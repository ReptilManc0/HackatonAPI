namespace HackatonAPI.models
{
    public class ObtenerDatosMapa
    {
         public string NombrePiso { get; set; }
        public string Coordenadas { get; set; }

        public string NombreFilial { get; set; }
       public string Categoria { get; set; }

        public ObtenerDatosMapa(string nombrePiso, string coordenadas, string categoria, string nombreFilial)
        {
            this.NombrePiso = nombrePiso;
            this.Coordenadas = coordenadas;
            this.Categoria = categoria;
            this.NombreFilial = nombreFilial;
        }
    }
}
