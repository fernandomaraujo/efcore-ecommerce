using Microsoft.EntityFrameworkCore.Infrastructure;

namespace eCommerce.Console.Query
{
    public class Usuario
    {
        // Aula de Lazy Load sem proxies
        private readonly ILazyLoader LazyLoader;

        public Usuario() { }
        public Usuario(ILazyLoader loader) {
            LazyLoader = loader;
        }

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

        // As três seguintes se tornaram virtual para permitir o Lazy Load com proxies.
        // Após o estudo com proxies, o virtual foi removido delas.
        public Contato? Contato { get; set; }

        // Criado para o LazyLoad sem proxies, utilizando do ILazyLoader
        private ICollection<EnderecoEntrega>? _enderecosEntrega { get; set; }

        // Alterado para LazyLoad sem proxies, utilizando do ILazyLoader
        public ICollection<EnderecoEntrega>? EnderecosEntrega { 
            get => LazyLoader.Load(this, ref _enderecosEntrega); 
            set => _enderecosEntrega = value; 
        }
        public ICollection<Departamento>? Departamentos { get; set; }
    }
}
