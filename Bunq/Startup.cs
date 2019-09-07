using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Bunq.Infrastructure;
using Bunq.Mapping;
using DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bunq
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private IContainer ApplicationContainer { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("bunqContext"),
                    assembly => assembly.MigrationsAssembly("DataModel")));

            // config AutoMapper
            var mapperProfile = new MapperConfiguration(
                mc => mc.AddProfile(new MappingProfile()));
            var mapper = mapperProfile.CreateMapper();
            services.AddSingleton(mapper);

            // config cores
            //services.AddCors(options => options.AddPolicy("AllowCors", policyVuilder => { }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // config AutoFac
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ContextModule());
            builder.RegisterModule(new MapperModule());
            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(ConfigureRoute);
        }

        private void ConfigureRoute(IRouteBuilder route)
        {
            route.MapRoute(
                "Default",
                "{controller=User}/{action}/{id?}");
        }
    }
}
