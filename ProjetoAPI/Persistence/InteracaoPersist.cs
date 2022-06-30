using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Models;
using ProjetoAPI.Persistence.Contextos;
using ProjetoAPI.Persistence.Contratos;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Persistence
{
    public class InteracaoPersist : IInteracaoPersist
    {
        private readonly ProjetoContext _context;

        public InteracaoPersist(ProjetoContext context)
        {
            _context = context;
        }

        public async Task<Interacao> GetInteracaoByIdAsync(int interacaoId)
        {
            IQueryable<Interacao> query = _context.Interacoes
                .Include(p => p.User)
                .Include(a => a.Comentario);

            query = query.Where(p => p.InteracaoId == interacaoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Interacao[]> GetInteracoesByComentarioAsync(int comentarioId)
        {
            IQueryable<Interacao> query = _context.Interacoes
                .Include(p => p.User)
                .Include(a => a.Comentario);

            query = query.Where(a => a.ComentarioId == comentarioId);

            return await query.ToArrayAsync();
        }
    }
}
