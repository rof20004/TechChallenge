using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TechChallenge.Models.Produto
{
    public class Produto
    {
        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do Produto é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descricao")]
        [Required(ErrorMessage = "A descricao é obrigatória", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [Key]
        [Column("IdProduto")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }

        [Column("Preco")]
        [Display(Name = "Preco")]
        [Required(ErrorMessage = "O Preco é obrigatório", AllowEmptyStrings = false)]
        public double Preco { get; set; }
    }
}
