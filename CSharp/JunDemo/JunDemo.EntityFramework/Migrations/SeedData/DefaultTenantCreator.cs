using System.Linq;
using JunDemo.EntityFramework;
using JunDemo.MultiTenancy;

namespace JunDemo.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly JunDemoDbContext _context;

        public DefaultTenantCreator(JunDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
