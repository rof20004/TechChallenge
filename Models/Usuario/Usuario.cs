using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TechChallenge.Models.Usuario
{
    public class Usuario
    {
        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do Usuario é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O Email é obrigatório", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Key]
        [Column("CPF")]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório", AllowEmptyStrings = false)]
        public string CPF { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone é obrigatório", AllowEmptyStrings = false)]
        public string Telefone { get; set; }
    }
}
