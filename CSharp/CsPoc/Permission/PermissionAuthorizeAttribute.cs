using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using static Permission.PermissionMatrix;

namespace Permission
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] _permissionsToCheck;

        public string[] PermissionsToCheck
        {
            get { return _permissionsToCheck; }
        }

        public PermissionAuthorizeAttribute(params string[] permissionsToCheck) : base("PermissionAuthorize")
        {
            _permissionsToCheck = permissionsToCheck;
        }

        public PermissionAuthorizeAttribute(params Premissions[] permissionsToCheck) : base("PermissionAuthorize")
        {
            _permissionsToCheck = permissionsToCheck.Select(x => x.GetPermissionKey()).ToArray();
        }
    }
}
