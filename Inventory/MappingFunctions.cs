using Entities.DataTransferObjects.User;
using Entities.Models;
using Mapster;
using System.Net.NetworkInformation;

namespace Inventory
{
    public static class MappingFunctions
    {
        public static UserDto UserById(User user)
        {
            var userDto = user.Adapt<UserDto>();
            return userDto;
        }

        public static User ReplaceUser(UserForUpdateDto userDto, User userEntity)
        {
            var user = userDto.Adapt(userEntity);
            return user;
        }

        public static User CreateUser(UserForCreationDto userDto)
        {
            var user = userDto.Adapt<User>();
            return user;
        }
    }
}
