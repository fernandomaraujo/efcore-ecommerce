using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace eCommerce.Models
{
    /*
     * Atributos que vem do Schema:
     * 
     * [Table] = Definir o nome da tabela.
     * [Column] = Definir o nome da coluna.
     * [NotMapped] = Não mapear uma propriedade.
     * [ForeignKey] = Definir que a propriedade é o vinculo da chave estrangeira.
     * [InverseProperty] = Definir a referência para cada FK vinda da mesma tabela.
     * [DatabaseGenerated] = Definir se uma propriedade vai ou não ser gerenciada pelo banco.
     * 
     * Atributo que vem do DataAnnotations:
     * [Key] = Definir que a propriedade é uma PK.
     * 
     * Atributo que vem do EF Core:
     * [Index] = Definir/Criar Indice no banco (Unique).
     */



    [Index(nameof(Email), IsUnique = true, Name = "IX_EMAIL_UNICO")]
    [Index(nameof(Nome), nameof(CPF))]
    [Table("TB_USUARIOS")]
    public class Usuario
    {
        public int Id { get; set; }

        /**
         * Indicando chave primária, caso queiramos explicitar uma e não usar a 
         * convenção do Entity de procurar por um campo que contenha "id" em seu nome. 
         
        [Key]
        [Column("COD")]
        public int Codigo {  get; set; }
        */
        public string Nome { get; set; } = null!;


        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        public string? Sexo { get; set; }

        [Column("REGISTRO_GERAL")]
        public string? RG { get; set; }
        public string CPF { get; set; } = null!;
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }
        public string? SituacaoCadastro { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Matricula {  get; set; }

        /**
         * 
         * Software/Aplicativo - Não persistindo.
         * RegistroAtico = (SituacaoCadastro == "ATIVO") ? true : false
         * 
         */
        [NotMapped]
        public bool RegistroAtivo { get; set; }

        public DateTimeOffset DataCadastro { get; set; }

        /**
         * Referenciando coluna
         * 
         */
        [ForeignKey("UsuarioId")]
        public Contato? Contato { get; set; }
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public ICollection<Departamento>? Departamentos { get; set; }


        /**
        * 
        * Usuario -> Pedido
        * Usuario (Clientes e Colaborador)
        * Pedido:
        * - Fazer pedido (Usuario-Cliente)
        * - Atualizar o pedido (Usuario-Colaborador)
        * - Supervisionar o pedido (Usuario-Supervisor)
        */

        /**
         * Apontando para o objeto navegável
         * 
         */
        [InverseProperty("Cliente")]
        public ICollection<Pedido>? PedidosCompradosPeloCliente { get; set; }

        [InverseProperty("Colaborador")]
        public ICollection<Pedido>? PedidosGerenciadosPeloColaborador { get; set; }

        [InverseProperty("Supervisor")]
        public ICollection<Pedido>? PedidosSupervisionadosPeloSupervisor { get; set; }
    }
}
