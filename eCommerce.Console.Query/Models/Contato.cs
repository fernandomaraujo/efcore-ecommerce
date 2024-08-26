namespace eCommerce.Console.Query
{
    public class Contato
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        // Tornou-se virtual para permitir o Lazy Load com proxies.
        // Após o estudo com proxies, o virtual foi removido delas.
        public Usuario? Usuario { get; set; }
    }
}
