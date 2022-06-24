using ProjetoAPI.Application.Dtos;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Contratos
{
    public interface IInteracaoService 
    {
        Task<InteracaoDto> AddInteracao(int userId, int comentarioId, InteracaoDto model);
        Task<InteracaoDto> UpdateInteracao(int userId, int interacaoId, InteracaoDto model);
        Task<bool> DeleteInteracao(int userId, int interacaoId);

        Task<InteracaoDto> GetInteracaoByIdAsync(int interacaoId);
        Task<InteracaoDto[]> GetInteracoesByComentarioIdAsync(int comentarioId);
    }
}
