using System.ComponentModel.DataAnnotations;

namespace BlogNoticias.Api.Models.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nome do Usuário é obrigatório!")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Senha do Usuário é obrigatório!")]
        public string? Password { get; set; }
    }
}
