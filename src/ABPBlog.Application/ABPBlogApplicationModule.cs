using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPBlog.Authorization;

namespace ABPBlog
{
    [DependsOn(
        typeof(ABPBlogCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ABPBlogApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ABPBlogAuthorizationProvider>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(AppCustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            Assembly thisAssembly = typeof(ABPBlogApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                //Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}