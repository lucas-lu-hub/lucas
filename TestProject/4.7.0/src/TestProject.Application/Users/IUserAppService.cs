using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TestProject.Roles.Dto;
using TestProject.Users.Dto;

namespace TestProject.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}