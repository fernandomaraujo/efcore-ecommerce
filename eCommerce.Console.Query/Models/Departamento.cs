namespace eCommerce.Console.Query
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        // Tornou-se virtual para permitir o Lazy Load com proxies.
        // Após o estudo com proxies, o virtual foi removido delas.
        public ICollection<Usuario>? Usuarios { get; set; }

    }
}
