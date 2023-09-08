using BlogNoticias.Api.Data.Dto;
using BlogNoticias.Api.Models;

namespace BlogNoticias.Api.Data.Repository
{
    public interface INoticiaRepository
    {
        Task<List<ReadNoticiaDto>> ObterNoticias();
        Task<ReadNoticiaDto> ObterNoticiasPorId(int id);
        Task<ReadNoticiaDto> CadastrarNoticia(CreateNoticiaDto noticiaDto);
    }
}