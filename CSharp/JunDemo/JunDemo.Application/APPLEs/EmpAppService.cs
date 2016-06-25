using Abp.Application.Services;
using Abp.Domain.Repositories;
using JunDemo.APPLEs.Dto;
using System.Threading.Tasks;
using AutoMapper;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace JunDemo.APPLEs
{
    public class EmpAppService : JunDemoAppServiceBase, IEmpAppService
    {
        //private readonly IRepository<Emp> _empRepository;
        private readonly IEmpRespository _empRepository;

        //public EmpAppService(IRepository<Emp> empRepository)
        //{
        //    _empRepository = empRepository;
        //}

        public EmpAppService(IEmpRespository empRepository)
        {
            _empRepository = empRepository;
        }

        public async Task CreateEmp(EmpDto input)
        {
            var emp = input.MapTo<Emp>();

            //Emp emp = new Emp();
            //emp.Address = input.Address;
            //emp.Name = input.Name;
            //emp.City = input.City;


            string a = emp.Address;
            await (_empRepository.InsertAsync(emp));

        }


        public GetEmpsOutput GetEmps(GetEmpsInput input)
        {

            var emps = _empRepository.GetAllWithCity(input.City);

            return new GetEmpsOutput
            {
                Emps = Mapper.Map<List<EmpDto>>(emps)
            };
        }
    }
}
