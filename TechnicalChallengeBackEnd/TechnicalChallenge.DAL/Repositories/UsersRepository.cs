using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TechnicalChallenge.Common.Dto.RequestsDto;
using TechnicalChallenge.Common.Dto.ResponsesDto;
using TechnicalChallenge.Common.Services;
using TechnicalChallenge.Common.Settings;

namespace TechnicalChallenge.DAL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbService<UsersConnectionString> _dbService;

        public UsersRepository(IDbService<UsersConnectionString> dbService)
        {
            _dbService = dbService;
        }

        public async Task<List<UserResponseDto>> GetUserList()
        {
            var query = "SELECT * FROM public.users";

            var userList = await _dbService.GetAll<UserResponseDto>(query, new { });

            return userList;
        }

        public async Task<UserResponseDto> GetUser(int id)
        {
            var query = @"SELECT ""Id"", ""FirstName"", ""LastName"", ""Age"", ""Occupation"" FROM public.users where ""Id""=@id";

            var user = await _dbService.GetAsync<UserResponseDto>(query, new { id });

            return user;
        }

        public async Task<bool> CreateUser(UserRequestDto user)
        {
            var query = @"INSERT INTO public.users (""FirstName"", ""LastName"", ""Age"", ""Occupation"") VALUES (@FirstName, @LastName, @Age, @Occupation)";

            var result = await _dbService.EditData(query,user);

            return result > 0;
        }

        public async Task<bool> UpdateUser(int id, UserRequestDto user)
        {
            var query = @"UPDATE public.users SET ""FirstName""=@FirstName, ""LastName""=@LastName, ""Age""=@Age, ""Occupation""=@Occupation WHERE ""Id"" ="+id;

            var updateUser = await _dbService.EditData(query, user);

            return updateUser > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var query = @"DELETE FROM public.users WHERE ""Id""=@id";

            var deleteUser = await _dbService.EditData(query, new { id });

            return deleteUser > 0;
        }
    }
}
