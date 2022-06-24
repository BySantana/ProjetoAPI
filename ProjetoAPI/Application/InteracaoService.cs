using AutoMapper;
using ProjetoAPI.Application.Contratos;
using ProjetoAPI.Application.Dtos;
using ProjetoAPI.Models;
using ProjetoAPI.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace ProjetoAPI.Application
{
    public class InteracaoService : IInteracaoService
    {
        private readonly IInteracaoPersist _interacaoPersist;
        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;

        public InteracaoService(IInteracaoPersist interacaoPersist, IGeralPersist geralPersist, IMapper mapper)
        {
            _interacaoPersist = interacaoPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }

        public async Task<InteracaoDto> AddInteracao(int userId, int comentarioId, InteracaoDto model)
        {
            try
            {
                var interacao = _mapper.Map<Interacao>(model);
                interacao.UserId = userId;
                interacao.ComentarioId = comentarioId;

                _geralPersist.Add<Interacao>(interacao);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var interacaoRetorno = await _interacaoPersist.GetInteracaoByIdAsync(interacao.InteracaoId);

                    return _mapper.Map<InteracaoDto>(interacaoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteInteracao(int userId, int interacaoId)
        {
            try
            {
                var interacao = await _interacaoPersist.GetInteracaoByIdAsync(interacaoId);
                if (interacao == null) throw new Exception("Interacao para delete não encontrado.");

                if(interacao.UserId == userId)
                {
                    _geralPersist.Delete(interacao);
                    return await _geralPersist.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Interacao para delete não encontrado.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InteracaoDto> GetInteracaoByIdAsync(int interacaoId)
        {
            try
            {
                var interacao = await _interacaoPersist.GetInteracaoByIdAsync(interacaoId);
                if (interacao == null) return null;

                var resultado = _mapper.Map<InteracaoDto>(interacao);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InteracaoDto[]> GetInteracoesByComentarioIdAsync(int comentarioId)
        {
            try
            {
                var interacao = await _interacaoPersist.GetInteracoesByComentarioAsync(comentarioId);
                if (interacao == null) return null;

                var resultado = _mapper.Map<InteracaoDto[]>(interacao);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InteracaoDto> UpdateInteracao(int userId, int interacaoId, InteracaoDto model)
        {
            try
            {
                var interacao = await _interacaoPersist.GetInteracaoByIdAsync(interacaoId);
                if (interacao == null) return null;

                model.InteracaoId = interacao.InteracaoId;
                model.UserId = userId;

                _mapper.Map(model, interacao);

                _geralPersist.Update(interacao);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var Retorno = await _interacaoPersist.GetInteracaoByIdAsync(interacao.ComentarioId);

                    return _mapper.Map<InteracaoDto>(Retorno);
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
