using ProjetoAPI.Application.Dtos;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Contratos
{
    public interface IComentarioService
    {
        Task<ComentarioDto> AddComentario(int userId, int postId, ComentarioDto model);
        Task<ComentarioDto> UpdateComentario(int userId, int comentarioId, ComentarioDto model);
        Task<bool> DeleteComentario(int userId, int comentarioId);

        Task<ComentarioDto[]> GetAllComentariosAsync(int postId);
        Task<ComentarioDto[]> GetComentariosByUserId(int userId);
        Task<ComentarioDto> GetComentarioById(int id);
    }
}
