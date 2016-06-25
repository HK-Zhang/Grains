using Abp.Authorization;
using JunDemo.Authorization.Roles;
using JunDemo.MultiTenancy;
using JunDemo.Users;

namespace JunDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
