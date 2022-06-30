using ProjetoAPI.Application.Dtos;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Contratos
{
    public interface IPostService
    {
        Task<PostDto> AddPost(int userId, PostDto model);
        Task<PostDto> UpdatePost(int userId, int postId, PostDto model);
        Task<bool> DeletePost(int userId, int postId);

        Task<PostDto[]> GetAllPostAsync();
        Task<PostDto[]> GetAllPostByUserIdAsync(int userId);
        Task<PostDto> GetPostByIdAsync(int postId);
        Task<PostDto[]> GetPostByTagAsync(string tag);
        Task<PostDto[]> GetPostByTituloAsync(int userId, string Titulo);
    }
}
