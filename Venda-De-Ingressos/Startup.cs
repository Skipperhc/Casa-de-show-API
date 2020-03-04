using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Venda_De_Ingressos.Data;
using Venda_De_Ingressos.Repositories;
using Venda_De_Ingressos.Repositories.Interface;

namespace Venda_De_Ingressos {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddControllers().AddNewtonsoftJson();
            
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ICasaDeShowRepository, CasaDeShowRepository>();
            services.AddTransient<IEventoRepository, EventoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            
            services.AddSwaggerGen
            (c => {
                c.SwaggerDoc
                ("v1", new OpenApiInfo {
                    Version = "v1", Title = "API Casa de Shows", Description = "API de gerenciamento de shows."
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseAuthorization();
            
            app.UseSwaggerUI
                (c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Casa de Shows");
            });

            app.UseEndpoints
            (endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}