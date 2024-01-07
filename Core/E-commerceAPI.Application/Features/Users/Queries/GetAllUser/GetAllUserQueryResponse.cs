using E_commerceAPI.Application.Dtos.User;

namespace E_commerceAPI.Application.Features.Users.Queries.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public List<UserDto> Users { get; set; }
        public int TotalUserCount { get; set; }
    }
}
