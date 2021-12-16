using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authorization.Entity;

namespace Authorization.Abstraction
{
    public interface IUser
    {
        Task<User> Create(User user);
        Task<User> Read(string Id);
        Task<User> Update(User user);
        Task Delete(string Id);
        Task<IEnumerable<User>> All();
        Task<IEnumerable<User>> GetUsersOfRole(string roleId);
        Task<IEnumerable<User>> GetUsersOfCompany(string companyId);
    }
}
