using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Permackathon.DAL;
using Permackathon.DAL.Interfaces;
using Permackathon.DAL.Repositories;
using Permackathon.DAL.UnitOfWork;
using System;

namespace Permackathon.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
            //services.AddControllers();

            //Our services
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IFinancialRepository, FinancialRepository>();
            services.AddTransient<IIndicatorRepository, IndicatorRepository>();
            services.AddTransient<ISiteRepository, SiteRepository>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>()
                                                                 .AddDefaultTokenProviders();

            //AutoMapper for transfer objects
            //TODO : https://code-maze.com/automapper-net-core/
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();

            //DB Context
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Production"))
            {
                services.AddDbContext<ApplicationContext>(option =>
                {
                    option.UseSqlServer(Configuration.GetConnectionString("Permackathon"));
                });
            }
            else
            {
                services.AddDbContext<ApplicationContext>(option =>
                {
                    option.UseSqlServer(Configuration.GetConnectionString("Permackathon"));
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}