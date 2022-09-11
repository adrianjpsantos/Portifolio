using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Models
{
     [Table("Technology")]
    public class Technology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTechnology { get; set;}

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Por favor, Informe o Nome da Tecnologia")]
        [StringLength(30, ErrorMessage = "O Nome deve possuir no máximo 30 caracteres")]
        public string name { get; set; } = string.Empty;

        [Display(Name = "Icone")]
        [Required(ErrorMessage = "Por favor, Informe o Icone da Tecnologia")]
        [StringLength(30, ErrorMessage = "O Icone deve possuir no máximo 30 caracteres")]
        public string icon { get; set; } = string.Empty;

        public ICollection<ProjectTechnology> projectsWithTechnology { get; set; } = new List<ProjectTechnology>();

        public Technology(){

        }

        public Technology(string name,string icon){
            this.name = name;
            this.icon = icon;
        }
    }

}