using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Permission.Tests")]
namespace Permission
{

    internal class PermissionRepository : IPermissionRepository
    {
        private IEnumerable<PermissionEntity> AllPermissions { get; set; }

        public async Task<IEnumerable<PermissionEntity>> GetAll()
        {
            if (AllPermissions == null)
            {
                var classList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                    .Where(x => typeof(IPermissionMatrix).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                    .ToList();

                var permissions = classList.SelectMany(x => x.EnumerateNestedTypes()).Where(t => t.IsEnum).ToList();

                AllPermissions = permissions.SelectMany(x => x.GetFields())
                    .SelectMany(x => x.GetCustomAttributes(typeof(PermissionValueAttribute), false) as PermissionValueAttribute[])
                    .Select(x => new PermissionEntity() { Id = x.Id, Name = x.Name, Key = x.Key, Description = x.Description, Group = x.Group })
                    .ToList();
            }

            return await Task.FromResult(AllPermissions);
        }
    }
}
