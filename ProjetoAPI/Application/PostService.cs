using AutoMapper;
using ProjetoAPI.Application.Contratos;
using ProjetoAPI.Application.Dtos;
using ProjetoAPI.Models;
using ProjetoAPI.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace ProjetoAPI.Application
{
    public class PostService : IPostService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPostPersist _postPersist;
        private readonly IMapper _mapper;

        public PostService(IGeralPersist geralPersist, IPostPersist postPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _postPersist = postPersist;
            _mapper = mapper;
        }

        public async Task<PostDto> AddPost(int userId, PostDto model)
        {
            try
            {
                var post = _mapper.Map<Post>(model);
                post.UserId = userId;

                _geralPersist.Add<Post>(post);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var postRetorno = await _postPersist.GetPostByIdAsync(post.PostId);

                    return _mapper.Map<PostDto>(postRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePost(int postId)
        {
            try
            {
                var evento = await _postPersist.GetPostByIdAsync(postId);
                if (evento == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Post>(evento);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PostDto[]> GetAllPostAsync()
        {
            try
            {
                var eventos = await _postPersist.GetAllPostAsync();
                if (eventos == null) return null;

                var resultado = _mapper.Map<PostDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PostDto[]> GetAllPostByUserIdAsync(int userId)
        {
            try
            {
                var eventos = await _postPersist.GetAllPostByUserIdAsync(userId);
                if (eventos == null) return null;

                var resultado = _mapper.Map<PostDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PostDto> GetPostByIdAsync(int postId)
        {
            try
            {
                var eventos = await _postPersist.GetPostByIdAsync(postId);
                if (eventos == null) return null;

                var resultado = _mapper.Map<PostDto>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<PostDto[]> GetPostByTagAsync(int userId, string tag)
        //{
        //    try
        //    {
        //        var eventos = await _postPersist.GetPostByTagAsync(userId, tag);
        //        if (eventos == null) return null;

        //        var resultado = _mapper.Map<PostDto[]>(eventos);

        //        return resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<PostDto[]> GetPostByTituloAsync(string Titulo)
        {
            try
            {
                var eventos = await _postPersist.GetPostByTituloAsync(Titulo);
                if (eventos == null) return null;

                var resultado = _mapper.Map<PostDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<PostDto[]> GetPostByTituloAsync(int userId, string Titulo)
        {
            throw new NotImplementedException();
        }

        public async Task<PostDto> UpdatePost(int userId, int postId, PostDto model)
        {
            try
            {
                var evento = await _postPersist.GetPostByIdAsync(postId);
                if (evento == null) return null;

                model.PostId = evento.PostId;
                model.UserId = userId;

                _mapper.Map(model, evento);

                _geralPersist.Update<Post>(evento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _postPersist.GetPostByIdAsync(evento.PostId);

                    return _mapper.Map<PostDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
