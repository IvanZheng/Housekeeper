using System;
using Housekeeper.Domain.Repositories;
using Housekeeper.Persistence.Repositories;
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
using Microsoft.EntityFrameworkCore;
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
                         .UseAutofacContainer(a => a.GetName().Name.StartsWith("Housekeeper"))
                         .UseConfiguration(configuration)
                         .UseCommonComponents()
                         .UseJsonNet()
                         .UseEntityFrameworkComponents<HousekeeperDbContext>()
                         .UseDbContextPool<HousekeeperDbContext>(options => options.UseMySql(Configuration.Instance.GetConnectionString(nameof(HousekeeperDbContext)).ConnectionString));
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMiniProfiler()
                    .AddEntityFramework();
            services.Configure<WeChatApp>(Configuration.Instance.GetSection(nameof(WeChatApp)))
                    .AddMvc();
            return ObjectProviderFactory.Instance
                                        .RegisterComponents(RegisterComponents, ServiceLifetime.Scoped)
                                        .Build(services);
        }

        private static void RegisterComponents(IObjectProviderBuilder providerBuilder, ServiceLifetime lifetime)
        {
            // TODO: register other components or services
            providerBuilder.Register<IHousekeeperRepository, HousekeeperRepository>(lifetime);
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
            app.UseMiniProfiler();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                                "default",
                                "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                                           "spa-fallback",
                                           new {controller = "Home", action = "Index"});
            });
        }
    }
}