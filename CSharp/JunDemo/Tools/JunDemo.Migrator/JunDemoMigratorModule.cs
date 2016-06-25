using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using JunDemo.EntityFramework;

namespace JunDemo.Migrator
{
    [DependsOn(typeof(JunDemoDataModule))]
    public class JunDemoMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<JunDemoDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}