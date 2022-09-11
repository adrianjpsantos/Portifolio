using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPerson{ get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage = "Digite um nome")]
        [StringLength(60,ErrorMessage = "O Nome deve ter no maximo 60 caracteres")]
        public string name { get; set; } = string.Empty;

        [Display(Name = "Sobre Mim")]
        [Required(ErrorMessage = "Digite o sobre mim")]
        [StringLength(1000, ErrorMessage = "O Sobre mim deve ter no maximo 1000 caracteres")]
        public string about { get; set; } = string.Empty;

        public string? urlLinkedin{ get; set; }
        public string? urlGithub{ get; set; }
        public string? emailAddress{ get; set; }
    }
}