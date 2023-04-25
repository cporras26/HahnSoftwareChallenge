using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Common.Dto.RequestsDto;
using TechnicalChallenge.Common.Dto.ResponsesDto;

namespace TechnicalChallenge.BLL
{
    public interface ITechnicalChallengeBll
    {
        Task<UserResponseDto> GetUserById(int id);
        Task<List<UserResponseDto>> GetAllUsers();
        Task<bool> AddUser(UserRequestDto user);
        Task<bool> UpdateUserInformation(int id, UserRequestDto user);
        Task<bool> DeleteUserById(int id);
    }
}
