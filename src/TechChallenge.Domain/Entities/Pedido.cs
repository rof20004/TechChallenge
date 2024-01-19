using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TechChallenge.Domain.Entities
{
    public class Pedido
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("idCliente")]
        [Display(Name = "idCliente")]
        public string IdCliente { get; set; }

        [Column("Status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Column("StatusPagamento")]
        [Display(Name = "StatusPagamento")]
        public string StatusPagamento { get; set; }

        public List<Produto> Produtos { get; set; }

        [IgnoreDataMember]
        public decimal TotalPedido { get; set; }
    }
}