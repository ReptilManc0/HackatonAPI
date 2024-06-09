namespace HackatonAPI.models
{
    public class ObtenerDatosMapa
    {
         public int IdZona { get; set; }
        public string CodigoZona { get; set; }
        public string Coordenadas { get; set; }

       public string Categoria { get; set; }

        public ObtenerDatosMapa(int idZona, string coordenadas, string categoria, string codigoZona)
        {
            this.IdZona = idZona;
            this.Coordenadas = coordenadas;
            this.Categoria = categoria;
            this.CodigoZona= codigoZona;

        }
    }
}
