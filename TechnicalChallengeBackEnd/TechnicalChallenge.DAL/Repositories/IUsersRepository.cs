using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalChallenge.Common.Dto.RequestsDto;
using TechnicalChallenge.Common.Dto.ResponsesDto;

namespace TechnicalChallenge.DAL.Repositories
{
    public interface IUsersRepository
    {
        Task<List<UserResponseDto>> GetUserList();
        Task<UserResponseDto> GetUser(int id);
        Task<bool> CreateUser(UserRequestDto user);
        Task<bool> UpdateUser(UserRequestDto user);
        Task<bool> DeleteUser(int id);
    }
}
