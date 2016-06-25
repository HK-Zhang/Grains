using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JunDemo.MultiTenancy.Dto;

namespace JunDemo.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
