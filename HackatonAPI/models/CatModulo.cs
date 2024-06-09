namespace HackatonAPI.models
{
    public class CatModulo
    {
        public string Categoria { get; set; }
        public string Modulo { get; set; }

        public CatModulo(string categoria, string modulo)
        {
            this.Categoria = categoria;
            this.Modulo = modulo;
        }
    }
}
