using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public class PedidoProduto
    {
        [Key]
        [Column("id")]
        [Display(Name = "id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("idPedido")]
        [Display(Name = "idPedido")]
        public int IdPedido { get; set; }

        [Column("idProduto")]
        [Display(Name = "idProduto")]
        [Required]
        public int IdProduto { get; set; }
    }
}