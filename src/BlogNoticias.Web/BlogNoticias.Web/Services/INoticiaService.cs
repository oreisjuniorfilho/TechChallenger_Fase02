using BlogNoticias.Web.ViewModels;

namespace BlogNoticias.Web.Services
{
    public interface INoticiaService
    {
        Task<IEnumerable<NoticiaViewModel>> ObterNoticias();
        Task<NoticiaViewModel> ObterNoticiasPorId(int id);
        Task<NoticiaViewModel> CadastrarNoticia(NoticiaViewModel noticiaDto);
    }
}
