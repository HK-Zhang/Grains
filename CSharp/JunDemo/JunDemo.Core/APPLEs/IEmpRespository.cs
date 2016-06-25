using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace JunDemo.APPLEs
{
    public interface IEmpRespository:IRepository<Emp>
    {
        List<Emp> GetAllWithCity(string city);
    }
}
