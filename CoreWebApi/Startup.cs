using System;
using CoreAPI.Infrastructure.Data.EF.SQL;
using CoreAPI.Services.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util.ApplicationServices;
using Util.Datas.Ef;

namespace CoreWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           // CoreUnitOfWork.connectString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration["RedisConnectionString"];
                options.InstanceName = "RedisDistributedCache";
            });
            services.AddDbContext<CoreUnitOfWork>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);

            });
            return Ioc.RegisterNetCore(services, new IocConfig());
          
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
