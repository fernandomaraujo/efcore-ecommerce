namespace eCommerce.Console.Query
{
    public class Contato
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        // Tornou-se virtual para permitir o Lazy Load com proxies
        public virtual Usuario? Usuario { get; set; }
    }
}
