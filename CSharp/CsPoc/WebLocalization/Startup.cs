using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;

namespace WebLocalization
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStringLocalizer<Startup> stringLocalizer, IStringLocalizerFactory stringLocalizerFactory)
        {
            app.UseRequestLocalization(BuildLocalizationOptions());

            app.Use(async (context, next) =>
            {
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/html; charset=utf-8";
                context.Response.Cookies.Append(".AspNetCore.Culture", "c=ko-KR|uic=ko-KR");
                await context.Response.WriteAsync(BuildResponse(stringLocalizer, stringLocalizerFactory));
            });

            //            if (env.IsDevelopment())
            //            {
            //                app.UseDeveloperExceptionPage();
            //            }
            //            else
            //            {
            //                app.UseExceptionHandler("/Home/Error");
            //            }
            //            app.UseStaticFiles();
            //
            //            app.UseRouting();
            //
            //            app.UseAuthorization();
            //
            //            app.UseEndpoints(endpoints =>
            //            {
            //                endpoints.MapControllerRoute(
            //                    name: "default",
            //                    pattern: "{controller=Home}/{action=Index}/{id?}");
            //            });
        }


        private RequestLocalizationOptions BuildLocalizationOptions()
        {
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("es-ES"),
                new CultureInfo("de-DE"),
                new CultureInfo("fr-FR"),
                new CultureInfo("ko-KR")
            };

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            return options;
        }

        private string BuildResponse(IStringLocalizer stringLocalizer, IStringLocalizerFactory stringLocalizerFactory)
        {
            var currentCultureName = CultureInfo.CurrentCulture.EnglishName;
            var currentUICultureName = CultureInfo.CurrentUICulture.EnglishName;

            var type = typeof(Startup);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);

            var sharedStringLocalizer = stringLocalizerFactory.Create("Shared", assemblyName.Name);

            return "<html><body>"
                   + $"<h2>{stringLocalizer["Hello"]}!</h2><table border=\"1\" cellpadding=\"5\" style=\"border-collapse:collapse;\">"
                   + $"<tr><td>{stringLocalizer["Current Culture"]}</td><td>{currentCultureName}</td></tr>"
                   + $"<tr><td>{stringLocalizer["Current UI Culture"]}</td><td>{currentUICultureName}</td></tr>"
                   + $"<tr><td>{stringLocalizer["The Current Date"]}</td><td>{DateTime.Now.ToString("D")}</td></tr>"
                   + $"<tr><td>{stringLocalizer["A Formatted Number"]}</td><td>{(1234567.89).ToString("n")}</td></tr>"
                   + $"<tr><td>{stringLocalizer["A Currency Value"]}</td><td>{(42).ToString("C")}</td></tr></table>"
                   + $"<h2>{sharedStringLocalizer["Goodbye"]}</h2>"
                   + "</body></html>";
        }
    }
}
