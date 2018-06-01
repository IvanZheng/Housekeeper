using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Housekeeper.Portal.Models;
using HouseKeeper.Persistence;
using IFramework.Config;
using IFramework.DependencyInjection;
using IFramework.DependencyInjection.Autofac;
using IFramework.EntityFrameworkCore;
using IFramework.JsonNet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Housekeeper.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration.Instance
                         .UseAutofacContainer()
                         .UseConfiguration(configuration)
                         .UseCommonComponents()
                         .UseJsonNet()
                         .UseEntityFrameworkComponents<HousekeeperDbContext>();
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<WeChatApp>(Configuration.Instance.GetSection(nameof(WeChatApp)))
                    .AddMvc();
            return ObjectProviderFactory.Instance
                                        .Build(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
