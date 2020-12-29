using System;
using System.Collections.Generic;
using System.Text;

namespace Permission
{
    public class PermissionEntity
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
    }
}
