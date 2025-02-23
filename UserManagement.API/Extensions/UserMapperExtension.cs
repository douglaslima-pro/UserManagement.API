using UserManagement.API.DTO;
using UserManagement.API.Models;

namespace UserManagement.API.Extensions
{
    public static class UserMapperExtension
    {
        public static void MapFromDTO(this User user, UserDTO dto)
        {
            if (dto.Name != null)
            {
                user.Name = dto.Name;
            }
            if (dto.Email != null)
            {
                user.Email = dto.Email;
            }
            if (dto.Password != null)
            {
                user.Password = dto.Password;
            }
        }
    }
}
