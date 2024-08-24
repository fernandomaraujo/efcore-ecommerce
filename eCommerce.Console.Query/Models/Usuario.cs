namespace eCommerce.Console.Query
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sexo { get; set; }
        public string? RG { get; set; }
        public string CPF { get; set; } = null!;
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }
        public string? SituacaoCadastro { get; set; }
        public DateTimeOffset DataCadastro { get; set; }
        // As três seguintes se tornaram virtual para permitir o Lazy Load com proxies
        public virtual Contato? Contato { get; set; }
        public virtual ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public virtual ICollection<Departamento>? Departamentos { get; set; }
    }
}
