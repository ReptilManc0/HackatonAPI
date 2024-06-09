namespace HackatonAPI.models
{
    public class Cuenta
    {
        public string codEstudiante { get; set; }
        public string contrasenia {  get; set; }

        public Cuenta(string codEstudiante, string contrasenia)
        {
            this.codEstudiante = codEstudiante;
            this.contrasenia = contrasenia;
        }
    }
}
