using System.ComponentModel.DataAnnotations;

namespace Portifolio.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Nome de Usuário")]
        [Required(ErrorMessage = "Informe o nome do usuário")]
        [StringLength(30, ErrorMessage = "O Nome de usuário deve possuir no máximo 30 caracteres")]
        public string? Username { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha do usuário")]
        [StringLength(30, ErrorMessage = "A senha deve possuir no máximo 30 caracteres")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public void SetPerson(Person person)
        {
            this.Username = person.Username;
            this.Password = person.Password;
        }
    }
}