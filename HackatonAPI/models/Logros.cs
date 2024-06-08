namespace HackatonAPI.models
{
    public class logros
    {
        public int id { get; set; }
        public string descripcion { get;set; }
        public string image { get;set; }

        public logros(int id, string descripcion, string image)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.image = image;
        }
    }
}
