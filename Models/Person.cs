using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }

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
        public string? Username { get; set; }
        public string? Password { get; set; }


        public void UpdatePerson(Profile profile){
            this.Name = profile.Name;
            this.About = profile.About;
            this.UrlGithub = profile.UrlGithub;
            this.UrlLinkedin = profile.UrlLinkedin;
        }

        public void UpdateUser(User user){
            this.Username = user.Username;
            this.Password = user.Password;
        }
    }
}