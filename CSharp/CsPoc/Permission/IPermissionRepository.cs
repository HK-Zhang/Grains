using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Permission
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<PermissionEntity>> GetAll();
    }
}
