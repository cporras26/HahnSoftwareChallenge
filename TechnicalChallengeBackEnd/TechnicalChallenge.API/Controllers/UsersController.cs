using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalChallenge.API.Requests;
using TechnicalChallenge.API.Responses;
using TechnicalChallenge.BLL;
using TechnicalChallenge.Common.Dto.RequestsDto;
using TechnicalChallenge.Common.Dto.ResponsesDto;

namespace TechnicalChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ITechnicalChallengeBll _technicalChallengeBll;
        private readonly IMapper _mapper;

        public UsersController (ITechnicalChallengeBll technicalChallengeBll, IMapper mapper) 
        {
            _technicalChallengeBll = technicalChallengeBll;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _technicalChallengeBll.GetAllUsers();

            var resultResponse = _mapper.Map<List<UserResponseDto>, List<UserResponse>>(result);

            return Ok(resultResponse);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _technicalChallengeBll.GetUserById(id);

            var resultResponse = _mapper.Map<UserResponseDto,UserResponse>(result);

            return Ok(resultResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserRequest user)
        {
            var requestDto = _mapper.Map<UserRequest, UserRequestDto>(user);

            await _technicalChallengeBll.AddUser(requestDto);

            return StatusCode(StatusCodes.Status201Created, string.Empty);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserRequest user)
        {
            if(user.Id == null) return StatusCode(StatusCodes.Status400BadRequest, "The Id field is required");

            var requestDto = _mapper.Map<UserRequest, UserRequestDto>(user);

            var result = await _technicalChallengeBll.UpdateUserInformation(requestDto);

            return result ? Ok(string.Empty) : StatusCode(StatusCodes.Status204NoContent, string.Empty);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _technicalChallengeBll.DeleteUserById(id);

            return result ? Ok(string.Empty) : StatusCode(StatusCodes.Status204NoContent, string.Empty);
        }
    }
}
