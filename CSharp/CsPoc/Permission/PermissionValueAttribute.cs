using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Permission
{
    public class PermissionValueAttribute : Attribute
    {
        public PermissionValueAttribute()
        {
        }

        public string Id { [CompilerGenerated]get; [CompilerGenerated]set; }

        public string Key { [CompilerGenerated]get; [CompilerGenerated]set; }

        public string Name { [CompilerGenerated]get; [CompilerGenerated]set; }

        public string Description { [CompilerGenerated]get; [CompilerGenerated]set; }

        public string Group { [CompilerGenerated]get; [CompilerGenerated]set; }

    }
}
