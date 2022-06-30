using Microsoft.AspNetCore.Identity;
using ProjetoAPI.Application.Dtos;
using System.Threading.Tasks;

namespace ProjetoAPI.Application.Contratos
{
    public interface IAccountService
    {
        Task<bool> UserExists(string userName);
        Task<UserUpdateDto> GetUserByUserNameAsync(string userName);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password);
        Task<UserUpdateDto> CreateAccountAsync(UserDto userDto);
        Task<UserUpdateDto> UpdateAccount(UserUpdateDto userUpdateDto);
        Task<UserUpdateDto[]> GetUsersAsync();
    }
}
