using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CompleteWebApp1.Domain.Repositories;
using CompleteWebApp1.Domain.Services;
using CompleteWebApp1.Persistence.Contexts;
using CompleteWebApp1.Persistence.Repositories;
using CompleteWebApp1.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace CompleteWebApp1
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
            
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("DataBase");
            });

            
            services.AddScoped<IRoverRepository, RoverRepository>();
            services.AddScoped<IRoverService, RoverService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddSwaggerGen(c =>
            //{
            //  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rovers", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
