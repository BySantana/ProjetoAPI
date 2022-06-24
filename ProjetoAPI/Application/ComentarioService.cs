using AutoMapper;
using ProjetoAPI.Application.Contratos;
using ProjetoAPI.Application.Dtos;
using ProjetoAPI.Models;
using ProjetoAPI.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace ProjetoAPI.Application
{
    public class ComentarioService : IComentarioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IComentarioPersist _comentarioPersist;
        private readonly IMapper _mapper;

        public ComentarioService(IGeralPersist geralPersist, IComentarioPersist comentarioPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _comentarioPersist = comentarioPersist;
            _mapper = mapper;
        }

        public async Task<ComentarioDto> AddComentario(int userId, int postId, ComentarioDto model)
        {
            try
            {
                var comentario = _mapper.Map<Comentario>(model);
                comentario.UserId = userId;
                comentario.PostId = postId;

                _geralPersist.Add(comentario);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var comentarioRetorno = await _comentarioPersist.GetComentarioByIdAsync(comentario.ComentarioId);

                    return _mapper.Map<ComentarioDto>(comentarioRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteComentario(int userId, int comentarioId)
        {
            try
            {
                var comentario = await _comentarioPersist.GetComentarioByIdAsync(comentarioId);
                if (comentario == null) throw new Exception("Comentario para delete não encontrado.");

                if(comentario.UserId == userId)
                {
                    _geralPersist.Delete(comentario);

                    return await _geralPersist.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Usuário sem permissão.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ComentarioDto[]> GetAllComentariosAsync(int postId)
        {
            try
            {
                var comentario = await _comentarioPersist.GetAllComentariosAsync(postId);
                if (comentario == null) throw new Exception("Comentario para delete não encontrado.");

                var resultado = _mapper.Map<ComentarioDto[]>(comentario);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ComentarioDto[]> GetComentariosByUserId(int userId)
        {
            try
            {
                var comentario = await _comentarioPersist.GetComentariosByUserId(userId);
                if (comentario == null) throw new Exception("Comentario para delete não encontrado.");

                var resultado = _mapper.Map<ComentarioDto[]>(comentario);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ComentarioDto> GetComentarioById(int id)
        {
            try
            {
                var comentario = await _comentarioPersist.GetComentarioByIdAsync(id);
                if (comentario == null) throw new Exception("Comentario para delete não encontrado.");

                var resultado = _mapper.Map<ComentarioDto>(comentario);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ComentarioDto> UpdateComentario(int userId, int comentarioId, ComentarioDto model)
        {
            try
            {
                var comentario = await _comentarioPersist.GetComentarioByIdAsync(comentarioId);
                if (comentario == null) return null;

                model.ComentarioId = comentario.ComentarioId;
                model.UserId = userId;

                _mapper.Map(model, comentario);

                _geralPersist.Update(comentario);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _comentarioPersist.GetComentarioByIdAsync(comentario.ComentarioId);

                    return _mapper.Map<ComentarioDto>(eventoRetorno);
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
