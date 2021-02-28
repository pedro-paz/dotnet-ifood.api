using deep.ifood.api.Domain.Interfaces.Generics;
using deep.ifood.api.Infrastructure.Repositories;
using deep.ifood.api.Interfaces.Services;
using deep.ifood.api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace deep.ifood.api.Presentation
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
            services.AddScoped(typeof(IRepository<>), typeof(PostgresRepository<>));
            services.AddScoped(typeof(IServiceProduct), typeof(ServiceProduct));
            services.AddScoped(typeof(IServiceClient), typeof(ServiceClient));
            services.AddScoped(typeof(IServiceOrder), typeof(ServiceOrder));
            services.AddScoped(typeof(IServiceIngredient), typeof(IServiceIngredient));
            services.AddScoped(typeof(IServiceUser), typeof(ServiceUser));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "deep.ifood.api.Presentation", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "deep.ifood.api.Presentation v1"));
            }

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
