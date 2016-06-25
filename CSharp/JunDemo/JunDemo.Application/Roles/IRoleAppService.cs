using System.Threading.Tasks;
using Abp.Application.Services;
using JunDemo.Roles.Dto;

namespace JunDemo.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
