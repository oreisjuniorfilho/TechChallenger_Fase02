using BlogNoticias.Web.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace BlogNoticias.Web.Services
{
    public class NoticiaService : INoticiaService
    {
        private readonly HttpClient httpClient;

        public NoticiaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<NoticiaViewModel> CadastrarNoticia(NoticiaViewModel noticiaDto)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(noticiaDto), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("Noticias/Cadastrar", content);

                if (response.IsSuccessStatusCode)
                {
                    var noticias = await response.Content.ReadFromJsonAsync<NoticiaViewModel>();
                    return noticias;
                }

                return new NoticiaViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<NoticiaViewModel>> ObterNoticias()
        {
            try
            {
                var response = await httpClient.GetAsync("Noticias/Consultar");

                if (response.IsSuccessStatusCode)
                {
                    var noticias = await response.Content.ReadFromJsonAsync<IEnumerable<NoticiaViewModel>>();
                    return noticias;
                }
                return new List<NoticiaViewModel>();
            }
            catch (Exception )
            {
                throw;
            }
        }

        public async Task<NoticiaViewModel> ObterNoticiasPorId(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"Noticias/Consultar/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var noticias = await response.Content.ReadFromJsonAsync<NoticiaViewModel>();
                    return noticias;
                }
                return new NoticiaViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
