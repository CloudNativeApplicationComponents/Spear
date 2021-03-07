using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Spear.Engine.Builder;
using Spear.Persistency.Memory.Builder;

namespace Spear.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //TODO Authentication and Authorization
            //TODO Paging and sorting on request and responses + HATEOAS
            //TODO Api versioning
            //TODO Exception handling
            //TODO Chache

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Spear.Api", Version = "v1" });
                c.CustomSchemaIds(type => type.ToString());
            });

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            //TODO create builders
            services.AddDefaultSpareEngine();
            services.AddSpearMemoryPersisterFactory();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spear.Api v1"));
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
