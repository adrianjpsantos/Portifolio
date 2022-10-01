

using System.ComponentModel.DataAnnotations;

namespace Portifolio.ViewsModels
{
    public class Login
    {
        [Display(Name ="Endereço de E-mail:")]
        [Required(ErrorMessage = "Digite um e-mail.")]
        [EmailAddress(ErrorMessage = "Endereço de E-mail Inválido.")]
        public string email { get; set; } = string.Empty;

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "Digite sua senha.")]
        public string password { get; set; } = string.Empty;
    }
}