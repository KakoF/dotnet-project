using Api.Helpers.Middleware;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Integrator.Interface;
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
using Repository.Context;
using Repository.Repository;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
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
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IIntegrator, Integrator.Integrator>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnnouncementDto, AnnouncementEntity>().ReverseMap();
                cfg.CreateMap<AnnouncementDtoCreate, AnnouncementEntity>().ReverseMap();
                cfg.CreateMap<AnnouncementDtoUpdate, AnnouncementEntity>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddDbContext<MyContext>(
                   options => options.UseNpgsql(Configuration["DATABASE_CONNECTION"]));

            services.AddControllers(options => options.Filters.Add<ValidationMiddleware>())
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebMotors API",
                    Description = "WebMotors",
                    Contact = new OpenApiContact
                    {
                        Name = "Kako",
                        Email = "kakoferrare87@gmail.com",
                        Url = new Uri("https://github.com/KakoF")
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebMotors");
                c.RoutePrefix = string.Empty;
            });
            app.UseCors("MyPolicy");
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
