
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProject { get; set; }

        [Display(Name = "Titulo do Projeto")]
        [Required(ErrorMessage = "Informe o Titulo")]
        [StringLength(60, ErrorMessage = "O Titulo deve possuir no máximo 60 caracteres.")]
        public string title { get; set; } = String.Empty;

        public string? subTitle { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição do projeto")]
        [StringLength(2000, ErrorMessage = "A Descrição deve possuir no máximo 1000 caracteres")]
        public string description { get; set; } = string.Empty;

        [Display(Name = "Thumbnail")]
        [Required(ErrorMessage = "Escolha uma image")]
        [StringLength(2000, ErrorMessage = "A Descrição deve possuir no máximo 1000 caracteres")]
        public string thumbnail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe se o projeto está concluido")]
        public bool finish { get; set; } = false;

        [Display(Name = "Link github")]
        public string? urlSource { get; set; }

        [Display(Name = "Link para visualização")]
        public string? urlDemo { get; set; }

        
        public ICollection<ProjectTechnology> technologies { get; set; } = new List<ProjectTechnology>();

    }
}