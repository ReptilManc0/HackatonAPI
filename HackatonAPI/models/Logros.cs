namespace HackatonAPI.models
{
    public class Logros
    {
        public int id { get; set; }
        public string descripcion { get;set; }
        public string image { get;set; }

        public Logros(int id, string descripcion, string image)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.image = image;
        }
    }
}
