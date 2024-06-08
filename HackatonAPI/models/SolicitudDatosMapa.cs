namespace HackatonAPI.models
{
    public class SolicitudDatosMapa
    {
        public string sede { get; set; }
        public string piso { get; set; }

        public SolicitudDatosMapa(string sede, string piso)
        {
            this.sede = sede;
            this.piso = piso;
        }
    }
}
