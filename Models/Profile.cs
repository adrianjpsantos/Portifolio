using System.ComponentModel.DataAnnotations;

namespace Portifolio.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Digite um nome")]
        [StringLength(60, ErrorMessage = "O Nome deve ter no maximo 60 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Sobre Mim")]
        [Required(ErrorMessage = "Digite o sobre mim")]
        [StringLength(1000, ErrorMessage = "O Sobre mim deve ter no maximo 1000 caracteres")]
        public string About { get; set; } = string.Empty;

        public string? UrlLinkedin { get; set; }
        public string? UrlGithub { get; set; }

        public void SetPerson(Person person)
        {
            this.Id = person.IdPerson;
            this.Name = person.Name;
            this.About = person.About;
            this.UrlGithub = person.UrlGithub;
            this.UrlLinkedin = person.UrlLinkedin;
        }
    }
}