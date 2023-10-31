using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechChallenge.Domain.Entities
{
    public class Cliente
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nome")]
        [Display(Name = "nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        [Display(Name = "cpf")]
        public string CPF { get; set; }

        [Column("email")]
        [Display(Name = "email")]
        public string Email { get; set; }
    }
}