using ProjetoAPI.Models;
using System.Threading.Tasks;

namespace ProjetoAPI.Persistence.Contratos
{
    public interface IPostPersist
    {
        Task<Post[]> GetAllPostAsync();
        Task<Post[]> GetAllPostByUserIdAsync(int userId);
        Task<Post> GetPostByIdAsync(int postId);
        //Task<Post[]> GetPostByTagAsync(int userId, string tag);
        Task<Post[]> GetPostByTituloAsync(string Titulo);
    }
}
