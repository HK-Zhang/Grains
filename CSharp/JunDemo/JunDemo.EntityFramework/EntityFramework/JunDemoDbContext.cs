using System.Data.Common;
using Abp.Zero.EntityFramework;
using System.Data.Entity;
using JunDemo.Authorization.Roles;
using JunDemo.MultiTenancy;
using JunDemo.Users;
using JunDemo.APPLEs;

namespace JunDemo.EntityFramework
{
    public class JunDemoDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Emp> Emps { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public JunDemoDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in JunDemoDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of JunDemoDbContext since ABP automatically handles it.
         */
        public JunDemoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public JunDemoDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
