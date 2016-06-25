using Abp.Application.Services;
using JunDemo.APPLEs.Dto;
using System.Threading.Tasks;

namespace JunDemo.APPLEs
{
    public interface IEmpAppService:IApplicationService
    {
        Task CreateEmp(EmpDto input);
        GetEmpsOutput GetEmps(GetEmpsInput input);
    }
}
