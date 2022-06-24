using ProjetoAPI.Models;
using System.Threading.Tasks;

namespace ProjetoAPI.Persistence.Contratos
{
    public interface IInteracaoPersist
    {
        Task<Interacao[]> GetInteracoesByComentarioAsync(int comentarioId);
        Task<Interacao> GetInteracaoByIdAsync(int interacaoId);

    }
}
