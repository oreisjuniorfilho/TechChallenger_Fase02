using Microsoft.AspNetCore.Mvc;
using BlogNoticias.Web.ViewModels;
using BlogNoticias.Web.Services;

namespace BlogNoticias.Web.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiaService _noticiaService;

        public NoticiaController(INoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = _noticiaService.ObterNoticias().Result.ToList();
            return View(viewModel);
        }
              
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiaViewModel = _noticiaService.ObterNoticiasPorId(id).Result;

            if (noticiaViewModel == null)
            {
                return NotFound();
            }

            return View(noticiaViewModel);
        }

        // GET: Noticia/Create
        public IActionResult Create()
        {
            return View();
        }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Chapeu,DataPublicacao,Autor")] NoticiaViewModel noticiaViewModel)
        {
            var noticia = _noticiaService.CadastrarNoticia(noticiaViewModel);

            if (noticia!=null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(noticia);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }
                
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Chapeu,DataPublicacao,Autor")] NoticiaViewModel noticiaViewModel)
        {
            return View();
        }

        // GET: Noticia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();
        }

        private bool NoticiaViewModelExists(int id)
        {
           return true;
        }
    }
}
