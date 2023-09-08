using AutoMapper;
using BlogNoticias.Api.Data.Dto;
using BlogNoticias.Api.Models;

namespace BlogNoticias.Api.Profiles
{
    public class NoticiaProfile : Profile
    {
        public NoticiaProfile()
        {
            CreateMap<CreateNoticiaDto, Noticia>();
            CreateMap<Noticia, ReadNoticiaDto>();
        }
    }
}
