using System;
using System.Linq;
using AutoMapper;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Domain.Services;
using deep.wefood.api.Infrastructure.Repositories;
using deep.wefood.api.Interfaces.Services;
using deep.wefood.api.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace deep.wefood.api.Presentation
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(env.ContentRootPath)
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                          .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IConfiguration), Configuration);
            services.AddScoped(typeof(PostgresContext), typeof(PostgresContext));
            services.AddScoped(typeof(IProductRepository), typeof(ProductPostgresRepository));
            services.AddScoped(typeof(IRepository<>), typeof(PostgresRepository<>));
            services.AddScoped(typeof(IServiceProduct), typeof(ServiceProduct));
            services.AddScoped(typeof(IServiceOrder), typeof(ServiceOrder));
            services.AddScoped(typeof(IServiceComplement), typeof(ServiceComplement));
            services.AddScoped(typeof(IServiceCompany), typeof(ServiceCompany));
            services.AddScoped(typeof(IServiceUser), typeof(ServiceUser));
            services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(
                    AppDomain.CurrentDomain.GetAssemblies()
                        .Where(x => x.FullName.Contains("deep."))
                        .Select(x => x.GetTypes().Where(type => type.IsClass && type.IsSubclassOf(typeof(Profile))))
                        .SelectMany(x => x)
                        .Select(x => Activator.CreateInstance(x) as Profile).ToList()
                );
            }).CreateMapper());

            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "deep.wefood.api.Presentation", Version = "v1" });
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(Configuration.GetValue<string>("secret"))
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "deep.wefood.api.Presentation v1"));
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
