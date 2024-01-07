namespace E_commerceAPI.Application.Dtos.User
{
    public class ListUserDto
    {
        public List<UserDto> Users { get; set; }
        public int TotalUserCount { get; set; }
    }
}
