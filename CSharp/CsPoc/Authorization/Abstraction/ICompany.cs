using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authorization.Entity;

namespace Authorization.Abstraction
{
    public interface ICompany
    {
        Task<Company> Create(Company company);
        Task<Company> Read(string Id);
        Task<Company> Update(Company company);
        Task Delete(string Id);
        Task<IEnumerable<Company>> All();
    }
}
