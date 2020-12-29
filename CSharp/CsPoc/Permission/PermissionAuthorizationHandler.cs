using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Permission
{
    internal class PermissionAuthorizationHandler : AttributeAuthorizationHandler<PermissionRequirement, PermissionAuthorizeAttribute>
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserPermissionReader _userPermission;

        public PermissionAuthorizationHandler(
                IHttpContextAccessor httpContextAccessor, IUserPermissionReader userPermission)
        {
            _httpContextAccessor = httpContextAccessor;
            _userPermission = userPermission;
        }


        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement, IEnumerable<PermissionAuthorizeAttribute> attributes)
        {
            var varacityId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(t => t.Type == "userId")?.Value;
            var requiredPermissions = attributes.SelectMany(t => t.PermissionsToCheck).ToList();
            var ownedPermissions = await _userPermission.GetPermissions(varacityId);

            if (requiredPermissions.Any() == false || requiredPermissions.All(t => ownedPermissions.Any(x => x.Key == t)))
            {
                context.Succeed(requirement);
            }
            else
            {
                var missedPermissions = requiredPermissions.Where(t => ownedPermissions.Any(x => x.Key == t) == false).ToList();
                throw new UnauthorizedAccessException($"miss permissions: {string.Join(",", missedPermissions)}.");
            }
        }
    }
}
