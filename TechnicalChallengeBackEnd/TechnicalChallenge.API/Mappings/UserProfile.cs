using AutoMapper;
using TechnicalChallenge.API.Requests;
using TechnicalChallenge.API.Responses;
using TechnicalChallenge.Common.Dto.RequestsDto;
using TechnicalChallenge.Common.Dto.ResponsesDto;

namespace TechnicalChallenge.API.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserResponseDto, UserResponse>();
            CreateMap<UserRequest, UserRequestDto>();
        }
    }
}
