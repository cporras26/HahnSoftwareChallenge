using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Common.Dto.RequestsDto;
using TechnicalChallenge.Common.Dto.ResponsesDto;
using TechnicalChallenge.DAL.Repositories;

namespace TechnicalChallenge.BLL
{
    public class TechnicalChallengeBll : ITechnicalChallengeBll
    {
        private readonly IUsersRepository _usersRepository;

        public TechnicalChallengeBll(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<UserResponseDto>> GetAllUsers()
        {
            return await _usersRepository.GetUserList();
        }

        public async Task<UserResponseDto> GetUserById(int id)
        {
            return await _usersRepository.GetUser(id);
        }

        public async Task<bool> AddUser(UserRequestDto requestDto)
        {
            return await _usersRepository.CreateUser(requestDto);
        }

        public async Task<bool> UpdateUserInformation(UserRequestDto requestDto)
        {
            return await _usersRepository.UpdateUser(requestDto);
        }

        public async Task<bool> DeleteUserById(int id)
        {
            return await _usersRepository.DeleteUser(id);
        }
    }
}
