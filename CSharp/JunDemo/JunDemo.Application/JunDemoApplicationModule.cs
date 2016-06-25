using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace JunDemo
{
    [DependsOn(typeof(JunDemoCoreModule), typeof(AbpAutoMapperModule))]
    public class JunDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
