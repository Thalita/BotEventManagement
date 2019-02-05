﻿using EventManager.Api.Middleware;
using EventManager.Services.Interfaces;
using EventManager.Services.Model.Database;
using EventManager.Services.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace BotEventTemplate.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables().Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Configure Services - Begin");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            Console.WriteLine("Configure Services - Before Database Configuration");
            services.AddDbContext<EventManagerContext>(options => options.UseSqlServer(Configuration["DefaultConnection"]));

            Console.WriteLine("Configure Services - Before Swagger Configuration");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Event Manager",
                    Version = "v1",
                    Description = "API to manage events",
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "EventManager.Api.xml");

                Console.WriteLine($"Configure Services - Directory: {xmlPath}");

                c.IncludeXmlComments(xmlPath);
            });

            Console.WriteLine("Configure Services - Before Dependency Injection Configuration");

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            services.AddScoped<ISponsorRepository, SponsorRepository>();
            services.AddScoped<IAttendantRepository, AttendantRepository>();
            services.AddScoped<ICredentialRepository, CredentialRepository>();
            services.AddScoped<IPresentationRepository, PresentationRepository>();
            services.AddScoped<ISpeakerPresentationRepository, SpeakerPresentationRepository>();
            services.AddScoped<IAttendantPresentationRepository, PresentationAttendantRepository>();
            services.AddScoped<IPresentationCredentialRepository, PresentationCredentialRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Console.WriteLine("Configure Services - Before Environment Configuration");

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            Console.WriteLine("Configure Services - Before Middleware Configuration");
            app.UseMiddleware<ErrorHandlingMiddleware>();

            Console.WriteLine("Configure Services - Before Update Database Configuration");
            UpdateDatabase(app);

            Console.WriteLine("Configure Services - Before Swagger Json Configuration");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event Manager V1");
                c.RoutePrefix = "";
            });

            app.UseMvc();
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<EventManagerContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
