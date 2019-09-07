using AutoMapper;
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

        public void ConfigureServices(IServiceCollection services)
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
                "{controller}/{action}/{id?}");
        }
    }
}
