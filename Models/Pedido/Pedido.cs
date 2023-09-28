using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TechChallenge.Models.Pedido
{
    public class Pedido 
    {
        [Key]
        [Column("IdPedido")]
        [Display(Name = "IdPedido")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }

        [Required]
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

    }
}
