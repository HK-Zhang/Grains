using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Permission
{
    public static class PermissionDefaultSetup
    {

        public static IServiceCollection UseDefaultPermissionSource<T>(this IServiceCollection services) where T : IUserPermissionReader
        {
            return services.AddSingleton<IPermissionRepository, PermissionRepository>().AddPermissionAuthorization<T>();
        }

        public static IServiceCollection AddPermissionAuthorization<T>(this IServiceCollection services) where T : IUserPermissionReader
        {
            services.AddScoped(typeof(IUserPermissionReader), typeof(T));
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            return services.AddAuthorization(config =>
            {
                config.AddPolicy("PermissionAuthorize", policy => policy.AddRequirements(new PermissionRequirement()));
            });
        }
    }
}
