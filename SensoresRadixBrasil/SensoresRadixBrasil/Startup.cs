using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sensores.Radix.Application.AutoMapper;
using Sensores.Radix.Infra.CrossCutting.IoC;
using Sensores.Radix.Infra.Data.DbContexts;
using SensoresRadixBrasil.Doc;
using SensoresRadixBrasil.Hubs;
using System;
using System.Linq;
using System.Reflection;

namespace SensoresRadixBrasil
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
            services.AddCors(options =>
            {
                var corsUrls = Configuration.GetSection("App:CorsOrigins").Value.ToString()
                          .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(o => o.Trim('/'))
                                 .ToArray();
                options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.WithOrigins(corsUrls)
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });

            services.AddSignalR();
            services.AddDbContext<SensorEventContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBContextConfig")));
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            RegisterServices(services, Configuration);

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Radix Sensor Events Api",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Jucélio Amaral",
                        Url = new System.Uri("https://linkedin.com/in/jucélio-rodrigues-do-amaral-4717408b"),
                    }
                });
                s.SchemaFilter<SwaggerFilterConfig>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<DashboardHub>("/DashboardHub");
            });

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = string.Empty;
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

        }

        private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            NativeInjector.RegisterServices(services, configuration);
        }
    }
}
