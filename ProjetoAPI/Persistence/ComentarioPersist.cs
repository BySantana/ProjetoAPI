using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Models;
using ProjetoAPI.Persistence.Contextos;
using ProjetoAPI.Persistence.Contratos;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Persistence
{
    public class ComentarioPersist : IComentarioPersist
    {
        private readonly ProjetoContext _context;

        public ComentarioPersist(ProjetoContext context)
        {
            _context = context;
        }
        public async Task<Comentario[]> GetAllComentariosAsync(int postId)
        {
            IQueryable<Comentario> query = _context.Comentarios
                .Include(c => c.Interacoes)
                .Include(p => p.User)
                .Include(a => a.Post);

            query = query.Where(x => x.PostId == postId);

            return await query.ToArrayAsync();
        }

        public async Task<Comentario[]> GetComentariosByUserId(int userId)
        {
            IQueryable<Comentario> query = _context.Comentarios
                .Include(c => c.Interacoes)
                .Include(p => p.User)
                .Include(a => a.Post);

            query = query.Where(x => x.UserId == userId);

            return await query.ToArrayAsync();
        }

        public async Task<Comentario> GetComentarioByIdAsync(int comentarioId)
        {
            IQueryable<Comentario> query = _context.Comentarios
                .Include(c => c.Interacoes)
                .Include(p => p.User)
                .Include(a => a.Post);

            query = query.Where(x => x.ComentarioId == comentarioId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
