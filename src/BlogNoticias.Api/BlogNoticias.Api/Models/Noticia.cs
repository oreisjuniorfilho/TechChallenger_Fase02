using System.ComponentModel.DataAnnotations;

namespace BlogNoticias.Api.Models
{
    public class Noticia
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Chapeu { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get; set; }
    }
}
