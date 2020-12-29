using System;
using System.Collections.Generic;
using System.Text;

namespace Permission
{
    public class PermissionMatrix: IPermissionMatrix
    {

        public enum Premissions
        {
            [PermissionValue(Id = "1", Key = "ManageUser", Name = "ManageUser", Group = "Admin", Description = "ManageUser")]
            ManageUser,

            [PermissionValue(Id = "2", Key = "ViewUser", Name = "ViewUser", Group = "Admin", Description = "ViewUser")]
            ViewUser,

            [PermissionValue(Id = "3", Key = "ViewRole", Name = "ViewRole", Group = "Admin", Description = "ViewRole")]
            ViewRole,

            [PermissionValue(Id = "4", Key = "ManageRole", Name = "ManageRole", Group = "Admin", Description = "ManageRole")]
            ManageRole
        }
    }
}
