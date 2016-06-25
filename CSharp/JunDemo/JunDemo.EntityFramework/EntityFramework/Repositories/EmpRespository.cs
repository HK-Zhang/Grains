using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Abp.EntityFramework;
using JunDemo.APPLEs;

namespace JunDemo.EntityFramework.Repositories
{
    public class EmpRespository : JunDemoRepositoryBase<Emp>,IEmpRespository
    {
        public EmpRespository(IDbContextProvider<JunDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<Emp> GetAllWithCity(string city)
        {
            var query = GetAll();

            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(emp => emp.City == city);
            }


            return query
                .OrderByDescending(emp => emp.Name)
                .ToList();
        }
    }
}
