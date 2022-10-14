
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
        public int IdProject { get; set; }

        [Display(Name = "Titulo do Projeto")]
        [Required(ErrorMessage = "Informe o Titulo")]
        [StringLength(60, ErrorMessage = "O Titulo deve possuir no máximo 60 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Subtitulo do Projeto")]
        [StringLength(200, ErrorMessage = "O Titulo deve possuir no máximo 200 caracteres.")]
        public string? SubTitle { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição do projeto")]
        [StringLength(2000, ErrorMessage = "A Descrição deve possuir no máximo 1000 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Thumbnail")]
        [StringLength(200, ErrorMessage = "A Descrição deve possuir no máximo 200 caracteres")]
        public string Thumbnail { get; set; } = string.Empty;
        
        [Display(Name = "Projeto Concluido")]
        [Required(ErrorMessage = "Informe se o projeto está concluido")]
        public bool Finish { get; set; } = false;

        [Display(Name = "Link github")]
        public string? UrlSource { get; set; }

        [Display(Name = "Link para visualização")]
        public string? UrlDemo { get; set; }

        
        public ICollection<ProjectTechnology> Technologies { get; set; } = new List<ProjectTechnology>();

    }
}