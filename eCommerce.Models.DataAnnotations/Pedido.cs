using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        // Utilizando navegação pela propriedade Cliente
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("Cliente")]
        public int ColaboradorId {  get; set; }

        [ForeignKey("Cliente")]
        public int SupervisorId {  get; set; }


        public Usuario? Cliente { get; set; }
        public Usuario? Colaborador { get; set; }
        public Usuario? Supervisor { get; set; }
    }
}
