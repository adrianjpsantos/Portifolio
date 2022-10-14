using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Models
{
     [Table("Technology")]
    public class Technology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTechnology { get; set;}

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Por favor, Informe o Nome da Tecnologia")]
        [StringLength(30, ErrorMessage = "O Nome deve possuir no máximo 30 caracteres")]
        public string? Name { get; set; }

        [Display(Name = "Icone",Prompt = "Classe do icone na devicon.dev")]
        [Required(ErrorMessage = "Por favor, Informe o Icone da Tecnologia")]
        [StringLength(50, ErrorMessage = "O Icone deve possuir no máximo 50 caracteres")]
        public string? Icon { get; set; }

        public ICollection<ProjectTechnology> ProjectsWithTechnology { get; set; } = new List<ProjectTechnology>();

    }

}