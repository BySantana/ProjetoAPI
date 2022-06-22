using ProjetoAPI.Application.Dtos;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}
