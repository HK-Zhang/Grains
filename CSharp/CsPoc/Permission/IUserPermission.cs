using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Permission
{
    public interface IUserPermissionReader
    {
        Task<IEnumerable<PermissionEntity>> GetPermissions(string veracityId);
    }
}
