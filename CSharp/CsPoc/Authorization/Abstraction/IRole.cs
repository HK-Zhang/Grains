using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authorization.Entity;

namespace Authorization.Abstraction
{
    public interface IRole
    {
        Task<Role> Create(Role role);
        Task<Role> Read(string Id);
        Task<Role> Update(Role role);
        Task Delete(string Id);
        Task<IEnumerable<Role>> All();
    }
}
