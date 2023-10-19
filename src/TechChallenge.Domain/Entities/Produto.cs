using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public class Produto
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Categoria")]
        [Display(Name = "Categoria")]
        public int Categoria { get; set; }

        [Column("Valor")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
    }
}