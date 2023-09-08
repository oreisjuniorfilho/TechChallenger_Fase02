using System.ComponentModel.DataAnnotations;

namespace BlogNoticias.Api.Data.Dto
{
    public class ReadNoticiaDto
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de Titulo é obrigatório")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Chapeu { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get; set; }
    }
}
