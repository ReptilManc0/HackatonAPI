namespace HackatonAPI.models
{
    public class DetallesZona
    {
        public string descripcion { get; set; }
        public int mesa { get; set; }
        public int silla { get; set; }
        public int banquito { get; set; }
        public int expendedoraBebida { get; set; }
        public int expendedoraSnack { get; set; }
        public int expendedoraCafe { get; set; }
        public int puff { get; set; }
        public int pupitres { get; set; }
        public int computadora { get; set; }

        public DetallesZona(string descripcion, int mesa, int silla, int banquito, int expendedoraBebida, int expendedoraSnack, int expendedoraCafe, int puff, int pupitres, int computadora)
        {
            this.descripcion = descripcion;
            this.mesa = mesa;
            this.silla = silla;
            this.banquito = banquito;
            this.expendedoraBebida = expendedoraBebida;
            this.expendedoraSnack = expendedoraSnack;
            this.expendedoraCafe = expendedoraCafe;
            this.puff = puff;
            this.pupitres = pupitres;
            this.computadora = computadora;
        }
    }
}
