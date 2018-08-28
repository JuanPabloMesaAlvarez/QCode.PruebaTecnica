namespace QCode.Domain
{
    public class Usuario
    {
        public string UsuarioId { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }

        public bool IsValid = false;
    }
}