using ProjetoAPI.Models;
using System.Threading.Tasks;

namespace ProjetoAPI.Persistence.Contratos
{
    public interface IComentarioPersist
    {
        Task<Comentario[]> GetAllComentariosAsync(int postId);
        Task<Comentario[]> GetComentariosByUserId(int userId);
        public Task<Comentario> GetComentarioByIdAsync(int comentarioId);
    }
}
