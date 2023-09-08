using AutoMapper;
using BlogNoticias.Api.Data.Dto;
using BlogNoticias.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNoticias.Api.Data.Repository
{
    public class NoticiaRepository : INoticiaRepository
    {
        private NoticiaContext _context;
        private IMapper _mapper;

        public NoticiaRepository(NoticiaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadNoticiaDto> CadastrarNoticia(CreateNoticiaDto noticiaDto)
        {
            Noticia noticia = _mapper.Map<Noticia>(noticiaDto);

            _context.Noticias.Add(noticia);
            _context.SaveChanges();

            return  _mapper.Map<ReadNoticiaDto>(noticia);
        }

        public async Task<List<ReadNoticiaDto>> ObterNoticias()
        {
            var noticias = await _context.Noticias.ToListAsync();

            if (noticias == null)
            {
                return null;
            }

            return _mapper.Map<List<ReadNoticiaDto>>(noticias);
        }

        public async Task<ReadNoticiaDto> ObterNoticiasPorId(int id)
        {
            var noticia =  _context.Noticias.FirstOrDefault(noticia => noticia.Id == id);
           
            if (noticia != null)
            {
                return _mapper.Map<ReadNoticiaDto>(noticia);
            }

            return null;
        }
    }
}
