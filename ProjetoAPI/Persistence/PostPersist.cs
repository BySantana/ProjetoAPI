using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Models;
using ProjetoAPI.Persistence.Contextos;
using ProjetoAPI.Persistence.Contratos;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Persistence
{
    public class PostPersist : IPostPersist
    {
        private readonly ProjetoContext _context;

        public PostPersist(ProjetoContext context)
        {
            _context = context;
        }

        public async Task<Post[]> GetAllPostAsync()
        {
            IQueryable<Post> query = _context.Posts
                .Include(p => p.Comentarios);
                //.Include(p => p.Tags);

            return await query.ToArrayAsync();
        }

        public async Task<Post[]> GetAllPostByUserIdAsync(int userId)
        {
            IQueryable<Post> query = _context.Posts
                .Include(p => p.Comentarios);
                //.Include(p => p.Tags);

            query = query.Where(p => p.UserId == userId);

            return await query.ToArrayAsync();
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            IQueryable<Post> query = _context.Posts
                .Include(p => p.Comentarios);
                //.Include(p => p.Tags);

            query = query.Where(p => p.PostId == postId);

            return await query.FirstOrDefaultAsync();
        }

        //public async Task<Post[]> GetPostByTagAsync(int userId, string tag)
        //{
        //    IQueryable<Post> query = _context.Posts
        //        .Include(p => p.Comentarios);
        //        //.Include(p => p.Tags);

        //    query = query.Where(p => p.Tags.Contains(tag));

        //    return await query.ToArrayAsync();
        //}

        public async Task<Post[]> GetPostByTituloAsync(string titulo)
        {
            IQueryable<Post> query = _context.Posts
                .Include(p => p.Comentarios);
                //.Include(p => p.Tags);

            query = query.Where(p => p.Titulo.Contains(titulo));

            return await query.ToArrayAsync();
        }
    }
}
