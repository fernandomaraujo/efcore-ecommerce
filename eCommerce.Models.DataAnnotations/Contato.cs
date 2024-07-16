using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }

        /**
         * Coluna - MER Coluna (modelo entidade relacionamento)
         * Convenção aplicada: O Entity já consegue definir que esse propriedade é um FK.
         * {Modelo}+{PK} = UsuarioID
         
        public int UsuarioId { get; set; }
         */

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        /**
         * 
         * POO (Navegar)
         * 
         * FK (Propriedade da POO) -> UsuarioId(MER - Coluna) 
         * 
         * Usuário será navegável com base em UsuarioId
         * 
         * [ForeignKey("UsuarioId")]
         * public Usuario? Usuario { get; set; }
         */
      

        public Usuario? Usuario { get; set; }
    }
}
