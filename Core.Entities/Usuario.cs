namespace Gestion.Core.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }  
        public string Nombre { get; set; }

        public string Hash { get; set; }
        public string Salt { get; set; }

    }

}
