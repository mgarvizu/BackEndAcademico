using BackEnd.Core.Interfaces;
using BackEnd.Infraestructura.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using BackEnd.Infraestructura.Filters;

namespace BackendAcademico
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
            services.AddControllers( options => 
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });
            // services.AddTransient<IEstudianteRepository, EstudianteRepository>();
            // services.AddTransient<IMateriaRepository, MateriaRepository>();
            services.AddSingleton<IConfiguration>(Configuration); // sirve para agregar con 
            services.AddTransient<IEstudianteDapperRepository, EstudianteDapperRepository>();
            services.AddTransient<IMateriaDapperRepository, MateriaDapperRepository>();
            services.AddTransient<IInscripcionDapperRepository, InscripcionDapperRepository>();   
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // habilitacion de serilog 
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
