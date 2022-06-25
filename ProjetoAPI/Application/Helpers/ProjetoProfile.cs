using System;
using AutoMapper;
using ProjetoAPI.Application.Dtos;
using ProjetoAPI.Models;
using ProjetoAPI.Models.Identity;

namespace ProjetoAPI.Application.Helpers
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();

            CreateMap<Comentario, ComentarioDto>().ReverseMap();
            CreateMap<Interacao, InteracaoDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
